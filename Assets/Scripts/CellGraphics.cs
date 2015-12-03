using UnityEngine;
using System.Collections;

public class CellGraphics : MonoBehaviour {
	private Cell cell{ get { return GetComponent<Cell> (); } }
	public Material[] m_WallTextures;
	public Material[] m_FloorTextures;

	public void Start(){
		if(m_WallTextures.Length != 0)
		{
			cell.WallE.GetComponent<Renderer>().material = m_WallTextures[Random.Range(0,m_WallTextures.Length)];
			cell.WallN.GetComponent<Renderer>().material = m_WallTextures[Random.Range(0,m_WallTextures.Length)];
			cell.WallW.GetComponent<Renderer>().material = m_WallTextures[Random.Range(0,m_WallTextures.Length)];
			cell.WallS.GetComponent<Renderer>().material = m_WallTextures[Random.Range(0,m_WallTextures.Length)];
		}
		if(m_FloorTextures.Length != 0)
			cell.Floor.GetComponent<Renderer>().material = m_FloorTextures[Random.Range(0,m_FloorTextures.Length)];
	}
}
