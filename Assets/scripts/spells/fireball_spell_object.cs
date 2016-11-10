using UnityEngine;
using System.Collections;



public class fireball_spell_object : MonoBehaviour {
	private float velocity;
	private Vector3 direction;
	private float max_time;
	private float spawn_time;
	private fireball_spell_object self_spell_object;
	public Sprite[] sprite_list;
	private bool impact;

	private float max_impact_time;
	private float impact_time;
	private float direction_angle;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "spell" && !impact) {
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_list [1];
			velocity = 0f;
			impact = true;
			impact_time = Time.time;
			this.transform.Translate (this.direction.normalized * this.sprite_list [0].bounds.max.x * 3f);
			this.transform.Rotate (new Vector3 (0f, 0f, this.direction_angle));

		}
	}

	public void move_spell(Vector3 direction_in, float velocity_in){
		this.gameObject.transform.Translate (direction_in * velocity_in * Time.deltaTime);
	}
	public void move_spell_default(){
		//this.gameObject.transform.Translate (this.self_spell_object.direction.normalized * this.self_spell_object.velocity * Time.deltaTime);
		this.gameObject.transform.Translate (this.direction.normalized * this.velocity * Time.deltaTime);
	}

	public bool spell_timeout(){
		//return ((Time.time - this.self_spell_object.spawn_time) > this.self_spell_object.max_time);
		return ((Time.time - this.spawn_time) > this.max_time);
	}

	/*public fireball_spell_object(float velocity_in, Vector3 direction_in, float max_time_in){
		velocity = velocity_in;
		direction = direction_in;
		max_time = max_time_in;
		spawn_time = Time.time;
	}*/

	void Start(){
		//self_spell_object = new fireball_spell_object (8f, GameObject.Find("input_manager").GetComponent<input_manager>().get_direction(), 5f);
		this.velocity = 8f;
		this.impact = false;
		this.direction = GameObject.Find ("input_manager").GetComponent<input_manager> ().get_direction ();
		this.spawn_time = Time.time;
		this.max_time = 5f;
		this.max_impact_time = 0.1f;

		if (this.direction.y >= 0) {
			this.direction_angle = Vector2.Angle (new Vector2 (1f, 0f), this.direction) - 90f;
		} else {
			this.direction_angle = Vector2.Angle (new Vector2 (-1f, 0f), this.direction) + 90f;
		}

		this.sprite_list = new Sprite [2];

		this.sprite_list[0] = GameObject.Find ("spell_manager").GetComponent<spell_manager> ().all_spell_sprites [0];
		this.sprite_list[1] = GameObject.Find ("spell_manager").GetComponent<spell_manager> ().all_spell_sprites [1];

		this.gameObject.layer = 8;
		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_list[0];

		this.gameObject.AddComponent<BoxCollider2D> ();
		this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;

		this.gameObject.AddComponent<Rigidbody2D> ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;

		this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
		this.gameObject.transform.position = GameObject.Find ("leila").transform.position + (this.direction.normalized * 1);

		this.gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}
	void FixedUpdate(){
		if (spell_timeout()) {
			GameObject.Destroy (this.gameObject);
		}
		if (impact && (Time.time - impact_time) >= max_impact_time) {
			GameObject.Destroy (this.gameObject);
		}
		move_spell_default();
	}

}

