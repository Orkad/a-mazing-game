using UnityEngine;
using System.Collections;

public static class Data {
	private const string DIFFICULTY_KEY = "Difficulty";
	private const string PLAYER_NAME_KEY = "PlayerName";
	
	public static int Difficulty{
		get{
			return PlayerPrefs.GetInt(DIFFICULTY_KEY,0);
		}
		set{
			PlayerPrefs.SetInt(DIFFICULTY_KEY,value);
		}
	}

	public static string PlayerName{
		get{
			return PlayerPrefs.GetString(PLAYER_NAME_KEY,"Unknown");
		}
		set{
			PlayerPrefs.SetString(PLAYER_NAME_KEY,value);
		}
	}
}
