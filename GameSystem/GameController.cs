using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Transform throwPoint;
    public static Vector3 throwPointPos;
    private void Awake()
    {
        throwPointPos = throwPoint.position;
    }
}
