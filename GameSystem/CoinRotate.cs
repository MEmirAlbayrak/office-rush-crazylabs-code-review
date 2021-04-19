using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinRotate : MonoBehaviour
{
    public Vector3 axis;
    public float angularSpeed = 10f;
    void Update()
    {
        transform.Rotate(axis, angularSpeed * Time.deltaTime, Space.Self);
    }
}
