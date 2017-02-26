using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpenDoors : MonoBehaviour
{
    public float angleOpen = -90f;
    public float angleClose = 0f;

    private GameObject player;
    private float smooth = 1f;
    private float distance = 3f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        if (distance < this.distance)
        {
            Quaternion mainTarget = Quaternion.Euler(-90f, 0f, angleOpen);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, mainTarget, this.smooth * Time.deltaTime);
        }
        else
        {
            Quaternion mainTarget = Quaternion.Euler(-90f, 0f, angleClose);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, mainTarget, this.smooth * Time.deltaTime);
        }
    }
}
