using UnityEngine;
using System.Collections;

public class soldier_enemy_object : MonoBehaviour {
	public Sprite[] sprite_list;
	private soldier_enemy_object self_enemy_object;

	private soldier_enemy_object (){

	}

	// Use this for initialization
	void Start () {
		sprite_list = GameObject.Find ("spawn_manager").GetComponent<spawn_manager> ().all_enemy_sprites;
		//self_enemy_object = new soldier_enemy_object ();

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

	int direction = 0;
	int moving = 0;
	int current_frame = 0;

	public void move_soldier(int in_direction, float velocity_in){
		direction = in_direction;
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
		direction = in_direction;
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

	void Update () {
		direction = (int)((Time.time / 1f) % 4);
		move_soldier (direction, 2f);
		//this.transform.rotation = Quaternion.Euler (0, 0, 0);
		GetComponent<SpriteRenderer> ().flipX = false;

		if (1 == moving) {
			switch (direction) {
			case 0:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [1 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				moving = 0;
				break;
			case 1:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [3 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				moving = 0;
				break;
			case 2:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [6 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				moving = 0;
				break;
			case 3:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [3 + current_frame];
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
	}
}
