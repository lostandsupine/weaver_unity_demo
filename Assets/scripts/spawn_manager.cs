using UnityEngine;
using System.Collections;

public class spawn_manager : MonoBehaviour {
	public Sprite[] all_enemy_sprites;

	public void make_soldier_enemy(Vector3 position_in){
		GameObject new_soldier = new GameObject ("soldier");
		new_soldier.tag = "enemy";
		new_soldier.AddComponent<soldier_enemy_object> ();
		new_soldier.transform.position = position_in;
	}
	public Vector3[] starting_soldier_position_list;

	// Use this for initialization
	void Start () {
		//make_soldier_enemy (new Vector3 (0.0f, 10.0f,-1.0f));
		for (int i = 0; i < starting_soldier_position_list.Length; i++) {
			make_soldier_enemy (starting_soldier_position_list [i]);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
