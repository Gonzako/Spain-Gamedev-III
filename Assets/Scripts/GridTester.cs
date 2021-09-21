using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridTester : MonoBehaviour
{
    public GameObject playerPrefab;

    private GameObject Player;

    private Vector2 Player_previousPosition;
    private Vector2 Player_Position;

    private SquareGrid grid = new SquareGrid(50,50);

    void Start()
    {
        
    }

    void Update()
    {
        drawPlayer();

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
            Player = Instantiate(playerPrefab, Player_Position, Quaternion.identity);
        }

        Player_previousPosition = Player_Position;
    }
}
