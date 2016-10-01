using UnityEngine;
using System.Collections;

public class input_manager : MonoBehaviour {

	public static bool is_paused = false;
	public bool[] rune_keys_down;
	public bool[] rune_keys_pressed;
	private float num_rune_keys_pressed = 0;
	private bool tab_down = false;
	private bool pause_down = false;
	private float velocity = 7f;
	private Vector2 current_direction = new Vector2(0f,0f);
	private Vector2 last_direction = new Vector2(0f,-1f);

	void Start () {
	
		this.rune_keys_down = new bool[4];
		this.rune_keys_pressed = new bool[4];
		for (int i = 0; i < 4; i++) {
			this.rune_keys_down [i] = false;
			this.rune_keys_pressed [i] = false;
		}
	}

	public Vector2 get_direction(){
		return(last_direction);
	}
		
	void FixedUpdate () {
		if((Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.JoystickButton7)) && !pause_down)
		{
			Time.timeScale = 1.0f - Time.timeScale;
			is_paused = !is_paused;
			pause_down = true;
		}
		float move_x = 0;
		float move_y = 0;
		pause_down = Input.GetKey (KeyCode.Escape) || Input.GetKey (KeyCode.JoystickButton7);

		if (!is_paused) {
			
			if (!is_paused && (Input.GetKey (KeyCode.DownArrow) || (Input.GetAxis ("Vertical1") == -1))) {
				//GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (0,velocity);
				move_y--;
			}
			if (!is_paused  && (Input.GetKey (KeyCode.LeftArrow) || (Input.GetAxis ("Horizontal1") == -1))) {
				//GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (1,velocity);
				move_x--;
			}
			if (!is_paused && (Input.GetKey (KeyCode.UpArrow) || (Input.GetAxis ("Vertical1") == 1))) {
				//GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (2,velocity);
				move_y++;
			}
			if (!is_paused && (Input.GetKey (KeyCode.RightArrow) || (Input.GetAxis ("Horizontal1") == 1))) {
				//GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (3,velocity);
				move_x++;
			}
			if (move_x != 0 && move_y == 0) {
				GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (2 + (int)move_x, velocity);
				GameObject.Find ("leila").GetComponent<leila_walk> ().moving = 1;
			} else if (move_x == 0 && move_y != 0) {
				GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (1 + (int)move_y, velocity);
				GameObject.Find ("leila").GetComponent<leila_walk> ().moving = 1;
			} else if (move_x != 0 && move_y != 0) {
				GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (2 + (int)move_x, velocity / 1.414214f);
				GameObject.Find ("leila").GetComponent<leila_walk> ().move_leila (1 + (int)move_y, velocity / 1.414214f);
				GameObject.Find ("leila").GetComponent<leila_walk> ().moving = 1;
			} else {
				GameObject.Find ("leila").GetComponent<leila_walk> ().moving = 0;
			}

			current_direction = new Vector2 (move_x, move_y);
			if (current_direction.magnitude > 0) {
				last_direction = current_direction;
			}

			if (Input.GetKey (KeyCode.S) || Input.GetKey (KeyCode.JoystickButton0)) {
				rune_keys_down [0] = true;
			} else if (rune_keys_down [0]) {
				rune_keys_down [0] = false;
				rune_keys_pressed [0] = true;
			}
			if (Input.GetKey (KeyCode.A) || Input.GetKey (KeyCode.JoystickButton2)) {
				rune_keys_down [1] = true;
			} else if (rune_keys_down [1]) {
				rune_keys_down [1] = false;
				rune_keys_pressed [1] = true;
			}
			if (Input.GetKey (KeyCode.W) || Input.GetKey (KeyCode.JoystickButton3)) {
				rune_keys_down [2] = true;
			} else if (rune_keys_down [2]) {
				rune_keys_down [2] = false;
				rune_keys_pressed [2] = true;
			}
			if (Input.GetKey (KeyCode.D) || Input.GetKey (KeyCode.JoystickButton1)) {
				rune_keys_down [3] = true;
			} else if (rune_keys_down [3]) {
				rune_keys_down [3] = false;
				rune_keys_pressed [3] = true;
			}

			num_rune_keys_pressed = 0;
			for (float i = 0; i < 4; i++) {
				if (rune_keys_pressed [(int)i]) {
					num_rune_keys_pressed = num_rune_keys_pressed + Mathf.Pow (10f, i);
					rune_keys_pressed [(int)i] = false;
				}
			}

			if (1f == num_rune_keys_pressed | 10f == num_rune_keys_pressed | 100f == num_rune_keys_pressed | 1000f == num_rune_keys_pressed) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().mark_runes ((int)Mathf.Log10 (num_rune_keys_pressed));
			}

			if (Input.GetKey (KeyCode.Alpha1) || Input.GetAxis ("Vertical2") == -1) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().change_spell (0);
			}
			if (Input.GetKey (KeyCode.Alpha2) || Input.GetAxis ("Horizontal2") == -1) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().change_spell (1);
			}
			if (Input.GetKey (KeyCode.Alpha3) || Input.GetAxis ("Vertical2") == 1) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().change_spell (2);
			}
			if (Input.GetKey (KeyCode.Alpha4) || Input.GetAxis ("Horizontal2") == 1) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().change_spell (3);
			}
			
			if ((Input.GetKey (KeyCode.Tab) || Input.GetKey (KeyCode.JoystickButton4)) && !tab_down) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().next_spell (-1);
				tab_down = true;
			}
			if ((Input.GetKey (KeyCode.JoystickButton5)) && !tab_down) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().next_spell (1);
				tab_down = true;
			}
			tab_down = Input.GetKey (KeyCode.Tab) || Input.GetKey (KeyCode.JoystickButton4) || Input.GetKey (KeyCode.JoystickButton5);

			if (Input.GetKey (KeyCode.Space)  || (Input.GetAxis("RTrigger") >= 0.75)) {
				GameObject.Find ("rune_manager").GetComponent<rune_manager> ().cast_spell(current_direction.normalized);
			}
		}
	}
}
