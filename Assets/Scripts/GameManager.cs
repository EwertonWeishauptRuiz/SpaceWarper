using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int pointCounter;

    string name;
    float points;
    float multiplier = 1;
    int targetScore = 10;
    [HideInInspector]
    public int finalScore;
    [HideInInspector]
    public int roundPoints;
    
    public Text pointsDisplay;
    PlayerMovement player;
    HighScoreManager scoreManager;
    GameObject speedCanvas;
    public GameObject highscoreHolder;

    void Start(){
        if(name == null){
            name = PlayerPrefs.GetString("name");
        }
    
        finalScore = 0;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        scoreManager = GetComponent<HighScoreManager>();
        speedCanvas = GameObject.Find("SpeedIndicator");
        highscoreHolder.SetActive(false);    
    }
    
    void Update() {
        if(!player.dead){
			DisplayPoints();
			Multipliers();         
        } else {
            PlayerDead(roundPoints);
        }
    }     

    void DisplayPoints() {
        roundPoints = Mathf.RoundToInt(points);
        pointsDisplay.text = roundPoints.ToString();
    }

    void Multipliers(){            
        if (pointCounter > targetScore){
            targetScore += 10;
            multiplier += 0.1f;            
        }
    }
        
    void PlayerDead(int points){
        speedCanvas.SetActive(false);
        pointsDisplay.GetComponent<Text>().enabled = false;        
        print("Score is " + points + " and the player is " + PlayerPrefs.GetString("PlayerName"));
		highscoreHolder.SetActive(true);
        scoreManager.CheckHighScores(PlayerPrefs.GetString("PlayerName"), finalScore); 
    }
    
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid") {
            pointCounter++;            
            points = pointCounter * multiplier * 10;
            print("Should add points");
        }
    }
}
