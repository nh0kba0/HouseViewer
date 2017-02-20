using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenGroupDoor : MonoBehaviour, IGvrGazeResponder {

	public GameObject canvas;
	public float openTime = 1f;
	public float closeTime = 10f;

	private Slider slider;
	private float timer;
	private bool gazeAt;
	private Coroutine fillBarRoutine;

	private int count = 2;
	private GameObject player;
	private GameObject[] doors = new GameObject[2];
	//private OpenDoor[] openDoorScripts = new OpenDoor[2];
	private bool isOpen = false;
	private bool isNear = false;

	void Update(){
		float distance = Vector3.Distance (doors [1].transform.position, player.transform.position);
		if (distance < 500.0f)
			isNear = true;
		else
			isNear = false;
	}

	void Start(){
		canvas.SetActive (false);
		for (int i = 0; i < count; i++) {
			doors [i] = this.gameObject.transform.GetChild (i).gameObject;
			//openDoorScripts[i] = doors [i].GetComponent (typeof(OpenDoor)) as OpenDoor;
		}
		player = GameObject.FindGameObjectWithTag ("Player");
		slider = canvas.transform.GetChild(0).GetComponent<Slider> ();
	}
		
	public void OnGazeEnter(){

	}

	public void OnGazeExit(){
		hideSlider ();
		StartCoroutine (closeAllDoors());
	}

	public void OnGazeTrigger(){
		if (!isOpen && isNear) {
			canvas.SetActive (true);
			gazeAt = true;
			fillBarRoutine = StartCoroutine (openAllDoors ());
		}
	}

	private IEnumerator openAllDoors(){
		timer = 0f;
		while (timer < openTime) {
			timer += Time.deltaTime;
			slider.value = timer / openTime;
			yield return null;

			if (gazeAt)
				continue;
			timer = 0f;
			slider.value = 0f;
			yield break;
		}

		for (int i = 0; i < count; i++) {
			//openDoorScripts [i].open ();
		}
		hideSlider ();
		isOpen = true;
	}

	private IEnumerator closeAllDoors(){
		yield return new WaitForSeconds(closeTime);
		if (isOpen) {
			for (int i = 0; i < count; i++) {
				//openDoorScripts [i].close ();
			}
			isOpen = false;
		}
	}

	private void hideSlider(){
		gazeAt = false;
		if (fillBarRoutine != null) {
			StopCoroutine (fillBarRoutine);
		}
		timer = 0f;
		slider.value = 0f;
		canvas.SetActive (false);
	}
}
