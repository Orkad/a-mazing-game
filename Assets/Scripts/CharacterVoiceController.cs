using UnityEngine;
using System.Collections;

public class CharacterVoiceController : MonoBehaviour {
    public UDP_RecoServer speechReco;

	void Update () {
        if (speechReco.UDPGetPacket() == "Up")
        {
            transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (speechReco.UDPGetPacket() == "Left")
        {
            transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (speechReco.UDPGetPacket() == "Right")
        {
            transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (speechReco.UDPGetPacket() == "Down")
        {
            transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            speechReco.set_strReceive("Close");
        }
        if (speechReco.UDPGetPacket() == "Stop")
        {
            transform.position = transform.position;
        }
    }
}
