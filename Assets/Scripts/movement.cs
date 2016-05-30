using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {

	public GameObject player;
	Vector3 rt;
    
	public float speed = 10.0f;
	//float recoveryRate = 5.0f;
    float Jumptimer;
	public bool useGamepad;


	
	void Update() 
	{
		if (useGamepad) {
			controllerMvmt();
		} else {
			keyboardMvmt();
		
		}
	}
	void controllerMvmt(){
		var tr = transform;
		var pos = transform.position;

		if (Input.GetAxis ("LEFT&RIGHT") < -0.3 || Input.GetAxis ("LEFT&RIGHT") > 0.3 || Input.GetAxis ("UP&DOWN") < -0.3 || Input.GetAxis ("UP&DOWN") > 0.3) {
			pos += new Vector3 (Input.GetAxis ("LEFT&RIGHT"), 0, Input.GetAxis ("UP&DOWN"));
			//print("LEFT&RIGHT: "+Input.GetAxis ("LEFT&RIGHT")+" UP&DOWN: "+Input.GetAxis ("UP&DOWN"));
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, Mathf.Atan2(Input.GetAxis ("LEFT&RIGHT"), Input.GetAxis ("UP&DOWN")) * Mathf.Rad2Deg, player.transform.eulerAngles.z); //player.transform.eulerAngles.y
			rt = transform.eulerAngles;
		}
		else {
			transform.position = pos;
			//print("LEFT&RIGHT: "+Input.GetAxis ("LEFT&RIGHT")+" UP&DOWN: "+Input.GetAxis ("UP&DOWN"));;
		}
	}

	void keyboardMvmt(){
		var tr = transform;
		var pos = transform.position;
		Jumptimer += Time.deltaTime;

		//Jump
		while(Input.GetKey(KeyCode.Space) && transform.position == pos && Jumptimer > 0.5f)
		{
			int x = 0;
			x += 100;
			pos += new Vector3(0, x, 0);
			transform.position = Vector3.MoveTowards(tr.position, pos, Time.deltaTime * speed);
			if(x >= 300)
			{
				x = 0;
				pos += new Vector3(0, x, 0);
				transform.position = Vector3.MoveTowards(tr.position, pos, Time.deltaTime * speed);
				Jumptimer = 0;
			}
		}
		
		//move forward and to the right 
		if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.D) && transform.position == pos) {
			
			
			pos += new Vector3 (-5000, 0, 5000);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 315, 0);
			rt = transform.eulerAngles;
			
			//move forward and to the left
		} else if (Input.GetKey (KeyCode.W) && Input.GetKey (KeyCode.A) && transform.position == pos) {
			
			pos += new Vector3 (-5000, 0, -5000);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 225, 0);
			rt = transform.eulerAngles;
			
			//move backward and left
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.A) && transform.position == pos) {
			
			pos += new Vector3 (5000, 0, -5000);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 135, 0);
			rt = transform.eulerAngles;
			
			//move backward and right
		} else if (Input.GetKey (KeyCode.S) && Input.GetKey (KeyCode.D) && transform.position == pos) {
			
			pos += new Vector3 (5000, 0, 5000);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 45, 0);
			rt = transform.eulerAngles;
			
			
			//move left
		} else if (Input.GetKey (KeyCode.A) && tr.position == pos) { 
			
			pos += new Vector3 (0, 0, -5000);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 180, 0);
			rt = transform.eulerAngles;
			
			//move right
		} else if (Input.GetKey (KeyCode.D) && transform.position == pos) {
			
			pos += new Vector3 (0, 0, 5000);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 0, 0);
			rt = transform.eulerAngles;
			
			
			//move backward
		} else if (Input.GetKey (KeyCode.S) && transform.position == pos) {
			
			pos += new Vector3 (5000, 0, 0);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 90, 0);;
			rt = transform.eulerAngles;
			
			//move forward
		} else if (Input.GetKey (KeyCode.W) && transform.position == pos) {
			
			pos += new Vector3 (-5000, 0, 0);
			transform.position = Vector3.MoveTowards (tr.position, pos, Time.deltaTime * speed);
			transform.eulerAngles = new Vector3(0, 270, 0);
			rt = transform.eulerAngles;
			
			
			//remain at last recorded coordinates
		} else {
			pos = transform.position;
		}
	}

    public Vector3 getRt()
    {
        return rt;
    }
}