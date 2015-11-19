using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Menu:MonoBehaviour{

	public Button newStoryGameButton;
	public Button customGameButton;
	public Button continueStoryGameButton;

	void Start(){
		newStoryGameButton.onClick.AddListener (GameManager.NewStoryGame);
		continueStoryGameButton.onClick.AddListener (GameManager.ContinueStoryGame);
	}
}
