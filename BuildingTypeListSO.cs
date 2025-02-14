using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "ScriptableObjects/BuildingTypeListSO")]

public class BuildingTypeListSO : ScriptableObject
{
 public List<BuildingTypeSO> buildingType;
}
