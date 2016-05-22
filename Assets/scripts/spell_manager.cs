using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class spell_manager : MonoBehaviour {
	public Sprite[] all_spell_sprites;

	public void make_fireball_spell(Vector2 direction_in){
		GameObject new_fireball = new GameObject ("fireball");
		new_fireball.tag = "spell";
		new_fireball.AddComponent<spell_object> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {

	}
}
