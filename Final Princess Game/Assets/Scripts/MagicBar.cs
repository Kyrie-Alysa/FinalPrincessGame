using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{

    public Slider slider;
    private static int potionAmount;
    private int curPotionAmount = 0;

    public void SetMaxMagic(int magic)
    {
        slider.maxValue = magic;
        slider.value = magic;

    }

    public void SetMagic(int magic)
    {
        slider.value = magic;
    }

    public void Update() {
        potionAmount = PlayerManager.potionCount;
        int potionDif = potionAmount - curPotionAmount;
        if (potionDif == 2) 
        {
            SetMagic(100);
            curPotionAmount = 1;
        }
    }

}
