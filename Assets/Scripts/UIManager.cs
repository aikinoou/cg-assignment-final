using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    private void Awake()
    {
        instance = this;
    }
    
    [SerializeField] TMP_Text interactText;

    public void EnableInteractText(string text)
    {
        interactText.text = text + " (E)";
        interactText.gameObject.SetActive(true);
    }

    public void DisableInteractText()
    {
        interactText.gameObject.SetActive(false);
    }
}
