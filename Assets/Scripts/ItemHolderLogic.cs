using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class ItemHolderLogic : MonoBehaviour
{

    #region PublicFields
    //1st is caller, 2nd is target
    public static event Action<(ItemHolderLogic, ItemHolderLogic)> OnItemCollide;
    public ItemDescriptor currentItem { get { return _currentItem; } set { _currentItem = value; _targetSprite.sprite = value.sprite; } }

    private HexCell CurrentCell { get => _currentCell; set { PlaceInHex(value); } }

    public int Value { get => value; set { this.value = value; targetText.text = value.ToString(); } }

    #endregion

    #region PrivateFields
    private ItemDescriptor _currentItem;
    private SpriteRenderer _targetSprite;
    private HexCell _currentCell;
    private TextMeshPro targetText;
    private int value = 2;

    private const float Speed = 0.2f;
    #endregion

    #region UnityCallBacks

    void Awake()
    {
        _targetSprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        if(transform.parent != null)
        {
            CurrentCell = GetComponentInParent<HexCell>();
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
    //Possible cases 
    //We move without touching
    //We move when looping
    //We move and collide with something craftable
    //We move and collider with something not craftable
    public IEnumerator MoveDistance(HexDirection direction, int strengh)
    {
        HexCell target = null;
        HexCell origin = _currentCell;
        moveCases currentCase = moveCases.movedWithoutInterruption;

        for (int i = 0; i < strengh; i++)
        {
            target = origin.GetNeighbor(direction);
            if(target is null) //We hit a wall. Stopping
            {
                currentCase = moveCases.hitAWall;
                break;
            }
            else if(target.currentItem.currentHeldItem != null)
            {
                currentCase = moveCases.collidedWithTarget;
                break;
            }
            origin = target;
        }

        switch (currentCase)
        {
            case moveCases.movedWithoutInterruption:
                PlaceInHex(target);
                yield return StartCoroutine(MoveAnimation());
                break;
            case moveCases.collidedWithTarget:
                PlaceInHex(origin);
                yield return StartCoroutine(MoveAnimation());
                OnItemCollide?.Invoke((this, target.currentItem.currentHeldItem));
                break;
            case moveCases.hitAWall:
                PlaceInHex(origin);
                yield return StartCoroutine(MoveAnimation());
                break;
        }
    }

    public void PlaceInHex(HexCell target)
    {
        _currentCell = target;
        target.currentItem.currentHeldItem = this;
        transform.SetParent(target.transform, true);

    }
    #endregion


    #region PrivateMethods
    private IEnumerator MoveAnimation()
    {
        Tween t = transform.DOLocalMove(Vector3.zero, transform.localPosition.magnitude / Speed);
        yield return new WaitUntil(() => !t.IsActive());

    }

    private enum moveCases
    {
        movedWithoutInterruption, collidedWithTarget, hitAWall
    }
    #endregion
}
