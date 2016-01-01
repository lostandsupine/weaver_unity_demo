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
	
	// Update is called once per frame
	void Update () {
		// Left
		if((Input.GetKey(KeyCode.LeftArrow)))
		{
			transform.Translate((Vector3.left* velocity) * Time.deltaTime);
			direction = 1;
			moving = 1;
		}
		// Right
		if((Input.GetKey(KeyCode.RightArrow)))
		{
			transform.Translate((Vector3.right * velocity) * Time.deltaTime);
			direction = 3;
			moving = 1;
		}
		// Up
		if((Input.GetKey(KeyCode.UpArrow)))
		{
			transform.Translate((Vector3.forward * velocity) * Time.deltaTime);
			direction = 2;
			moving = 1;
		}
		// Down
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate((Vector3.back * velocity) * Time.deltaTime);
			direction = 0;
			moving = 1;
		}
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
