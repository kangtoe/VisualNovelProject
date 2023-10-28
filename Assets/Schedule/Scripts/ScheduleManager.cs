using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    ScheduleResources resource => ScheduleResources.Instance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RectTransform AddSechdule(ScheduleEntity entity)
    {
        RectTransform targetUI;

        if (currMorning is null)
        {
            currMorning = entity;
            targetUI =  morningScheduleTf;
        }
        else if (currDay is null)
        {
            currDay = entity;
            targetUI = dayScheduleTf;
        }
        else if (currNight is null)
        {
            currNight = entity;
            targetUI = nightScheduleTf;
        }
        else
        {
            Debug.Log("schedule full!");
            return null;
        }

        resource.adjustBlood += entity.blood;
        resource.adjustLove += entity.love;
        resource.adjustStress += entity.stress;
        if (entity.money > 0) resource.addMoney += entity.money; else resource.subMoney += entity.money; //resource.adjustMoney += entity.money;
        resource.PreviewUI();
        return targetUI;
    }

    // 버튼 - 스케쥴 확정 & 실행
    public void Confirm()
    { 
    
    }

    // 버튼 - 스케쥴 초기화
    public void Init()
    {
        if (currMorning)
        {
            currMorning.DeselectSchedule();
            currMorning = null;
        }

        if (currDay)
        {
            currDay.DeselectSchedule();
            currDay = null;
        }

        if (currNight)
        {
            currNight.DeselectSchedule();
            currNight = null;
        }

        resource.Init();
    }

    // 스토리 모드로 돌아가기
    public void ToStory()
    { 
    }
}
