using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    float AISpeed = 70f;

    Transform cam;
    [SerializeField] float rotationMin, rotationMax, rotationNormal, nextChangeCooldown = 5f, rotationSpeed = 45, startTime = 2.5f;
    float nextChange, nextRotation, startX;
    public bool reach = true, start = false;
    Vector3 playerStartingPos;
    Rigidbody rb;
    CapsuleCollider capsuleCollider;
    Animator animator;
    [SerializeField] GameObject[] hats;
    [SerializeField] Transform hatPosition;
    FinishScript finishScript;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        int random = Random.Range(0, hats.Length + 1);
        if (random != hats.Length) Instantiate(hats[random], hatPosition);
    }

    private void OnEnable()
    {
        animator.SetBool("Running", true);
    }

    private void OnDisable()
    {
        animator.SetBool("Running", false);
    }
    void Start()
    {
        finishScript = FindObjectOfType<FinishScript>();
        AISpeed = DebugMenu.Instance.GetAISpeed();
        
        cam = Camera.main.transform;
        rb = GetComponent<Rigidbody>();
        capsuleCollider = GetComponent<CapsuleCollider>();

        playerStartingPos = transform.position + Vector3.up * 3;

        nextChange = nextChangeCooldown - startTime;
        startX = GameController.throwPointPos.x;
        rotationNormal = transform.rotation.eulerAngles.y;
        rotationMin = rotationNormal - 45;
        rotationMax = rotationNormal + 45;
    }
    void Update()
    {
        layerChange();
        RotationChange();
        Rotate();
    }

    void layerChange()
    {
        if (transform.position.z <= cam.position.z)
        {
            gameObject.layer = 10;
        }

        else
        {
            gameObject.layer = 0;
        }
    }

    void Rotate()
    {
        float currentRotation = transform.rotation.eulerAngles.y;

        if (currentRotation >= nextRotation && !reach)
        {
            transform.Rotate(0, Time.deltaTime * -rotationSpeed, 0);

            if (currentRotation < nextRotation) reach = true;
        }

        if (currentRotation <= nextRotation && !reach)
        {
            transform.Rotate(0, Time.deltaTime * rotationSpeed, 0);

            if (currentRotation > nextRotation) reach = true;
        }
    }

    void RotationChange()
    {
        nextChange += Time.deltaTime;

        if (nextChange > nextChangeCooldown)
        {
            nextChange = 0;

            int possibility;

            if (transform.position.x > startX) possibility = Random.Range(2, 4);

            else possibility = Random.Range(1, 3);

            switch (possibility)
            {
                case 1:
                    nextRotation = Random.Range(rotationMin, rotationMin + 22.5f);
                    break;

                case 2:
                    if (nextRotation != rotationNormal) nextRotation = rotationNormal;
                    else nextChange = nextChangeCooldown;
                    break;

                case 3:
                    nextRotation = Random.Range(rotationMax - 22.5f, rotationMax);
                    break;
            }

            reach = false;
        }
    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * Time.deltaTime * AISpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Walls"))
        {
            nextChange = 0;

            if (transform.position.x > startX)
            {
                nextRotation = Random.Range(rotationMax - 22.5f, rotationMax);
            }

            else
            {
                nextRotation = Random.Range(rotationMin, rotationMin + 22.5f);
            }

            reach = false;
        }
        if(other.CompareTag("FinishLine"))
        {
            finishScript.SetPlace();
            Destroy(this);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Object"))
        {
            rb.velocity = Vector3.zero;
            transform.position = playerStartingPos;

        }
    }
    
}
