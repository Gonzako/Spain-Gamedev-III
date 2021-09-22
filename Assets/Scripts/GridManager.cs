using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class SquareGrid
{

    #region PublicFields

    #endregion

    #region PrivateFields
    private int width;
    private int height;
    private int[,] internalMatrix;
    #endregion


    #region PublicMethods

    public SquareGrid(int width, int height)
    {
        /*
        GUIA:

            0 Vacio
            1 Pared
            4 Player
            7 Corazón1 / Heart1
            8 Corazón2 / Heart2
        */

        this.width = width;
        this.height = height;

        internalMatrix = new int[width, height];


        internalMatrix[20,20] = 4; //poner al jugador

        internalMatrix[25,25] = 1; //poner pared
        internalMatrix[26,25] = 1;
        internalMatrix[23,25] = 1;

        internalMatrix[25,21] = 7; //poner Corazón1 



        // EN ESTA PARTE DEL TUTORIAL, EL QUE EXPLICA USA ESTOS for PARA ESCRIBIR TEXTO EN PANTALLA CON UNA LIBRERIA PROPIA DEL CANAL
        /*for (int i = 0; i < internalMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < internalMatrix.GetLength(1); j++)
            {
                     
            }
        }*/
    }

    public Vector2Int GetPlayerPosition()
    {
        for(int x = 0; x < internalMatrix.GetLength(0); x++)
        {
            for(int y = 0; y < internalMatrix.GetLength(1); y++)
            {
                if(internalMatrix[x,y] == 4)
                {
                    return new Vector2Int(x, y);
                }
            }
        }

        return new Vector2Int(-50,-50); // significa que Player no existe, no deberia ocurrir nunca
    }

    public Vector2Int GetHeart1Position()
    {
        for(int x = 0; x < internalMatrix.GetLength(0); x++)
        {
            for(int y = 0; y < internalMatrix.GetLength(1); y++)
            {
                if(internalMatrix[x,y] == 7)
                {
                    Debug.Log(x + " " + y);
                    return new Vector2Int(x, y);
                }
            }
        }

        return new Vector2Int(-50,-50);
    }


    public void MovePlayerPosition(int X_mov, int Y_mov)
    {
        Vector2Int vec = GetPlayerPosition();
        int x = vec.x;
        int y = vec.y;

        if(internalMatrix[x + X_mov, y + Y_mov] != 1) // Pregunta por las Colisiones
        {
            if(internalMatrix[x + X_mov, y + Y_mov] == 7) // Choca con Corazón
            {
                if(internalMatrix[x + X_mov * 2, y + Y_mov * 2] != 1)
                {
                    internalMatrix[x + X_mov * 2, y + Y_mov * 2] = 7;
                    internalMatrix[x + X_mov, y + Y_mov] = 4;   // Empuja Corazón en caso de ser posible
                    internalMatrix[x,y] = 0;
                }
            }
            else
            {
                internalMatrix[x,y] = 0; // Deja vacio el lugar
                internalMatrix[x + X_mov, y + Y_mov] = 4; // Posiciona nuevamente al jugador
            }
        }
        else{
            Debug.Log("Choque!");
        }

    }

    #endregion


    #region PrivateMethods


    #endregion
}
