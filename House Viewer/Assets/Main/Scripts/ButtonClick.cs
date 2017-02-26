using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class ButtonClick : MonoBehaviour
{
    public int noOfStair = 1;
    public int sceneIndex = 1;
    public GameObject canvas;
    public float delayTime = 1f;


    private Slider slider;
    private float timer;
    private bool gazeAt;
    private Coroutine fillBarRoutine;

    public GameObject loading;

    void Start()
    {
        canvas.SetActive(false);
        slider = canvas.transform.GetChild(0).GetComponent<Slider>();
        //loading.SetActive(false);
    }

    public void OnGazeEnter()
    {
        canvas.SetActive(true);
        gazeAt = true;
        fillBarRoutine = StartCoroutine(ChangeScene());
    }

    private IEnumerator ChangeScene()
    {
        timer = 0f;
        while (timer < delayTime)
        {
            timer += Time.deltaTime;
            slider.value = timer / delayTime;
            yield return null;

            if (gazeAt)
                continue;
            timer = 0f;
            slider.value = 0f;
            yield break;
        }

        OnGazeExit();
        PlayerPrefs.SetInt("stair", noOfStair);
        //loading.SetActive(true);
        SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        //StartCoroutine(LoadSceneFloor());
    }

    private IEnumerator LoadSceneFloor()
    {
        yield return new WaitForSeconds(1);
        AsyncOperation ao = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Single);
        ao.allowSceneActivation = false;
        while (!ao.isDone)
        {
            if (ao.progress == 0.9f)
                ao.allowSceneActivation = true;
            yield return null;
        }
        loading.SetActive(false);
    }

    public void OnGazeExit()
    {
        gazeAt = false;
        if (fillBarRoutine != null)
        {
            StopCoroutine(fillBarRoutine);
        }
        timer = 0f;
        slider.value = 0f;
        canvas.SetActive(false);
    }
}
