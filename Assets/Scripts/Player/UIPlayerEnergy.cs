using UnityEngine;
using UnityEngine.UI;

public class UIPlayerEnergy : MonoBehaviour
{
    public Slider Slider;
    public GameObject UIEnergyBar;
    public GameObject UIEnergyBorder;
    private float timer;
    [SerializeField] private float timeBeforeWheelDissapears;
    [SerializeField] private PlayerEnergy PlayerEnergy;

    private void Start()
    {
        timer = timeBeforeWheelDissapears;
    }
    private void Update()
    {
        if(PlayerEnergy.CurrentPlayerEnergy == PlayerEnergy.MaxPlayerEnergy)
        {
            if(timer > 0) timer -= Time.deltaTime;
            if(timer <= 0)
            {
                UIEnergyBar.gameObject.SetActive(false);
                UIEnergyBorder.SetActive(false);
            }
        }
    }
    public void SetMaxEnergy(float Min,float Max)
    {
        Slider.maxValue = Max;
        Slider.minValue = Min;
        Slider.value = Max;
        UIEnergyBar.gameObject.SetActive(true);
        UIEnergyBorder.SetActive(true);
        timer = timeBeforeWheelDissapears;
    }
    public void SetEnergy(float Energy)
    {
        if (Energy > Slider.maxValue) 
        {
            Slider.value = Slider.maxValue;
        }
        else if (Energy < Slider.minValue)
        {
            Slider.value = Slider.minValue;
        }

        Slider.value = Energy;
        UIEnergyBar.gameObject.SetActive(true);
        UIEnergyBorder.gameObject.SetActive(true);
        timer = timeBeforeWheelDissapears;
    }
}
