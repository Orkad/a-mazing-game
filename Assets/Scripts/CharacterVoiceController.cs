using UnityEngine;
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Diagnostics;

public class CharacterVoiceController : MonoBehaviour {

    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    public float m_Force = 50f;
    public float m_MaxSpeed = 3f;
	//Voice Recognition
	private Process m_Process;
	private Thread m_Thread;
	private string m_Word;

	void OnEnable()
    {
		m_Process = new Process ();
		m_Process.StartInfo.RedirectStandardOutput = true;
		m_Process.StartInfo.UseShellExecute = false;
		m_Process.StartInfo.CreateNoWindow = true;
		// Setup executable and parameters
		m_Process.StartInfo.FileName = "Recognition.exe";
		// Go
		m_Process.Start();
		m_Thread = new Thread(new ThreadStart(ReceiveData));
    }

	public void OnDisable()
	{
		m_Process.Kill ();
	}

	private void ReceiveData(){
		UdpClient client = new UdpClient(26000);
		while (true) {
			try
			{
				if(m_Process.HasExited)
					return;
				IPEndPoint anyIP = new IPEndPoint(IPAddress.Broadcast, 26000);
				byte[] data = client.Receive(ref anyIP);
				m_Word = Encoding.UTF8.GetString(data);
			}
			catch (Exception err)
			{
				print(err.ToString());
			}
		}
	}

	void FixedUpdate () {
        switch (m_Word)
        {
            case "Up":
                //transform.Translate(Vector3.forward * Time.deltaTime/1.5f);
                rb.AddForce(Vector3.forward * m_Force);
                break;
            case "Left":
                transform.Translate(Vector3.left * Time.deltaTime/1.5f);
                break;
            case "Right":
                transform.Translate(Vector3.right * Time.deltaTime/1.5f);
                break;
            case "Down":
                transform.Translate(Vector3.back * Time.deltaTime/1.5f);
                break;
            case "Stop":
                transform.position = transform.position;
                break;
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, m_MaxSpeed);
    }

    
}
