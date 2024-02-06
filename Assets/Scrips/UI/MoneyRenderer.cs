using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyRenderer : MonoBehaviour
{
    Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    public void updateMoneyCount(PlayerMoney amount)
    {
        text.text = amount.ToString();
    }
}
