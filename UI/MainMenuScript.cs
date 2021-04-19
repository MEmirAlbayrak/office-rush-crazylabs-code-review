using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] Image maincv;
    [SerializeField] Image shopCv;
    [SerializeField] Image inGameCv;
    [SerializeField] Image debugCv;
    [SerializeField] Image titleImage;
    ShopCanvasScript shopCanvasScript;

    [SerializeField] PlayerMovement playerMovement;
    [SerializeField] Transform AIS;
    [SerializeField] SpawnObject objectSpawner;
    [SerializeField] Transform[] AISpawnPoints;
    int AICount;
    [SerializeField] GameObject AIPrefab;
    [SerializeField] Transform spawnParent;
    [SerializeField] TextMeshProUGUI mainCoinText;
    [SerializeField] GameObject tutorial;
    [SerializeField] TMP_InputField playerNameInput;
    [SerializeField] TextMeshProUGUI nameError;
    int totalCoin;
    void Start()
    {
        if (PlayerPrefs.GetString("Player Name") != "") playerNameInput.text = PlayerPrefs.GetString("Player Name");
        tutorial.SetActive(false);
        PlayerPrefs.Save();
        AICount = DebugMenu.Instance.GetAICount();
        totalCoin = PlayerPrefs.GetInt("Total Coin");
        mainCoinText.text = totalCoin.ToString("F0");
        ScaleUpTitle();
        if (AICount > 8) AICount = 8;

        shopCanvasScript = shopCv.transform.parent.GetComponent<ShopCanvasScript>();
        ScaleDownIngame();
        ScaleDownShop();
        ScaleDownDebug();

        for (int i = 0; i < AICount; i++)
        {
            Instantiate(AIPrefab, AISpawnPoints[i].position, AIPrefab.transform.rotation, AIS);
        }

        StopGame();
    }

    public void PlayButton()
    {
        if (playerNameInput.text != "")
        {
            PlayerPrefs.SetString("Player Name", playerNameInput.text);

            ScaleUpIngame();
            ScaleDownMain();

            StartGame();
        }

        else nameError.gameObject.SetActive(true);
    }


    public void StartGame()
    {
        playerMovement.enabled = true;
        objectSpawner.enabled = true;

        foreach (Transform Ai in AIS)
        {
            AI ai = Ai.GetComponent<AI>();
            if (ai != null) ai.enabled = true;
        }

        tutorial.SetActive(true);
    }

    public void StopGame()
    {
        playerMovement.enabled = false;
        objectSpawner.enabled = false;

        foreach (Transform objects in spawnParent)
        {
            Destroy(objects.gameObject);
        }

        foreach (Transform Ai in AIS)
        {
            AI ai = Ai.GetComponent<AI>();
            if (ai != null) ai.enabled = false;
        }
    }
    public void ShopButton()
    {
        shopCanvasScript.SetShopMaterials();
        ScaleDownMain();
        ScaleUpShop();
    }
    public void BackButton()
    {
        ScaleDownShop();
        ScaleUpTitle();
        totalCoin = PlayerPrefs.GetInt("Total Coin");
        mainCoinText.text = totalCoin.ToString("F0");
    }

    public void DebugbButton()
    {
        debugCv.transform.parent.GetComponent<DebugMenuCanvas>().setFields();

        ScaleUpDebug();
        ScaleDownMain();
    }
    void ScaleDownMain()
    {
        LeanTween.scale(maincv.gameObject, new Vector3(0f, 0f, 0f), 0.1f).setOnComplete(ScaleDownTitle);

    }
    void ScaleUpMain()
    {
        LeanTween.scale(maincv.gameObject, new Vector3(1f, 1f, 1f), 0.3f).setEase(LeanTweenType.easeOutElastic);

    }
    void ScaleDownShop()
    {
        LeanTween.scale(shopCv.gameObject, new Vector3(0f, 0f, 0f), 0.1f).setEase(LeanTweenType.easeOutElastic);
    }
    void ScaleUpShop()
    {
        LeanTween.scale(shopCv.gameObject, new Vector3(1f, 1f, 1f), 0.7f).setEase(LeanTweenType.easeOutElastic);
    }
    void ScaleUpIngame()
    {
        LeanTween.scale(inGameCv.gameObject, new Vector3(1f, 1f, 1f), 0.3f).setEase(LeanTweenType.easeOutBounce);

    }
    void ScaleDownIngame()
    {
        LeanTween.scale(inGameCv.gameObject, new Vector3(0f, 0f, 0f), 0f).setEase(LeanTweenType.easeOutBounce);
    }
    void ScaleDownDebug()
    {
        LeanTween.scale(debugCv.gameObject, new Vector3(0f, 0f, 0f), 0f);
    }
    void ScaleUpDebug()
    {
        LeanTween.scale(debugCv.gameObject, new Vector3(0.4864f, 0.4864f, 0.4864f), 0.7f).setEase(LeanTweenType.easeOutBounce);
    }
    void ScaleUpTitle()
    {
        LeanTween.scale(titleImage.gameObject, new Vector3(1f, 1f, 1f), 0.1f).setEase(LeanTweenType.easeOutBounce).setOnComplete(ScaleUpMain);
    }
    void ScaleDownTitle()
    {
        LeanTween.scale(titleImage.gameObject, new Vector3(0f, 0f, 0f), 0f);
    }

}
