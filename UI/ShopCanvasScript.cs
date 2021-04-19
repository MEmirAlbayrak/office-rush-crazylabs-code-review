using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopCanvasScript : MonoBehaviour
{
    [SerializeField] Transform hatPosition;
    [SerializeField] GameObject wizardHatPrefab;
    [SerializeField] GameObject cowboyHatPrefab;
    [SerializeField] GameObject pirateHatPrefab;
    [SerializeField] GameObject topHatPrefab;
    [SerializeField] Image wizardHat;
    [SerializeField] Button wizardHatBuy;
    [SerializeField] Image cowboyHat;
    [SerializeField] Button cowboyHatBuy;
    [SerializeField] Image pirateHat;
    [SerializeField] Button pirateHatBuy;
    [SerializeField] Image topHat;
    [SerializeField] Button topHatBuy;
    [SerializeField] Sprite use, used;
    [SerializeField] TextMeshProUGUI mainCoinText;
   
  
    public void SetShopMaterials()
    {
        DebugMenu variables = DebugMenu.Instance;
       int currentCoin = PlayerPrefs.GetInt("Total Coin");

        mainCoinText.text = currentCoin.ToString("F0");
        if (PlayerPrefs.GetString("Hat") == "WizardHat")
        {
            wizardHat.gameObject.SetActive(false);
            wizardHatBuy.interactable = false;
            wizardHatBuy.image.sprite = used;
        }

        else if (PlayerPrefs.GetInt("WizardHat") == 1)
        {
            wizardHat.gameObject.SetActive(false);
            wizardHatBuy.interactable = true;
            wizardHatBuy.image.sprite = use;
        }

        else if (currentCoin < variables.GetWizardHatPrice()) wizardHatBuy.interactable = false;

        if (PlayerPrefs.GetString("Hat") == "CowboyHat")
        {
            cowboyHat.gameObject.SetActive(false);
            cowboyHatBuy.interactable = false;
            cowboyHatBuy.image.sprite = used;
        }

        else if (PlayerPrefs.GetInt("CowboyHat") == 1)
        {
            cowboyHat.gameObject.SetActive(false);
            cowboyHatBuy.interactable = true;
            cowboyHatBuy.image.sprite = use;
        }

        else if (currentCoin < variables.GetCowboyHatPrice()) cowboyHatBuy.interactable = false;

        if (PlayerPrefs.GetString("Hat") == "PirateHat")
        {
            pirateHat.gameObject.SetActive(false);
            pirateHatBuy.interactable = false;
            pirateHatBuy.image.sprite = used;
        }

        else if (PlayerPrefs.GetInt("PirateHat") == 1)
        {
            pirateHat.gameObject.SetActive(false);
            pirateHatBuy.interactable = true;
            pirateHatBuy.image.sprite = use;
        }

        else if (currentCoin < variables.GetPirateHatPrice()) pirateHatBuy.interactable = false;

        if (PlayerPrefs.GetString("Hat") == "TopHat")
        {
            topHat.gameObject.SetActive(false);
            topHatBuy.interactable = false;
            topHatBuy.image.sprite = used;
        }

        else if (PlayerPrefs.GetInt("TopHat") == 1)
        {
            topHat.gameObject.SetActive(false);
            topHatBuy.interactable = true;
            topHatBuy.image.sprite = use;
        }

        else if (currentCoin < variables.GetTopHatPrice()) topHatBuy.interactable = false;
    }

    public void WizardHatButton()
    {
        if (wizardHatBuy.image.sprite == use)
        {
            PutOnWizardHat();
            SetShopMaterials();
        }

        else
        {
            BuyWizardHat();
        }
    }

    public void CowboyHatButton()
    {
        if (cowboyHatBuy.image.sprite == use)
        {
            PutOnCowboyHat();
            SetShopMaterials();
        }

        else
        {
            BuyCowboyHat();
        }
    }

    public void PirateHatButton()
    {
        if (pirateHatBuy.image.sprite == use)
        {
            PutOnPirateHat();
            SetShopMaterials();
        }

        else
        {
            BuyPirateHat();
        }
    }

    public void TopHatButton()
    {
        if (topHatBuy.image.sprite == use)
        {
            PutOnTopHat();
            SetShopMaterials();
        }

        else
        {
            BuyTopHat();
        }
    }

    public void PutOnWizardHat()
    {
        foreach (Transform child in hatPosition)
        {
            Destroy(child.gameObject);
        }

        Instantiate(wizardHatPrefab, hatPosition);

        PlayerPrefs.SetString("Hat", "WizardHat");
    }
    public void PutOnCowboyHat()
    {
        foreach (Transform child in hatPosition)
        {
            Destroy(child.gameObject);
        }

        Instantiate(cowboyHatPrefab, hatPosition);

        PlayerPrefs.SetString("Hat", "CowboyHat");
    }
    public void PutOnPirateHat()
    {
        foreach (Transform child in hatPosition)
        {
            Destroy(child.gameObject);
        }

        Instantiate(pirateHatPrefab, hatPosition);

        PlayerPrefs.SetString("Hat", "PirateHat");
    }
    public void PutOnTopHat()
    {
        foreach (Transform child in hatPosition)
        {
            Destroy(child.gameObject);
        }

        Instantiate(topHatPrefab, hatPosition);

        PlayerPrefs.SetString("Hat", "TopHat");
    }

    void BuyWizardHat()
    {
        PlayerPrefs.SetInt("WizardHat", 1);

        PlayerPrefs.SetInt("Total Coin", PlayerPrefs.GetInt("Total Coin") - DebugMenu.Instance.GetWizardHatPrice());

        SetShopMaterials();
    }
    void BuyCowboyHat()
    {
        PlayerPrefs.SetInt("CowboyHat", 1);

        PlayerPrefs.SetInt("Total Coin", PlayerPrefs.GetInt("Total Coin") - DebugMenu.Instance.GetCowboyHatPrice());

        SetShopMaterials();
    }
    void BuyPirateHat()
    {
        PlayerPrefs.SetInt("PirateHat", 1);

        PlayerPrefs.SetInt("Total Coin", PlayerPrefs.GetInt("Total Coin") - DebugMenu.Instance.GetPirateHatPrice());

        SetShopMaterials();
    }
    void BuyTopHat()
    {
        PlayerPrefs.SetInt("TopHat", 1);

        PlayerPrefs.SetInt("Total Coin", PlayerPrefs.GetInt("Total Coin") - DebugMenu.Instance.GetTopHatPrice());

        SetShopMaterials();
    }

}
