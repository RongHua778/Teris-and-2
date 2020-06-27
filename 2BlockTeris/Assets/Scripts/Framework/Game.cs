using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(GameEvents))]
[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(Sound))]
public class Game : Singleton<Game>
{
    int MaxLevel = 3;
    public Animator transition;
    public float transitionTime = 0.8f;

    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

    }
    public void LoadScene(int index)
    {
        //StartCoroutine(Transition(index));
        SceneManager.LoadScene(index, LoadSceneMode.Single);
    }

    public void LoadNextLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 <= MaxLevel)
            LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            LoadScene(4);


    }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene().buildIndex);
    }



    IEnumerator Transition(int index)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(index, LoadSceneMode.Single);
        transition.SetTrigger("End");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
