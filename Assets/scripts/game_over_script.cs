using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class game_over_script : MonoBehaviour {

	private float exit_time;
	private float game_over_time;
	private bool is_game_over;
	private Text the_text;

	// Use this for initialization
	void Start () {
		exit_time = 3f;
		is_game_over = false;
		this.gameObject.GetComponent<Text> ().text = "";
	}

	public void game_over(){
		is_game_over = true;
		game_over_time = Time.time;
		this.gameObject.GetComponent<Text> ().text = "Game Over";
	}
	// Update is called once per frame
	void Update () {
		if (is_game_over & (Time.time - game_over_time) >= exit_time) {
			Debug.Log ("exiting");
			Application.Quit ();
		}
	}
}
