using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/FactoryType")]
public class FactoryTypeSO : ScriptableObject
{

    public string nameString;
    public Transform prefab;
    //public bool hasResourceGeneratorData;
    //public ResourceGeneratorData resourceGeneratorData;
    //public Sprite sprite;
    public float minConstructionRadius;
    public ResourceAmount[] constructionResourceCostArray;
    public int healthAmountMax;
    //public float constructionTimerMax;




}
