using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rbd;

    public int thrust = 1000;
	// Use this for initialization
	void Start () {
        rbd = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A)) {
            rbd.AddForce(-thrust, 0, 0);
            transform.rotation = Quaternion.Euler(15,-90, 0);
        } else if (Input.GetKey(KeyCode.D)) {
            rbd.AddForce(thrust, 0, 0);
            transform.rotation = Quaternion.Euler(-15, -90, 0);
        } else if (Input.GetKey(KeyCode.W)) {
            rbd.AddForce(0, thrust, 0);
            transform.rotation = Quaternion.Euler(0, -90, 15);
        } else if (Input.GetKey(KeyCode.S)) {
            rbd.AddForce(0, -thrust, 0);
            transform.rotation = Quaternion.Euler(0, -90, -15);
        } else {
           transform.rotation = Quaternion.Euler(0,-90,0);
        }
    }
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Asteroid") {
            print("Game Over");
            Destroy(gameObject);
        }
    }
}
