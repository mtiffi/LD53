using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitText : MonoBehaviour
{
    public string text;
    private TextMeshProUGUI textMeshProUGUIMain;
    private TextMeshProUGUI textMeshProUGUIDetails;
    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUIMain = GetComponent<TextMeshProUGUI>();
        textMeshProUGUIDetails = GameObject.Find("Details").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (textMeshProUGUIMain.color.a >= 0)
        {
            textMeshProUGUIMain.color = new Color(textMeshProUGUIMain.color.r, textMeshProUGUIMain.color.g, textMeshProUGUIMain.color.b, textMeshProUGUIMain.color.a - fadeSpeed);
            textMeshProUGUIDetails.color = new Color(textMeshProUGUIDetails.color.r, textMeshProUGUIDetails.color.g, textMeshProUGUIDetails.color.b, textMeshProUGUIDetails.color.a - fadeSpeed);

        }
    }

    public void changeText(string mainText, string details, bool green)
    {
        textMeshProUGUIMain.text = mainText;
        textMeshProUGUIDetails.text = details;
        if (green)
        {
            textMeshProUGUIMain.color = Color.green;
            textMeshProUGUIDetails.color = Color.green;
        }
        else
        {
            textMeshProUGUIMain.color = Color.red;
            textMeshProUGUIDetails.color = Color.red;
        }
    }
}
