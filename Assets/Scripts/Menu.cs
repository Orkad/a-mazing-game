using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu:MonoBehaviour{

	public Button newGameButton;

	void Start(){
		newGameButton.onClick.AddListener (GameManager.NewGame);
	}
}
