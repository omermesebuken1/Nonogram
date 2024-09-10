using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameGridScript : MonoBehaviour
{
    [SerializeField] private GameObject cellPrefab;
    [SerializeField] private GameObject gridPrefab;
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float cellSize;
    [SerializeField] private Vector3 originPosition;
    private int[,] gridArray;

    public void CreateCells()
    {
        gridArray = new int[width, height];

        Vector3 point1 = new Vector3(0,0,0);
        Vector3 point2 = new Vector3(0,0,0);
        Vector3 Midpoint;
        GameObject parent;
        GameObject pivotPoint;
        
        pivotPoint = new GameObject();
        pivotPoint.name = "Cells";
        
        parent = Instantiate(gridPrefab);
        parent.name = "Grid";


        for (float x = 0; x < gridArray.GetLength(0); x++) 
            {
                for (float y = 0; y < gridArray.GetLength(1); y++) 
                {
                    
                    var tmpcell = Instantiate(cellPrefab,new Vector3(x+0.5f,y+0.5f,0),Quaternion.identity);
                    tmpcell.transform.parent = pivotPoint.transform;
                    tmpcell.name = $"{y}x{x}";
                    tmpcell.GetComponent<CellScirpt>().cellValue = Random.Range(0, 2);
                    parent.GetComponent<GridControl>().cellList.Add(tmpcell);

                    if(x == 0 && y == 0)
                    {
                        point1 = tmpcell.transform.position;
                    }
                    else if(x == gridArray.GetLength(0) - 1 && y == gridArray.GetLength(1) - 1)
                    {
                        point2 = tmpcell.transform.position;
                        
                    }

                }
            }

        
        Midpoint = (point1 + point2) / 2;
        pivotPoint.transform.position = transform.position + -1f * Midpoint;
        pivotPoint.transform.parent = parent.transform;
        parent.transform.localScale = parent.transform.localScale*0.5f;
        parent.GetComponent<GridControl>().lengthX = width;
        parent.GetComponent<GridControl>().lengthY = height;
        parent.GetComponent<GridControl>().PrepareLists();

    }

    public Vector3 GetWorldPosition(int x, int y) {
        return new Vector3(x, y) * cellSize + originPosition;
    }

}
