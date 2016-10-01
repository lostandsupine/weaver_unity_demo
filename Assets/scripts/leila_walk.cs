using UnityEngine;
using System.Collections;

public class leila_walk : MonoBehaviour {

	public Sprite[] sprite_list;
	//int velocity = 10;
	int direction = 0;
	public int moving = 0;
	int current_frame = 0;

	void Start () {
	
	}

	public void move_leila(int in_direction, float velocity_in){
		direction = in_direction;
		//moving = 1;
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

	public void translate_leila(int in_direction, float velocity_in){
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
		
		GetComponent<SpriteRenderer> ().flipX = false;

		if (1 == moving) {
			switch (direction) {
			case 0:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [1 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				//moving = 0;
				break;
			case 1:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [4 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				//moving = 0;
				break;
			case 2:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [7 + current_frame];
				current_frame = (int)((3 * Time.fixedTime) % 2);
				//moving = 0;
				break;
			case 3:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [4 + current_frame];
				GetComponent<SpriteRenderer> ().flipX = true;
				current_frame = (int)((3 * Time.fixedTime) % 2);
				//moving = 0;
				break;
			}

		} else {
			switch (direction) {
			case 0:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [0];
				break;
			case 1:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [3];
				break;
			case 2:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [6];
				break;
			case 3:
				GetComponent<SpriteRenderer> ().sprite = sprite_list [3];
				GetComponent<SpriteRenderer> ().flipX = true;
				break;
			}

		}
	}
}
