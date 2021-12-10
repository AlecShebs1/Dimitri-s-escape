using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmRotation : MonoBehaviour
{
    [SerializeField] public Transform playersArm;
    private float xRotation = 0f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        Vector3 arm = playersArm.transform.rotation.eulerAngles;
       

        arm.x -= mouseY;
        arm.z = 0;

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playersArm.rotation = Quaternion.Euler(arm);
       


    }
}
