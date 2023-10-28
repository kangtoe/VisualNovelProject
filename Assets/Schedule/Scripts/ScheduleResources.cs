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

    public static readonly float MAX_STRESS = 100;
    public static readonly float MAX_LOVE = 100;
    public static readonly float MAX_BLOOD = 5.0f;
    public static readonly string BLOOD_STRING = "L";

    [Header("흡혈")]
    public float adjustBlood;
    [SerializeField]
    float currBlood = 0;
    public float CurrBlood => currBlood;
    [SerializeField]
    Text bloodTxt;    

    [Header("스트레스")]
    public float adjustStress;        
    [SerializeField]
    float currStress = 0;
    public float CurrStress => currStress;
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
    public float CurrLove => currLove;
    [SerializeField]
    Text loveTxt;

    [Header("돈")]
    public int adjustMoney;
    [SerializeField]
    int currMoney = 0;
    public int CurrMoney => currMoney;
    [SerializeField]
    Text moneyTxt;

    [Header("일자")]
    [SerializeField]
    float currDay = 0;
    public float CurrDay => currDay;
    [SerializeField]
    Text dayTxt;
    //float adjustDay;

    [Space]
    [SerializeField] GameObject confirmUI;

    const float MAX_DAY = 30;

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
        {
            // 흡혈
            if (adjustBlood > 0) color = colorPositive;
            else if (adjustBlood == 0) color = colorNomal;
            else color = colorNevative;
            bloodTxt.color = color;

            // 스트레스
            if (adjustStress < 0) color = colorPositive;
            else if (adjustStress == 0) color = colorNomal;
            else color = colorNevative;
            stressTxt.color = color;

            // 호감도
            if (adjustLove > 0) color = colorPositive;
            else if (adjustLove == 0) color = colorNomal;
            else color = colorNevative;
            loveTxt.color = color;

            // 돈
            if (adjustMoney > 0) color = colorPositive;
            else if (adjustMoney == 0) color = colorNomal;
            else color = colorNevative;
            moneyTxt.color = color;

        }

        // 게이지
        currStressGage.fillAmount = currStress / MAX_STRESS;
        previewStressGage.fillAmount = (currStress + adjustStress) / MAX_STRESS;      

        // 텍스트 설정
        bloodTxt.text = (currBlood + adjustBlood).ToString("F1") + "/" + MAX_BLOOD + BLOOD_STRING;
        stressTxt.text = (currStress + adjustStress).ToString() + "/" + MAX_STRESS;
        loveTxt.text = (currLove + adjustLove).ToString() + "/" + MAX_LOVE;
        moneyTxt.text = (currMoney + adjustMoney).ToString();
        dayTxt.text = currDay.ToString();
    }

    // 수정값 & 적용 UI 초기화 
    public void Init()
    {
        adjustBlood = 0;
        adjustStress = 0;
        adjustLove = 0;
        adjustMoney = 0;
        currDay = 0;

        PreviewUI();      
    }

    // 실행 버튼 클릭 시
    public void Confirm()
    {
        confirmUI.SetActive(true);
    }

    // 수정값 적용
    public void Admit()
    {
        currBlood += adjustBlood;
        currStress += adjustStress;
        currLove += adjustLove;
        currMoney += adjustMoney;

        adjustBlood = 0;
        adjustStress = 0;
        adjustLove = 0;
        adjustMoney = 0;

        currDay++;
        dayTxt.text = currDay.ToString();

        PreviewUI();

        ScheduleManager.Instance.Init();
        confirmUI.SetActive(false);
    }    
}
