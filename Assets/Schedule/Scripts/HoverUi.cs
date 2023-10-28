using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverUi : MonoBehaviour
{
    [Header("이익 문구")]
    [SerializeField] GameObject moneyP;
    [SerializeField] GameObject stressP;
    [SerializeField] GameObject loveP;
    [SerializeField] GameObject bloodP;

    [Header("불이익 문구")]
    [SerializeField] GameObject moneyN;
    [SerializeField] GameObject stressN;
    [SerializeField] GameObject loveN;
    [SerializeField] GameObject bloodN;

    [Header("변경 UI")]
    [SerializeField] HoverChangeUi moneyChange;
    [SerializeField] HoverChangeUi stressChange;
    [SerializeField] HoverChangeUi loveChange;
    [SerializeField] HoverChangeUi bloodChange;

    public void Init(int momeyChangeAmount, int stressChangeAmount, int loveChangeAmount, float bloodChangeAmount)
    {
        Debug.Log(name + " init");

        int CurrentMoney = ScheduleResources.Instance.CurrMoney;
        float CurrentStress = ScheduleResources.Instance.CurrStress;
        float CurrentLove = ScheduleResources.Instance.CurrLove;
        float CurrentBlood = ScheduleResources.Instance.CurrBlood;

        // 증감 문구 토글 (변화가 없는 경우 끄기)
        {
            bool isMoneyChage = (momeyChangeAmount == 0); // 값 변화가 있는가?
            bool moneyChangePositive = (momeyChangeAmount > 0);
            moneyP.SetActive(isMoneyChage);
            moneyN.SetActive(isMoneyChage);
            moneyChange.gameObject.SetActive(isMoneyChage);
            if (isMoneyChage) moneyChange.Init(moneyChangePositive, CurrentMoney, momeyChangeAmount); // 변화량 문구 초기화

            bool isStressChange = (stressChangeAmount == 0);
            bool stressChangePositive = (stressChangeAmount > 0);
            moneyP.SetActive(isStressChange);
            moneyN.SetActive(isStressChange);
            moneyChange.gameObject.SetActive(isStressChange);
            if (isStressChange) moneyChange.Init(stressChangePositive, CurrentStress, stressChangeAmount);

            bool isLoveChange = (loveChangeAmount == 0);
            bool loveChangePositive = (loveChangeAmount > 0);
            moneyP.SetActive(isLoveChange);
            moneyN.SetActive(isLoveChange);
            moneyChange.gameObject.SetActive(isLoveChange);
            if (isLoveChange) moneyChange.Init(loveChangePositive, CurrentLove, loveChangeAmount);

            bool isBloodChange = (bloodChangeAmount == 0);
            bool bloodChangePositive = (stressChangeAmount < 0);
            moneyP.SetActive(isBloodChange);
            moneyN.SetActive(isBloodChange);
            moneyChange.gameObject.SetActive(isBloodChange);
            if (isBloodChange) moneyChange.Init(bloodChangePositive, CurrentBlood, bloodChangeAmount);

        }
    }
}
