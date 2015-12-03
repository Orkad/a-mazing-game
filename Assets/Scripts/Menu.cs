using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu:MonoBehaviour{

	public Button m_HardcoreGameButton;
    public Button m_QuitButton;

	void Start(){
        m_HardcoreGameButton.onClick.AddListener(GameManager.ContinueHardcoreMode);
        m_QuitButton.onClick.AddListener (Application.Quit);
	}
}
