using UnityEngine;
using System.Collections;

public class spell_object{
	public Sprite[] spell_sprite_list;
	private float velocity;
	private Vector2 direction;
	private Vector2 origin;
	private float max_time;
	public GameObject spell_game_object;
	private string spell_name;
	private float spawn_time;

	public spell_object(Sprite[] spell_sprite_list_in, float velocity_in, Vector2 direction_in, Vector2 origin_in, float max_time_in, string spell_name_in){
		this.spell_sprite_list = spell_sprite_list_in;
		this.velocity = velocity_in;
		this.direction = direction_in;
		this.origin = origin_in;
		this.max_time = max_time_in;
		this.spell_name = spell_name_in;
		this.spell_game_object = new GameObject (spell_name);
		this.spawn_time = Time.time;
	}
	public spell_object(){

	}

	public void spell_timeout(){
		if ((Time.time -this.spawn_time) > this.max_time){
			
		}
	}

}

public class spell_obj_fireball : spell_object{
	public spell_obj_fireball(){

	}
}


public class spell_manager : MonoBehaviour {


	public spell_manager(){

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
