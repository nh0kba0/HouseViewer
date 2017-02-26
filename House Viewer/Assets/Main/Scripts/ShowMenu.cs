using UnityEngine;
using System.Collections;

public class ShowMenu : MonoBehaviour {

    public GameObject menu;
    private GameObject player;
    public float _distance = 4f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(menu.transform.position, player.transform.position);
        if (distance < _distance)
        {
            menu.SetActive(true);
        }
        else
        {
            menu.SetActive(false);
        }
    }
}