using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class CharacterVoiceController : MonoBehaviour {

    public UDP_RecoServer speechReco;


    private Rigidbody rb { get { return GetComponent<Rigidbody>(); } }
    public float m_Force = 50f;
    public float m_MaxSpeed = 3f;

    void Start()
    {
        
    }

	void FixedUpdate () {
        switch (speechReco.UDPGetPacket())
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

    public void OnDisable()
    {
        speechReco.stopServer();
    }

    void OnEnable()
    {
        speechReco.startServer();
    }
}
