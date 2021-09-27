using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class DirectionResources : MonoBehaviour
{

    #region PublicFields


    #endregion

    #region PrivateFields
    int startValue = 3;
    List<int> DirResources = new List<int>(6);

    [SerializeField] IntGameEvent OnPlayerCanMove;
    [SerializeField] IntGameEvent OnDirectionGainResource;
    #endregion

    #region UnityCallBacks

    void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            DirResources.Add(startValue);
            
        }
    }

    void FixedUpdate()
    {

    }

    void OnEnable()
    {

    }


    private void OnDisable()
    {

    }


    #endregion

    #region PublicMethods

    public void ParseDesireMove(int dir)
    {
        Debug.Log(dir.ToString());
        int currentValue = DirResources[dir];
        
        if(currentValue > 0)
        {
            OnPlayerCanMove?.Raise(dir);
            DirResources[dir] = DirResources[dir]-1;
            AddToRandomDir(dir);
        }
        else
        {

        }

    }
    #endregion


    #region PrivateMethods

    private void AddToRandomDir(int exclude)
    {
        int randomExcluded = UnityEngine.Random.Range(0, DirResources.Count);
        while(randomExcluded == exclude)
        {

            randomExcluded = UnityEngine.Random.Range(0, DirResources.Count);
        }
        DirResources[randomExcluded]++;
        OnDirectionGainResource?.Raise(randomExcluded);
    }
    #endregion
}
