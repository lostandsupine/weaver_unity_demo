using UnityEngine;
using System.Collections;

public class leia_left_collider : MonoBehaviour {

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
		/*RaycastHit2D hit = Physics2D.Raycast (GameObject.Find ("leila").transform.position, Vector2.left);
		Debug.Log (hit.distance);
		if (hit.distance <= 0.2) {
			GameObject.Find ("leila").GetComponent<leila_walk> ().translate_leila (1, hit.distance);
			is_touching = true;
		}*/
	}
}
