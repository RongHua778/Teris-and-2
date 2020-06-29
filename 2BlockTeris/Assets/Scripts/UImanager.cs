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
        Score += amount;
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
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
        Game.Instance.gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ShowNextTeris(TerisItem item1, TerisItem item2)
    {
        next1_Img.sprite = Resources.Load<Sprite>(item1.imagePath);
        next2_Img.sprite = Resources.Load<Sprite>(item2.imagePath);

    }
}
