#include "pch.h"

#include "WindowsVoice.h"

#include <sapi.h>
//#include <iostream>

namespace WindowsVoice {

  void speechThreadFunc()
  {
    ISpVoice * pVoice = NULL;

    if (FAILED(::CoInitializeEx(NULL, COINITBASE_MULTITHREADED)))
    {
      //std::cout<<"Failed to initialize COM for Voice.\n";
      return;
    }

    HRESULT hr = CoCreateInstance(CLSID_SpVoice, NULL, CLSCTX_ALL, IID_ISpVoice, (void **)&pVoice);
    if (!SUCCEEDED(hr))
    {
      LPVOID pText = 0;

      ::FormatMessage(FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS,
        NULL, hr, MAKELANGID(LANG_NEUTRAL, SUBLANG_DEFAULT), (LPSTR)&pText, 0, NULL);
      //std::cout<<"Failed to create voice instance. Error: "<<pText<<std::endl;
      LocalFree(pText);
      return;
    }

    //std::cout << "Speech ready.\n";
    wchar_t* priorText = nullptr;
    while (!shouldTerminate)
    {
      wchar_t* wText = NULL;
      if (!theSpeechQueue.empty())
      {
        theMutex.lock();
        wText = theSpeechQueue.front();
        theSpeechQueue.pop_front();
        theMutex.unlock();
      }
      if (wText)
      {
        if (priorText == nullptr || lstrcmpW(wText, priorText) != 0)
        {
          pVoice->Speak(wText, SPF_IS_XML, NULL);
          Sleep(250);
          delete[] priorText;
          priorText = wText;
        }
        else
          delete[] wText;
      }
      else
      {
        delete[] priorText;
        priorText = nullptr;
        Sleep(50);
      }
    }
    pVoice->Release();
    //std::cout << "Speech thread terminated.\n";
  }

  void addToSpeechQueue(const char* text)
  {
    if (text)
    {
      int len = strlen(text) + 1;
      wchar_t *wText = new wchar_t[len];

      memset(wText, 0, len);
      ::MultiByteToWideChar(CP_ACP, NULL, text, -1, wText, len);

      theMutex.lock();
      theSpeechQueue.push_back(wText);
      theMutex.unlock();
    }
  }
  void initSpeech()
  {
    //std::cout << "Starting Windows Voice.\n";
    shouldTerminate = false;
    theSpeechThread = new std::thread(WindowsVoice::speechThreadFunc);
  }
  void destroySpeech()
  {
    shouldTerminate = true;
    theSpeechThread->join();
    delete theSpeechThread;
    CoUninitialize();
  }
}


BOOL APIENTRY DllMain(HMODULE, DWORD ul_reason_for_call, LPVOID)
{
  switch (ul_reason_for_call)
  {
  case DLL_PROCESS_ATTACH:
  case DLL_THREAD_ATTACH:
  case DLL_THREAD_DETACH:
  case DLL_PROCESS_DETACH:
    break;
  }
  
  return TRUE;
}