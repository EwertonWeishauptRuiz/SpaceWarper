using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreManager : MonoBehaviour {

    static HighScoreManager instance;
    int leaderBoardLenght = 5;

    public static HighScoreManager scoreManager {
        get {
        //If there is no HighScore Manager to the scene, add it.
            if(instance == null){
                instance = new GameObject("HighScore Manager").AddComponent<HighScoreManager>();
            }
            return instance;
        }
    }

    void Awake(){
        if(instance == null){
            instance = this;
        } else if (instance != this){
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void SaveHighScore(string name, int score) {
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while (i < leaderBoardLenght && PlayerPrefs.HasKey("HighScore" + i + "score")){
            Scores temporary = new Scores();
            temporary.name = PlayerPrefs.GetString("HighScore" + i + "score");
            temporary.score = PlayerPrefs.GetInt("HighScore" + i + "name");
            HighScores.Add(temporary);
            i++;
        }

        if (HighScores.Count == 0)
        {
            Scores temporary = new Scores();
            temporary.name = name;
            temporary.score = score;
            HighScores.Add(temporary);
        } else {
            for (i = 1; i <= HighScores.Count && i <= leaderBoardLenght; i++){
                if(score > HighScores[ i - 1].score){
                    Scores temporary = new Scores();
                    temporary.name = name;
                    temporary.score = score;
                    HighScores.Insert(i -1, temporary);
                    break;
                }
                if( i == HighScores.Count && i < leaderBoardLenght){
                    Scores temporary = new Scores();
                    temporary.name = name;
                    temporary.score = score;
                    HighScores.Add(temporary);
                    break;
                }
            }
        }
    }
    
    public List<Scores> GetHighScore(){
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while(i <= leaderBoardLenght && PlayerPrefs.HasKey("HighScores" + i + "scores")){
            Scores temporary = new Scores();
			temporary.name = PlayerPrefs.GetString("HighScore" + i + "name");
            temporary.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            HighScores.Add(temporary);
            i++;
        }
        return HighScores;
    }

    public void ClearLeaderBoards(){
        List<Scores> HighScore = GetHighScore();

        for (int i = 1; i <= HighScore.Count; i++){
            PlayerPrefs.DeleteKey("HighScore" + i + "name");
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
        }
    }

    void OnApplicationQuit() {
        PlayerPrefs.Save();
    }
    
    //Nested Class. 
    public class Scores {
        public int score;
        public string name;        
    }
}
