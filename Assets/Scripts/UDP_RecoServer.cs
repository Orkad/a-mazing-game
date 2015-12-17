﻿// *********************************************************
// UDP SPEECH RECOGNITION 
// *********************************************************
using UnityEngine;
using System.Collections;
using System;
using System.Net;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

public class UDP_RecoServer : MonoBehaviour
{
    Thread receiveThread;
    UdpClient client;
    public int port = 26000; // DEFAULT UDP PORT !!!!! THE QUAKE ONE ;)
    string strReceiveUDP = "";
    string LocalIP = String.Empty;
    string hostname;

    private static Process recoServer;
    private const string outputPath = "RecoServeurX64.exe";


    public void Start()
    {
        Application.runInBackground = true;
        init();
        recoServer = new Process();
        recoServer.StartInfo.FileName = outputPath;
        //recoServer.Start();
    }
    // init
    private void init()
    {
        receiveThread = new Thread(new ThreadStart(ReceiveData));
        receiveThread.IsBackground = true;
        receiveThread.Start();
        hostname = Dns.GetHostName();
        IPAddress[] ips = Dns.GetHostAddresses(hostname);
        if (ips.Length > 0)
        {
            LocalIP = ips[0].ToString();
            UnityEngine.Debug.Log(" MY IP : " + LocalIP);
        }
    }

    private void ReceiveData()
    {
        client = new UdpClient(port);
        while (true)
        {
            try
            {
                IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast, port);
                byte[] data = client.Receive(ref anyIP);
                strReceiveUDP = Encoding.UTF8.GetString(data);
                // ***********************************************************************
                // Simple Debug. Must be replaced with SendMessage for example.
                // ***********************************************************************
                UnityEngine.Debug.Log(strReceiveUDP);
                // ***********************************************************************
            }
            catch (Exception err)
            {
                print(err.ToString());
            }
        }
    }

    public string UDPGetPacket()
    {
        return strReceiveUDP;
    }

    void OnDisable()
    {
        if (receiveThread != null) receiveThread.Abort();
        client.Close();
        UnityEngine.Debug.Log("close server");
    }

    public void set_strReceive(string command)
    {
        strReceiveUDP = command;
    }

    public void startServer()
    {
        recoServer.Start();
        recoServer.
    }

    public void stopServer()
    {
        recoServer.Kill();
    }
}
// *********************************************************