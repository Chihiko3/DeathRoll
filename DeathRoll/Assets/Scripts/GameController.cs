using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text Text;
    [SerializeField] private Text TextShadow;
    [SerializeField] private Text Range;
    [SerializeField] private Text RangeShadow;
    [SerializeField] private GameObject RestartButton;
    [SerializeField] private GameObject RollButton;

    public int ceiling;
    private int latestScore = 2;
    private bool isReadyToRestart = false;
    public void Start()
    {
        RestartButton.SetActive(false);
        RollButton.SetActive(true);
    ceiling = 100;
        Text.text = ceiling.ToString();
        TextShadow.text = ceiling.ToString();
        Range.text = "Let's Roll!";
        RangeShadow.text = "Let's Roll!";
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
                DeathRoll();
            }
        }
    }
        public void DeathRoll()
    {
        latestScore = Random.Range(0, ceiling + 1);
        ceiling = latestScore;

        if (ceiling == 1)
        {
            Text.text = "1!!!!";
            TextShadow.text = "1!!!!";
            Range.text = "Gotcha!";
            RangeShadow.text = "Gotcha!";
            RollButton.SetActive(false);

            StartCoroutine(Wait());
        }
        else if (ceiling >1)
        {
            Text.text = latestScore.ToString();
            TextShadow.text = latestScore.ToString();
            Range.text = "( 0 - " + ceiling + " )";
            RangeShadow.text = "( 0 - " + ceiling + " )";
        }
        else
        {
            Text.text = "0";
            TextShadow.text = "0";
            Range.text = "Excluded!";
            RangeShadow.text = "Excluded!";
            RollButton.SetActive(false);

            StartCoroutine(Wait());
        }
    }
    /*public void DeathRoll1()
    {

    Might try something fun here :D
    
    }*/

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
