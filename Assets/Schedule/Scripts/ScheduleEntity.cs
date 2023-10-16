using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleEntity : MonoBehaviour
{    
    public GameObject selectPreviewObj;
    List<GameObject> spwanedPreviewObjList = new List<GameObject>();

    [Space]
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
        foreach (GameObject go in spwanedPreviewObjList)
        {
            // TODO : 오브젝트 페이드 아웃 후 삭제
            Destroy(go);
        }
        spwanedPreviewObjList.Clear();        
    }

    public void SelectSchedule()
    {
        if (isChanging)
        {
            Debug.Log("isChanging");
            return;
        }

        GameObject go = Instantiate(selectPreviewObj, transform.root);
        go.SetActive(true);
        spwanedPreviewObjList.Add(go);
        RectTransform rt = go.GetComponent<RectTransform>();

        RectTransform targetRt = ScheduleManager.AddSechdule(this);
        if (!targetRt) return;
        
        Vector2 targetSize = targetRt.sizeDelta;
        Vector2 targetPos = targetRt.anchoredPosition;

        StartCoroutine(SmoothChange(rt, targetSize, targetPos));
    }    

    IEnumerator SmoothChange(RectTransform rt, Vector2 targetSize, Vector2 TargetPos)
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

        rectTransform.SetParent(rectTransform.root);
        rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
        rectTransform.anchorMax = new Vector2(0.5f, 0.5f);

        Vector3 globalAnchoredPosition = rectTransform.anchoredPosition;
        Debug.Log(rectTransform.name + ": globalAnchoredPosition =" + globalAnchoredPosition);

        rectTransform.SetParent(originPa);        
        rectTransform.anchorMin = originMin;
        rectTransform.anchorMin = originMax;

        return globalAnchoredPosition;
    }
}
