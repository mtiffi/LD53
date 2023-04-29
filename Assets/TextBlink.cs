using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextBlink : MonoBehaviour
{
    private TextMeshProUGUI text;
    public float blinkSpeed;

    private bool goingUp;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!goingUp)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - blinkSpeed);
        }
        if (goingUp)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + blinkSpeed);
        }
        if (text.color.a < .2f)
        {
            goingUp = true;
        }
        if (text.color.a > .99f)
        {
            goingUp = false;
        }
    }
}
