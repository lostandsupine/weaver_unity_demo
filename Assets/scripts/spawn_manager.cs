using UnityEngine;
using System.Collections;

public class spawn_manager : MonoBehaviour {
	public Sprite[] all_enemy_sprites;

	public void make_fireball_spell(Vector3 position_in){
		GameObject new_soldier = new GameObject ("soldier");
		new_soldier.tag = "enemy";
		new_soldier.AddComponent<soldier_enemy_object> ();
		new_soldier.transform.position = position_in;
	}

	// Use this for initialization
	void Start () {
		make_fireball_spell (new Vector3 (0.0f, 10.0f,-1.0f));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
