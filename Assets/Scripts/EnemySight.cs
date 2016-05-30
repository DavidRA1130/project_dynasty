using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {
	public GameObject target;
	private GameObject myTransform;
	public int moveSpeed ;

	void Awake(){

		myTransform = this.gameObject;

	}

	void Start(){
	
		GameObject go = GameObject.FindGameObjectWithTag("Player");
		
		target = go;
	
	}

	void Update() {


		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Vector3 bkwd = transform.TransformDirection(Vector3.back);
		Vector3 left = transform.TransformDirection(Vector3.left);
		Vector3 right = transform.TransformDirection(Vector3.right);

		if (Physics.Raycast (transform.position, fwd, 10)) {
			print ("There is something in front of the object!");

			// Get a direction vector from us to the target
            Vector3 dir = target.GetComponent<Transform>().position - myTransform.GetComponent<Transform>().position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize ();
			
			// Move ourselves in that direction
			transform.position += dir * moveSpeed * Time.deltaTime;
            transform.eulerAngles = target.GetComponent<movement>().getRt();
		
		} else if (Physics.Raycast (transform.position, bkwd, 10)) {
		
			// Get a direction vector from us to the target
            Vector3 dir = target.GetComponent<Transform>().position - myTransform.GetComponent<Transform>().position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize ();
			
			// Move ourselves in that direction
			transform.position += dir * moveSpeed * Time.deltaTime;
            transform.eulerAngles = target.GetComponent<movement>().getRt();

		} else if (Physics.Raycast (transform.position, left, 10)) {

			// Get a direction vector from us to the target
            Vector3 dir = target.GetComponent<Transform>().position - myTransform.GetComponent<Transform>().position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize ();
			
			// Move ourselves in that direction
			transform.position += dir * moveSpeed * Time.deltaTime;
            transform.eulerAngles = target.GetComponent<movement>().getRt();
		
		} else if (Physics.Raycast (transform.position, right, 10)) {
		
			// Get a direction vector from us to the target
            Vector3 dir = target.GetComponent<Transform>().position - myTransform.GetComponent<Transform>().position;
			
			// Normalize it so that it's a unit direction vector
			dir.Normalize ();
			
			// Move ourselves in that direction
			transform.position += dir * moveSpeed * Time.deltaTime;
            transform.eulerAngles = target.GetComponent<movement>().getRt();
		
		}
	}
}

