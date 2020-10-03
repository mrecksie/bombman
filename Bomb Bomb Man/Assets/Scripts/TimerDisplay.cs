using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDisplay : MonoBehaviour
{
    Movement player;
    RectTransform display;
    float xOfAverageScale = -6.3f;
    private void Awake()
    {
        player = FindObjectOfType<Movement>();
        display = GetComponent<RectTransform>();

    }
    void Update()
    {

        if (player == null) { return; }
        if (player.timer / player.playerTime <= 0)
        {
            transform.localScale = new Vector3(0, display.localScale.y);
            return;
        }

        transform.localScale = new Vector3(player.timer / player.playerTime * xOfAverageScale, display.localScale.y);
    }
}