using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultUi : MonoBehaviour
{
    [SerializeField] Text day;

    [SerializeField] Text bloodBefore;
    [SerializeField] Text bloodAfter;
    [SerializeField] Text LoveBefore;
    [SerializeField] Text LoveAfter;
    [SerializeField] Text StressBefore;
    [SerializeField] Text StressAfter;
    [SerializeField] Text MoneyBefore;
    [SerializeField] Text MoneyAfter;

    [SerializeField] Text income;
    [SerializeField] Text consum;
    [SerializeField] Text profit;

    [SerializeField] Text loveNeed;
    [SerializeField] Text bloodNeed;
    [SerializeField] Image loveGage;
    [SerializeField] Image bloodGage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        UpdateUi();
    }

    void UpdateUi()
    {
        float currBlood = ScheduleResources.Instance.CurrBlood;
        float currStress = ScheduleResources.Instance.CurrStress;
        float currLove = ScheduleResources.Instance.CurrLove;
        int currMoney = ScheduleResources.Instance.CurrMoney;

        float adjustBlood = ScheduleResources.Instance.adjustBlood;
        float adjustStress = ScheduleResources.Instance.adjustStress;
        float adjustLove = ScheduleResources.Instance.adjustLove;
        int adjustMoney = ScheduleResources.Instance.addMoney + ScheduleResources.Instance.subMoney;

        float resultBlood = currBlood + adjustBlood;
        float resultStress = currStress + adjustStress;
        float resultLove = currLove + adjustLove;
        int resultMoney = currMoney + adjustMoney;

        float resultBloodClm = Mathf.Clamp(resultBlood, 0, int.MaxValue);
        float resultStressClm = Mathf.Clamp(resultStress, 0, int.MaxValue);
        float resultLoveClm = Mathf.Clamp(resultLove, 0, int.MaxValue);
        int resultMoneyClm = Mathf.Clamp(resultMoney, 0, int.MaxValue);

        // 텍스트 색 설정
        {
            Color color;
            Color colorPositive = new Color(0.1725f, 0.6863f, 0.3765f, 1); // 2CAF60
            Color colorNevative = new Color(0.7961f, 0.1294f, 0.1294f, 1); // CB2121
            Color colorNomal = new Color(0.3529412f, 0.2745098f, 0.2627451f, 1);

            // 흡혈
            if (adjustBlood > 0) color = colorPositive;
            else if (adjustBlood == 0) color = colorNomal;
            else color = colorNevative;
            bloodAfter.color = color;

            // 스트레스
            if (adjustStress < 0) color = colorPositive;
            else if (adjustStress == 0) color = colorNomal;
            else color = colorNevative;
            StressAfter.color = color;

            // 호감도
            if (adjustLove > 0) color = colorPositive;
            else if (adjustLove == 0) color = colorNomal;
            else color = colorNevative;
            LoveAfter.color = color;

            // 돈
            if (adjustMoney > 0) color = colorPositive;
            else if (adjustMoney == 0) color = colorNomal;
            else color = colorNevative;
            MoneyAfter.color = color;

        }

        // 텍스트 내용 설정
        {
            day.text = ScheduleResources.Instance.CurrDay + "/30";

            bloodBefore.text = currBlood.ToString("F1") + "L";
            bloodAfter.text = resultBloodClm.ToString("F1") + "L";

            StressBefore.text = currStress.ToString();
            StressAfter.text = resultStressClm.ToString();

            LoveBefore.text = currLove.ToString();
            LoveAfter.text = resultLoveClm.ToString();

            MoneyBefore.text = currMoney.ToString();
            MoneyAfter.text = resultMoneyClm.ToString();
        }

        // 수입, 지출
        {
            income.text = ScheduleResources.Instance.addMoney.ToString();
            consum.text = Mathf.Abs(ScheduleResources.Instance.subMoney).ToString();
            profit.text = resultMoneyClm.ToString();
        }

        // 게이지 설정
        {
            loveNeed.text = resultLove + "/" + ScheduleResources.MAX_LOVE;
            bloodNeed.text = resultBlood + "/" + ScheduleResources.MAX_BLOOD;

            loveGage.fillAmount = resultLove / ScheduleResources.MAX_LOVE;
            bloodGage.fillAmount = resultBlood / ScheduleResources.MAX_BLOOD;
        }
    }
}
