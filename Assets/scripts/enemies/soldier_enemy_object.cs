using UnityEngine;
using System.Collections;

public class soldier_enemy_object : MonoBehaviour {
	public Sprite[] sprite_list;
	private soldier_enemy_object self_enemy_object;

	private soldier_enemy_object (){

	}

	// Use this for initialization
	void Start () {
		sprite_list = GameObject.Find ("spawn_manager").GetComponent<spawn_manager> ().all_enemy_sprites;
		//self_enemy_object = new soldier_enemy_object ();

		this.gameObject.layer = 9;
		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
			
		this.gameObject.AddComponent<BoxCollider2D> ();
		this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;

		this.gameObject.AddComponent<Rigidbody2D> ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		this.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;

		this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
		this.gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
