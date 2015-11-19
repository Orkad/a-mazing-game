using UnityEngine;
using System.Collections;

public class Menu:MonoBehaviour{

	public void NewGame(){
		Application.LoadLevel ("Game");
	}

	public void QuitGame() {
		Application.Quit ();
	}

}
