using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{

    public Slider slider;
    private static int potionAmount;


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
        if (potionAmount == 1) 
        {
            SetMagic(100);
        }
    }
    

}
