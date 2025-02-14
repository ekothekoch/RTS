using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindCraftSite : MonoBehaviour
{

    Renderer rend;
    Color red = new Color(1, 0, 0, .5f);
    Color green = new Color(0, 1, 0, .5f);
    public float maxBuildDistance = 150;
    public Transform buildingPrefab;
    public PlayerSetupDefinition Info;
    public Transform Source;
    public float cost = 200;
    public ResourceGeneratorData generatorData;
    public BuildingTypeSO buildingType;
    private void Start()
    {
        MouseManager.Current.enabled = false;
       
        rend = GetComponent<Renderer>();
    }
    void Update()
    {
        var tempTarget = BuildingManager.Current.ScreenPointToMapPosition(Input.mousePosition);
        if (tempTarget.HasValue == false)
            return;
        transform.position = tempTarget.Value;
        //Vector3.Distance(transform.position, Source.position) > maxBuildDistance &&
        if (ResourceGenerator.GetNearbyResourceAmount(generatorData, transform.position) == 0)
        {
            rend.material.color = red;
            return;
        }
        //else
        //{
        //    rend.material.color = green;
         

        //}
        if (BuildingManager.Current.isGameObjectSafeToPlace(gameObject))
        {
            rend.material.color = green;
            if (Input.GetMouseButtonDown(0))
            {
                ResourceManager.Instance.SpendResources(buildingType.constructionResourceCostArray);
                var go = Instantiate(buildingPrefab);
                go.transform.position = transform.position;
                //Info.Credits -= cost;
              //  go.AddComponent<Player>().Info = Info;
                Destroy(this.gameObject);
            }
        }
        else rend.material.color = red;
    }
    private void OnDestroy()
    {
        MouseManager.Current.enabled = true;

    }
}

