//This is the behavior script for the camera so that it constantly follows the player at a fixed angle 

using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	// Use this for initialization
	public GameObject Player;
	public Vector3 Offset;
    Vector3 EnemyRotation;
	
    void Start()
    {
        Player = GameObject.Find("Player");

    }

	void LateUpdate ()
	{
		if (Player != null)
			transform.position = Player.GetComponent<Transform>().position + Offset;
	}
}