using UnityEngine;
using System.Collections;

public class AutoWalk : MonoBehaviour
{

    public float speed = 5.0F;
    public bool isWalking = false;
    private CharacterController controller;
    private Transform vrHead;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        vrHead = Camera.main.transform;

        int stair = PlayerPrefs.GetInt("stair");
        if (stair > 1 && stair < 12)
        {
            ShareInfo._VRMainInfo info = new ShareInfo().getInfo(stair);

            Vector3 newPos = new Vector3(info._xPos, transform.position.y, info._zPos);
            transform.position = newPos;

            Vector3 newRot = new Vector3(transform.eulerAngles.x, info._yRot, transform.eulerAngles.z);
            transform.eulerAngles = newRot;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isWalking = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            isWalking = false;
        }

        if (isWalking)
        {
            Vector3 forward = vrHead.TransformDirection(Vector3.forward);
            controller.SimpleMove(forward * speed);
        }
    }
}
