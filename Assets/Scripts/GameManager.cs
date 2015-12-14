using UnityEngine;
using System.Collections;
using System.Diagnostics;

public static class GameManager {

    private const string GAME_SCENE_NAME = "Game";
    private const string MENU_SCENE_NAME = "Menu";
    public static bool hardcoreMode = false;
    public static int currentDifficulty = 0;

    private static Process recoServer;
    private static string outputPath = "RecoServeurX64.exe";

    public static void ContinueHardcoreMode() {
        recoServer = new Process();
        recoServer.StartInfo.FileName = outputPath;
        recoServer.Start();
        hardcoreMode = true;
        Application.LoadLevel(GAME_SCENE_NAME);
    }


    public static void CustomGame(int p_mazeSizeX, int p_mazeSizeY) {

    }

    public static void BackToMenu() {
        recoServer.Kill();
        Application.LoadLevel(MENU_SCENE_NAME);
    }

    public static void WinLevel() {
        if (hardcoreMode)
        {
            ContinueHardcoreMode();
            recoServer.Kill();
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
