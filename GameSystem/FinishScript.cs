using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class FinishScript : MonoBehaviour
{
    [SerializeField] Image endCanvas;
    [SerializeField] bool gameEnded;
    [SerializeField] TextMeshProUGUI mainCoinText;
    SaveScore coinHandler;
    [SerializeField] GameObject[] animationCoins;
    [SerializeField] GameObject mainCoin , collectButton, continueButton;
    [HideInInspector] public int id;
    [HideInInspector] public LTDescr d;
    [SerializeField] MainMenuScript mainMenu;
    [SerializeField] TextMeshProUGUI placesText1, placesText2, placesText3;
    int playerPlace , place = 1, totalCoin;
    List<int> usedNames;
    void Start()

    {
        usedNames = new List<int>();

        continueButton.SetActive(false);
        foreach (GameObject coin in animationCoins)
        {
            LeanTween.scale(coin, new Vector3(0f, 0f, 0f), 0);
        }
        coinHandler = GameObject.Find("Player").GetComponent<SaveScore>();
        totalCoin = PlayerPrefs.GetInt("Total Coin");
        mainCoinText.text = totalCoin.ToString("F0");

        LeanTween.scale(endCanvas.gameObject, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeOutBounce);
    }
    private string RandomName()
    {
        int randomNum = 0;
        bool used = false;
        string[] randomName = new string[]
        {"Dragonfly", "Flyby", "Thumper", "Snow White", "Mountain", "Donuts", "Beetle", "Heisenberg", "Romeo", "Buttercup", "Queenie", "Daria", "Dreamey", "Rockette", "Dracula", "Cheddar"};

        randomNum = Random.Range(0, randomName.Length);

        foreach (int number in usedNames)
        {
            if (number == randomNum)
            {
                used = true;
                break;
            }
        }

        if (used) return RandomName();

        usedNames.Add(randomNum);
        return randomName[randomNum];
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerPlace = place;

            if (playerPlace == 1)
            {
                placesText1.text = PlayerPrefs.GetString("Player Name");
                placesText2.text = RandomName();
                placesText3.text = RandomName();
            }

            else if (playerPlace == 2)
            {
                placesText1.text = RandomName();
                placesText2.text = PlayerPrefs.GetString("Player Name");
                placesText3.text = RandomName();
            }

            else if (playerPlace == 3)
            {
                placesText1.text = RandomName();
                placesText2.text = RandomName();
                placesText3.text = PlayerPrefs.GetString("Player Name");
            }

            else
            {
                placesText1.text = RandomName();
                placesText2.text = RandomName();
                placesText3.text = RandomName();
            }

            totalCoin = PlayerPrefs.GetInt("Total Coin");
            mainCoinText.text = totalCoin.ToString("F0");
            endCanvas.enabled = true;
            LeanTween.scale(endCanvas.gameObject, new Vector3(1f, 1f, 1f), 0.2f).setEase(LeanTweenType.easeOutBounce);

            gameEnded = true;

            mainMenu.StopGame();
        }
    }

    public void SetPlace()
    {
        place++;
    }

    public void ContinueButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void CollectButton()
    {
        if (SaveScore.getCoin() > 0)
        {
            LeanTween.scale(collectButton, new Vector3(1.5f, 1.5f, 1.5f), 0.1f).setOnComplete(ScaleButton);

            foreach (GameObject coin in animationCoins)
            {

                LeanTween.scale(coin, new Vector3(1f, 1f, 1f), 0.1f).setOnComplete(MoveCoin);


                LeanTween.move(coin, mainCoin.transform.position, 0.5f).setOnComplete(IncreaseCoin);
                //d = LeanTween.descr(id);
            }
        }

        else
        {
            LeanTween.scale(collectButton, new Vector3(1.5f, 1.5f, 1.5f), 0.1f).setOnComplete(ScaleButton);
        }
        //if (d != null)

        //{
        //    d.setOnComplete(IncreaseCoin);
        //}

    }
    public void IncreaseCoin()
    {
        totalCoin = PlayerPrefs.GetInt("Total Coin");

        if (playerPlace == 1)
        {
            totalCoin += SaveScore.getCoin() * 4;
        }

        else if (playerPlace == 2)
        {
            totalCoin += SaveScore.getCoin() * 3;
        }

        else if (playerPlace == 3)
        {
            totalCoin += SaveScore.getCoin() * 2;
        }

        else
        {
            totalCoin += SaveScore.getCoin();
        }

        coinHandler.ResetCoin();
        PlayerPrefs.SetInt("Total Coin", totalCoin);
        mainCoinText.text = totalCoin.ToString("F0");
    }
    public void MoveCoin()
    {
        foreach (GameObject coin in animationCoins)
        {
            LeanTween.move(coin, mainCoin.transform.position, 0.5f).setDestroyOnComplete(coin);

        }
    }
    public void ScaleButton()
    {
        LeanTween.scale(collectButton, new Vector3(2f, 2f, 2f), 0.1f).setDestroyOnComplete(collectButton);
        continueButton.SetActive(true);
    }
    public void ingameBacktoMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
