using UnityEngine;
using System.Collections;

public class rune_object {
	public Sprite[] rune_sprite_list;
	public Sprite[] rune_complete_sprite_list;
	private int[] path_list;
	private int[,] position_list;
	public GameObject[] rune_obj_list;

	private int flip(int direction_in){
		switch (direction_in){
		case 0: 
			return 2;
			break;
		case 1:
			return 3;
			break;
		case 2:
			return 0;
			break;
		case 3:
			return 1;
			break;
		default:
			return -1;
			Debug.Log("can't flip this direction");
			break;
		}
	}
		
	public int current_incomplete_rune;
	public bool[] rune_keys_down;
	public bool[] rune_keys_pressed;

	public rune_object(int[] path_list_in,Sprite[] rune_start_list,Sprite[,] rune_body_array,Sprite[] rune_end_list,
		Sprite[] rune_complete_start_list,Sprite[,] rune_complete_body_array,Sprite[] rune_complete_end_list){

		this.path_list = path_list_in;
		this.rune_sprite_list = new Sprite[this.path_list.Length+1];
		this.rune_complete_sprite_list = new Sprite[this.path_list.Length+1];
		this.position_list = new int[this.path_list.Length+1,2];
		this.rune_obj_list = new GameObject[this.path_list.Length+1];

		this.rune_sprite_list[0] = rune_start_list[path_list_in[0]];
		this.rune_complete_sprite_list[0] = rune_complete_start_list[path_list_in[0]];
		this.position_list[0,0] = 0;
		this.position_list[0,1] = 0;

		this.current_incomplete_rune = 1;

		this.rune_keys_down = new bool[4];
		this.rune_keys_pressed = new bool[4];
		for (int i = 0; i < 4; i++) {
			this.rune_keys_down [i] = false;
			this.rune_keys_pressed [i] = false;
		}

		for (int i = 1; i <= (this.path_list.Length); i++){
			if (i == (this.path_list.Length)){
				this.rune_sprite_list[i] = rune_end_list[path_list_in[i-1]];
				this.rune_complete_sprite_list[i] = rune_complete_end_list[path_list_in[i-1]];

			} else {
				//Debug.Log(i.ToString() + flip(path_list_in[i-1]).ToString() + path_list_in[i].ToString());
				this.rune_sprite_list[i] = rune_body_array[flip(path_list_in[i-1]),path_list_in[i]];
				this.rune_complete_sprite_list[i] = rune_complete_body_array[flip(path_list_in[i-1]),path_list_in[i]];

			}
			switch (path_list_in[i-1]){
			case 0:
				this.position_list[i,0] = this.position_list[i-1,0];
				this.position_list[i,1] = this.position_list[i-1,1]-1;
				break;
			case 1:
				this.position_list[i,0] = this.position_list[i-1,0]-1;
				this.position_list[i,1] = this.position_list[i-1,1];
				break;
			case 2:
				this.position_list[i,0] = this.position_list[i-1,0];
				this.position_list[i,1] = this.position_list[i-1,1]+1;
				break;
			case 3:
				this.position_list[i,0] = this.position_list[i-1,0]+1;
				this.position_list[i,1] = this.position_list[i-1,1];
				break;
			default:
				Debug.Log("incorrect direction in path list of rune object");
				break;
			}
		}
	}
	public int[] get_path(){
		return this.path_list;
	}
	public void make_rune_tiles(){
		for (int i = 0; i < this.rune_sprite_list.Length;  i++){
			//var gameObject = new GameObject("rune_tile");
			//gameObject.AddComponent<SpriteRenderer> ();
			//gameObject.GetComponent<SpriteRenderer> ().sprite = this.rune_sprite_list[i];
			
			//gameObject.transform.rotation = Quaternion.Euler(90,0,0);
			//gameObject.transform.position = new Vector3 (-9+this.position_list[i,0],1.1F, 13+this.position_list[i,1]);
			//gameObject.transform.localScale = new Vector3 (6, 6, 6);

			this.rune_obj_list[i] = new GameObject("rune_tile");
			this.rune_obj_list[i].AddComponent<SpriteRenderer> ();
			this.rune_obj_list[i].GetComponent<SpriteRenderer> ().sprite = this.rune_sprite_list[i];
			
			this.rune_obj_list[i].transform.rotation = Quaternion.Euler(90,0,0);
			this.rune_obj_list[i].transform.position = new Vector3 (-9+this.position_list[i,0],1.1F, 13+this.position_list[i,1]);
			this.rune_obj_list[i].transform.localScale = new Vector3 (5, 5, 5);
		}

	}
	public void move_rune(Vector3 direction){
		for (int i = 0; i < this.rune_obj_list.Length; i++){
			this.rune_obj_list[i].transform.Translate(direction);
		}
	}
	public void swap_rune(bool p_complete,int i){
		if (p_complete){
			//Debug.Log (this.rune_obj_list [i]);
			this.rune_obj_list[i].GetComponent<SpriteRenderer> ().sprite = this.rune_complete_sprite_list[i];
		} else {
			this.rune_obj_list[i].GetComponent<SpriteRenderer> ().sprite = this.rune_sprite_list[i];					
		}
	}
	public bool check_rune(int i, int dir){
		return (this.path_list[i-1] == dir);
	}
	public void mark_rune(int dir){
		if (check_rune (this.current_incomplete_rune, dir)) {
			swap_rune (true, this.current_incomplete_rune);
			this.current_incomplete_rune++;
		} else {
			swap_rune (false, Mathf.Max (this.current_incomplete_rune-1, 1));
			this.current_incomplete_rune = Mathf.Max (this.current_incomplete_rune - 1, 1);
		}
	}
	public void reset_rune(){
		this.current_incomplete_rune = 1;
		for (int i = 1; i < this.rune_obj_list.Length; i++) {
			this.rune_obj_list[i].GetComponent<SpriteRenderer> ().sprite = this.rune_sprite_list[i];
		}
	}
}

public class rune_manager : MonoBehaviour {
	public Sprite[] rune_start_list;
	public Sprite[] rune_body_list;
	public Sprite[] rune_end_list;

	public Sprite[] rune_complete_start_list;
	public Sprite[] rune_complete_body_list;
	public Sprite[] rune_complete_end_list;

	public Sprite[,] rune_body_array;
	public Sprite[,] rune_complete_body_array;
	public rune_object the_rune;
	private float num_rune_keys_pressed = 0;

	// Use this for initialization
	void Start () {
		rune_body_array = new Sprite[4,4];
		rune_body_array[0,1] = rune_body_list[0];
		rune_body_array[0,2] = rune_body_list[1];
		rune_body_array[0,3] = rune_body_list[2];
		rune_body_array[1,0] = rune_body_list[3];
		rune_body_array[1,2] = rune_body_list[4];
		rune_body_array[1,3] = rune_body_list[5];
		rune_body_array[2,0] = rune_body_list[6];
		rune_body_array[2,1] = rune_body_list[7];
		rune_body_array[2,3] = rune_body_list[8];
		rune_body_array[3,0] = rune_body_list[9];
		rune_body_array[3,1] = rune_body_list[10];
		rune_body_array[3,2] = rune_body_list[11];

		rune_complete_body_array = new Sprite[4,4];
		rune_complete_body_array[0,1] = rune_complete_body_list[0];
		rune_complete_body_array[0,2] = rune_complete_body_list[1];
		rune_complete_body_array[0,3] = rune_complete_body_list[2];
		rune_complete_body_array[1,0] = rune_complete_body_list[3];
		rune_complete_body_array[1,2] = rune_complete_body_list[4];
		rune_complete_body_array[1,3] = rune_complete_body_list[5];
		rune_complete_body_array[2,0] = rune_complete_body_list[6];
		rune_complete_body_array[2,1] = rune_complete_body_list[7];
		rune_complete_body_array[2,3] = rune_complete_body_list[8];
		rune_complete_body_array[3,0] = rune_complete_body_list[9];
		rune_complete_body_array[3,1] = rune_complete_body_list[10];
		rune_complete_body_array[3,2] = rune_complete_body_list[11];

		the_rune = new rune_object(new int[]{0,3,3,2,3,0,0,1,0,0,0,3,0,3,0,3,3,2},rune_start_list,rune_body_array,rune_end_list,
			rune_complete_start_list,rune_complete_body_array,rune_complete_end_list);
		//Debug.Log (the_rune.get_path()[1]);
		the_rune.make_rune_tiles();

		the_rune.swap_rune(true,0);

	}
	
	// Update is called once per frame
	int velocity = 10;
	void Update () {
		// Left
		if((Input.GetKey(KeyCode.LeftArrow)))
		{
			the_rune.move_rune((Vector3.left* velocity) * Time.deltaTime);
		}
		// Right
		if((Input.GetKey(KeyCode.RightArrow)))
		{
			the_rune.move_rune((Vector3.right* velocity) * Time.deltaTime);
		}
		// Up
		if((Input.GetKey(KeyCode.UpArrow)))
		{
			the_rune.move_rune((Vector3.up* velocity) * Time.deltaTime);
		}
		// Down
		if(Input.GetKey(KeyCode.DownArrow))
		{
			the_rune.move_rune((Vector3.down* velocity) * Time.deltaTime);
		}

		if (Input.GetKey (KeyCode.S)) {
			the_rune.rune_keys_down [0] = true;
		} else if (the_rune.rune_keys_down [0]) {
			the_rune.rune_keys_down [0] = false;
			the_rune.rune_keys_pressed [0] = true;
		}
		if (Input.GetKey (KeyCode.A)) {
			the_rune.rune_keys_down [1] = true;
		}else if (the_rune.rune_keys_down [1]) {
			the_rune.rune_keys_down [1] = false;
			the_rune.rune_keys_pressed [1] = true;
		}
		if (Input.GetKey (KeyCode.W)) {
			the_rune.rune_keys_down [2] = true;
		}else if (the_rune.rune_keys_down [2]) {
			the_rune.rune_keys_down [2] = false;
			the_rune.rune_keys_pressed [2] = true;
		}
		if (Input.GetKey (KeyCode.D)) {
			the_rune.rune_keys_down [3] = true;
		}else if (the_rune.rune_keys_down [3]) {
			the_rune.rune_keys_down [3] = false;
			the_rune.rune_keys_pressed [3] = true;
		}

		num_rune_keys_pressed = 0;
		for (float i = 0; i < 4; i++) {
			if (the_rune.rune_keys_pressed [(int)i]) {
				num_rune_keys_pressed = num_rune_keys_pressed + Mathf.Pow (10f, i);
				the_rune.rune_keys_pressed [(int)i] = false;
			}
		}
		//Debug.Log (num_rune_keys_pressed);
		if (1f == num_rune_keys_pressed | 10f == num_rune_keys_pressed | 100f == num_rune_keys_pressed | 1000f == num_rune_keys_pressed) {
			the_rune.mark_rune ((int)Mathf.Log10(num_rune_keys_pressed));
		}

		if (Input.GetKey (KeyCode.Escape)) {
			the_rune.reset_rune ();
		}
	}
}