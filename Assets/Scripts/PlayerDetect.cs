using UnityEngine;
using System.Collections;


//This is the script to make the controller responsible for sending out 
//enemies when a player is within its range.

public class PlayerDetect : MonoBehaviour {

    bool playerFound;
    float timeSpotted;
    public float detectRange;

    void DetectEnemy(Vector3 center, float radius)
    {

        Collider[] hitColliders = Physics.OverlapSphere(center, radius);

        for (var i = 0; i < hitColliders.Length; i++)
        {
            // collect information on the hits here
            //print(hitColliders[i].tag);

            if (hitColliders[i].tag == "Player_ch")
            {
                playerFound = true;
                timeSpotted = Time.time;

            }
            else if (hitColliders[i].tag != "Player_ch" && Time.time > timeSpotted + 3)
            {
                playerFound = false;
            }
        }
    }

    public bool isPlayerFound(bool found)
    {
        if (found == playerFound)
        {
            return true;
        }
        else {
            return false;
        }
        //		status = hit;
        //		return status;

    }

    // Use this for initialization
    void Start () {

        playerFound = false;
	}
	
	// Update is called once per frame
	void Update () {
        DetectEnemy(transform.position, detectRange);
	}
}
