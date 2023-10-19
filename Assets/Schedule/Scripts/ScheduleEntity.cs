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
    
    // ���� ������ ������ UI ��� �����
    public void DeselectSchedule()
    {
        foreach (GameObject go in spwanedPreviewObjList)
        {
            // TODO : ������Ʈ ���̵� �ƿ� �� ����
            Destroy(go);
        }
        spwanedPreviewObjList.Clear();        
    }

    // ��ư �̺�Ʈ - UI Ŭ����
    public void SelectSchedule()
    {
        if (isChanging)
        {
            Debug.Log("isChanging");
            return;
        }

        // ������ UI Ÿ�� ���ϱ�
        RectTransform targetRt = ScheduleManager.AddSechdule(this);
        if (targetRt) Debug.Log("targetRt: " + targetRt.name);
        else return;

        // ���ο� ������ UI ����
        GameObject go = Instantiate(selectPreviewObj, transform.root);
        go.SetActive(true);
        spwanedPreviewObjList.Add(go);
        RectTransform startRt = go.GetComponent<RectTransform>();        
        startRt.position = rt.position;        
        
        // ������ UI -> Ÿ�� UI�� �ε巴�� ��ȯ
        Vector2 targetSize = targetRt.sizeDelta;
        Vector2 targetPos = targetRt.position;
        Debug.Log("targetRt.position :" + targetRt.position);
        StartCoroutine(SmoothChange(startRt, targetSize, targetPos));
    }    

    // UI ����
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
