using UnityEngine;

/// 
/// Copyright (c) 2021 All Rights Reserved
///
/// Any Doubts Email Me At contactgonzako@gmail.com
///
/// <author>Gonzako</author>
/// <co-authors>... </co-author>
/// <summary> Monobeavior class that does something </summary>


public class ItemVisualManager : MonoBehaviour
{

    #region PublicFields

    #endregion

    #region PrivateFields
    UnitsDictionary visualData;
    [SerializeField] AudioSource fusionSoundHolder;
    #endregion

    #region UnityCallBacks

    void Awake()
    {

        visualData = GetComponent<UnitsDictionary>();

    }

    void FixedUpdate()
    {

    }

    void OnEnable()
    {
        FusionManager.OnFusion += FusionManager_OnFusion;
        ItemSpawner.OnItemCreated += OnCreation;
    }


    private void OnDisable()
    {

        FusionManager.OnFusion -= FusionManager_OnFusion;
        ItemSpawner.OnItemCreated -= OnCreation;
    }


    #endregion

    #region PublicMethods

    #endregion


    #region PrivateMethods


    private void FusionManager_OnFusion(ItemHolderLogic obj)
    {
        if (visualData.Data.TryGetValue(obj.Value, out UnitToVisualValue visuals)) 
        {
            obj.SpriteColor = visuals.CircleColor;
            obj.textColor = visuals.TextColor;
            if(visuals.targetSprite != null)
            {
                obj.Sprite = visuals.targetSprite;
                
            }
            if(visuals.PossibleSoundEffects != null)
            {
                visuals.PossibleSoundEffects.PlaySound(fusionSoundHolder);
            }
        }
        else
        {
            obj.SpriteColor = new Color(Random.value, Random.value, Random.value, Random.value);
            obj.textColor = new Color(Random.value, Random.value, Random.value, Random.value);

            if (visuals.targetSprite != null)
            {
                obj.Sprite = visuals.targetSprite;
            }
            if (visuals.PossibleSoundEffects != null)
            {
                visuals.PossibleSoundEffects.PlaySound(fusionSoundHolder);
            }
        }

    }


    void OnCreation(ItemHolderLogic obj)
    {
        if (visualData.Data.TryGetValue(obj.Value, out UnitToVisualValue visuals))
        {
            obj.SpriteColor = visuals.CircleColor;
            obj.textColor = visuals.TextColor;
            if (visuals.targetSprite != null)
            {
                obj.Sprite = visuals.targetSprite;
            }
        }
        else
        {

            if (visuals.targetSprite != null)
            {
                obj.Sprite = visuals.targetSprite;
            }
            obj.SpriteColor = new Color(Random.value, Random.value, Random.value, Random.value);
            obj.textColor = new Color(Random.value, Random.value, Random.value, Random.value);

        }
    }

    #endregion
}
