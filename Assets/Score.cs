[System.Serializable]
public class Highscore
{
    public string Name;
    public int Score;
}

[System.Serializable]
public class Scores
{
    public Highscore[] scores;
}