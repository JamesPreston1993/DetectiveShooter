using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyTextDeathScreen : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().SetText("You collected:\n${0}", MoneyManager.Instance.Money);
    }
}
