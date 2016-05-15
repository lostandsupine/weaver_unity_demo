using UnityEngine;
using System.Collections;

public class map_collision_manager : MonoBehaviour {

	public bool is_touching = false;
	void OnCollisionEnter2D(Collision2D coll) {
		is_touching = true;
	}
	void OnCollisionLeave2D(Collision2D coll){
		is_touching = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
