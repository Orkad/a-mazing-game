using UnityEngine;
using System.Collections;

public static class GameManager{

	private const string GAME_SCENE_NAME = "Game";
	private const string MENU_SCENE_NAME = "Menu";

	private static int currentDifficulty = 0;

	public static void NewStoryGame(){
		currentDifficulty = 0;
		ContinueStoryGame (currentDifficulty);
	}

	public static void ContinueStoryGame(int p_difficultyLevel){
		Application.LoadLevel (GAME_SCENE_NAME);
		MazeGenerator l_MazeGen = GameObject.FindObjectOfType<MazeGenerator> ();
		l_MazeGen.SizeY = l_MazeGen.SizeX = p_difficultyLevel * 5 + 10;
	}

	public static void CustomGame(int p_mazeSizeX, int p_mazeSizeY){
		Application.LoadLevel (GAME_SCENE_NAME)
	}

	public static void BackToMenu(){
		Application.LoadLevel (MENU_SCENE_NAME);
	}
}
