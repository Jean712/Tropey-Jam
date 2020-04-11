using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsManager : MonoBehaviour
{
    [SerializeField]
    private float CreditsTimer;
    
    private void Update()
    {
        CreditsTimer -= Time.deltaTime;
        
        if (CreditsTimer <= 0 || Input.anyKeyDown)
            Application.Quit();
    }
}
