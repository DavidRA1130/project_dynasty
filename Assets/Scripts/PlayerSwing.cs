using UnityEngine;
using System.Collections;

public class PlayerSwing : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            return;
        }
        if (other.attachedRigidbody && other.tag != "Player")
        {
            Debug.Log("Hit");
        }
    }

	// Update is called once per frame
	void Update () {
        
    }
}
