using UnityEngine;
using System.Collections.Generic;


/// <summary>
/// The main class to deal with for maze creation WORKING / TO OPTIMIZE
/// Depend of class Cell
/// </summary>
public class MazeGenerator : MonoBehaviour {
    //The cell prefab composed by 1 floor & 4 walls
    public Cell m_CellPrefab;
    //Size X of the grid
    public int SizeX;
    //Size Y of the grid
    public int SizeY;
    //TO OPTIMIZE by putting the bool that tell if the cell is already "mazed" by the algorythm
    //2D association of a Cell and a bool sized by sizeX & sizeY
    private KeyValuePair<Cell,bool>[,] m_CellMatrix;
    

    void Start()
    {
        //FIRST STEP
        //Create a 2D grid
        m_CellMatrix = new KeyValuePair<Cell, bool>[SizeX, SizeY];
        //2D iteration
        for (int i = 0; i < SizeX; i++)
        {
            for(int j=0;j<SizeY;j++)
            {
                //Create / Init / put in the matrix a cell
                Cell l_Cell = Instantiate(m_CellPrefab);
                l_Cell.Set(i, j);
                m_CellMatrix[i, j] = new KeyValuePair<Cell, bool>(l_Cell, false);
            }
        }

        //SECOND STEP
        //RECURSION
        Maze(m_CellMatrix[0, 0].Key);
    }

    void Maze(Cell p_Cell)
    {
        //Set the bool for the Cell to true
        m_CellMatrix[p_Cell.IndexX, p_Cell.IndexY] = new KeyValuePair<Cell, bool>(p_Cell, true);
        Cell l_Cell;
        //WHILE A RANDOM NEIGHBOUR IS FOUND STACK THE MAZE WAY 
        while ((l_Cell = Neighbour<Cell>(p_Cell.IndexX, p_Cell.IndexY, m_CellMatrix)) != null)
        {
            l_Cell.DeleteWallsBetween(p_Cell);
            p_Cell.DeleteWallsBetween(l_Cell);
            Maze(l_Cell);
        }
    }

    /// <summary>
    /// Find randomly a neightbour according to a Matrix TODO OPTIMIZED
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="x">X</param>
    /// <param name="y">Y</param>
    /// <param name="p_Matrix">//2D association of a type T and a bool sized by sizeX & sizeY</param>
    /// <returns>return the founded neighbour else null</returns>
    static T Neighbour<T>(int x, int y, KeyValuePair<T, bool>[,] p_Matrix) where T :class
    {
        bool l_CanGoNorth   = y + 1 < p_Matrix.GetLength(1) && p_Matrix[x, y + 1].Value == false;
        bool l_CanGoEast    = x + 1 < p_Matrix.GetLength(0) && p_Matrix[x + 1, y].Value == false;
        bool l_CanGoSouth   = y - 1 >= 0                    && p_Matrix[x, y - 1].Value == false;
        bool l_CanGoWest    = x - 1 >= 0                    && p_Matrix[x - 1, y].Value == false;
        //SWAP THE ORDER CAN BE OPTIMIZED
        foreach (int i in UniqueRandom(0,3))
        {
            switch (i)
            {
                case 0:
                    //NORTH DIRECTION AVAILABLE
                    if (l_CanGoNorth)
                        return p_Matrix[x, y + 1].Key;
                    break;
                case 1:
                    //WEST DIRECTION AVAILABLE
                    if (l_CanGoEast)
                        return p_Matrix[x + 1, y].Key;
                    break;
                case 2:
                    //SOUTH DIRECTION AVAILABLE
                    if (l_CanGoSouth)
                        return p_Matrix[x, y - 1].Key;
                    break;
                case 3:
                    //EAST DIRECTION AVAILABLE
                    if (l_CanGoWest)
                        return p_Matrix[x - 1, y].Key;
                    break;
                default:
                    break;
            }
        }
        return null;
    }

    /// <summary>
    /// Make an unique random list of int from min to max included
    /// </summary>
    /// <param name="minInclusive">min value</param>
    /// <param name="maxInclusive">max value</param>
    /// <returns></returns>
    private static IEnumerable<int> UniqueRandom(int minInclusive, int maxInclusive)
    {
        List<int> candidates = new List<int>();
        for (int i = minInclusive; i <= maxInclusive; i++)
        {
            candidates.Add(i);
        }
        while (candidates.Count > 0)
        {
            int index = Random.Range(0,candidates.Count);
            yield return candidates[index];
            candidates.RemoveAt(index);
        }
    }
}
