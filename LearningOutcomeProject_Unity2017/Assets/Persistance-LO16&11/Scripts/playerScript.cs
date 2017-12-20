using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
	public string playerName;
	public GameObject InputField;

	void Start(){
		GameObject.Find ("InputField");
		InputField.GetComponent<InputField> ().text = "Bob";
	}

	void Update(){
		playerName = InputField.GetComponent<InputField> ().text;
	}
}
