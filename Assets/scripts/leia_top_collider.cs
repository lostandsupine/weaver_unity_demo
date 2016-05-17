using UnityEngine;
using System.Collections;

public class leia_top_collider : MonoBehaviour {

	public bool is_touching = false;
	void OnTriggerEnter2D(Collider2D coll) {
		is_touching = true;
		//Debug.Log (coll.bounds);
	}
	void OnTriggerExit2D(Collider2D coll){
		is_touching = false;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
