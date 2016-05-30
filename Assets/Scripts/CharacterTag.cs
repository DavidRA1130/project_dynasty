using UnityEngine;
using System.Collections;

public class CharacterTag : MonoBehaviour {

	// Use this for initialization
	//public GameObject Obj;
	public CanvasGroup cg;
	
	void Start()
	{
		//Obj = GameObject.Find ("Enemy");

		cg.alpha = 0;


		
	}

	public void turnVisible(){

		cg.alpha = 1;
	
	}

	public void turnInvisible(){
		cg.alpha = 0;
	}
	
	void Update ()
	{


	}
}
