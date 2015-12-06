using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class CharacterVoiceController : MonoBehaviour {

    public UDP_RecoServer speechReco;
    private static string outputPath = "RecoServeurX64.exe";
    Process foo = new Process();
    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    public KeyCode m_NorthKey = KeyCode.Z;
    public KeyCode m_EastKey = KeyCode.D;
    public KeyCode m_SouthKey = KeyCode.S;
    public KeyCode m_WestKey = KeyCode.Q;
    public float m_Force = 1000f;
    public float m_MaxSpeed = 3f;

    void Start()
    {
        foo.StartInfo.FileName = outputPath;
        foo.Start();
    }

	void Update () {
        switch (speechReco.UDPGetPacket())
        {
            case "Up":
                transform.Translate(Vector3.forward * Time.deltaTime/1.5f);
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
    }
}
