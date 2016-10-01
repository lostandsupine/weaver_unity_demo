using UnityEngine;
using System.Collections;

public class fireorbit_spell_object : MonoBehaviour {
	private float velocity;
	private Vector3 direction;
	private float max_time;
	private float spawn_time;


	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag != "spell"){
			//GameObject.Destroy(this.gameObject);
		}
	}

		
	public void move_spell_default(){
		
		float angle = Mathf.Atan2(this.transform.localPosition.y,this.transform.localPosition.x);
		//Debug.Log (angle);
		this.direction.y = Mathf.Cos (angle);
		this.direction.x = -Mathf.Sin (angle);
		this.gameObject.transform.Translate (this.direction.normalized * this.velocity * Time.deltaTime);
		this.gameObject.transform.localPosition = this.gameObject.transform.localPosition.normalized * 1.5f;
	}

	public bool spell_timeout(){
		return ((Time.time - this.spawn_time) > this.max_time);
	}

	void Start(){
		this.velocity = 15f;
		this.direction = GameObject.Find ("input_manager").GetComponent<input_manager> ().get_direction ();
		this.spawn_time = Time.time;
		this.max_time = 15f;
		this.gameObject.layer = 8;

		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = GameObject.Find ("spell_manager").GetComponent<spell_manager> ().all_spell_sprites [0];

		this.gameObject.AddComponent<BoxCollider2D> ();
		this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;

		this.gameObject.AddComponent<Rigidbody2D> ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;

		this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
		this.gameObject.transform.parent = GameObject.Find ("leila").transform;
		this.gameObject.transform.position = GameObject.Find ("leila").transform.position + (this.direction * 3);

		this.gameObject.transform.localScale = new Vector3 (3, 3, 3);
	}
	void FixedUpdate(){
		if (spell_timeout()) {
			GameObject.Destroy (this.gameObject);
		}
		move_spell_default();
	}

}

