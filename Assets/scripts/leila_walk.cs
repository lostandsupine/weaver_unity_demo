using UnityEngine;
using System.Collections;

public class leila_walk : MonoBehaviour {

	public Sprite[] tiles;
	//int velocity = 10;
	int direction = 0;
	int moving = 0;
	int current_frame = 0;

	void Start () {
	
	}

	public void move_leila(int in_direction, float velocity_in){
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
		
		if (1 == moving) {

			GetComponent<SpriteRenderer> ().sprite = tiles [2 * direction + current_frame];
			//current_frame = 1 - current_frame;
			current_frame = (int)((3 * Time.fixedTime) % 2);
			moving = 0;
		} else {
			GetComponent<SpriteRenderer> ().sprite = tiles [2 * direction];
		}
	}
}
