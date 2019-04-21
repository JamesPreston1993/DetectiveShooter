using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class StartGameButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private TextMeshProUGUI buttonText;
    private string initaltextValue;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.None;
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        initaltextValue = buttonText.text;
        buttonText.SetText(initaltextValue + "?");
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonText.SetText(initaltextValue + "!");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonText.SetText(initaltextValue + "?");
    }
}
