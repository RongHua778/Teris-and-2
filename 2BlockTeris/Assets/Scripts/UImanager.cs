using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : Singleton<UImanager>
{

    public GameObject gameoverPanel;
    public Image next1_Img;
    public Image next2_Img;
    int score;
    int max;
    int Change_Speed = 5;
    public int Score
    {
        get { return score; }
        set
        {
            score = value;
            score_txt.text = value.ToString();
        }
    }

    public int Max
    {
        get { return max; }
        set
        {
            max = value;
            max_txt.text = value.ToString();
        }
    }

    public Text score_txt;
    public Text max_txt;

    public void AddScore(int amount)
    {
        StartCoroutine(AddScoreCor(amount));
    }

    IEnumerator AddScoreCor(int amount)
    {
        int delta = amount / Change_Speed;
        for(int i = 0; i < Change_Speed; i++)
        {
            Score += delta;
            yield return new WaitForSeconds(0.05f);
        }
        if (Score > Max)
        {
            PlayerPrefs.SetInt("Max", Score);
            Max = Score;
        }
        StopCoroutine("AddScoreCor");
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        Max = PlayerPrefs.GetInt("Max", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Gameover()
    {
        Game.Instance.gameOver = true;
        gameoverPanel.SetActive(true);
    }

    void StartBtnClick()
    {

    }

    public void RestartBtnClick()
    {
        Sound.Instance.PlayEffect("按钮");
        Game.Instance.ReloadScene();
    }

    public void ShowNextTeris(TerisItem item1, TerisItem item2)
    {
        next1_Img.sprite = Resources.Load<Sprite>(item1.imagePath);
        next2_Img.sprite = Resources.Load<Sprite>(item2.imagePath);

    }
}
