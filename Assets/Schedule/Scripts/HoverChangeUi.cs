using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HoverChangeUi : MonoBehaviour
{
    [Header("≈ÿΩ∫∆ÆUI")]
    [SerializeField]Text beforeTxt;
    [SerializeField]Text afterTxt;

    public void Init(bool changePositive, float changeBefore, float chagneAfter)
    {        
        Color afterColor;
        if (changePositive) afterColor = Color.green;
        else afterColor = Color.red;

        beforeTxt.text = changeBefore.ToString();
        afterTxt.text = chagneAfter.ToString();
        afterTxt.color = afterColor;
    }
}
