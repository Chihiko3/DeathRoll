using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    private int latestScore;
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        latestScore = 0;
    }
    void Update()
    {
        textMesh.text = latestScore.ToString();
    }
}
