using UnityEngine;
using System.Collections;

public class AutoWalk : MonoBehaviour {

	public float speed = 5.0F;
	public bool isWalking = false;
	private CharacterController controller;
	private Transform vrHead;

	void Start(){
		controller = GetComponent<CharacterController> ();
		vrHead = Camera.main.transform;
	}

	void Update() {
		if (Input.GetButtonDown ("Fire1")) {
			isWalking = true;
		}

		if (Input.GetButtonUp ("Fire1")) {
			isWalking = false;
		}

		if (isWalking) {
			Vector3 forward = vrHead.TransformDirection (Vector3.forward);
			controller.SimpleMove (forward * speed);
		}
	}
}
