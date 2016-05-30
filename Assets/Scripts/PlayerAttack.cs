using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour {

    //public GameObject Player;
    public DWeapon Weapon;
    public Collider self;
    private bool isSheathed;
    private Renderer rend;

	// Use this for initialization
	void Start () {
        Weapon.setSeath(false);
	}

	// Update is called once per frame
	void Update () {

        if(Input.GetMouseButton(0))
        {
            Weapon.setSeath(true);
        }
        else
        {
        Weapon.setSeath(false);
        }
	}
}
