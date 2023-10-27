using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 우타게 외부 세이브 데이터 관리
public static class ExtraSave
{
    static string flagKey = "flagKey";
    static string DayProgressKey = "dayProgressKey";
    static string moneyKey = "moneyKey";
    static string stressKey = "stressKey";
    static string loveKey = "loveKey";
    static string bloodKey = "bloodKey";

    public static int Flag
    {
        get
        {
            return PlayerPrefs.GetInt(flagKey);
        }
        set
        {
            PlayerPrefs.SetInt(flagKey, value);
        }
    }

    public static int DayProgress
    {
        get
        {
            return PlayerPrefs.GetInt(DayProgressKey);
        }
        set
        {
            PlayerPrefs.SetInt(DayProgressKey, value);
        }
    }

    public static int Money
    {
        get
        {
            return PlayerPrefs.GetInt(moneyKey);
        }
        set
        {
            PlayerPrefs.SetInt(moneyKey, value);
        }
    }

    public static int Stress
    {
        get
        {
            return PlayerPrefs.GetInt(stressKey);
        }
        set
        {
            PlayerPrefs.SetInt(stressKey, value);
        }
    }

    public static int love
    {
        get
        {
            return PlayerPrefs.GetInt(loveKey);
        }
        set
        {
            PlayerPrefs.SetInt(loveKey, value);
        }
    }

    public static float Blood
    {
        get
        {
            return PlayerPrefs.GetFloat(bloodKey);
        }
        set
        {
            PlayerPrefs.SetFloat(bloodKey, value);
        }
    }

    // 모든 저장 데이터 삭제 메소드
    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
