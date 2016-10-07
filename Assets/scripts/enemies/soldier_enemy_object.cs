using UnityEngine;
using System.Collections;

public class soldier_enemy_object : MonoBehaviour {
	public Sprite[] sprite_list;
	int sprite_direction = 0;
	int moving = 0;
	int current_frame = 0;
	float vision_distance = 10f;
	enum alive_state_enum {alive = 0, burning = 1, dead = 2};
	alive_state_enum alive_state = alive_state_enum.alive;
	float dead_time = 2f;
	float dying_time;
	enum ai_state_enum {
		wandering=0,
		fleeing=1,
		hiding=2,
		cowering=3,
		seeking=4,
		approaching=5,
		flanking=6,
		preparing=7,
		charging=8
	};
	ai_state_enum ai_state = ai_state_enum.wandering;
	float wander_switch_time;
	float wander_start_time;
	Vector2 wander_direction;
	float wander_speed = 1f;
	float approach_speed = 5f;

	// Use this for initialization
	void Start () {
		wander_switch_time = 0f;
		wander_start_time = Time.time;
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

	private float distance_to_player(){
		return ((this.transform.position - GameObject.Find ("leila").transform.position).magnitude);
	}

	private void do_ai()
	{
		switch (ai_state){
		case ai_state_enum.wandering:
			if (distance_to_player () <= vision_distance) {
				ai_state = ai_state_enum.approaching;
			}
			break;
		}
	}

	private void ai_action(){
		
		switch (ai_state){
			case ai_state_enum.wandering:
				if ((Time.time - wander_start_time) >= wander_switch_time) {
					wander_start_time = Time.time;
					wander_switch_time = Random.Range (1f, 10f);
					wander_direction = new Vector2 (Random.Range (-1f, 1f), Random.Range (-1f, 1f));
					sprite_direction = get_sprite_direction (wander_direction);
				}
				this.transform.Translate (wander_direction.normalized * wander_speed * Time.deltaTime);
				break;
		case ai_state_enum.approaching:
			wander_direction = GameObject.Find ("leila").transform.position - this.transform.position;
			sprite_direction = get_sprite_direction (wander_direction);
			this.transform.Translate (wander_direction.normalized * approach_speed * Time.deltaTime);
			break;
		}
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

	/*public void seek_player(){
		Vector3 new_dir = this.transform.position - GameObject.Find ("leila").transform.position;
		move_soldier (0, velocity * new_dir.normalized.y);
		move_soldier (1, velocity * new_dir.normalized.x);

		sprite_direction = get_sprite_direction (new_dir);
	}*/

	private int get_sprite_direction(Vector2 direction_in){
		int direction_out;
		if (Mathf.Abs (direction_in.x) > Mathf.Abs (direction_in.y)) {
			if (direction_in.x > 0) {
				direction_out = 3;
			} else {
				direction_out = 1;
			}
		} else {
			if (direction_in.y > 0) {
				direction_out = 2;
			} else {
				direction_out = 0;
			}
		}
		return (direction_out);
	}

	private void choose_sprite(int direction_in){
		GetComponent<SpriteRenderer> ().flipX = false;
		switch (direction_in) {
			case 0:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [1 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
			case 1:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [4 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
			case 2:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [7 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
			case 3:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [4 + current_frame];
				GetComponent<SpriteRenderer> ().flipX = true;
				//this.transform.rotation = Quaternion.Euler (0, 180, 0);
				current_frame = (int)((3 * Time.fixedTime) % 2);
				break;
		}
	}

	void Update () {
		if (alive_state == alive_state_enum.alive) {
			do_ai ();
			ai_action ();
			choose_sprite (sprite_direction);
		} else {
			if (alive_state == alive_state_enum.burning & (Time.time - this.dying_time) > this.dead_time) {
				kill ();
			} else if (alive_state == alive_state_enum.burning) {
				this.transform.Translate (new Vector2(Random.Range(-1,1),Random.Range(-1,1)) * Time.deltaTime);
			}
		}
	}
}
