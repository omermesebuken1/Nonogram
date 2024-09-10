using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CellScirpt : MonoBehaviour
{
    [SerializeField] private Sprite[] images;

    [HideInInspector] public int cellValue;
    [HideInInspector] public bool valueAplied;

    private bool selectStatusForFill;
    private bool selectStatusForCross;
    private bool touchEnabled;

    Touch touch;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = images[2];
    }

    void Update()
    {
        UITouchChecker();
        TouchToApplyValue();
    }

    private void TouchToApplyValue()
    {

        if (touchEnabled)
        {
            if (Input.touchCount > 0)
            {
                touch = Input.GetTouch(0);

                if (touch.phase == TouchPhase.Began)
                {

                    ApplyValue();
                }

                if (touch.phase == TouchPhase.Moved)
                {
                    ApplyValue();
                }

                if (touch.phase == TouchPhase.Ended)
                {


                }

            }

        }

    }


    private void ApplyValue()
    {
        if (ClickSelect() != null)
        {
            if (!ClickSelect().GetComponent<CellScirpt>().valueAplied)
            {

                if (FindObjectOfType<GamePlay>().switchStatus)
                {
                    if (ClickSelect().GetComponent<CellScirpt>().cellValue == 1)
                    {
                        ClickSelect().GetComponent<SpriteRenderer>().sprite = images[1];
                        ClickSelect().GetComponent<CellScirpt>().valueAplied = true;
                        FindObjectOfType<GamePlay>().checkCell = true;
                        print("Correct");
                    }
                    else
                    {
                        ClickSelect().GetComponent<SpriteRenderer>().sprite = images[0];
                        ClickSelect().GetComponent<CellScirpt>().valueAplied = true;
                        FindObjectOfType<GamePlay>().checkCell = true;
                        FindObjectOfType<GamePlay>().health--;
                        print("Wrong");
                    }

                }
                else
                {
                    if (ClickSelect().GetComponent<CellScirpt>().cellValue == 0)
                    {
                        ClickSelect().GetComponent<SpriteRenderer>().sprite = images[0];
                        ClickSelect().GetComponent<CellScirpt>().valueAplied = true;
                        FindObjectOfType<GamePlay>().checkCell = true;
                        print("Correct");
                    }
                    else
                    {
                        ClickSelect().GetComponent<SpriteRenderer>().sprite = images[1];
                        ClickSelect().GetComponent<CellScirpt>().valueAplied = true;
                        FindObjectOfType<GamePlay>().health--;
                        FindObjectOfType<GamePlay>().checkCell = true;
                        print("Wrong");
                    }
                }
            }

        }





    }


    GameObject ClickSelect()
    {
        //Converting Mouse Pos to 2D (vector2) World Pos
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(touch.position).x, Camera.main.ScreenToWorldPoint(touch.position).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            //Debug.Log(hit.transform.name);
            return hit.transform.gameObject;
        }
        else return null;
    }


    private void UITouchChecker()
    {
        //Exit if touch is over UI element.
        foreach (Touch touch in Input.touches)
        {
            int id = touch.fingerId;

            if (EventSystem.current.IsPointerOverGameObject(id))
            {

                touchEnabled = false;

                return;
            }

            else
            {
                touchEnabled = true;

            }
        }
    }

}
