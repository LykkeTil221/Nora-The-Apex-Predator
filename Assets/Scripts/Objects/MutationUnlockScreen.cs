using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class MutationUnlockScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI MutationNameDisplay;
    [SerializeField] private TextMeshProUGUI MutationDescription;
    [SerializeField] private Image MutationIcon;
    [SerializeField] private GameObject mutationUnlockScreen;
    [SerializeField] private MUnlockData[] unlockDatas;

    private void Start()
    {
        PlayerUnlockManager.UnlockMuationScreenActivate += ActivateMutationUnlockScreen;
        PlayerStateManager.CloseUnlockScreen += CloseMenu;
    }
    public void ActivateMutationUnlockScreen(int number)
    {
        mutationUnlockScreen.SetActive(true);
        MutationNameDisplay.text = unlockDatas[number].name;
        MutationDescription.text = unlockDatas[number].mutationDescription;
        MutationIcon.sprite = unlockDatas[number].mutationIcon;

        Time.timeScale = 0;
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;
        mutationUnlockScreen.SetActive(false);
    }

    private void OnDisable()
    {
        PlayerStateManager.CloseUnlockScreen -= CloseMenu;
        PlayerUnlockManager.UnlockMuationScreenActivate -= ActivateMutationUnlockScreen;
    }
}
