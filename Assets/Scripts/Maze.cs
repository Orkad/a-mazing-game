using UnityEngine;
using System.Collections;

public class Maze : MonoBehaviour {
    /// <summary>
    /// Amount of Cells on X axis
    /// </summary>
    [Tooltip("Amount of Cells on X axis")]
    int m_SizeX = 4;

    /// <summary>
    /// Amount of Cells on Y axis
    /// </summary>
    [Tooltip("Amount of Cells on Y axis")]
    int m_SizeY = 4;
    
    /// <summary>
    /// Generate the maze on Start according to the Size X/Y
    /// </summary>
    void Start()
    {

    }

    void TestAlgo()
    {
        //STEP 1
        //Build all wall according to the Size X/Y to make closed cells
        //Chose a random cell on the maze
        //Set the cell to 'built' (only one pass for each cells)

        //STEP 2 RECURSIVE
        //Find a not built neightboor cell
        //Case 1 available neighbors:
            //Delete the wall between the current cell and the neighboor 
            //Call Step 2 with the neighboor cell
        //Case 2 no availables neighbors:
            //return to the previous
    }
}
