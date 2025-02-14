using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFactoryAction : ActionBehavior
{

    public GameObject GhostBuildingPrefab;
    GameObject active = null;
    [SerializeField] FactoryTypeSO factoryType;
    public GameObject buildingPrefab;
    public float maxBuildingDistance = 200;
    [SerializeField] ResourceAmount[] resourceCostArray;
    public override Action GetClickAction()
    {
        return delegate () {
            //var player = GetComponent<Player>().Info;
            //if (player.Credits < cost)
            //{
            //	Debug.Log("Not enough credits. Costs " + cost);
            //	return;
            //}
            if (ResourceManager.Instance.CanAfford(resourceCostArray))//&& areThereResources())
            {
                ResourceManager.Instance.SpendResources(resourceCostArray);

                var go = Instantiate(GhostBuildingPrefab);
                var finder = go.AddComponent<FindBuildingSite>();
                //var holder=go.AddComponent<BuildingTypeHolder>();
                finder.buildingPrefab = factoryType.prefab;
                finder.maxBuildDistance = maxBuildingDistance;
                //finder.Info = player;
                finder.Source = transform;
                active = go;
            }
            else Debug.Log("Cant build");
        };
    }
    private void Update()
    {
        if (active == null)
            return;
        if (Input.GetKeyDown(KeyCode.Escape))
            GameObject.Destroy(active);
    }
    private void OnDestroy()
    {
        if (active == null) return;
        Destroy(active);
    }


}
