using UnityEngine;
using System.Collections;

public class general : MonoBehaviour {

    public GameObject cameraUp;
    public GameObject cameraFP;
	// Use this for initialization
	void Start () {
        cameraUp = GameObject.FindGameObjectWithTag("cameraUp");
        cameraFP = GameObject.FindGameObjectWithTag("cameraFP");
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetKeyUp(KeyCode.Tab))
        {
            CameraChange();
        }
	}
public void CameraChange()
    {
        if (cameraFP.active)
        {
            cameraFP.SetActive(false);
            cameraUp.SetActive(true);
        }
        else
        {
            cameraFP.SetActive(true);
            cameraUp.SetActive(false);
        }
    }
}
