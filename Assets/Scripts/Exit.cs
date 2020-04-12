using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public FadeCamera fade;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            fade.RedoFade();
            Invoke("Load", 2);
        }
    }
    public void Load()
    {
        SceneManager.LoadScene("WinScene");
    }
}
