using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine;

public class UIBombsUsed : MonoBehaviour
{
    Text text;
    Movement player;
    void Start()
    {
        player = FindObjectOfType<Movement>();
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (text != null && player != null)
        {
            text.text = "x" + player.bombsUsed.ToString();
        }
    }
}
