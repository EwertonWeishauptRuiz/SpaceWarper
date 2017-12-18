using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {

    Rigidbody rbd;
    public int thrust = 1000;
    public bool dead = false;    
    public int blasterDamage;
    float h, v;
    float range = 100;
    public int blasterCount;

    public GameObject mainCameram, hitParticle;

    public ParticleSystem blaster;
    
    public Transform shootOrigin;
    public LayerMask collisionMask;
    Vector3 shootOriginPosition;

    public Text blasterCountText, blasterEfficiency;
    public GameObject pickupText;
	Text pickupTextString;

    GameObject[] shipComponents;

    public Color[] colors;

    public bool godMode;
	// Use this for initialization
	void Start () {
        blasterDamage = 25;     
        blaster.Stop();
        pickupText.SetActive(false);        
        rbd = GetComponent<Rigidbody>();        
        pickupTextString = pickupText.GetComponent<Text>();
        Time.timeScale = 1;
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
        DamageMultiplier();

        if (godMode) {
            Physics.IgnoreLayerCollision(0, 9, true);
        } else {
            Physics.IgnoreLayerCollision(0, 9, false);
        }
    }
    
    
	void Shoot(){   
        if(Input.GetButtonDown("Fire1") && blasterCount > 0){
            //Blaster Particle play
            blaster.Play();
            blasterCount--;
            RaycastHit hit;
            if(Physics.Raycast(shootOriginPosition, shootOrigin.right * range, out hit, range, collisionMask)){
                Asteroids asteroids = hit.transform.GetComponent<Asteroids>();
                if(asteroids != null){
                    Instantiate(hitParticle, hit.transform.position, Quaternion.identity);
                    asteroids.TakeHit(blasterDamage);
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
        blasterEfficiency.text = "Blaster Efficiency at: " + blasterDamage.ToString() + "%";
    }
	
    IEnumerator PickUpUI(GameObject go, Text textUI, string text, float timer){
        go.SetActive(true);
        textUI.text = text;
        yield return new WaitForSeconds(timer);
        go.SetActive(false);
    }
    
    void OnCollisionEnter(Collision other) {
		if (other.gameObject.tag == "Asteroid" && !godMode) {
			print("Game Over");
			Destroy(gameObject);
			dead = true;
            Time.timeScale = 0;            
		}
	}
    
    void OnTriggerEnter(Collider other){
        if (other.gameObject.tag == "AmmoCrate") {
			blasterCount += 10;            
            StartCoroutine(PickUpUI(pickupText, pickupTextString, "+10 Blasters", 2));       
        }      
        if(other.gameObject.tag == "HologramCrate") {
            print("Got the HoloCrate");
            StartCoroutine("GodMode");
            StartCoroutine(PickUpUI(pickupText, pickupTextString, "5 Seconds Invulnerability", 2));
        }
    }
    
    IEnumerator GodMode() {        
        godMode = true;
        yield return new WaitForSeconds(5.2f);
        godMode = false;        
    }

    void DamageMultiplier(){
        if(blasterCount == 0) {
            blasterCountText.color = Color.red;
        } else {
            blasterCountText.color = Color.white;
        }
        if (blasterCount > 40) {
            blasterDamage = 100;
            blasterEfficiency.color = colors[0];
        } else if (blasterCount > 30) {
            blasterDamage = 75;
            blasterEfficiency.color = colors[1];
        } else if (blasterCount > 20) {
            blasterDamage = 50;
            blasterEfficiency.color = colors[2];
        } else {
            blasterDamage = 25;
            blasterEfficiency.color = colors[3];
        }
    }
}
