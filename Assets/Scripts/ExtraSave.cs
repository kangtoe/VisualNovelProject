using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Ÿ�� �ܺ� ���̺� ������ ����
public static class ExtraSave
{
    static string chapterProgressKey = "chapterPorgressKey";
    static string dayProgressKey = "dayProgressKey";
    static string moneyKey = "moneyKey";
    static string stressKey = "stressKey";
    static string loveKey = "loveKey";
    static string bloodKey = "bloodKey";

    public static int ChapterProgress
    {
        get
        {
            return PlayerPrefs.GetInt(chapterProgressKey);
        }
        set
        {
            PlayerPrefs.SetInt(chapterProgressKey, value);
        }
    }

    public static int DayProgress
    {
        get
        {
            return PlayerPrefs.GetInt(dayProgressKey);
        }
        set
        {
            PlayerPrefs.SetInt(dayProgressKey, value);
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

    // ��� ���� ������ ���� �޼ҵ�
    public static void ClearData()
    {
        PlayerPrefs.DeleteAll();
    }
}
