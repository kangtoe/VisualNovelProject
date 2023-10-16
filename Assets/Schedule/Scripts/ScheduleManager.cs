using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ScheduleType
{ 
    Morning,
    Day,
    Night
}

public class ScheduleManager : MonoBehaviour
{
    public static ScheduleManager Instance
    {
        get
        {
            if (instance == null) instance = FindObjectOfType<ScheduleManager>();

            return instance;
        }
    }
    private static ScheduleManager instance;

    public RectTransform morningScheduleTf;
    public RectTransform dayScheduleTf;
    public RectTransform nightScheduleTf;

    public ScheduleEntity currMorning;
    public ScheduleEntity currDay;
    public ScheduleEntity currNight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ��ư - ������ Ȯ�� & ����
    public void Confirm()
    { 
    
    }

    // ��ư - ������ �ʱ�ȭ
    public void Init()
    { 
    
    }

    // ���丮 ���� ���ư���
    public void ToStory()
    { 
    }
}
