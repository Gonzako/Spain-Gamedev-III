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
    public List<int> DirResources = new List<int>(6);

    [SerializeField] IntGameEvent OnPlayerCanMove;
    [SerializeField] IntGameEvent OnDirectionGainResource;

    private bool somethingHappened = false;
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
        ItemHolderLogic.OnItemMove += ItemHolderLogic_OnItemMove;
        ItemSpawner.OnItemCreated += ItemSpawner_OnItemCreated;
    }


    private void OnDisable()
    {
        ItemHolderLogic.OnItemMove -= ItemHolderLogic_OnItemMove;
        ItemSpawner.OnItemCreated -= ItemSpawner_OnItemCreated;
    }


    #endregion

    #region PublicMethods

    public void ParseDesireMove(int dir)
    {
        somethingHappened = false;
        Debug.Log(dir.ToString());

        StartCoroutine(checkResource(dir));


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

    private IEnumerator checkResource(int dir)
    {

        int currentValue = DirResources[dir];

        if (currentValue > 0)
        {
            OnPlayerCanMove?.Raise(dir);
            yield return new WaitForSeconds(0.02f);

            if (somethingHappened)
            {

                DirResources[dir] = DirResources[dir] - 1;
                AddToRandomDir(dir);
                somethingHappened = false;

            }
            else
            {

            }
        }
    }



    private void ItemSpawner_OnItemCreated(ItemHolderLogic obj)
    {
        somethingHappened = true;
    }


    private void ItemHolderLogic_OnItemMove()
    {
        somethingHappened = true;
    }
    #endregion
}
