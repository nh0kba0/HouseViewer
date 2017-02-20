using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonClick : MonoBehaviour {

	private int curScene;
	private int nextScene;
	private int preScene;

	public GameObject canvas;
	public float delayTime = 1f;

	private Slider slider;
	private float timer;
	private bool gazeAt;
	private Coroutine fillBarRoutine;

	void Start(){
		curScene = SceneManager.GetActiveScene ().buildIndex;
		nextScene = curScene + 1;
		preScene = curScene - 1;

		canvas.SetActive (false);
		slider = canvas.transform.GetChild (0).GetComponent<Slider> ();
	}

	public void OnGazeButtonUp(){
		canvas.SetActive (true);
		gazeAt = true;
		fillBarRoutine = StartCoroutine (UpStair());
	}

	private IEnumerator UpStair(){
		timer = 0f;
		while (timer < delayTime) {
			timer += Time.deltaTime;
			slider.value = timer / delayTime;
			yield return null;

			if (gazeAt)
				continue;
			timer = 0f;
			slider.value = 0f;
			yield break;
		}

		OnGazeButtonExit ();
		SceneManager.LoadScene (nextScene);
	}

	public void OnGazeButtonDown(){
		canvas.SetActive (true);
		gazeAt = true;
		fillBarRoutine = StartCoroutine (DownStair());
	}

	private IEnumerator DownStair(){
		timer = 0f;
		while (timer < delayTime) {
			timer += Time.deltaTime;
			slider.value = timer / delayTime;
			yield return null;

			if (gazeAt)
				continue;
			timer = 0f;
			slider.value = 0f;
			yield break;
		}

		OnGazeButtonExit ();
		SceneManager.LoadScene (preScene);
	}

	public void OnGazeButtonExit(){
		gazeAt = false;
		if (fillBarRoutine != null) {
			StopCoroutine (fillBarRoutine);
		}
		timer = 0f;
		slider.value = 0f;
		canvas.SetActive (false);
	}
}
