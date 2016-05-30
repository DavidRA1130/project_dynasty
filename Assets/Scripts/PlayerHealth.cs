using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject healthBar;
	
	void Start () {
		cur_Health = max_Health;
	}

	void Update(){
		if (Input.GetKeyDown ("1")) {
			if(cur_Health >= 1){
				decreaseHealth(1f);
			}
		}
		else if (Input.GetKeyDown ("2")) {
			if(cur_Health >= 5){
				decreaseHealth(5f);
			}
			else{
				decreaseHealth(cur_Health); //prevents the health from going further than the bar
			}
		}
		else if (Input.GetKeyDown ("3")) {
			if(cur_Health >= 10){
				decreaseHealth(10f);
			}
			else{
				decreaseHealth(cur_Health);
			}
		}
	}

	void decreaseHealth(float dmg){
		cur_Health -= dmg;
		float calc_Health = cur_Health / max_Health; //returns float between 0 & 1, for scaling bar
		SetHealthBar (calc_Health);
	}

	void SetHealthBar(float myHealth){
		//where the bar gets scaled
		healthBar.transform.localScale = new Vector3 (myHealth, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
	}
}
