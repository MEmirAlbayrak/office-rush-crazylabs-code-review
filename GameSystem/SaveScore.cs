using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SaveScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI coinCounterText;
    [SerializeField] ShopCanvasScript shopCanvas;
    static int coinCounter = 0;
    [HideInInspector] public int id;
    [HideInInspector] public LTDescr d;
    void Start()
    {
        coinCounterText.text = coinCounter.ToString("0");

        switch (PlayerPrefs.GetString("Hat"))
        {
            case "WizardHat":
                shopCanvas.PutOnWizardHat();
                break;

            case "CowboyHat":
                shopCanvas.PutOnCowboyHat();
                break;

            case "PirateHat":
                shopCanvas.PutOnPirateHat();
                break;

            case "TopHat":
                shopCanvas.PutOnTopHat();
                break;

            default:
                break;
        }
    }
    public static int getCoin()
    {
        return coinCounter;
    }
    public void ResetCoin()
    {
        coinCounter = 0;
        coinCounterText.text = coinCounter.ToString("F0");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {

            LeanTween.scale(coinCounterText.gameObject, new Vector3(1, 1.5f, 2), 0.15f).setEase(LeanTweenType.easeSpring);
            id = LeanTween.scale(coinCounterText.gameObject, new Vector3(1, 2, 2), 0.15f).setEase(LeanTweenType.easeSpring).id;
            d = LeanTween.descr(id);

            if (d != null)

            {
                d.setOnComplete(UIAnimationHandler);
            }
            Destroy(other.gameObject);
            coinCounter += 5;

            coinCounterText.text = coinCounter.ToString("0");
        }
    }

    void UIAnimationHandler()
    {
        LeanTween.scale(coinCounterText.gameObject, new Vector3(1, 1f, 1), 0.15f).setEase(LeanTweenType.easeSpring);
    }
}
