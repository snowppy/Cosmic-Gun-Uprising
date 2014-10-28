using UnityEngine;
using System.Collections;

public class BuildShipScript : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

		Vector3 pos_core = new Vector3(0, 0, 0);
	    GameObject core = (GameObject)Instantiate(Resources.Load("ShipParts/level1core2"), pos_core, Quaternion.identity);
		float core_x_size = GetParentSizeX (core);
		GameObject engine = (GameObject)Instantiate(Resources.Load("ShipParts/level1engine2"));
		FixedJoint engine_joint = engine.AddComponent<FixedJoint>();
		engine_joint.connectedBody = core.GetComponent<Rigidbody>();
		float engine_x_size = GetParentSizeX (engine);
	    Vector3 pos_engine = new Vector3(-1.5f, 0, 1.1f);
		engine.transform.position = pos_engine;
		GameObject shield1 = (GameObject)Instantiate(Resources.Load("ShipParts/level1shields2"));
		FixedJoint shield1_joint = shield1.AddComponent<FixedJoint>();
		shield1_joint.connectedBody = core.GetComponent<Rigidbody>();

		float shield1_x_size = GetParentSizeX (shield1);
		Vector3 pos_shield1 = new Vector3(0, 0, -1.2f);
		shield1.transform.position = pos_shield1;
		GameObject shield2 = (GameObject)Instantiate(Resources.Load("ShipParts/level1shields2"));
		FixedJoint shield2_joint = shield2.AddComponent<FixedJoint>();
		shield2_joint.connectedBody = core.GetComponent<Rigidbody>();
		float shield2_x_size = GetParentSizeX (shield2);
		Vector3 pos_shield2 = new Vector3(0, 0, 3.6f);
		shield2.transform.position = pos_shield2;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private float GetParentSizeX(GameObject gameObjectParent)
	{
		//GameObject[] childrenGameObjects = gameObjectTemp.
		GameObject firstGameObject = null, lastGameObject = null;
		firstGameObject = gameObjectParent.transform.GetChild(0).gameObject ;
		lastGameObject = gameObjectParent.transform.GetChild(1).gameObject;
		float sizeX = 0;
		foreach (Transform child in gameObjectParent.transform)
		{
			if (child.transform.position.x < firstGameObject.transform.position.x)
			{
				firstGameObject = child.gameObject;
				continue;
			}
			
			if (child.transform.position.x > lastGameObject.transform.position.x)
			{
				lastGameObject = child.gameObject;
				continue;
			}
		}
		
		if ((firstGameObject != null)&&(lastGameObject != null)&&(firstGameObject != lastGameObject))
		{
			sizeX = (lastGameObject.transform.position.x - firstGameObject.transform.position.x) + (lastGameObject.transform.localScale.x / 2 + firstGameObject.transform.localScale.x / 2);
		}
		
		Debug.Log("Parent Size: " + sizeX);
		return sizeX;
	}

	private float GetParentSizeY(GameObject gameObjectParent)
	{
		//GameObject[] childrenGameObjects = gameObjectTemp.
		GameObject firstGameObject = null, lastGameObject = null;
		firstGameObject = gameObjectParent.transform.GetChild(0).gameObject ;
		lastGameObject = gameObjectParent.transform.GetChild(1).gameObject;
		float sizeY = 0;
		foreach (Transform child in gameObjectParent.transform)
		{
			if (child.transform.position.y < firstGameObject.transform.position.y)
			{
				firstGameObject = child.gameObject;
				continue;
			}
			
			if (child.transform.position.y > lastGameObject.transform.position.y)
			{
				lastGameObject = child.gameObject;
				continue;
			}
		}
		
		if ((firstGameObject != null)&&(lastGameObject != null)&&(firstGameObject != lastGameObject))
		{
			sizeY = (lastGameObject.transform.position.y - firstGameObject.transform.position.y) + (lastGameObject.transform.localScale.y / 2 + firstGameObject.transform.localScale.y / 2);
		}
		
		Debug.Log("Parent Size: " + sizeY);
		return sizeY;
	}

	void OnDrawGizmosSelected () {
		// A sphere that fully encloses the bounding box
		var center = renderer.bounds.center;
		var radius = renderer.bounds.extents.magnitude;
		// Draw it
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (center, radius);
	}
}
