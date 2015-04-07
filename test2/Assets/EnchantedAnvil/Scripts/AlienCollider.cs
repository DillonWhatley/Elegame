using UnityEngine;
using System.Collections;


public class AlienCollider : MonoBehaviour {

	private int eleCount;
	public GUIText eleCountText;
	
	void Start (){
		eleCount = 0;
		eleCountText.text = "0";
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Pickup") {
			other.gameObject.SetActive(false);
			eleCount ++;
			eleCountText.text = eleCount.ToString();
		}
	}
}
