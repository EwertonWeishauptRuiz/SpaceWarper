using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour {

    Rigidbody rbd;
    public int thrust = 1000;
    public bool dead = false;
    public int asteroidDamage;
    float h, v;
    float range = 100;
    public int blasterCount;

    public ParticleSystem blaster;

    Camera cam;
    public Transform shootOrigin;
    public LayerMask collisionMask;
    Vector3 shootOriginPosition;

    public Text blasterCountText;

    public bool godMode;
	// Use this for initialization
	void Start () {        
        blaster.Stop();
        rbd = GetComponent<Rigidbody>();
        cam = Camera.main;        
    }

    // Update is called once per frame
    void Update() {
		shootOriginPosition = shootOrigin.transform.position;        
        h = Input.GetAxis("Horizontal") * thrust;
        v = Input.GetAxis("Vertical") * thrust;
        rbd.AddForce(h, v, 0);  
        
        RotateShip();
        Shoot();
    
		UI(); 
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
    
    void Shoot(){   
        if(Input.GetButtonDown("Fire1") && blasterCount > 0){            
			blaster.Play();
            blasterCount--;
            RaycastHit hit;
            if(Physics.Raycast(shootOriginPosition, shootOrigin.right * range, out hit, range, collisionMask)){
                Asteroids asteroids = hit.transform.GetComponent<Asteroids>();
                if(asteroids != null){
                    asteroids.TakeHit(asteroidDamage);
                }                
            }
        }
    }
    
    void RotateShip(){
		if (h < 0) {            
			transform.rotation = Quaternion.Euler(15,-90, 0);
		} else if (h > 0) {            
			transform.rotation = Quaternion.Euler(-15, -90, 0);
		} else if (v > 0) {            
			transform.rotation = Quaternion.Euler(0, -90, 15);
		} else if (v < 0) {            
			transform.rotation = Quaternion.Euler(0, -90, -15);
		} else {
			transform.rotation = Quaternion.Euler(0,-90,0);
		}
    }
    
    void UI(){
        blasterCountText.text = "Blasters: " + blasterCount.ToString();
    }
}
