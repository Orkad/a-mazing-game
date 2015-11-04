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
            case "Rouge": superHero.GetComponent<Light>().color = Color.red;
                break;
            case "Vert": superHero.GetComponent<Light>().color = Color.green;
                break;
            case "Bleu":
                superHero.GetComponent<Light>().color = Color.blue;
                break;
        }
        if (Input.GetKey(KeyCode.Z) || speechReco.UDPGetPacket() == "Monter")
        {
            superHero.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q) || speechReco.UDPGetPacket() == "Gauche") {
            superHero.transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D) || speechReco.UDPGetPacket() == "Droite")
        {
            superHero.transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || speechReco.UDPGetPacket() == "Descendre")
        {
            superHero.transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            superHero.transform.Translate(Vector3.up * Time.deltaTime);
        }
        if (speechReco.UDPGetPacket()== "Arret")
        {
            superHero.transform.position = superHero.transform.position;
        }
    }
}
