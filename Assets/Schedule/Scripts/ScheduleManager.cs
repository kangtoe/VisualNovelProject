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
        if (currMorning is null)
        {
            currMorning = entity;
            return morningScheduleTf;
        }
        else if (currDay is null)
        {
            currDay = entity;
            return dayScheduleTf;
        }
        else if (currNight is null)
        {
            currNight = entity;
            return nightScheduleTf;
        }
        else
        {
            Debug.Log("schedule full!");
            return null;
        }
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
    }

    // 스토리 모드로 돌아가기
    public void ToStory()
    { 
    }
}
