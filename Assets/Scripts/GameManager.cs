using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Diagnostics;

public static class GameManager {

    private const string GAME_SCENE_NAME = "Game";
    private const string MENU_SCENE_NAME = "Menu";
    public static bool hardcoreMode = false;
    public static int currentDifficulty = 0;


    public static void ContinueHardcoreMode() {
        hardcoreMode = true;
        SceneManager.LoadScene(GAME_SCENE_NAME);
    }


    public static void CustomGame(int p_mazeSizeX, int p_mazeSizeY) {

    }

    public static void BackToMenu() {
        SceneManager.LoadScene(MENU_SCENE_NAME);
    }

    public static void WinLevel() {
        if (hardcoreMode)
        {
            ContinueHardcoreMode();
        }
        else
            BackToMenu();
	}

    public static void LoseLevel()
    {
        hardcoreMode = false;
        currentDifficulty = 0;
    }
}
