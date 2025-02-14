using UnityEngine;
using System.Collections;
using System;

public class CreateBuildingAction : ActionBehavior {
	public GameObject GhostBuildingPrefab;
	GameObject active = null;
	public GameObject buildingPrefab;
	public float maxBuildingDistance = 30;
	public float cost = 0;
	public override Action GetClickAction ()
	{
		return delegate() {
			//var player= GetComponent<Player>().Info;
			//if(player.Credits<cost)
   //         {
			//	Debug.Log("Not enough credits. Costs " + cost);
			//	return;
   //         }
			var go = Instantiate(GhostBuildingPrefab);
			var finder=go.AddComponent<FindBuildingSite>();
			//finder.buildingPrefab = buildingPrefab;
			finder.maxBuildDistance = maxBuildingDistance;
			//finder.Info = player; 
			finder.Source = transform;
			active = go;
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
