using UnityEngine;
using System.Collections;



public class moveCharacter : MonoBehaviour {

    public GameObject superHero;
    public GameObject cameraFP;
    public GameObject cameraUp;
    public UDP_RecoServer speechReco;

    // Use this for initialization
    void Start () {
        cameraUp = GameObject.Find("cameraUp");
        cameraFP = GameObject.Find("cameraFP");
        superHero = GameObject.FindGameObjectWithTag("Player");
        //speechReco = new UDP_RecoServer();
	}
	
	// Update is called once per frame
	void Update () {
        switch (speechReco.UDPGetPacket()){
            case "Red": superHero.GetComponent<Light>().color = Color.red;
                break;
            case "Green": superHero.GetComponent<Light>().color = Color.green;
                break;
            case "Blue":
                superHero.GetComponent<Light>().color = Color.blue;
                break;
        }
        if (Input.GetKey(KeyCode.Z) || speechReco.UDPGetPacket() == "Up")
        {
            superHero.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q) || speechReco.UDPGetPacket() == "Left") {
            superHero.transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || speechReco.UDPGetPacket() == "Right")
        {
            superHero.transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || speechReco.UDPGetPacket() == "Down")
        {
            superHero.transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            superHero.transform.Translate(Vector3.up * Time.deltaTime);
        }
        if (speechReco.UDPGetPacket()== "Stop")
        {
            superHero.transform.position = superHero.transform.position;
        }
    }
}
