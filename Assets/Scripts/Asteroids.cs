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
        
        if (gameManager.pointCounter > 5) {
            speed = Random.Range(100f, 250f);
        }
        if (gameManager.pointCounter > 20) {
            speed = Random.Range(200f, 350f);
        }
        if (gameManager.pointCounter > 30) {
            speed = Random.Range(250f, 750f);
        }
        if (gameManager.pointCounter > 50) {
            speed = Random.Range(350f, 550f);
        }
        if (gameManager.pointCounter > 60) {
            speed = Random.Range(500f, 700f);
        }
        if (gameManager.pointCounter > 70) {
            speed = Random.Range(700f, 900f);
        }
        if (gameManager.pointCounter > 80) {
            speed = Random.Range(700f, 900f);
        }
        if (gameManager.pointCounter > 90) {
            speed = Random.Range(800f, 950f);
        }
    }

    // Update is called once per frame
    void Update () {
        rbd.AddForce(0, 0, -speed * Time.deltaTime);
        float rotX = Random.Range(0.03f, 0.09f);
        float rotY = Random.Range(0.05f, 0.08f);
        transform.Rotate(Time.time * rotX, Time.time * rotY, 0);        
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player" || other.gameObject.tag == ("Kill")) {
            Destroy(gameObject);
        }
    }
}
