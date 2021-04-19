using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] MainMenuScript mainMenu;
    [SerializeField] Transform hand;
    bool toRight = false;
    float startingPos;
    float speed;
    private void OnEnable()
    {
        if (PlayerPrefs.GetInt("Tutorial") == 1) gameObject.SetActive(false);

        else
        {
            mainMenu.StopGame();
            gameObject.SetActive(true);

            startingPos = hand.transform.localPosition.x;
            speed = (2 * startingPos) / 122f;
        }
    }

    void Update()
    {
        if (hand.localPosition.x > startingPos)
        {
            toRight = false;
        }

        if (hand.localPosition.x < -startingPos)
        {
            toRight = true;
        }

        Vector3 handPos = hand.position;

        if (toRight)
        {
            handPos.x += speed;
        }

        else
        {
            handPos.x -= speed;
        }

        hand.position = handPos;

        if (Input.GetMouseButton(0))
        {
            mainMenu.StartGame();
            gameObject.SetActive(false);

            PlayerPrefs.SetInt("Tutorial", 1);
        }
    }
}
