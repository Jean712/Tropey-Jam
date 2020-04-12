using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField]
    private GameObject OptionCanvas = new GameObject();
    [SerializeField]
    private GameObject MenuCanvas = new GameObject();

    private void Awake()
    {
        OptionCanvas.SetActive(false);
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }

    public void OpenOptions()
    {
        MenuCanvas.SetActive(false);
        OptionCanvas.SetActive(true);
    }

    public void CloseOptions()
    {
        OptionCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }
}
