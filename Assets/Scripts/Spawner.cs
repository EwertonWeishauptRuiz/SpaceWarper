using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    public GameObject asteroid, ammoCrate, hologramCrate;   
    public Transform[] spawnSpaces;
    float asteroidSpawnTimer = .5f;    
    public Text warpSpeedDisplay;
    public GameObject[] indicatorsWarp;
    public GameObject insideSpeedHUD;

    int spawnQuantities;
    float myRotation;
        
    public ParticleSystem warpBlue, warpOrange;
    float warpSpeed, warpEmission = 1;

    Color alphaChannel;

    public Animator animator;
    bool stopIncrementing = false;

    void Start(){
        myRotation = insideSpeedHUD.transform.rotation.z;
        myRotation = -297.93f;
        insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
        warpSpeedDisplay.text = "1";        
        animator.speed = 0;
		//After 2 seconds of game spawn an ammo crate every 8 seconds.
        InvokeRepeating("SpawnAmmoCrate", 2f, 8f);
        //After 10 seconds of game spawn an Hologram Crate, every 22.5 seconds.
        InvokeRepeating("SpawnHologramCrate", 11f, 22.5f);
    }

    void Update () {
        AdjustWarpSpeed();
        GameSpawner();      
        asteroidSpawnTimer -= Time.deltaTime;        
    }

    void GameSpawner() {
        if (spawnQuantities <= 5 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(2, 4f);
            if(warpEmission < 80) {
                warpEmission = 2 * Time.time * 2.5f;
                if (warpEmission > 80) {
                    warpEmission = 80;
                }                   
            }
            if (warpSpeed < 30) {
                warpEmission = 2 * Time.time * 1.5f;
                if (warpSpeed > 30) {
                    warpSpeed = 30;
                }
            }
            myRotation = -297.93f;            
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
        }
        if (spawnQuantities <= 10 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(1.3f, 2f);
            warpSpeedDisplay.text = "2";
            warpEmission = 90;
            warpSpeed = 35;
            indicatorsWarp[0].SetActive(true);                        
            myRotation = 36f;
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
            animator.speed = 0.1f;            
        }
        if (spawnQuantities <= 20 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(1f, 1.5f);
            warpSpeedDisplay.text = "3";
            warpEmission = 100;
            warpSpeed = 40;
            indicatorsWarp[1].SetActive(true);
            myRotation = -2.5f;
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
            animator.speed = 0.2f;
        }
        if (spawnQuantities <= 30 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.8f, 1f);
            warpSpeedDisplay.text = "4";
            warpEmission = 105;
            warpSpeed = 50;
            indicatorsWarp[2].SetActive(true);
            myRotation = -44;
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
            animator.speed = 0.3f;
        }
        if (spawnQuantities <= 40 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.8f, .8f);
            warpSpeedDisplay.text = "5";
            warpEmission = 105;
            warpSpeed = 50;
            indicatorsWarp[3].SetActive(true);
            myRotation = -87;
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
            animator.speed = 0.4f;
        }
        if(spawnQuantities <= 50 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.5f, .8f);
            warpSpeedDisplay.text = "6";
            warpEmission = 110;
            warpSpeed = 55;
            indicatorsWarp[4].SetActive(true);
            myRotation = -120f;
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
            animator.speed = 0.5f;
        }
        if (spawnQuantities <= 60 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.35f, .65f);
            warpSpeedDisplay.text = "7";
            warpEmission = 115;
            warpSpeed = 60;
            indicatorsWarp[5].SetActive(true);
            myRotation = -143;
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
            animator.speed = 0.6f;
        }
        if (spawnQuantities <= 70 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.2f, .5f);
            warpSpeedDisplay.text = "8";
            warpEmission = 120;
            warpSpeed = 65;
            indicatorsWarp[6].SetActive(true);
            myRotation = -160f;
            insideSpeedHUD.transform.rotation = Quaternion.Euler(0, 0, myRotation);
            animator.speed = 0.7f;
        }
        if (spawnQuantities <= 80 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.2f, .45f);
            warpSpeedDisplay.text = "9";
            warpEmission = 120;
            warpSpeed = 68;
            animator.speed = 0.8f;
        }
        if (spawnQuantities <= 90 && asteroidSpawnTimer < 0) {
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.2f, .45f);            
            warpEmission = 125;
            warpSpeed = 70;                        
            animator.speed = 1;            
            stopIncrementing = true;
        }
        if(stopIncrementing && asteroidSpawnTimer < 0){
            SpawnAsteroid();
            asteroidSpawnTimer = Random.Range(.2f, .5f);            
            warpEmission = 125;
            warpSpeed = 70;            
            animator.speed = 1;            
            stopIncrementing = true;
        }
    }   

    void SpawnAsteroid() {
        Transform spawnPoint = spawnSpaces[Random.Range(0, spawnSpaces.Length)];
        Instantiate(asteroid, spawnPoint.position, Quaternion.identity);
        spawnQuantities++;
    }

    void SpawnAmmoCrate() {
        Transform spawnPoint = spawnSpaces[Random.Range(0, spawnSpaces.Length)];
        Instantiate(ammoCrate, spawnPoint.position, Quaternion.Euler(90,0,180));
    }    

    void SpawnHologramCrate() {
        Transform spawnPoint = spawnSpaces[Random.Range(0, spawnSpaces.Length)];
        Instantiate(hologramCrate, spawnPoint.position, Quaternion.Euler(90, 0, 180));
    }

    void AdjustWarpSpeed() {
        var mainBlue = warpBlue.main;
        var mainOrange = warpOrange.main;
        mainBlue.startSpeed = warpSpeed;
        mainOrange.startSpeed = warpSpeed;

        var emissionBlue = warpBlue.emission;
        var emissionOrange = warpOrange.emission;
        emissionBlue.rateOverTime = warpEmission;
        emissionOrange.rateOverTime = warpEmission;

        if (warpSpeed <= 20 && warpEmission <= 80) {
            warpSpeed = Time.timeSinceLevelLoad * 5;
            warpEmission = Time.timeSinceLevelLoad * 15;
        }
    }
}
