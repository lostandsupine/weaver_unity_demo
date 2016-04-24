using UnityEngine;
using System.Collections;

public class leila_walk : MonoBehaviour {

	public Sprite[] tiles;

	int velocity = 10;
	int direction = 0;
	int moving = 0;
	int current_frame = 0;
	// Use this for initialization
	void Start () {
	
	}

	public void move_leila(int in_direction){
		direction = in_direction;
		moving = 1;
		switch (in_direction) {
		case 0:
			this.transform.Translate ((Vector3.back * velocity) * Time.deltaTime);
			break;
		case 1:
			this.transform.Translate ((Vector3.left * velocity) * Time.deltaTime);
			break;
		case 2:
			this.transform.Translate ((Vector3.forward * velocity) * Time.deltaTime);
			break;
		case 3:
			this.transform.Translate ((Vector3.right * velocity) * Time.deltaTime);
			break;
		}

	}
	
	// Update is called once per frame
	void Update () {
		
		// Left
		/*
		if(!input_manager.is_paused && (Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("Horizontal1") == -1)))
		{
			transform.Translate((Vector3.left* velocity) * Time.deltaTime);
			direction = 1;
			moving = 1;
		}
		// Right
		if(Input.GetKey(KeyCode.RightArrow) || (Input.GetAxis("Horizontal1") == 1))
		{
			transform.Translate((Vector3.right * velocity) * Time.deltaTime);
			direction = 3;
			moving = 1;
		}
		// Up
		if(Input.GetKey(KeyCode.UpArrow) || (Input.GetAxis("Vertical1") == 1))
		{
			transform.Translate((Vector3.forward * velocity) * Time.deltaTime);
			direction = 2;
			moving = 1;
		}
		// Down
		if(Input.GetKey(KeyCode.DownArrow) || (Input.GetAxis("Vertical1") == -1))
		{
			transform.Translate((Vector3.back * velocity) * Time.deltaTime);
			direction = 0;
			moving = 1;
		}
		*/
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
