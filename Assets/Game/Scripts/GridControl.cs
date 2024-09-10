using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GridControl : MonoBehaviour
{

    public List<GameObject> cellList = new List<GameObject>();

    private List<BoxElement> columnList = new List<BoxElement>();
    private List<BoxElement> rowList = new List<BoxElement>();
    
    [SerializeField] private GameObject rowTextPre;
    [SerializeField] private GameObject colTextPre;

    [HideInInspector] public int lengthX;
    [HideInInspector] public int lengthY;

    public class BoxElement
    {       
        public List<int> list;
    }


    public void PrepareLists()
    {
            
        int tmpx;
        int tmpy;
        string[] splitArray;
        

        GameObject[,] gridArray = new GameObject[lengthY, lengthX];

        foreach (var item in cellList)
        {
            //Split
            splitArray = item.name.Split(char.Parse("x"));

            tmpx = int.Parse(splitArray[0]);
            tmpy = int.Parse(splitArray[1]);

            gridArray[tmpx, tmpy] = item;

            
        }

        print(gridArray.GetLength(0));
            print(gridArray.GetLength(1));
            
        int counter = 0;

        BoxElement tmpBoxElement;
         
        //creating row list

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            tmpBoxElement = new BoxElement();   
            tmpBoxElement.list = new List<int>();
            tmpBoxElement.list.Clear();

            for (int j = 0; j < gridArray.GetLength(1); j++)
            {
                if (gridArray[i, j].GetComponent<CellScirpt>().cellValue == 0)
                {
                    counter++;
                }
                else
                {
                    if (counter != 0)
                    {
                        tmpBoxElement.list.Add(counter);
                    }

                    counter = 0;
                }

            }

            if (counter != 0)
            {
                tmpBoxElement.list.Add(counter);
            }

            counter = 0;
            rowList.Add(tmpBoxElement);
        }

        //creating column list

        for (int i = 0; i < gridArray.GetLength(1); i++)
        {
            tmpBoxElement = new BoxElement();   
            tmpBoxElement.list = new List<int>();
            tmpBoxElement.list.Clear();

            for (int j = gridArray.GetLength(0) - 1; j >= 0; j--)
            {
                if (gridArray[j, i].GetComponent<CellScirpt>().cellValue == 0)
                {
                    counter++;
                }
                else
                {
                    if (counter != 0)
                    {
                        tmpBoxElement.list.Add(counter);
                    }

                    counter = 0;
                }

            }

            if (counter != 0)
            {
                tmpBoxElement.list.Add(counter);
            }

            counter = 0;
            columnList.Add(tmpBoxElement);
        }


        //creating text areas

        GameObject tmpText;

        //rowTexts

        for (int i = 0; i < gridArray.GetLength(0); i++)
        {
            
            tmpText = Instantiate(rowTextPre);
            tmpText.name = "RowText" + i.ToString();
            tmpText.transform.position = gridArray[i,0].transform.position + new Vector3(-0.4f,0,0);


            string tmpString = "";

            foreach (var item in rowList[i].list)
            {

                tmpString = tmpString + " " + item.ToString();

            }


            tmpText.GetComponent<TextMeshPro>().text = tmpString;


            tmpText.transform.parent = this.gameObject.transform;
        }

        //columnTexts

        for (int i = 0; i < gridArray.GetLength(1); i++)
        {
            
            tmpText = Instantiate(colTextPre);
            tmpText.name = "ColumnText" + i.ToString();
            tmpText.transform.position = gridArray[gridArray.GetLength(0)-1,i].transform.position + new Vector3(0,0.5f,0);


            string tmpString = "";

            foreach (var item in columnList[i].list)
            {
                if(tmpString == "")
                {
                    tmpString = item.ToString();
                }
                else
                {
                    tmpString = tmpString + " " + item.ToString();
                }

            }


            tmpText.GetComponent<TextMeshPro>().text = tmpString;

            tmpText.transform.parent = this.gameObject.transform;
        }

        







    }

}
