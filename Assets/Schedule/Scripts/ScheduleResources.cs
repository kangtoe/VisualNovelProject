using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScheduleResources : MonoBehaviour
{
    public static ScheduleResources Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<ScheduleResources>();

            return instance;
        }
    }
    private static ScheduleResources instance;

    [Header("흡혈")]
    public float adjustBlood;
    [SerializeField]
    float currBlood = 0;
    [SerializeField]
    Text bloodTxt;

    const float MAX_BLOOD = 0.5f;
    const string BLOOD_STRING = "L";

    [Header("스트레스")]
    public float adjustStress;        
    [SerializeField]
    float currStress = 0;
    [SerializeField]
    Text stressTxt;
    [SerializeField]
    Image currStressGage;
    [SerializeField]
    Image previewStressGage;

    [Header("호감도")]
    public float adjustLove;
    [SerializeField]
    float currLove = 0;
    [SerializeField]
    Text loveTxt;

    [Header("돈")]
    public float adjustMoney;
    [SerializeField]
    float currMoney = 0;
    [SerializeField]
    Text moneyTxt;

    [Header("일자")]
    [SerializeField]
    float currDay = 0;
    [SerializeField]
    Text dayTxt;                              
    //float adjustDay;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 수정값대로 UI 미리보기
    public void PreviewUI()
    {
        Color color;        
        Color colorPositive = Color.green;
        Color colorNevative = Color.red;
        Color colorNomal = Color.white;

        // 텍스트 색 설정

        if (adjustBlood > 0) color = colorPositive;
        else if (adjustBlood == 0) color = colorNomal;
        else color = colorNevative;
        bloodTxt.color = color;        

        if (adjustStress < 0) color = colorPositive;
        else if (adjustStress == 0) color = colorNomal;
        else color = colorNevative;
        stressTxt.color = color;
        previewStressGage.fillAmount = (currStress + adjustStress / 100);

        if (adjustLove > 0) color = colorPositive;
        else if (adjustLove == 0) color = colorNomal;
        else color = colorNevative;
        loveTxt.color = color;

        if (adjustMoney > 0) color = colorPositive;
        else if (adjustMoney == 0) color = colorNomal;
        else color = colorNevative;
        moneyTxt.color = color;

        bloodTxt.text = (currBlood + adjustBlood).ToString() + "/100";
        stressTxt.text = (currStress + adjustStress).ToString() + "/100";
        loveTxt.text = (currLove + adjustLove).ToString("F1") + "/" + MAX_BLOOD + BLOOD_STRING;
        moneyTxt.text = (currMoney + adjustMoney).ToString();
    }

    // 수정값 & 적용 UI 초기화 
    public void Init()
    {
        adjustBlood = 0;
        adjustStress = 0;
        adjustLove = 0;
        adjustMoney = 0;

        PreviewUI();      
    }

    // 수정값 적용
    public void Confirm()
    {
        currBlood += adjustBlood;
        currStress += adjustStress;
        currLove += adjustLove;
        currMoney += adjustMoney;
        currDay++;
        //currDay += adjustDay;

        PreviewUI();
    }
}
