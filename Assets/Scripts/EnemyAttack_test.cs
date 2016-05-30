using UnityEngine;
using System.Collections;

public class EnemyAttack_test : MonoBehaviour {

    //public GameObject Player;
    public DWeapon Weapon;
    public Collider self;
    private bool isSheathed;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        Weapon.setSeath(false);
	}


    void OnTriggerEnter(Collider other)
    {
        //Collider self = GetComponent<Collider>();
        if (other.tag == "Player_ch")
        {
            Weapon.setSeath(true);
        }
        else
        {
            Weapon.setSeath(false);
        }
    }


    void OnTriggerStay(Collider other)
    {
        
        //Collider self = GetComponent<Collider>();
        if (other.tag == "Player_ch")
        {
            Weapon.setSeath(true);
        }
    }

    void OnTriggerExit()
    {
        Weapon.setSeath(false);
    }

	// Update is called once per frame
	void Update () {
	
	}
}
