using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GamePlay : MonoBehaviour
{

    [SerializeField] private GameObject[] Hearths;
    [SerializeField] private Sprite[] switchImages;
    [SerializeField] private GameObject switchButton;
    [SerializeField] private TextMeshProUGUI gameStatusText;
    [SerializeField] private GameObject EndScreen;
    [HideInInspector] public int health;
    [HideInInspector] public bool checkCell;
    private int cellCount;
    [HideInInspector] public bool switchStatus;

    private void Start()
    {
        gameStatusText.text = "";
        EndScreen.SetActive(false);
        health = 3;
        checkCell = true;
        CheckCellCount();
    }

    private void Update()
    {

        CheckCellCount();
        HeartStatus();
        GameStaus();
        SwitchStatusCheck();
    }

    private void CheckCellCount()
    {
        if (checkCell)
        {

            cellCount = 0;

            foreach (var item in FindObjectOfType<GridControl>().cellList)
            {
                if (!item.GetComponent<CellScirpt>().valueAplied)
                {
                    cellCount++;
                }

            }

            //print("Cell Count: " + cellCount);
            checkCell = false;
        }


    }

    private void HeartStatus()
    {
        if (health == 3)
        {
            Hearths[0].SetActive(true);
            Hearths[1].SetActive(true);
            Hearths[2].SetActive(true);
        }
        else if (health == 2)
        {
            Hearths[0].SetActive(true);
            Hearths[1].SetActive(true);
            Hearths[2].SetActive(false);
        }
        else if (health == 1)
        {
            Hearths[0].SetActive(true);
            Hearths[1].SetActive(false);
            Hearths[2].SetActive(false);
        }
        else if (health <= 0)
        {
            Hearths[0].SetActive(false);
            Hearths[1].SetActive(false);
            Hearths[2].SetActive(false);
        }

    }

    private void GameStaus()
    {
        if (health <= 0)
        {
            //lose
            EndScreen.SetActive(true);
            gameStatusText.text = "YOU LOSE :(";
            
        }
        else if (health > 0 && cellCount <= 0)
        {
            //win  
            EndScreen.SetActive(true);
            gameStatusText.text = "YOU WIN!";
               
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void SwitchStatusCheck()
    {

        if(switchStatus)
        {
            switchButton.GetComponent<Image>().sprite = switchImages[0];
        }
        else
        {
            switchButton.GetComponent<Image>().sprite = switchImages[1];
        }
            


    }

    public void ChangeSwitch()
    {

        if(switchStatus)
        {
            switchStatus = false;
        }
        else
        {
            switchStatus = true;
        }


    }




}
