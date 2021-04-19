using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Player;
    private Vector3 cameraOffset;

    private void Start()
    {
        cameraOffset = DebugMenu.Instance.getCameraOffset();
    }

    void Update()
    {
        transform.position = Player.transform.position + cameraOffset;
    }

    public Vector3 GetCameraOffset()
    {
        return cameraOffset = transform.position - Player.transform.position;
    }
}
