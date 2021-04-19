using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    float pcTurningSpeed = 300f, turningSpeed , playerSpeed;
    private float movementPC;
    Vector3 tempPos, playerStartingPos;
    Rigidbody rb;
    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        animator.SetBool("Running", true);
    }

    private void OnDisable()
    {
        animator.SetBool("Running", false);
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        playerSpeed = DebugMenu.Instance.GetPlayerSpeed();
        turningSpeed = DebugMenu.Instance.GetTurningSpeed();

        playerStartingPos = transform.position + Vector3.up * 3;
    }
    private void Update()
    {
        movementPC = Input.GetAxis("Horizontal");

        RestartScene();
    }
    private void FixedUpdate()
    {
        RotatePlayer();
        MovePlayerPC();
    }

    private void RestartScene()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void MovePlayerPC()
    {
        transform.Rotate(0, Time.deltaTime * movementPC * pcTurningSpeed, 0);
    }

    private void RotatePlayer()
    {
        if (Input.touchCount > 0)
        {
            Touch finger = Input.GetTouch(0);
            transform.Rotate(0, Time.deltaTime * turningSpeed * finger.deltaPosition.x, 0);
        }

        transform.position += transform.forward * Time.deltaTime * playerSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Object"))
        {
            rb.velocity = Vector3.zero;
            transform.position = playerStartingPos;
        }
    }
}
