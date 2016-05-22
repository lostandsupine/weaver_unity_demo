using UnityEngine;
using System.Collections;

public class spell_object : MonoBehaviour {
	private float velocity;
	private Vector3 direction;
	private float max_time;
	private float spawn_time;
	private spell_object self_spell_object;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "spell"){
			GameObject.Destroy(this.gameObject);
		}
	}

	public spell_object(float velocity_in, Vector3 direction_in, float max_time_in){
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
		self_spell_object = new spell_object (8f, GameObject.Find("input_manager").GetComponent<input_manager>().get_direction(), 5f);

		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("spell_manager").GetComponent<spell_manager> ().all_spell_sprites [0];

		this.gameObject.AddComponent<BoxCollider2D> ();
		this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;

		this.gameObject.AddComponent<Rigidbody2D> ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;

		this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
		this.gameObject.transform.position = GameObject.Find ("leila").transform.position + (this.self_spell_object.direction * 1);

		this.gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}
	void FixedUpdate(){
		if (spell_timeout()) {
			GameObject.Destroy (this.gameObject);
		}
		move_spell_default();
	}

}

