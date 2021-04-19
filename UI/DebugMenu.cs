using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugMenu : MonoBehaviour
{
    private static DebugMenu _instance;

    public static DebugMenu Instance
    {
        get { return _instance; }
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(this.gameObject);

        cameraOffset = Camera.main.GetComponent<CameraFollow>().GetCameraOffset();

        Initialize();
    }

    void Initialize()
    {
        cameraOffsetInitial = cameraOffset;

        spawnObjectMinCountdownInitial = spawnObjectMinCountdown;
        spawnObjectMaxCountdownInitial = spawnObjectMaxCountdown;
        spawnObjectMinNumberInitial = spawnObjectMinNumber;
        spawnObjectMaxNumberInitial = spawnObjectMaxNumber;

        minSpeedInitial = minSpeed;
        maxSpeedInitial = maxSpeed;

        AICountInitial = AICount;
        AISpeedInitial = AISpeed;

        coinAmountInitial = coinAmount;

        playerSpeedInitial = playerSpeed;
        turningSpeedInitial = turningSpeed;

        wizardHatPriceInitial = wizardHatPrice;
        topHatPriceInitial = topHatPrice;
        cowboyHatPriceInitial = cowboyHatPrice;
        pirateHatPriceInitial = pirateHatPrice;
    }

    #region Shop Materials
    [Header("Shop Materials")]
    [SerializeField] int wizardHatPrice;
    [SerializeField] int topHatPrice;
    [SerializeField] int cowboyHatPrice;
    [SerializeField] int pirateHatPrice;
    int wizardHatPriceInitial;
    int topHatPriceInitial;
    int cowboyHatPriceInitial;
    int pirateHatPriceInitial;
    public int GetWizardHatPrice()
    {
        return wizardHatPrice;
    }
    public int GetTopHatPrice()
    {
        return topHatPrice;
    }
    public int GetCowboyHatPrice()
    {
        return cowboyHatPrice;
    }
    public int GetPirateHatPrice()
    {
        return pirateHatPrice;
    }

    #endregion

    #region Camera Follow
    [Header("Camera Follow")]
    [SerializeField] Vector3 cameraOffset;
    Vector3 cameraOffsetInitial;
    public Vector3 getCameraOffset()
    {
        return cameraOffset;
    }
    #endregion
    #region Object Spawner
    [Header("Object Spawner")]
    [SerializeField] float spawnObjectMinCountdown;
    [SerializeField] float spawnObjectMaxCountdown;
    [SerializeField] int spawnObjectMinNumber;
    [SerializeField] int spawnObjectMaxNumber;
    float spawnObjectMinCountdownInitial;
    float spawnObjectMaxCountdownInitial;
    int spawnObjectMinNumberInitial;
    int spawnObjectMaxNumberInitial;
    public float GetSpawnObjectMinCountdown()
    {
        return spawnObjectMinCountdown;
    }
    public float GetSpawnObjectMaxCountdown()
    {
        return spawnObjectMaxCountdown;
    }
    public int GetSpawnObjectMinNumber()
    {
        return spawnObjectMinNumber;
    }
    public int GetSpawnObjectMaxNumber()
    {
        return spawnObjectMaxNumber;
    }
    #endregion

    #region Throwing Object
    [Header("Throwing Object")]
    [SerializeField] float minSpeed = 25f;
    [SerializeField] float maxSpeed = 350f;
    float minSpeedInitial;
    float maxSpeedInitial;
    public float GetMinSpeed()
    {
        return minSpeed;
    }
    public float GetMaxSpeed()
    {
        return maxSpeed;
    }
    #endregion

    #region Coin Spawn
    [Header("Coin Spawn")]
    [SerializeField] int coinAmount = 25;
    int coinAmountInitial;
    public int GetCoinAmount()
    {
        return coinAmount;
    }
    #endregion

    #region AI Settings
    [Header("AI Settings")]
    [SerializeField] int AICount = 8;
    [SerializeField] float AISpeed = 70f;
    int AICountInitial;
    float AISpeedInitial;
    public int GetAICount()
    {
        return AICount;
    }
    public float GetAISpeed()
    {
        return AISpeed;
    }
    #endregion

    #region  Player Movement
    [Header("Player Movement")]
    [SerializeField] float playerSpeed = 35f;
    [SerializeField] float turningSpeed = 5f;
    float playerSpeedInitial;
    float turningSpeedInitial;

    public float GetPlayerSpeed()
    {
        return playerSpeed;
    }
    public float GetTurningSpeed()
    {
        return turningSpeed;
    }
    #endregion

    public void SetVariables(Vector3 cameraOffset, float spawnObjectMinCountdown, float spawnObjectMaxCountdown, int spawnObjectMinNumber,
    int spawnObjectMaxNumber, float minSpeed, float maxSpeed, int coinAmount, float playerSpeed, float turningSpeed, int AICount, float AISpeed)
    {
        this.cameraOffset = cameraOffset;
        this.spawnObjectMinCountdown = spawnObjectMinCountdown;
        this.spawnObjectMaxCountdown = spawnObjectMaxCountdown;
        this.spawnObjectMinNumber = spawnObjectMinNumber;
        this.spawnObjectMaxNumber = spawnObjectMaxNumber;
        this.minSpeed = minSpeed;
        this.maxSpeed = maxSpeed;
        this.coinAmount = coinAmount;
        this.playerSpeed = playerSpeed;
        this.turningSpeed = turningSpeed;
        this.AICount = AICount;
        this.AISpeed = AISpeed;
    }

    public void ResetVariables()
    {
        cameraOffset = cameraOffsetInitial;
        spawnObjectMinCountdown = spawnObjectMinCountdownInitial;
        spawnObjectMaxCountdown = spawnObjectMaxCountdownInitial;
        spawnObjectMinNumber = spawnObjectMinNumberInitial;
        spawnObjectMaxNumber = spawnObjectMaxNumberInitial;
        minSpeed = minSpeedInitial;
        maxSpeed = maxSpeedInitial;
        coinAmount = coinAmountInitial;
        playerSpeed = playerSpeedInitial;
        turningSpeed = turningSpeedInitial;
        AICount = AICountInitial;
        AISpeed = AISpeedInitial;
    }
}
