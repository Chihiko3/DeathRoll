using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextMeshProUGUI;

    public int ceiling;
    private int latestScore;
    public void Start()
    {
        ceiling = 100;
        TextMeshProUGUI.text = ceiling.ToString();
    }
    public void DeathRoll()
    {
            latestScore = Random.Range(1, ceiling + 1);
            ceiling = latestScore;
        if (ceiling == 1)
        {
            TextMeshProUGUI.text = "1!!!!";
        }
        else
        {
            TextMeshProUGUI.text = latestScore.ToString();
        }
    }
}
