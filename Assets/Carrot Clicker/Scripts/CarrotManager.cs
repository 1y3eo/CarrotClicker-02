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
    [SerializeField] private int carrotIncrement;

    private void Awake()
    {
        LoadData();
        InputManager.onCarrotClicked += CarrotClickedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onCarrotClicked -= CarrotClickedCallback;

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

    private void SaveData()
    {
        PlayerPrefs.SetString("Carrots", totalCarrotCount.ToString());
    }

    private void LoadData()
    {
        double.TryParse(PlayerPrefs.GetString("Carrots"), out totalCarrotCount);

        UpdateCarrotsText();
    }
}
