﻿using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.AI;

public class RtsManager : MonoBehaviour {

	public static RtsManager Current = null;

	public List<PlayerSetupDefinition> Players = new List<PlayerSetupDefinition>();

	public TerrainCollider MapCollider;

	public Vector3? ScreenPointToMapPosition(Vector2 point)
	{
		var ray = Camera.main.ScreenPointToRay (point);
		RaycastHit hit;
		if (!MapCollider.Raycast (ray, out hit, Mathf.Infinity))
			return null;

		return hit.point;
	}
	//public bool isGameObjectSafeToPlace(GameObject go)
 //   {
	//	var verts = go.GetComponent<MeshFilter>().mesh.vertices;
	//	var obstacles = GameObject.FindObjectsOfType<NavMeshObstacle>();
	//	var cols = new List<Collider>();
 //       foreach (var o in obstacles)
 //       {
	//		if(o.gameObject!=go)
 //           {
	//			cols.Add(o.gameObject.GetComponent<Collider>());
 //           }
 //       }
 //       foreach (var v in verts)
 //       {
	//		NavMeshHit hit;
	//		var vReal = go.transform.TransformPoint(v);
	//		NavMesh.SamplePosition(vReal, out hit, 20, NavMesh.AllAreas);
	//		bool onXAxis = Mathf.Abs(hit.position.x - vReal.x) < .5f;
	//		bool onZAxis= Mathf.Abs(hit.position.z - vReal.z) < .5f;
	//		bool hitCollider = cols.Any(c => c.bounds.Contains(vReal));
	//		if (!onXAxis|| !onZAxis|| hitCollider)
	//		return false;
	//	}
	//	return true;
 //   }
	// Use this for initialization
	void Start () {
		Current = this;
		//foreach (var p in Players) {
		//	foreach (var u in p.StartingUnits)
		//	{
		//		var go = (GameObject)GameObject.Instantiate(u, p.Location.position, p.Location.rotation);

		//		var player = go.AddComponent<Player>();
		//		player.Info = p;
		//		if (!p.IsAi)
		//		{
		//			if (Player.Default == null) Player.Default = p;
		//			go.AddComponent<RightClickNavigation>();
		//			go.AddComponent<ActionsSelect>();
		//		}
		//	}
		//}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
