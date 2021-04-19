using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Minimap : MonoBehaviour
{
    [SerializeField] Image fill;
    [SerializeField] Transform player;
    [SerializeField] Transform finish;
    float startZ, finishZ, distance;
    float fillMin = 0.0973f, fillMax, playerMaxZ = 0;
    void Start()
    {
        fillMax = 1 - (fillMin * 2);

        startZ = player.position.z;

        finishZ = Mathf.Abs(1 / (finish.position.z - startZ));

        distance = Mathf.Abs(transform.position.z - finish.position.z);

        fill.fillAmount = fillMin;
    }

    void Update()
    {
        float playerZ = Mathf.Abs(player.position.z - startZ);

        if (playerZ > playerMaxZ)
        {
            playerMaxZ = playerZ;
        }

        fill.fillAmount = ((playerMaxZ * finishZ) * fillMax) + fillMin;
    }
}
