using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 디버그 용 클래스
// save data를 에디터에서 볼수 있도록 함 
public class SaveDataViewer : MonoBehaviour
{
    #region 싱글톤
    public static SaveDataViewer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<SaveDataViewer>();
            }
            return instance;
        }
    }
    private static SaveDataViewer instance;
    #endregion

    public int Flag;    
    public int Money;
    public int Stress;
    public int love;
    public float Blood;
    public int Day;

    private void Awake()
    {
        // 모든 씬에서 하나만 유지
        if (Instance != this) Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        GetSave();
    }

    // 저장 데이터 가져와 표시
    public void GetSave()
    {
        Flag = ExtraSave.Flag;        
        Money = ExtraSave.Money;
        Stress = ExtraSave.Stress;
        love = ExtraSave.love;
        Blood = ExtraSave.Blood;
        Day = ExtraSave.DayProgress;
    }

    // 현재 표시된 데이터로 저장 데이터 수정
    public void SetSave()
    {        
        ExtraSave.Flag = Flag;        
        ExtraSave.Money = Money;
        ExtraSave.Stress = Stress;
        ExtraSave.love = love;
        ExtraSave.Blood = Blood;
        ExtraSave.DayProgress = Day;
    }

    // 세이브 데이터 삭제 (초기화)
    public void ClearSave()
    {
        ExtraSave.ClearData();
    }
}
