using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetHighscores : MonoBehaviour
{

    public Scores scores;
    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("HighscoreList").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void PostHighScore(string playerName, int highscore)
    {
        string URL = "https://score.edv-bitches.de";
        string json = "{'Game':'ccc','Name':'" + playerName + "','Score':" + highscore + "}";

        Dictionary<string, string> headers = new Dictionary<string, string>();

        headers.Add("Content-Type", "application/json");

        json = json.Replace("'", "\"");

        Debug.Log(json);
        //Encode the JSON string into a bytes
        byte[] postData = System.Text.Encoding.UTF8.GetBytes(json);
        //Now we call a new WWW request
        WWW www = new WWW(URL, postData, headers);
        //And we start a new co routine in Unity and wait for the response.
        StartCoroutine(WaitForRequest(www));
    }
    //Wait for the www Request
    IEnumerator WaitForRequest(WWW www)
    {
        yield return www;
        if (www.error == null)
        {
            string highscoreText = "Highscores:\n";

            Debug.Log(www.text);
            scores = JsonUtility.FromJson<Scores>("{\"scores\":" + www.text + "}");
            for (int i = 0; i < scores.scores.Length; i++)
            {
                highscoreText += (i + 1) + ". " + scores.scores[i].Name + " - " + scores.scores[i].Score + "\n";
            }
            text.SetText(highscoreText);

            //Print server response
        }
        else
        {
            //Something goes wrong, print the error response
            Debug.Log(www.error);
        }
    }
}