using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] DataContainer data;
    [SerializeField] TMPro.TextMeshProUGUI coinscountText;

    public void Add(int count)
    {
        data.coins += count;
        coinscountText.text = "Coins:" + data.coins.ToString();
    }
}
