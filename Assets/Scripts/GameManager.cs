using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    NavMeshAgent navMeshAgent;
    Player move;
    bool gameOver;
    public FadeCamera fade;

    void Start()
    {
        navMeshAgent = player.GetComponent<NavMeshAgent>();
        move = player.GetComponent<Player>();
    }

    public void GameOver()
    {
        if (gameOver == false)
        {
            move.enabled = false;
            navMeshAgent.enabled = false;
            fade.RedoFade();
            Invoke("Reset", 2);
            gameOver = true;
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
