using UnityEngine;
using System.Collections;

public class AttackForce : MonoBehaviour {

    public Collider Self;
    private const float FORCE = 25.0f;

	// Use this for initialization
	void Start () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -5) * FORCE);
        //Vector3.Reflect(other.GetComponent<Rigidbody>().position, Vector3.right);
    }

    void OnTriggerStay(Collider other)
    {
        other.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, 0, -5) * FORCE);
        //Vector3.Reflect(other.GetComponent<Rigidbody>().position, Vector3.right);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
