using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControllerSwitcher : MonoBehaviour {
    Text text { get { return GetComponent<Text>(); } }
    public KeyCode keySwitch;
    CharacterKeyController keyController;
    CharacterVoiceController voiceController;

	// Use this for initialization
	void Start () {
        keyController = FindObjectOfType<CharacterKeyController>();
        voiceController = FindObjectOfType<CharacterVoiceController>();
        keyController.enabled = true;
        voiceController.enabled = false;
        text.text = "Key Control";
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(keySwitch))
            SwitchController();
	}

    public void SwitchController(){
        keyController.enabled = voiceController.enabled;
        voiceController.enabled = !keyController.enabled;
        if (keyController.enabled)
            text.text = "Key Control";
        else
            text.text = "Voice Control";
    }
}
