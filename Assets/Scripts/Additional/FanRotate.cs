using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanRotate : MonoBehaviour
{
    public float rotateSpeed = 20;
    // Update is called once per frame
    void Update()
    {
        //rotate along X axie:
        this.transform.localRotation *= Quaternion.AngleAxis(Time.deltaTime * rotateSpeed, new Vector3(0.0f, 1.0f, 0.0f));
    }
}
