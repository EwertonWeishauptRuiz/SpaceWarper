using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int pointCounter;
    float points;
    float multiplier = 1;
    int targetScore = 10;
    
    public Text pointsDisplay;
    PlayerMovement player;
    GameObject speedCanvas;

    void Start(){
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
        int roundPoints = Mathf.RoundToInt(points);
        pointsDisplay.text = roundPoints.ToString();
    }

    void Multipliers(){            
        if (pointCounter > targetScore){
            targetScore += 10;
            multiplier += 0.1f;            
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid") {
            pointCounter++;            
            points = pointCounter * multiplier * 10;
        }
    }
    
    void PlayerDead(){
        speedCanvas.SetActive(false);
        pointsDisplay.GetComponent<Text>().enabled = false;    
    }

}
