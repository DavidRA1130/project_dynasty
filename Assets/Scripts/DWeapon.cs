using UnityEngine;
using System.Collections;

public class DWeapon : MonoBehaviour {

    public string WeaponName;
    public WEAPONTYPES WeaponType;
    public WEAPONELEMENT WeaponElement;
    private Renderer rend;
    private Collider self;
    private const float FORCE = 2.0f;
	bool hitStatus = false;
    bool dmgStatus = false;


    void Awake()
    {
        self = GetComponent<Collider>();

		//status = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player_ch")
        {
            Debug.Log("Hit Player!");
        }
    }

	public void OnTriggerExit(Collider other){
        if (other.tag == "Player_ch")
        {
            hitStatus = false;
        }
        else if (other.tag == "Enemy") {
            dmgStatus = false;
        }
	}


    public void OnTriggerStay(Collider other)
    {


        if (other.tag == "Player_ch") {
            other.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-950, 0, 0));

            hitStatus = true;
        }
        else if(other.tag == "Enemy"){
            other.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-950, 0, 0));
            dmgStatus = true;
            //Debug.Log("You got me!");
        }
		//else {
//			trackHit(false);
//		}
    }

	public bool trackHit(bool hit){
		if (hit == hitStatus) {
			return true;
		} else {
			return false;
		}
//		status = hit;
//		return status;

	}

    public bool trackDmg(bool hit)
    {
        if (hit == dmgStatus)
        {
            return true;
        }
        else {
            return false;
        }
    }


    public void setSeath(bool seth)
    {
        rend.gameObject.SetActive(seth);
    }

    public enum WEAPONTYPES
    {
        NONE,
        //MELEE Weapons
        SWORD,
        AXE,
        THSWORD,
        LANCE,
        SPEAR,
        //RANGED Weapons
        BOW,
        GUN,
        JAVELIN,
        //MAGIC Weapons
        WSTAFF,
        LSTAFF,
    }

    public enum WEAPONELEMENT
    {
        NONE,
        FIRE,
        WATER,
        WIND,
        EARTH,
        LIGHT,
        DARK,
        MAGNITE
    }


	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        rend.gameObject.SetActive(false);
		hitStatus = false;
        dmgStatus = false;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
