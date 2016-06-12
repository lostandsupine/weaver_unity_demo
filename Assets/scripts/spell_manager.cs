using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class spell_manager : MonoBehaviour {
	public Sprite[] all_spell_sprites;

	public void make_fireball_spell(Vector2 direction_in){
		GameObject new_fireball = new GameObject ("fireball");
		new_fireball.tag = "spell";
		new_fireball.AddComponent<fireball_spell_object> ();
	}

	public void make_firebomb_spell(Vector2 direction_in){
		GameObject new_firebomb = new GameObject ("firebomb");
		new_firebomb.tag = "spell";
		new_firebomb.AddComponent<firebomb_spell_object> ();
	}

	public void make_fireorbit_spell(Vector2 direction_in){
		GameObject new_fireorbit = new GameObject ("fireorbit");
		new_fireorbit.tag = "spell";
		new_fireorbit.AddComponent<fireorbit_spell_object> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame

	void Update () {

	}
}
