using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour
{
    private Text score;

    private void Start()
    {
        score = GetComponent<Text>();
        score.text = Inventory.finalValue.ToString();
    }
}
