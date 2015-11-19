using UnityEngine;
using System.Collections;

public static class GameManager{

	private const string GAME_SCENE_NAME = "Game";
	private const string MENU_SCENE_NAME = "Menu";

	public static void NewStoryGame(){
		Data.Difficulty = 0;
		ContinueStoryGame ();
	}

	public static void ContinueStoryGame(){
		Application.LoadLevel (GAME_SCENE_NAME);
		MazeGenerator l_MazeGen = GameObject.FindObjectOfType<MazeGenerator> ();
		l_MazeGen.SizeY = l_MazeGen.SizeX = Data.Difficulty * 5 + 10;
		GameObject.FindObjectOfType<Game> ().SetOption(true,30f + Data.Difficulty * 5f);
	}

	public static void CustomGame(int p_mazeSizeX, int p_mazeSizeY){
		Application.LoadLevel (GAME_SCENE_NAME);
		MazeGenerator l_MazeGen = GameObject.FindObjectOfType<MazeGenerator> ();
		l_MazeGen.SizeY = p_mazeSizeX;
		l_MazeGen.SizeX = p_mazeSizeY;
	}

	public static void BackToMenu(){
		Application.LoadLevel (MENU_SCENE_NAME);
	}

	public static void WinLevel(){
		Game currentGame = GameObject.FindObjectOfType<Game> ();
		if (currentGame.m_StoryMod)
			ContinueStoryGame(++Data.Difficulty);
		else
			BackToMenu ();
	}
}
