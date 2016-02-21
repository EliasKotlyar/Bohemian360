using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

	public Camera camera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;

		if(Physics.Raycast (camera.transform.position, camera.transform.forward, out hit, 500)) {
			Debug.Log ("trace: " + hit.collider.gameObject.name);
		} else {
			//Debug.Log ("no trace");
		}

	}
}
