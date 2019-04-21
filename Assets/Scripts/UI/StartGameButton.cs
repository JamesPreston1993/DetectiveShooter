using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadScene("Game");
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
