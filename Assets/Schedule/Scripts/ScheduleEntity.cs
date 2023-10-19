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
    bool isChanging = false;

    ScheduleManager ScheduleManager => ScheduleManager.Instance;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();     
    }
    
    // 기존 생성된 스케쥴 UI 모두 지우기
    public void DeselectSchedule()
    {
        foreach (GameObject go in spwanedPreviewObjList)
        {
            // TODO : 오브젝트 페이드 아웃 후 삭제
            Destroy(go);
        }
        spwanedPreviewObjList.Clear();        
    }

    // 버튼 이벤트 - UI 클릭시
    public void SelectSchedule()
    {
        if (isChanging)
        {
            Debug.Log("isChanging");
            return;
        }

        // 스케쥴 UI 타겟 구하기
        RectTransform targetRt = ScheduleManager.AddSechdule(this);
        if (targetRt) Debug.Log("targetRt: " + targetRt.name);
        else return;

        // 새로운 스케쥴 UI 생성
        GameObject go = Instantiate(selectPreviewObj, transform.root);
        go.SetActive(true);
        spwanedPreviewObjList.Add(go);
        RectTransform startRt = go.GetComponent<RectTransform>();        
        startRt.position = rt.position;        
        
        // 생성된 UI -> 타겟 UI로 부드럽게 변환
        Vector2 targetSize = targetRt.sizeDelta;
        Vector2 targetPos = targetRt.position;
        Debug.Log("targetRt.position :" + targetRt.position);
        StartCoroutine(SmoothChange(startRt, targetSize, targetPos));
    }    

    // UI 연출
    IEnumerator SmoothChange(RectTransform _rt, Vector2 targetSize, Vector2 TargetPos)
    {
        float duration = 0.5f;
        float t = 0;

        Vector2 startSize = _rt.sizeDelta;
        Vector2 startPos = _rt.position;

        isChanging = true;
        while (true)
        {
            t += Time.deltaTime / duration;
            if (t > 1) t = 1;

            _rt.sizeDelta = Vector2.Lerp(startSize, targetSize, t);
            _rt.position = Vector2.Lerp(startPos, TargetPos, t);

            if (t == 1) break;

            yield return null;
        }

        isChanging = false;
    }
}
