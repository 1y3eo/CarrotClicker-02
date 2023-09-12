using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarrotManager : MonoBehaviour
{
    public static CarrotManager instance;

    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI carrotsText;

    [Header(" Data ")]
    [SerializeField] private double totalCarrotCount;
    [SerializeField] private int FrenzyModeMultiplier;
    private int carrotIncrement;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);

        LoadData();

        carrotIncrement = 1;

        InputManager.onCarrotClicked += CarrotClickedCallback;

        Carrot.onFrenzyModeStarted += FrenzyModeStartedCallback;
        Carrot.onFrenzyModeStopped += FrenzyModeStoppedCallback;

    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;

        Carrot.onFrenzyModeStarted -= FrenzyModeStartedCallback;
        Carrot.onFrenzyModeStopped -= FrenzyModeStoppedCallback;
    }
    void Start()
    {
        AddCarrots(5000);
    }

    void Update()
    {
        
    }

    public bool TryPurchase(double price)
    {
        if (price <= totalCarrotCount)
        {
            totalCarrotCount -= price;
            return true;
        }
        return false;
    }

    public void AddCarrots(double value)
    {
        totalCarrotCount += value;

        UpdateCarrotsText();

        SaveData();
    }

    public void AddCarrots(float value)
    {
        totalCarrotCount += value;

        UpdateCarrotsText();

        SaveData();
    }

    private void CarrotClickedCallback()
    {

        UpdateCarrotsText();

        SaveData();
    }

    private void UpdateCarrotsText()
    {
        carrotsText.text = totalCarrotCount.ToString("F0") + " Carrots!";
    }

    private void FrenzyModeStartedCallback()
    {
        carrotIncrement = FrenzyModeMultiplier;
    }

    private void FrenzyModeStoppedCallback()
    {
        carrotIncrement = 1;
    }

    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotCount.ToString());
    }

    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotCount);

        UpdateCarrotsText();
    }

    public int GetCurrentMultiplier()
    {
        return carrotIncrement;
    }
}
