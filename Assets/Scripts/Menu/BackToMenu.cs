using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu : MonoBehaviour
{
    [SerializeField]
    private float CreditsTimer;

    private void Update()
    {
        CreditsTimer -= Time.deltaTime;

        if (CreditsTimer <= 0 || Input.anyKeyDown)
            SceneManager.LoadScene("MainMenu");
    }
}
