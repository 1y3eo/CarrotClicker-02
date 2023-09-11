using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CarrotManager : MonoBehaviour
{

    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI carrotsText;

    [Header(" Data ")]
    [SerializeField] private double totalCarrotCount;
    [SerializeField] private int FrenzyModeMultiplier;
    private int carrotIncrement;

    private void Awake()
    {
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
        
    }

    void Update()
    {
        
    }

    private void CarrotClickedCallback()
    {
        totalCarrotCount += carrotIncrement;

        UpdateCarrotsText();

        SaveData();
    }

    private void UpdateCarrotsText()
    {
        carrotsText.text = totalCarrotCount + " Carrots!";
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
