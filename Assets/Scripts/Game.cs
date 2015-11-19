using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {
	public bool m_StoryMod;
	public float m_MinTimeToWin;
	public float m_Timer = 0f;
	
	void Start () {
		
	}

	void Update(){
		m_Timer += Time.deltaTime;
		if (m_Timer > m_MinTimeToWin && m_MinTimeToWin != -1f)
			;//TODO LOSE
	}

	public void SetOption(bool p_StoryMod,float p_MinTimeToWin = -1f){
		m_StoryMod = p_StoryMod;
		m_MinTimeToWin = p_MinTimeToWin;
	}
}
