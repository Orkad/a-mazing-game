#ifdef DLL_EXPORTS
#define DLL_API __declspec(dllexport)
#else
#define DLL_API __declspec(dllimport)
#endif

#include <mutex>
#include <list>
#include <thread>

namespace WindowsVoice {
  extern "C" {
    DLL_API void __cdecl initSpeech();
    DLL_API void __cdecl addToSpeechQueue(const char* text);
    DLL_API void __cdecl destroySpeech();
  }

  std::mutex theMutex;
  std::list<wchar_t*> theSpeechQueue;
  std::thread* theSpeechThread;
  bool shouldTerminate;
}