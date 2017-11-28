using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    public int pointCounter;
    float points;
    float multiplier = 1;
    int targetScore = 10;
    [HideInInspector]
    public int finalScore;
    [HideInInspector]
    public int roundPoints;
    
    public Text pointsDisplay;
    PlayerMovement player;
    GameObject speedCanvas;

    void Start(){
        finalScore = 0;
        player = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        speedCanvas = GameObject.Find("SpeedIndicator");
    }
    
    void Update() {
        if(!player.dead){
			DisplayPoints();
			Multipliers();         
        } else {
            PlayerDead();
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
        
    void PlayerDead(){
        speedCanvas.SetActive(false);
        pointsDisplay.GetComponent<Text>().enabled = false;
        roundPoints = finalScore;  
    }
    
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid") {
            pointCounter++;            
            points = pointCounter * multiplier * 10;
            print("Should add points");
        }
    }
}
