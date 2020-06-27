using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetromio : Singleton<SpawnTetromio>
{

    public GameObject[] Tetrominoes;
    Transform spawnPoint1;
    Transform spawnPoint2;
    bool falled1 = false;
    bool falled2 = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint1 = transform.Find("SpawnPoint1");
        spawnPoint2 = transform.Find("SpawnPoint2");

        NewTetromino();
        GameEvents.Instance.onTetrominosFalled += CheckTwoTerisFalled;
    }


    public void NewTetromino()
    {
        if (Game.Instance.gameOver)
            return;
        falled1 = false;
        falled2 = false;

        GameObject teris1 = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], spawnPoint1.position, Quaternion.identity);
        teris1.GetComponent<TerisBlock>().ID = 1;
        GameObject teris2 = Instantiate(Tetrominoes[Random.Range(0, Tetrominoes.Length)], spawnPoint2.position, Quaternion.identity);
        teris2.GetComponent<TerisBlock>().ID = 2;

    }

    void CheckTwoTerisFalled(int terisID)
    {
        if (terisID == 1)
        {
            falled1 = true;
        }
        if (terisID == 2)
        {
            falled2 = true;
        }
        if (falled1 && falled2)
        {
            NewTetromino();
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
