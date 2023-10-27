using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverUi : MonoBehaviour
{
    [Header("���� ����")]
    [SerializeField] GameObject moneyP;
    [SerializeField] GameObject stressP;
    [SerializeField] GameObject loveP;
    [SerializeField] GameObject bloodP;

    [Header("������ ����")]
    [SerializeField] GameObject moneyN;
    [SerializeField] GameObject stressN;
    [SerializeField] GameObject loveN;
    [SerializeField] GameObject bloodN;

    [Header("���� UI")]
    [SerializeField] HoverChangeUi moneyChange;
    [SerializeField] HoverChangeUi stressChange;
    [SerializeField] HoverChangeUi loveChange;
    [SerializeField] HoverChangeUi bloodChange;

    
}
