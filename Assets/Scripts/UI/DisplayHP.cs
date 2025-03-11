using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHP : MonoBehaviour
{
    Slider HpSlider;

    public static Action<int> OnHpChanged;

    private void Awake()
    {
        HpSlider = GetComponentInChildren<Slider>();

        OnHpChanged += UpdateHP;
    }

    void Start()
    {
        HpSlider.maxValue = ResourceManager.Instance.maxHp;
        HpSlider.value = HpSlider.maxValue;
    }

    private void UpdateHP(int newHp)
    {
        HpSlider.value = newHp;
    }

    private void OnDestroy()
    {
        OnHpChanged -= UpdateHP;
    }
}
