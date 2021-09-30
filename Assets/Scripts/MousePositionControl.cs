using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class MousePositionControl : MonoBehaviour
{

    [SerializeField]
    private IntGameEvent ClickEvent;

    [SerializeField]
    private IntGameEvent MoveEvent;


    private int direction;
    private int previous_direction;

    private Vector2 ScreenCenter;
    private Vector2 MouseDifference;

    [SerializeField, Range(0f,3f)]
    private float linearDifferenceXY;


    void Awake()
    {
        CheckScreenSize();
        InvokeRepeating("CheckScreenSize", 2f, 4f);
    }

    void CheckScreenSize()
    {
        ScreenCenter = new Vector2(Screen.width/2, Screen.height/2);
    }

    void Update()
    {   
        MouseDifference = (Vector2)Input.mousePosition - ScreenCenter;

        var angle = Vector2.SignedAngle(Vector2.right, MouseDifference);


        if(angle > 0)
        {
            direction = 0;
            if(angle > 60)
            {
                direction = 5;
                if(angle > 120)
                {
                    direction = 4;
                }
            }
        }
        else
        {
            direction = 1;
            if (angle < -60)
            {
                direction = 2;
                if (angle < -120)
                {
                    direction = 3;
                }
            }
        }

        if(previous_direction != direction)
        {
            MoveEvent.Raise(direction);
            previous_direction = direction;
        }

        if(Input.GetMouseButtonDown(0))
        {
            ClickEvent.Raise(direction);
        }
    }
}
