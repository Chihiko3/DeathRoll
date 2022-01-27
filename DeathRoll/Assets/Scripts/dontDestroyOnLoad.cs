using UnityEngine;
using System.Collections;

public class dontDestroyOnLoad : MonoBehaviour
{

    private GameObject[] music;
    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("gameMusic");
        if (music.Length != 1)
        {
            Destroy(music[1]);
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}

