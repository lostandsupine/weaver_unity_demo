using UnityEngine;
using System.Collections;

public class input_manager : MonoBehaviour {

	public static bool is_paused = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Escape))
		{
			Time.timeScale = 1.0f - Time.timeScale;
			is_paused = !is_paused;
		}

		if(!is_paused && (Input.GetKey(KeyCode.DownArrow) || (Input.GetAxis("Vertical1") == -1)))
		{
			GameObject.Find("leila").GetComponent<leila_walk>().move_leila(0);
			GameObject.Find("camera").GetComponent<CameraController>().move_camera(0);
			GameObject.Find("rune_manager").GetComponent<rune_manager>().move_runes(0);
		}
		if(!is_paused && (Input.GetKey(KeyCode.LeftArrow) || (Input.GetAxis("Horizontal1") == -1)))
		{
			GameObject.Find("leila").GetComponent<leila_walk>().move_leila(1);
			GameObject.Find("camera").GetComponent<CameraController>().move_camera(1);
			GameObject.Find("rune_manager").GetComponent<rune_manager>().move_runes(1);
		}
		if(!is_paused && (Input.GetKey(KeyCode.UpArrow) || (Input.GetAxis("Vertical1") == 1)))
		{
			GameObject.Find("leila").GetComponent<leila_walk>().move_leila(2);
			GameObject.Find("camera").GetComponent<CameraController>().move_camera(2);
			GameObject.Find("rune_manager").GetComponent<rune_manager>().move_runes(2);
		}
		if(!is_paused && (Input.GetKey(KeyCode.RightArrow) || (Input.GetAxis("Horizontal1") == 1)))
		{
			GameObject.Find("leila").GetComponent<leila_walk>().move_leila(3);
			GameObject.Find("camera").GetComponent<CameraController>().move_camera(3);
			GameObject.Find("rune_manager").GetComponent<rune_manager>().move_runes(3);
		}

	}
}
