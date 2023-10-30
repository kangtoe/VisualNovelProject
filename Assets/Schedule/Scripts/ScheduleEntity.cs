using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScheduleEntity : MonoBehaviour
{
    public GameObject hoverUi;

    public GameObject selectPreviewObj;
    List<GameObject> spwanedPreviewObjList = new List<GameObject>();

    [Space]
    public float blood;
    public int stress;
    public int money;
    public int love;

    RectTransform rt;
    //bool isChanging = false;

    ScheduleManager ScheduleManager => ScheduleManager.Instance;

    // Start is called before the first frame update
    void Start()
    {
        rt = GetComponent<RectTransform>();

        // ȣ�� �̺�Ʈ ���
        {
            EventTrigger et = gameObject.AddComponent<EventTrigger>();
            EventTrigger.Entry entry;

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerEnter;
            entry.callback.AddListener(delegate {
                ActiveHoverUi();
            });
            et.triggers.Add(entry);

            entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerExit;
            entry.callback.AddListener(delegate {
                InactiveHoverUi();
            });
            et.triggers.Add(entry);
        }

        InitHoverUi();
    }
    
    // ���� ������ ������ UI ��� �����
    public void DeselectSchedule()
    {
        foreach (GameObject go in spwanedPreviewObjList)
        {
            // TODO : ������Ʈ ���̵� �ƿ� �� ����
            StopAllCoroutines();
            Destroy(go);
        }
        spwanedPreviewObjList.Clear();        
    }

    // ��ư �̺�Ʈ - UI Ŭ����
    public void SelectSchedule()
    {
        //if (isChanging)
        //{
        //    Debug.Log("isChanging");
        //    return;
        //}

        // ������ ���������� üũ
        {
            if (ScheduleResources.Instance.PreviewMoney + money < 0) return;
            if (ScheduleResources.Instance.PreviewStress + stress > ScheduleResources.MAX_STRESS) return;
        }

        // ������ UI Ÿ�� ���ϱ�
        RectTransform targetRt = ScheduleManager.AddSechdule(this);
        if (targetRt) Debug.Log("targetRt: " + targetRt.name);
        else return;

        // ���ο� ������ UI ����
        Transform tf = transform.root.GetChild(transform.root.childCount-2);
        GameObject go = Instantiate(selectPreviewObj, tf);
        go.SetActive(true);
        spwanedPreviewObjList.Add(go);
        RectTransform startRt = go.GetComponent<RectTransform>();        
        startRt.position = rt.position;        
        
        // ������ UI -> Ÿ�� UI�� �ε巴�� ��ȯ
        Vector2 targetSize = targetRt.sizeDelta;
        Vector2 targetPos = targetRt.position;
        Debug.Log("targetRt.position :" + targetRt.position);
        StartCoroutine(SmoothChange(startRt, targetSize, targetPos));

        InitHoverUi();
    }    

    // UI ����
    IEnumerator SmoothChange(RectTransform _rt, Vector2 targetSize, Vector2 TargetPos)
    {
        //float duration = 0.5f;
        //float t = 0;
        //Vector2 startSize = _rt.sizeDelta;
        //Vector2 startPos = _rt.position;
        //isChanging = true;

        Image img = _rt.GetComponent<Image>();
        float alpha = 0.4f;

        while (true)
        {
            //t += Time.deltaTime / duration;
            //if (t > 1) t = 1;
            //_rt.sizeDelta = Vector2.Lerp(startSize, targetSize, t);
            //_rt.position = Vector2.Lerp(startPos, TargetPos, t);

            float speed = 10f * Time.deltaTime;
            _rt.sizeDelta = Vector2.Lerp(_rt.sizeDelta, targetSize, speed);
            _rt.position = Vector2.Lerp(_rt.position, TargetPos, speed);

            Color col = img.color;
            alpha = Mathf.Lerp(alpha, 1, speed);            
            col.a = alpha;
            img.color = col;

            //if (t == 1) break;

            yield return null;
        }

        //isChanging = false;
    }

    public void InitHoverUi()
    {
        HoverUi ui = hoverUi.GetComponent<HoverUi>();
        ui.Init(money, stress, love, blood);
    }

    public void ActiveHoverUi()
    {
        InitHoverUi();
        hoverUi.SetActive(true);        
    }

    public void InactiveHoverUi()
    {
        hoverUi.SetActive(false);
    }
}
