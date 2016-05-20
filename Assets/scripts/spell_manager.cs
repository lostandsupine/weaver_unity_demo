using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class spell_object{
	public Sprite[] spell_sprite_list;
	private float velocity;
	private Vector3 direction;
	private Vector3 origin;
	private float max_time;
	public GameObject spell_game_object;
	private string spell_name;
	private float spawn_time;

	public spell_object(Sprite[] spell_sprite_list_in, float velocity_in, Vector3 direction_in, Vector3 origin_in, float max_time_in, string spell_name_in,int position_in_spell_list){
		this.spell_sprite_list = spell_sprite_list_in;
		this.velocity = velocity_in;
		this.direction = direction_in;
		this.origin = origin_in;
		this.max_time = max_time_in;
		this.spell_name = spell_name_in;

		this.spawn_time = Time.time;
		this.spell_game_object = new GameObject ();
		this.spell_game_object.name = spell_name;

		this.spell_game_object.AddComponent<SpriteRenderer> ();
		this.spell_game_object.GetComponent<SpriteRenderer> ().sprite = this.spell_sprite_list[0];

		this.spell_game_object.transform.rotation = Quaternion.Euler(0,0,0);
		this.spell_game_object.transform.position = this.origin;
		this.spell_game_object.transform.localScale = new Vector3 (2, 2, 2);

	}
	public void move_spell(Vector3 direction_in, float velocity_in){
		this.spell_game_object.transform.Translate (direction_in * velocity_in * Time.deltaTime);
	}
	public void move_spell_default(){
		this.spell_game_object.transform.Translate (this.direction * this.velocity * Time.deltaTime);
	}

	public bool spell_timeout(){
		return ((Time.time - this.spawn_time) > this.max_time);
	}

}




public class spell_manager : MonoBehaviour {
	private List<spell_object> active_spell_list = new List<spell_object> ();
	public Sprite[] all_spell_sprites;
	private List<int> active_spells_to_remove = new List<int>();

	public void make_fireball_spell(Vector2 direction_in){

		this.active_spell_list.Add (new spell_object (new Sprite[]{ all_spell_sprites [0], all_spell_sprites [1] }, 10.0f, direction_in, this.transform.position, 2.0f, "fireball"+this.active_spell_list.Count,this.active_spell_list.Count));
	}

	public spell_manager(){

	}

	// Use this for initialization
	void Start () {
		//this.active_spell_list = new spell_object[0];
		//this.make_fireball_spell ();
	
	}
	
	// Update is called once per frame

	void Update () {
		active_spells_to_remove.Clear();
		for (int i = 0; i < this.active_spell_list.Count; i++) {
			if (this.active_spell_list [i].spell_timeout ()) {
				active_spells_to_remove.Add (i);
			}
		}
		for (int i = 0; i < this.active_spells_to_remove.Count; i++) {
			GameObject.DestroyObject (active_spell_list [i].spell_game_object);
			active_spell_list.RemoveAt (i);
		}

		for (int i = 0; i < this.active_spell_list.Count; i++) {
			this.active_spell_list [i].move_spell_default ();
		}
	}
}
