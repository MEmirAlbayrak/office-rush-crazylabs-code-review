using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] GameObject coinPrefab;
    [SerializeField] float height;
    int coinCount;
    [SerializeField] Transform coinTop, coinBot;
    Vector3 unitVector;

    void Start()
    {
        coinCount = DebugMenu.Instance.GetCoinAmount();
        
        Vector2 coinTopYZ = new Vector2(coinTop.position.y, coinTop.position.z);
        Vector2 coinBotYZ = new Vector2(coinBot.position.y, coinBot.position.z);
        float magnitudeYZ = Vector2.Distance(coinTopYZ, coinBotYZ);

        unitVector = (coinTop.position - coinBot.position).normalized;

        float distanceX = coinBot.GetComponent<MeshRenderer>().bounds.extents.x;

        for (int i = 0; i < coinCount; i++)
        {
            float coinYZDistance = Random.Range(0, magnitudeYZ);
            float randomX = Random.Range(-distanceX, distanceX);

            Vector3 newPos = new Vector3(0, unitVector.y, unitVector.z) * coinYZDistance;
            newPos.y += height;
            newPos.x += randomX;

            Instantiate(coinPrefab, coinBot.position + newPos, coinPrefab.transform.rotation);
        }
    }
}
