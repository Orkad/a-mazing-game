using UnityEngine;
using System.Collections;



public class moveCharacter : MonoBehaviour {

    public GameObject superHero;
    public GameObject cameraFP;
    public GameObject cameraUp;

    // Use this for initialization
    void Start () {
        cameraUp = GameObject.Find("cameraUp");
        cameraFP = GameObject.Find("cameraFP");
        superHero = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Z))
        {
            superHero.transform.Translate(Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Q)) {
            superHero.transform.Translate(Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            superHero.transform.Translate(Vector3.right * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            superHero.transform.Translate(Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            superHero.transform.Translate(Vector3.up * Time.deltaTime);
        }
    }
}
