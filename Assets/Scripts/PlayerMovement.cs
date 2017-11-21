using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rbd;
    public int thrust = 1000;
    public bool dead = false;

    public bool godMode;
	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();        
	}

    // Update is called once per frame
    void Update() {
        float h = Input.GetAxis("Horizontal") * thrust;
        float v = Input.GetAxis("Vertical") * thrust;
        rbd.AddForce(h, v, 0);
    
        if (Input.GetKey(KeyCode.A)) {            
            transform.rotation = Quaternion.Euler(15,-90, 0);
        } else if (Input.GetKey(KeyCode.D)) {            
            transform.rotation = Quaternion.Euler(-15, -90, 0);
        } else if (Input.GetKey(KeyCode.W)) {            
            transform.rotation = Quaternion.Euler(0, -90, 15);
        } else if (Input.GetKey(KeyCode.S)) {            
            transform.rotation = Quaternion.Euler(0, -90, -15);
        } else {
           transform.rotation = Quaternion.Euler(0,-90,0);
        }
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid" && !godMode) {
            print("Game Over");
            Destroy(gameObject);
            dead = true;
        }
        if (godMode){
            Physics.IgnoreLayerCollision(0,9,true);
        }
    }
}
