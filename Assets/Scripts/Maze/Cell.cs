using UnityEngine;

public enum Direction{North,East,South,West}

public class Cell : MonoBehaviour {
    public GameObject WallN;
    public GameObject WallE;
    public GameObject WallS;
    public GameObject WallW;
	public GameObject Floor;
	[HideInInspector]
	public bool Mazed = false;

    public float PositionY
    {
        get { return transform.position.z; }
        set { transform.position = new Vector3(transform.position.x,transform.position.y,value); }
    }
    public float PositionX
    {
        get { return transform.position.x; }
        set { transform.position = new Vector3(value, transform.position.y, transform.position.z); }
    }
    public float SizeX { get{ return transform.localScale.z; } }
    public float SizeY { get { return transform.localScale.x; } }
    public int IndexX
    {
        get { return (int)(PositionX / SizeX); }
        set { PositionX = SizeX * value; }
    }
    public int IndexY
    {
        get { return (int)(PositionY / SizeY); }
        set { PositionY = SizeY * value; }
    }

    public void Set(int p_X,int p_Y)
    {
        IndexX = p_X;
        IndexY = p_Y;
    }

    public void DeleteWalls(params Direction[] p_Directions)
    {
        foreach(Direction i_Direction in p_Directions)
        {
            switch (i_Direction)
            {
                case Direction.North:
                    WallN.SetActive(false);
                    break;
                case Direction.East:
                    WallE.SetActive(false);
                    break;
                case Direction.South:
                    WallS.SetActive(false);
                    break;
                case Direction.West:
                    WallW.SetActive(false);
                    break;
                default:
                    break;
            }
        }
    }

    public void DeleteWallsBetween(Cell p_Cell)
    {
        if(IndexX > p_Cell.IndexX)
        {
            DeleteWalls(Direction.West);
        }
        else if(IndexX < p_Cell.IndexX)
        {
            DeleteWalls(Direction.East);
        }
        if(IndexY > p_Cell.IndexY)
        {
            DeleteWalls(Direction.South);
        }
        else if(IndexY < p_Cell.IndexY)
        {
            DeleteWalls(Direction.North);
        }
    }
}
