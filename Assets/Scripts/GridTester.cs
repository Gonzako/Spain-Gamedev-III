using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour
{
    public GameObject PlayerPrefab;

    private GameObject Player;
    private Vector2 Player_previousPosition;
    private Vector2 Player_Position;


    public GameObject Heart1Prefab;

    private GameObject Heart1;
    private Vector2 Heart1_previousPosition;
    private Vector2 Heart1_Position;

    private SquareGrid grid = new SquareGrid(50,50);

    void Start()
    {
        
    }

    void Update()
    {
        drawPlayer();
        drawHeart1();

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            grid.MovePlayerPosition(0, 1);
        }else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            grid.MovePlayerPosition(0, -1);
        }else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            grid.MovePlayerPosition(1, 0);
        }else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            grid.MovePlayerPosition(-1, 0);
        }
    }
    

    void drawPlayer()
    {
        Player_Position = grid.GetPlayerPosition();
        if(Player_Position != Player_previousPosition)
        {
            if(Player != null) Destroy(Player);
            Player = Instantiate(PlayerPrefab, Player_Position, Quaternion.identity);
        }

        Player_previousPosition = Player_Position;
    }

    void drawHeart1() // Esta función se puede sintetizar en una sola para las 2 mitades de corazón
    {
        Heart1_Position = grid.GetHeart1Position();
        if(Heart1_Position != Heart1_previousPosition)
        {
            if(Heart1 != null) Destroy(Heart1);
            Heart1 = Instantiate(Heart1Prefab, Heart1_Position, Quaternion.identity);
        }

        Heart1_previousPosition = Heart1_Position;
    }


}
