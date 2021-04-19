using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] GameObject[] prefabObject;
    private float maxCountdown, minCountdown;
    private int minNumber, maxNumber;
    float countdown = 0, countdownRandom = 0;
    int howMany;
    float positionMinX, positionMaxX;
    [SerializeField] Transform spawnParent;
    void Start()
    {
        DebugMenu Instance = DebugMenu.Instance;

        maxCountdown = Instance.GetSpawnObjectMaxCountdown();
        minCountdown = Instance.GetSpawnObjectMinCountdown();

        minNumber = Instance.GetSpawnObjectMinNumber();
        maxNumber = Instance.GetSpawnObjectMaxNumber();

        positionMinX = GetComponent<MeshRenderer>().bounds.min.x;
        positionMaxX = GetComponent<MeshRenderer>().bounds.max.x;

        howMany = Random.Range(minNumber, maxNumber + 1);
    }

    void Update()
    {
        countdown += Time.deltaTime;
        if (countdown > countdownRandom)
        {
            for (int i = 0; i < howMany; i++)
            {
                int random = Random.Range(0, prefabObject.Length);
                float spawnX = Random.Range(positionMinX, positionMaxX);

                Vector3 randomStartPos = new Vector3(spawnX, transform.position.y, transform.position.z);
                Instantiate(prefabObject[random], randomStartPos, Quaternion.identity, spawnParent);
            }

            howMany = Random.Range(minNumber, maxNumber + 1);
            float countDownMultiplier = ((float)howMany - minNumber) / (maxNumber - minNumber);
            countdownRandom = Mathf.Lerp(minCountdown, maxCountdown, countDownMultiplier);
            countdown = 0;
        }
    }
}
