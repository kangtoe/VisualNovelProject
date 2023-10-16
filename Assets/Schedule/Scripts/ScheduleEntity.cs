using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleEntity : MonoBehaviour
{
    public ScheduleType type;

    public int stress;
    public int money;
    public int favor;

    RectTransform rt;
    Vector2 origonPos;
    Vector2 origonSize;    

    ScheduleManager ScheduleManager => ScheduleManager.Instance;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();
        origonSize = rt.sizeDelta;
        origonPos = rt.anchoredPosition;        
    }

    bool isChanging = false;

    public void DeselectSchedule()
    {
        StopAllCoroutines();

        StartCoroutine(SmoothChange(origonSize, origonPos));
    }

    public void SelectSchedule()
    {
        if (isChanging)
        {
            Debug.Log("isChanging");
            return;
        }

        Vector2 targetSize;
        Vector2 targetPos;

        switch (type)
        {
            case ScheduleType.Morning:
                targetSize = ScheduleManager.morningScheduleTf.sizeDelta;
                targetPos = GetGlobalAnchoredPosition(ScheduleManager.morningScheduleTf);
                ScheduleManager.currMorning?.DeselectSchedule();
                ScheduleManager.currMorning = this;
                break;
            case ScheduleType.Day:
                targetSize = ScheduleManager.dayScheduleTf.sizeDelta;
                targetPos = ScheduleManager.dayScheduleTf.anchoredPosition;
                ScheduleManager.currDay?.DeselectSchedule();
                ScheduleManager.currDay = this;
                break;
            case ScheduleType.Night:
                targetSize = ScheduleManager.nightScheduleTf.sizeDelta;
                targetPos = GetGlobalAnchoredPosition(ScheduleManager.nightScheduleTf);                    
                ScheduleManager.currNight?.DeselectSchedule();
                ScheduleManager.currNight = this;
                break;
            default:
                Debug.Log("type error : " + type);
                return;
        }

        StartCoroutine(SmoothChange(targetSize, targetPos));
    }    

    IEnumerator SmoothChange(Vector2 targetSize, Vector2 TargetPos)
    {
        float duration = 0.5f;
        float t = 0;

        Vector2 startSize = rt.sizeDelta;
        Vector2 startPos = rt.anchoredPosition;

        isChanging = true;
        while (true)
        {
            t += Time.deltaTime / duration;
            if (t > 1) t = 1;

            rt.sizeDelta = Vector2.Lerp(startSize, targetSize, t);
            rt.anchoredPosition = Vector2.Lerp(startPos, TargetPos, t);

            if (t == 1) break;

            yield return null;
        }

        isChanging = false;
    }


    // 전역 앵커드 포지션을 반환하는 함수
    public Vector2 GetGlobalAnchoredPosition(RectTransform rectTransform)
    {        
        Transform originPa = rectTransform.parent;
        Vector2 originMin = rectTransform.anchorMin;
        Vector2 originMax = rectTransform.anchorMin;

        rectTransform.parent = rectTransform.root;
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

        Vector3 globalAnchoredPosition = rectTransform.anchoredPosition;

        rectTransform.parent = originPa;
        rectTransform.anchorMin = originMin;
        rectTransform.anchorMin = originMax;

        return globalAnchoredPosition;
    }

    //
    //public Vector2 GetRelativeAnchoredPosition()
    //{ 
    
    //}
}
