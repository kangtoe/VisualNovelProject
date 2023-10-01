using System;
using UnityEngine;
using UnityEngine.UI;
using Utage;

public class NameTag : MonoBehaviour
{
    [SerializeField]
    UguiNovelText text; // ���־� �뺧 ���� NameText

    [SerializeField]
    Image image; // ���� �±��� image ������Ʈ

    void Update()
    {
        Color color = image.color;

        // ���� ������� ���
        if (String.IsNullOrEmpty(text.text))
        {
            color.a = 0f; // ������ 0
        }
        else
        {
            color.a = 255f; // ������ 255
        }

        image.color = color;
    }
}
