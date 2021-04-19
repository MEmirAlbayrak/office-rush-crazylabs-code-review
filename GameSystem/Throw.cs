using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float torque = 100f;
    private float speedMin, speedMax;
    float throwForceX = 5, throwForceY = 500f;
    void Start()
    {
        speedMin = DebugMenu.Instance.GetMinSpeed();
        speedMax = DebugMenu.Instance.GetMaxSpeed();

        rb = GetComponent<Rigidbody>();

        float speed = Random.Range(speedMin, speedMax);

        Vector2 direction = (GameController.throwPointPos - transform.position);
        direction = direction.normalized;

        rb.AddTorque(Random.insideUnitSphere * torque * 75);

        rb.AddForce(direction.x * throwForceX, direction.y * throwForceY, 30 * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("BackWall"))
        {
            Destroy(gameObject);
        }
    }
}
