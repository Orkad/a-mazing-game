using UnityEngine;
using System.Collections;

public class CharacterKeyController : MonoBehaviour {
	public KeyCode m_NorthKey = KeyCode.Z;
	public KeyCode m_EastKey = KeyCode.D;
	public KeyCode m_SouthKey = KeyCode.S;
	public KeyCode m_WestKey = KeyCode.Q;
	public float m_Speed = 2f;

	void Update(){
		if (Input.GetKey(m_NorthKey))
			transform.position += Vector3.forward * m_Speed * Time.deltaTime;
		if (Input.GetKey(m_EastKey))
			transform.position += Vector3.right * m_Speed * Time.deltaTime;
		if (Input.GetKey(m_SouthKey))
			transform.position += Vector3.back * m_Speed * Time.deltaTime;
		if (Input.GetKey(m_WestKey))
			transform.position += Vector3.left * m_Speed * Time.deltaTime;
	}
}
