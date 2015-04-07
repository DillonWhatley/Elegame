using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public Text UItext;
	int UIint;

	void Start () {
		UIint = 0;
	}
	
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive(false);
			updateText();
		}
	}

	void updateText(){
		UIint ++;

		UItext.text = "Elebits Collected:"+ UIint.ToString();
	}

}
