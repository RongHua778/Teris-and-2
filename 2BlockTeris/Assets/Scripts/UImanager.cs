using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : Singleton<UImanager>
{

    public GameObject gameoverPanel;
    // Start is called before the first frame update
    void Start()
    {
        
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
}
