using UnityEngine;
using System.Collections;

public class EndZone : MonoBehaviour {

	public void OnTriggerEnter(Collider other){
		GameManager.WinLevel ();
	}
}
