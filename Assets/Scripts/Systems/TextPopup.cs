using UnityEngine;

public class TextPopup : MonoBehaviour
{
    [SerializeField] private bool isBigText;
    [SerializeField] private float seconds;
    [SerializeField] private string text;
    public delegate void TextPopupDelegate(float seconds, string text);
    public static TextPopupDelegate textPopup;
    public delegate void BigTextPopupDelegate(float seconds, string text);
    public static BigTextPopupDelegate bigTextPopup;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log(text);
            
            if (isBigText)
            {
                bigTextPopup.Invoke(seconds, text);
                Destroy(gameObject);
            }
            else
            {
                textPopup.Invoke(seconds, text);
            }
        }
    }
}
