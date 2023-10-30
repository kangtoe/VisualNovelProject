using UnityEngine;

// 음향 재생
public class ScheduleBgm : MonoBehaviour
{
    public AudioSource bgm;

    // Start is called before the first frame update
    void Start()
    {
        bgm.Play();
    }
}
