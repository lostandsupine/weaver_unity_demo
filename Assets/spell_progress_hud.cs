using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spell_progress_hud : MonoBehaviour {

	void Start () {
		GameObject.Find ("blue_1").GetComponent<Image> ().fillAmount = 0f;
		GameObject.Find ("pink_1").GetComponent<Image> ().fillAmount = 0f;
	}

	void Update () {
		if (GameObject.Find ("rune_manager").GetComponent<rune_manager> ().is_channelling (0)) {
			GameObject.Find ("blue_1").GetComponent<Image> ().fillAmount = 0f;
			GameObject.Find ("pink_1").GetComponent<Image> ().fillAmount = GameObject.Find ("rune_manager").GetComponent<rune_manager> ().get_percent_complete (0);
		} else {
			GameObject.Find ("pink_1").GetComponent<Image> ().fillAmount = 0f;
			GameObject.Find ("blue_1").GetComponent<Image> ().fillAmount = GameObject.Find ("rune_manager").GetComponent<rune_manager> ().get_percent_complete (0);

		}
		if (GameObject.Find ("rune_manager").GetComponent<rune_manager> ().is_channelling (1)) {
			GameObject.Find ("blue_2").GetComponent<Image> ().fillAmount = 0f;
			GameObject.Find ("pink_2").GetComponent<Image> ().fillAmount = GameObject.Find ("rune_manager").GetComponent<rune_manager> ().get_percent_complete (1);
		} else {
			GameObject.Find ("pink_2").GetComponent<Image> ().fillAmount = 0f;
			GameObject.Find ("blue_2").GetComponent<Image> ().fillAmount = GameObject.Find ("rune_manager").GetComponent<rune_manager> ().get_percent_complete (1);

		}
	}
}
