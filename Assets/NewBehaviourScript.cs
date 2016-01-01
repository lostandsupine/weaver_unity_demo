using UnityEngine;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour {

	private SpriteRenderer tempRenderer;
	public Sprite[] tiles;

	// Use this for initialization
	void Start () {
		for (float i = -5; i < 5; i++) {
			for (float j = -5; j < 5; j++) {
				makeTile(i * 1.8F + j * 0.9F,j * 0.46F,tiles[(int)Random.Range(-0.5F,3.5F)]);
			}
		}
	
	}

	void makeTile(float x, float y, Sprite tile){
		var gameObject = new GameObject("new_obj");

		gameObject.AddComponent<SpriteRenderer> ();
		gameObject.GetComponent<SpriteRenderer> ().sprite = tile;
		
		gameObject.transform.rotation = Quaternion.Euler(90,0,0);
		gameObject.transform.position = new Vector3 (x, 0, y);
		gameObject.transform.localScale = new Vector3 (3, 3, 3);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("t")) {
			//var gameObject = new GameObject("new_obj");
			//gameObject.AddComponent<SpriteRenderer>();
			//gameObject.GetComponent<SpriteRenderer>().sprite = tile1;
			//gameObject.transform.rotation = Quaternion.Euler(90,0,0);
			makeTile(2,2,tiles[0]);
		}
	}
}
