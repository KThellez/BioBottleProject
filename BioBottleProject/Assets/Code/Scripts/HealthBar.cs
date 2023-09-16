using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour{

    private Slider slider;

    private void Start(){
        slider = GetComponent<Slider>();
    }

    public void ChangeMaxHealth(float maxHealth){
        slider.maxValue = maxHealth;
    }

    public void ChangeCurrentHealt(float healthAmount){
        slider.value = healthAmount;
    }

    public void InitializeHealthBar(float healthAmount){
        ChangeMaxHealth(healthAmount);
        ChangeCurrentHealt(healthAmount);
    }
}