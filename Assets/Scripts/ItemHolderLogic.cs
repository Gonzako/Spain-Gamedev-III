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
    public static event Action OnItemMove;
    public ItemDescriptor currentItem { get { return _currentItem; } set { _currentItem = value; _targetSprite.sprite = value.sprite; } }

    private HexCell CurrentCell { get => _currentCell; set { PlaceInHex(value); } }

    public int Value { get => value; set { this.value = value; targetText.text = value.ToString(); } }

    public Color textColor { get => targetText.color; set => targetText.color = value; }
    public Color SpriteColor { get => _targetSprite.color; set => _targetSprite.color = value; }
    public Sprite Sprite { get => _targetSprite.sprite; set => _targetSprite.sprite = value; }
    #endregion

    #region PrivateFields
    private ItemDescriptor _currentItem;
    private SpriteRenderer _targetSprite;
    private HexCell _currentCell;
    private TextMeshPro targetText;
    private int value = 2;

    private const float Speed = 10f;
    #endregion

    #region UnityCallBacks

    void Awake()
    {
        _targetSprite = GetComponentInChildren<SpriteRenderer>();
        targetText = GetComponentInChildren<TextMeshPro>();
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

    private void OnDestroy()
    {
        if(_currentCell != null)
             _currentCell.currentItem.currentHeldItem = null;
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
        HexCell oldOrigin = _currentCell;
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

        if(oldOrigin != origin)
        {
            OnItemMove?.Invoke();
        }

        switch (currentCase)
        {
            case moveCases.movedWithoutInterruption:
                PlaceInHex(target);
                yield return StartCoroutine(MoveAnimation());
                break;
            case moveCases.collidedWithTarget:
                PlaceInHex(origin);
                OnItemCollide?.Invoke((this, target.currentItem.currentHeldItem));
                yield return StartCoroutine(MoveAnimation());
                break;
            case moveCases.hitAWall:
                PlaceInHex(origin);
                yield return StartCoroutine(MoveAnimation());
                break;
        }
    }

    public void PlaceInHex(HexCell target)
    {
        if(CurrentCell != null)
            _currentCell.currentItem.currentHeldItem = null;
        _currentCell = target;

        if (target != null)
        {
            target.currentItem.currentHeldItem = this;
            transform.SetParent(target.transform, true);
        }

    }
    #endregion


    #region PrivateMethods
    private IEnumerator MoveAnimation()
    {
        Tween t = transform.DOLocalMove(-Vector3.forward, transform.localPosition.magnitude / Speed).SetEase(Ease.InOutCirc);
        yield return new WaitUntil(() => !t.IsActive());

    }

    private enum moveCases
    {
        movedWithoutInterruption, collidedWithTarget, hitAWall
    }
    #endregion
}
