using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerName : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    public Text nameText;
    public string newName;
    string storedName;
    bool nameChanged;
    bool inputActive;

    public GameObject inputFiled;
    public GameObject nameInstructions;
    InputField input;

    RotateObjectMenu rotateObject;
    
    void Start(){
        inputFiled.SetActive(false);
        nameInstructions.SetActive(false);
        input = inputFiled.GetComponent<InputField>();
        input.onValueChanged.AddListener(delegate { ValueChangeCheck(); });
        rotateObject = GameObject.Find("ShipHolder").GetComponent<RotateObjectMenu>();
    }

    // Update is called once per frame
    void Update() {
        ShowName();
        if (inputActive)
            rotateObject.canRotate = false;
    }

    void ShowName(){
        GetName();
        nameText.text = storedName;

        if(nameChanged){
            SavePlayerName();
        }
    }

    void GetName() {
        if (storedName == null) {
            storedName = PlayerPrefs.GetString("PlayerName");
        }
        nameText.text = storedName;
        rotateObject.canRotate = true;
    }

	public void GetText(){
		newName = input.text;
		//Flag for new Name
        nameChanged = true;  
        inputFiled.SetActive(false);
        inputActive = false;     
	}
    
    public void SavePlayerName() {
        PlayerPrefs.SetString("PlayerName", newName);
        if (storedName != newName) {
            storedName = newName;            
        }
    }

    public void OnPointerEnter(PointerEventData eventData) {
        nameInstructions.SetActive(true);
    }
    
    public void OnPointerExit(PointerEventData eventData) {
        nameInstructions.SetActive(false);
    } 

    public void OnPointerClick(PointerEventData eventData) {
        inputFiled.SetActive(true);
        inputActive = true;        
    }
    
    void ValueChangeCheck(){
     
    }
    
}
