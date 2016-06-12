using UnityEngine;
using System.Collections;

public class firebomb_spell_object : MonoBehaviour {
	private float velocity;
	private Vector3 direction;
	private float max_time;
	private float spawn_time;
	private firebomb_spell_object self_spell_object;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "spell"){
			GameObject.Destroy(this.gameObject);
		}
	}

	public firebomb_spell_object(float velocity_in, Vector3 direction_in, float max_time_in){
		velocity = velocity_in;
		direction = direction_in;
		max_time = max_time_in;
		spawn_time = Time.time;
	}

	public void move_spell(Vector3 direction_in, float velocity_in){
		this.gameObject.transform.Translate (direction_in * velocity_in * Time.deltaTime);
	}
	public void move_spell_default(){
		this.gameObject.transform.Translate (this.self_spell_object.direction.normalized * this.self_spell_object.velocity * Time.deltaTime);
	}

	public bool spell_timeout(){
		return ((Time.time - this.self_spell_object.spawn_time) > this.self_spell_object.max_time);
	}

	void Start(){
		self_spell_object = new firebomb_spell_object (4f, GameObject.Find("input_manager").GetComponent<input_manager>().get_direction(), 15f);

		this.gameObject.layer = 8;
		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("spell_manager").GetComponent<spell_manager> ().all_spell_sprites [1];

		this.gameObject.AddComponent<BoxCollider2D> ();
		this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;

		this.gameObject.AddComponent<Rigidbody2D> ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;

		this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
		this.gameObject.transform.position = GameObject.Find ("leila").transform.position + (this.self_spell_object.direction * 2);

		this.gameObject.transform.localScale = new Vector3 (4, 4, 4);
	}
	void FixedUpdate(){
		if (spell_timeout()) {
			GameObject.Destroy (this.gameObject);
		}
		move_spell_default();
	}

}

