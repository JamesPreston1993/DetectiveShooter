using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI buttonText;

    void Awake()
    {
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        buttonText.SetText("Ready?");
    }

    public void OnClick()
    {
        Debug.Log("Clicked");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.SetText("Ready!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.SetText("Ready?");
    }
}
