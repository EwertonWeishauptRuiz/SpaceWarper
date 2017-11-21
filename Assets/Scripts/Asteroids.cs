using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour {

    Rigidbody rbd;
    float speed;
    float sizeX, sizeY, sizeZ;
    GameManager gameManager;
    Renderer mat;

    public Material[] mats;
    int targetPoints = 10;
    
    // Use this for initialization
    void Start () {
        rbd = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        mat = GetComponent<Renderer>();
        sizeX = Random.Range(1f, 2f);
        sizeY = Random.Range(1f, 2f);
        sizeZ = Random.Range(1f, 2f);
        transform.localScale = new Vector3(sizeX, sizeY, sizeZ);
        speed = Random.Range(80f, 120f);

        int matIndex = Random.Range(0, mats.Length);
        mat.material = mats[matIndex];
    }

    // Update is called once per frame
    void Update () {
        UpdateSpeed();
        rbd.AddForce(0, 0, -speed * Time.deltaTime);
        float rotX = Random.Range(0.03f, 0.09f);
        float rotY = Random.Range(0.05f, 0.08f);
        transform.Rotate(Time.unscaledTime * rotX, Time.unscaledTime * rotY, 0);        
    }
    
    void UpdateSpeed(){
        float speedMin = 100;
        float speedMax = 250;
        
        if(gameManager.pointCounter > targetPoints){
            targetPoints += 10;
            if(speedMin < 800 && speedMax < 950){
                speedMin += 50;
                speedMax += 50;
                print("Stop incrementing Speed");
            }
            speed = Random.Range(speedMin, speedMax);
            print("Updated Speed");
        }    
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == ("Kill")) {
            Destroy(gameObject);
        }
    }
    

}
