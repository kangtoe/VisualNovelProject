using System;
using UnityEngine;
using UnityEngine.UI;
using Utage;

public class NameTag : MonoBehaviour
{
    [SerializeField]
    UguiNovelText text; // 비주얼 노벨 씬의 NameText

    [SerializeField]
    Image image; // 네임 태그의 image 컴포넌트

    void Update()
    {
        Color color = image.color;

        // 글이 비어있을 경우
        if (String.IsNullOrEmpty(text.text))
        {
            color.a = 0f; // 투명도를 0
        }
        else
        {
            color.a = 255f; // 투명도를 255
        }

        image.color = color;
    }
}
