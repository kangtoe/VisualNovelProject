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

    [Header("����")]
    public float adjustBlood;
    [SerializeField]
    float currBlood = 0;
    public float CurrBlood => currBlood;
    public float PreviewBlood => CurrBlood + adjustBlood;
    public float PreviewBloodClm => Mathf.Clamp(PreviewBlood, 0, float.MaxValue);
    [SerializeField]
    Text bloodTxt;    

    [Header("��Ʈ����")]
    public float adjustStress;        
    [SerializeField]
    float currStress = 0;
    public float CurrStress => currStress;
    public float PreviewStress => currStress + adjustStress;
    public float PreviewStressClm => Mathf.Clamp(PreviewStress, 0, float.MaxValue);
    [SerializeField]
    Text stressTxt;
    [SerializeField]
    Image currStressGage;
    [SerializeField]
    Image previewStressGage;

    [Header("ȣ����")]
    public float adjustLove;
    [SerializeField]
    float currLove = 0;
    public float CurrLove => currLove;
    public float PreviewLove => CurrLove + adjustLove;
    public float PreviewLoveClm => Mathf.Clamp(PreviewLove, 0, float.MaxValue);
    [SerializeField]
    Text loveTxt;

    [Header("��")]
    public int addMoney;
    public int subMoney;
    //public int adjustMoney;
    [SerializeField]
    int currMoney = 0;
    public int CurrMoney => currMoney;
    public int PreviewMoney => CurrMoney + addMoney + subMoney;
    public int PreviewMoneyClm => Mathf.Clamp(PreviewMoney, 0, int.MaxValue);
    [SerializeField]
    Text moneyTxt;

    [Header("����")]
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

    // ��������� UI �̸�����
    public void PreviewUI()
    {
        float adjustMoney = addMoney + subMoney;

        Color color;        
        Color colorPositive = Color.green;
        Color colorNevative = Color.red;
        Color colorNomal = Color.white;

        // �ؽ�Ʈ �� ����
        {
            // ����
            if (adjustBlood > 0) color = colorPositive;
            else if (adjustBlood == 0) color = colorNomal;
            else color = colorNevative;
            bloodTxt.color = color;

            // ��Ʈ����
            if (adjustStress < 0) color = colorPositive;
            else if (adjustStress == 0) color = colorNomal;
            else color = colorNevative;
            stressTxt.color = color;

            // ȣ����
            if (adjustLove > 0) color = colorPositive;
            else if (adjustLove == 0) color = colorNomal;
            else color = colorNevative;
            loveTxt.color = color;

            // ��
            if (adjustMoney > 0) color = colorPositive;
            else if (adjustMoney == 0) color = colorNomal;
            else color = colorNevative;
            moneyTxt.color = color;

        }

        // ������
        currStressGage.fillAmount = currStress / MAX_STRESS;
        previewStressGage.fillAmount = (currStress + adjustStress) / MAX_STRESS;
       
        // �ؽ�Ʈ ����
        bloodTxt.text = PreviewBloodClm.ToString("F1") + "/" + MAX_BLOOD + BLOOD_STRING;
        stressTxt.text = PreviewStressClm.ToString() + "/" + MAX_STRESS;
        loveTxt.text = PreviewLoveClm.ToString() + "/" + MAX_LOVE;
        moneyTxt.text = PreviewMoneyClm.ToString();
        dayTxt.text = currDay.ToString();
    }

    // ������ & ���� UI �ʱ�ȭ 
    public void Init()
    {
        adjustBlood = 0;
        adjustStress = 0;
        adjustLove = 0;
        addMoney = 0; subMoney = 0; //adjustMoney = 0;
        currDay = 0;

        PreviewUI();      
    }

    // ���� ��ư Ŭ�� ��
    public void Confirm()
    {
        confirmUI.SetActive(true);
    }

    // ������ ����
    public void Admit()
    {
        int adjustMoney = addMoney + subMoney;

        currBlood = PreviewBloodClm;
        currStress = PreviewStressClm;
        currLove = PreviewLoveClm;
        currMoney = PreviewMoneyClm;

        adjustBlood = 0;
        adjustStress = 0;
        adjustLove = 0;
        addMoney = 0; subMoney = 0;

        currDay++;
        dayTxt.text = currDay.ToString();

        PreviewUI();

        ScheduleManager.Instance.Init();
        confirmUI.SetActive(false);
    }    
}
