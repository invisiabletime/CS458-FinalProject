using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    static GameManager instance;

    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);

        DontDestroyOnLoad(this);
    }

    public delegate void OnGameStart();
    public static event OnGameStart StartGame;

    public delegate void OnGameEnd();
    public static event OnGameStart EndGame;

    private float score;

    public float Score { get { return score; } }

    private bool shouldCreateHitGraphic = false;

    public bool ShouldCreatedHitGraphic
    {
        get
        {
            return shouldCreateHitGraphic;
        }
    }
    
    public void PlayerScored(float targetValue)
    {
        score = score + targetValue;

        Debug.Log(score);
    }

    public void GameStart()
    {
        Debug.Log("<color=green>Game Started</color>");
        StartGame();
        shouldCreateHitGraphic = true;
    }

    public void GameOver()
    {
        EndGame();
    }
}
