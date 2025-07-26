using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class TextDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI DisplayText;
    [SerializeField] private TextMeshProUGUI BigDisplayText;
    private float timer;
    private float bigTimer;
    private void Start()
    {
        //Subscribe to events
        TextPopup.textPopup += DisplayTextFunction;
        TextPopup.bigTextPopup += BigDisplayTextFunction;
        DisplayText.gameObject.SetActive(false);
        BigDisplayText.gameObject.SetActive(false);
        PlayerCheckPoint.displayCheckPointName += BigDisplayTextFunction;
    }
    private void Update()
    {
        if(timer >= 0)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                DisplayText.gameObject.SetActive(false);
            }
        }
        if(bigTimer >= 0)
        {
            bigTimer -= Time.deltaTime;
            if(bigTimer <= 0)
            {
                BigDisplayText.gameObject.SetActive(false);
            }
        }

    }
    private void DisplayTextFunction(float seconds, string text)
    {
        DisplayText.gameObject.SetActive(true);
        timer = seconds;
        DisplayText.text = text;
    }
    private void BigDisplayTextFunction(float seconds, string text)
    {
        BigDisplayText.gameObject.SetActive(true);
        bigTimer = seconds;
        BigDisplayText.text = text;
    }
}
