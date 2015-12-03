using UnityEngine;
using System.Collections;

public class CharacterKeyController : MonoBehaviour {
	private Rigidbody rb{ get { return GetComponent<Rigidbody> (); } }
	public KeyCode m_NorthKey = KeyCode.Z;
	public KeyCode m_EastKey = KeyCode.D;
	public KeyCode m_SouthKey = KeyCode.S;
	public KeyCode m_WestKey = KeyCode.Q;
	public float m_Force = 1000f;
	public float m_MaxSpeed = 3f;
	
	void FixedUpdate(){
		if (Input.GetKey (m_NorthKey))
			rb.AddForce (Vector3.forward * m_Force);
		if (Input.GetKey(m_EastKey))
			rb.AddForce (Vector3.right * m_Force);
		if (Input.GetKey(m_SouthKey))
			rb.AddForce (Vector3.back * m_Force);
		if (Input.GetKey(m_WestKey))
			rb.AddForce (Vector3.left * m_Force);
		rb.velocity = Vector3.ClampMagnitude (rb.velocity, m_MaxSpeed);
	}
}
