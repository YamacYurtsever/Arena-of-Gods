using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot_Cooldown : MonoBehaviour
{
    public Slider slider; 

    public void SetCooldown(float cooldown)
    {
        slider.maxValue = cooldown;
        slider.value = cooldown;
    }

    public void SetTime(float time)
    {
        slider.value = time;
    }
}
