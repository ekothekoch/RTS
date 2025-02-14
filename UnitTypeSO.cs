using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/UnitType")]
public class UnitTypeSO : ScriptableObject
{

    public string nameString;
    public GameObject prefab;
    //public bool hasResourceGeneratorData;
    //public ResourceGeneratorData resourceGeneratorData;
    public Sprite sprite;
    public float minConstructionRadius;
    public ResourceAmount[] constructionResourceCostArray;
    public int healthAmountMax;
    public float constructionTimerMax;




}


