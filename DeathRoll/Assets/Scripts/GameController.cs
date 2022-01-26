using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text Text;
    [SerializeField] private Text TextShadow;
    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject RollButton;


    public int ceiling;
    private int latestScore;
    private bool isReadyToRestart = false;
    public void Start()
    {
        RestartButton.SetActive(false);
        RollButton.SetActive(true);
    ceiling = 100;
        Text.text = ceiling.ToString();
        TextShadow.text = ceiling.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isReadyToRestart == true && ceiling == 1)
            {
                RestartScene();
            }
            else
            {
                DeathRoll1();
            }
        }
    }
    /*
        public void DeathRoll()
    {
            latestScore = Random.Range(1, ceiling + 1);
            ceiling = latestScore;
        if (ceiling == 1)
        {
            Text.text = "1!!!!";
            TextShadow.text = "1!!!!";
            RollButton.SetActive(false);

            StartCoroutine(Wait());
        }
        else
        {
            Text.text = latestScore.ToString();
            TextShadow.text = latestScore.ToString();
        }
    }
    */
    public void DeathRoll1()
    {
        Debug.Log(ceiling);
        int minusNum = Random.Range(0, 10);
        Debug.Log(minusNum);
        latestScore = ceiling - minusNum;

        if (latestScore < 0)
        {
            latestScore = Mathf.Abs(latestScore);
            ceiling = latestScore;

            Text.text = latestScore.ToString();
            TextShadow.text = latestScore.ToString();
        }
        else if (latestScore ==0)
        {
            Text.text = "1!!!!";
            TextShadow.text = "1!!!!";
            RollButton.SetActive(false);

            StartCoroutine(Wait());
        }
        else if (latestScore >0)
        {
            ceiling = latestScore;
            Text.text = latestScore.ToString();
            TextShadow.text = latestScore.ToString();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.75f);
        RestartButton.SetActive(true);
        isReadyToRestart = true;
    }
}
