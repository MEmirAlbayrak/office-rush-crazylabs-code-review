using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DebugMenuCanvas : MonoBehaviour
{
    DebugMenu variables;
    [Header("AI Settings")]
    [SerializeField] TMP_InputField AICount;
    [SerializeField] Slider AICountSlider;
    [SerializeField] TMP_InputField AISpeed;
    [SerializeField] Slider AISpeedSlider;

    [Header("Camera Offset")]
    [SerializeField] TMP_InputField cameraOffsetX;
    [SerializeField] TMP_InputField cameraOffsetY;
    [SerializeField] TMP_InputField cameraOffsetZ;

    [Header("Object Spawner")]
    [SerializeField] TMP_InputField minCountdown;
    [SerializeField] TMP_InputField maxCountdown;
    [SerializeField] TMP_InputField minObject;
    [SerializeField] TMP_InputField maxObject;
    [SerializeField] Slider minCountdownSlider;
    [SerializeField] Slider maxCountdownSlider;
    [SerializeField] Slider minObjectSlider;
    [SerializeField] Slider maxObjectSlider;

    [Header("Throwing Objects")]
    [SerializeField] TMP_InputField throwingObjectMinSpeed;
    [SerializeField] TMP_InputField throwingObjectMaxSpeed;
    [SerializeField] Slider throwingObjectMinSpeedSlider;
    [SerializeField] Slider throwingObjectMaxSpeedSlider;

    [Header("Player Movement")]
    [SerializeField] TMP_InputField playerSpeed;
    [SerializeField] TMP_InputField turningSpeed;
    [SerializeField] Slider playerSpeedSlider;
    [SerializeField] Slider turningSpeedSlider;

    [Header("Coin Spawning")]
    [SerializeField] TMP_InputField coinAmount;
    [SerializeField] Slider coinAmountSlider;
    [SerializeField] TextMeshProUGUI mainCoin;

    private void Start()
    {
        variables = DebugMenu.Instance;

        setFields();

        this.enabled = false;
    }

    public void setFields()
    {
        this.enabled = true;

        mainCoin.text = PlayerPrefs.GetInt("Total Coin").ToString("F0");

        Vector3 cameraOffset = variables.getCameraOffset();

        float initialMinCountdown = variables.GetSpawnObjectMinCountdown();
        float initialMaxCountdown = variables.GetSpawnObjectMaxCountdown();
        int initialMinObject = variables.GetSpawnObjectMinNumber();
        int initialMaxObject = variables.GetSpawnObjectMaxNumber();

        float initialThrowingObjectMinSpeed = variables.GetMinSpeed();
        float initialThrowingObjectMaxSpeed = variables.GetMaxSpeed();

        float initialPlayerSpeed = variables.GetPlayerSpeed();
        float initialTurningSpeed = variables.GetTurningSpeed();

        int initialCoinAmount = variables.GetCoinAmount();

        int initialAICount = variables.GetAICount();
        float initialAISpeed = variables.GetAISpeed();

        //*******************************************************************************\\

        this.cameraOffsetX.text = cameraOffset.x.ToString("F2");
        this.cameraOffsetY.text = cameraOffset.y.ToString("F2");
        this.cameraOffsetZ.text = cameraOffset.z.ToString("F2");

        this.minCountdown.text = initialMinCountdown.ToString("F2");
        this.maxCountdown.text = initialMaxCountdown.ToString("F2");
        this.minObject.text = initialMinObject.ToString("F0");
        this.maxObject.text = initialMaxObject.ToString("F0");

        this.throwingObjectMinSpeed.text = initialThrowingObjectMinSpeed.ToString("F2");
        this.throwingObjectMaxSpeed.text = initialThrowingObjectMaxSpeed.ToString("F2");

        this.playerSpeed.text = initialPlayerSpeed.ToString("F2");
        this.turningSpeed.text = initialTurningSpeed.ToString("F2");

        this.coinAmount.text = initialCoinAmount.ToString("F0");

        this.AICount.text = initialAICount.ToString("F0");
        this.AISpeed.text = initialAISpeed.ToString("F2");

        //*******************************************************************************\\

        minCountdownSlider.value = initialMinCountdown;
        maxCountdownSlider.value = initialMaxCountdown;
        minObjectSlider.value = initialMinObject;
        maxObjectSlider.value = initialMaxObject;

        throwingObjectMinSpeedSlider.value = initialThrowingObjectMinSpeed;
        throwingObjectMaxSpeedSlider.value = initialThrowingObjectMaxSpeed;

        playerSpeedSlider.value = initialPlayerSpeed;
        turningSpeedSlider.value = initialTurningSpeed;

        coinAmountSlider.value = initialCoinAmount;

        AICountSlider.value = initialAICount;
        AISpeedSlider.value = initialAISpeed;
    }

    public void Confirm()
    {
        Vector3 cameraOffset = new Vector3(float.Parse(cameraOffsetX.text), float.Parse(cameraOffsetY.text), float.Parse(cameraOffsetZ.text));

        float minCountdown = float.Parse(this.minCountdown.text);
        float maxCountdown = float.Parse(this.maxCountdown.text);
        int minObject = int.Parse(this.minObject.text);
        int maxObject = int.Parse(this.maxObject.text);

        float throwingObjectMinSpeed = float.Parse(this.throwingObjectMinSpeed.text);
        float throwingObjectMaxSpeed = float.Parse(this.throwingObjectMaxSpeed.text);

        float playerSpeed = float.Parse(this.playerSpeed.text);
        float turningSpeed = float.Parse(this.turningSpeed.text);

        int coinAmount = int.Parse(this.coinAmount.text);

        int aiCount = int.Parse(this.AICount.text);
        float aiSpeed = float.Parse(this.AISpeed.text);

        variables.SetVariables(cameraOffset, minCountdown, maxCountdown, minObject, maxObject, throwingObjectMinSpeed, throwingObjectMaxSpeed, coinAmount, playerSpeed, turningSpeed, aiCount, aiSpeed);

        SceneManager.LoadScene(0);
    }

    public void addCoin()
    {
        PlayerPrefs.SetInt("Total Coin", PlayerPrefs.GetInt("Total Coin") + 50);
        mainCoin.text = PlayerPrefs.GetInt("Total Coin").ToString("F0");
    }

    public void openDebug()
    {
        gameObject.SetActive(true);
    }

    public void ResetVariables()
    {
        variables.ResetVariables();

        PlayerPrefs.DeleteAll();

        setFields();
    }

    private void Update()
    {
        minCountdown.text = minCountdownSlider.value.ToString("F2");
        if (minCountdownSlider.value > maxCountdownSlider.value) maxCountdownSlider.value = minCountdownSlider.value;
        maxCountdown.text = maxCountdownSlider.value.ToString("F2");

        minObject.text = minObjectSlider.value.ToString("F0");
        if (minObjectSlider.value > maxObjectSlider.value) maxObjectSlider.value = minObjectSlider.value;
        maxObject.text = maxObjectSlider.value.ToString("F0");

        throwingObjectMinSpeed.text = throwingObjectMinSpeedSlider.value.ToString("F2");
        if (throwingObjectMinSpeedSlider.value > throwingObjectMaxSpeedSlider.value) throwingObjectMaxSpeedSlider.value = throwingObjectMinSpeedSlider.value;
        throwingObjectMaxSpeed.text = throwingObjectMaxSpeedSlider.value.ToString("F2");

        playerSpeed.text = playerSpeedSlider.value.ToString("F2");
        turningSpeed.text = turningSpeedSlider.value.ToString("F2");

        coinAmount.text = coinAmountSlider.value.ToString("F0");

        AICount.text = AICountSlider.value.ToString("F0");
        AISpeed.text = AISpeedSlider.value.ToString("F2");
    }
}
