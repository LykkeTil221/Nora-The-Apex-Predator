using UnityEngine;
using UnityEngine.UI;

public class UIPlayerEnergy : MonoBehaviour
{
    public Slider Slider;
    public GameObject UIEnergyBar;
    private float timer;
    [SerializeField] private float timeBeforeWheelDissapears;

    private void Start()
    {
        timer = timeBeforeWheelDissapears;
    }
    private void Update()
    {
        if(Slider.value == Slider.maxValue)
        {
            if(timer > 0) timer -= Time.deltaTime;
            if(timer <= 0)
            {
                UIEnergyBar.gameObject.SetActive(false);
            }
        }
    }
    public void SetMaxEnergy(float energy)
    {
        Slider.maxValue = energy;
        Slider.value = energy;
        UIEnergyBar.gameObject.SetActive(true);
        timer = timeBeforeWheelDissapears;
    }
    public void SetEnergy(float Energy)
    {
        Slider.value = Energy;
        UIEnergyBar.gameObject.SetActive(true);
        UIEnergyBar.gameObject.SetActive(true);
        timer = timeBeforeWheelDissapears;
    }
}
