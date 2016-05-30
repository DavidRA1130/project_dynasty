using UnityEngine;
using System.Collections;

public class PlayerCollision : MonoBehaviour {
	
    void OnTriggerEnter()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sword")
        {
            Debug.Log("Attacked");
            //return;
        }

        if (other.attachedRigidbody && other.tag != "Sword")
        {
            //Debug.Log("Damaged");
        }
    }


	// Update is called once per frame
	void Update () {
	
	}
}
