using UnityEngine;
using System.Collections;

public class soldier_enemy_object : MonoBehaviour {
	public Sprite[] sprite_list;
	int direction = 0;
	int moving = 0;
	int current_frame = 0;
	float velocity = 3;
	enum alive_state_enum {alive = 0, burning = 1, dead = 2};
	alive_state_enum alive_state = alive_state_enum.alive;
	float dead_time = 2f;
	float dying_time;

	void OnTriggerEnter2D(Collider2D coll){
		if (coll.gameObject.tag == "spell"){
			burn ();
		}
	}

	private void burn(){
		this.dying_time = Time.time;
		this.alive_state = alive_state_enum.burning;
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_list [9];
	}
	private void kill (){
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_list [10];
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = true;
		this.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		this.gameObject.transform.rotation = Quaternion.Euler(0,0,(float)Random.Range(-90,90));
		this.alive_state = alive_state_enum.dead;
		this.transform.Translate (new Vector3 (0, 0, 0.5f));
	}


	// Use this for initialization
	void Start () {
		sprite_list = GameObject.Find ("spawn_manager").GetComponent<spawn_manager> ().all_enemy_sprites;

		this.gameObject.layer = 9;
		this.gameObject.AddComponent<SpriteRenderer> ();
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
			
		this.gameObject.AddComponent<BoxCollider2D> ();
		this.gameObject.GetComponent<BoxCollider2D> ().isTrigger = false;

		this.gameObject.AddComponent<Rigidbody2D> ();
		this.gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		this.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = true;
		this.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 0;

		this.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
		this.gameObject.transform.localScale = new Vector3 (2, 2, 2);
	}

	public void move_soldier(int in_direction, float velocity_in){
		//direction = in_direction;
		moving = 1;
		switch (in_direction) {
		case 0:
			this.transform.Translate ((Vector3.down * velocity_in) * Time.deltaTime);
			break;
		case 1:
			this.transform.Translate ((Vector3.left * velocity_in) * Time.deltaTime);
			break;
		case 2:
			this.transform.Translate ((Vector3.up * velocity_in) * Time.deltaTime);
			break;
		case 3:
			this.transform.Translate ((Vector3.right * velocity_in) * Time.deltaTime);
			break;
		}
	}

	public void translate_soldier(int in_direction, float velocity_in){
		//direction = in_direction;
		switch (in_direction) {
		case 0:
			this.transform.Translate ((Vector3.down * velocity_in));
			break;
		case 1:
			this.transform.Translate ((Vector3.left * velocity_in));
			break;
		case 2:
			this.transform.Translate ((Vector3.up * velocity_in));
			break;
		case 3:
			this.transform.Translate ((Vector3.right * velocity_in));
			break;
		}
	}

	public void seek_player(){
		Vector3 new_dir = this.transform.position - GameObject.Find ("leila").transform.position;
		move_soldier (0, velocity * new_dir.normalized.y);
		move_soldier (1, velocity * new_dir.normalized.x);

		if (Mathf.Abs (new_dir.x) > Mathf.Abs (new_dir.y)) {
			if (new_dir.x > 0) {
				direction = 1;
			} else {
				direction = 3;
			}
		} else {
			if (new_dir.y > 0) {
				direction = 0;
			} else {
				direction = 2;
			}
		}
	}

	void Update () {
		if (alive_state == alive_state_enum.alive) {
			seek_player ();
			GetComponent<SpriteRenderer> ().flipX = false;
			if (1 == moving) {
				switch (direction) {
				case 0:
					GetComponent<SpriteRenderer> ().sprite = sprite_list [1 + current_frame];
					current_frame = (int)((3 * Time.fixedTime) % 2);
					moving = 0;
					break;
				case 1:
					GetComponent<SpriteRenderer> ().sprite = sprite_list [4 + current_frame];
					current_frame = (int)((3 * Time.fixedTime) % 2);
					moving = 0;
					break;
				case 2:
					GetComponent<SpriteRenderer> ().sprite = sprite_list [7 + current_frame];
					current_frame = (int)((3 * Time.fixedTime) % 2);
					moving = 0;
					break;
				case 3:
					GetComponent<SpriteRenderer> ().sprite = sprite_list [4 + current_frame];
					GetComponent<SpriteRenderer> ().flipX = true;
				//this.transform.rotation = Quaternion.Euler (0, 180, 0);
					current_frame = (int)((3 * Time.fixedTime) % 2);
					moving = 0;
					break;
				}

			} else {
				switch (direction) {
				case 0:
					GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
					break;
				}

			}
		} else {
			if (alive_state == alive_state_enum.burning & (Time.time - this.dying_time) > this.dead_time) {
				kill ();
			} else if (alive_state == alive_state_enum.burning) {
				this.transform.Translate (new Vector2(Random.Range(-1,1),Random.Range(-1,1)) * Time.deltaTime);
			}
		}
	}
}
