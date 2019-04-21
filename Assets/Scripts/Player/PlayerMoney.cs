using TMPro;
using UnityEngine;

public class PlayerMoney : MonoBehaviour
{
    public TextMeshProUGUI moneyUi;
    private int collectedMoney;

    void Awake()
    {
        MoneyManager.Instance.Money = collectedMoney;
    }

    void Update()
    {
        moneyUi.SetText("Money: ${0}", collectedMoney);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            collectedMoney += 50;
            MoneyManager.Instance.Money = collectedMoney;
            Destroy(other.gameObject);
        }
    }
}
