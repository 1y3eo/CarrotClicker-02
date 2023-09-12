using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UpgradeButton : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI subtitleText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button button;

    public void Configure(Sprite icon, string title, string subtitle, string price)
    {
        iconImage.sprite = icon;
        titleText.text = title;
        subtitleText.text = subtitle;
        priceText.text = price;
    }
}
