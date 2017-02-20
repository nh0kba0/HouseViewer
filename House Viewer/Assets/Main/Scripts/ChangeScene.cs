using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public GameObject menu;
	private bool nearStair = false;

	void OnControllerColliderHit(ControllerColliderHit hit) {
		if (hit.gameObject.tag == "stair") {
			nearStair = true;
		} else {
			nearStair = false;
		}
	}

	void Update () {
		if (nearStair) {
			menu.SetActive (true);
		} else {
			menu.SetActive (false);
		}
	}
}