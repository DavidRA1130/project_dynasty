using UnityEngine;
using System.Collections;

//This is a test script to see whether we can break up 
//the track and attack behavior into two seperate scripts

//EDIT: the test was successful


public class EnemySight_test1 : MonoBehaviour {


	public GameObject target;
    public GameObject startingPosition;
    private GameObject myTransform;
	//public GameObject sword;
	public int moveSpeed;
	public float atkRange;
	public CharacterTag characterTag;
	float timePassed, atkTimePassed;
	NavMeshAgent Enemy;
	public float attackSpeed;
	public DWeapon dWeapon;
	public CooldownTimer cooldowntimer;
	bool confirmedHit, attackReady;
	public PlayerDetect playerDetect;
    //float startingPosition;

	//bool isHit = false;

	void AttackEnemy(Vector3 center, float radius){

        Collider[] atkColliders = Physics.OverlapSphere(center, radius);

        

        if (playerDetect.isPlayerFound(true))
        {
            //activate nametag for this enemy			
            characterTag.turnVisible();

            //give chase
            Enemy.destination = target.GetComponent<Transform> ().position;

            for (var i = 0; i < atkColliders.Length; i++)
            {

                if (cooldowntimer.getRestSeconds() <= 0)
                {
                    attackReady = true;
                    confirmedHit = false;
                }
                else if (confirmedHit == true)
                {
                    Enemy.speed = 0f;
                }
                else {
                    Enemy.speed = 3.5f;
                }


                if (atkColliders[i].tag == "Player_ch" && attackReady == true)
                {
                    print("Begin attack");

                    atkTimePassed = Time.time;

                    Enemy.speed = Enemy.speed + attackSpeed;

                    if (dWeapon.trackHit(true))
                    {//fixed but now needs to slow down even if it misses
                        print("Completed attack");

                        confirmedHit = true;//needed for stopping after each hit?

                        attackReady = false;

                        Enemy.speed = 0f;

                        cooldowntimer.RestartTime(5);
                    }
                    else {
                        print("Hasn't struck");

                        if (Time.time > atkTimePassed + 3 && attackReady == true)
                            attackReady = false;
                        cooldowntimer.RestartTime(5);
                        //Enemy.speed = 3.5f;
                    }
                }
                else if (atkColliders[i].tag != "Player_ch" && attackReady == false && confirmedHit == false)
                {//&& Time.time > atkTimePassed+5
                    print("Too long since last struck");

                    Enemy.speed = 3.5f;
                }

            }
        }
        else
        {
            characterTag.turnInvisible();
            Enemy.destination = startingPosition.GetComponent<Transform>().position;
        }
	}
	
	//void DetectEnemy(Vector3 center, float radius){
		
	//	Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		
		
		
		
	//	for (var i = 0; i < hitColliders.Length; i++) {
	//		// collect information on the hits here
	//		//print(hitColliders[i].tag);
			
	//		if (hitColliders[i].tag == "Player_ch"){
				
	//			//print ("Found Player!");
				
	//			//activate nametag for this enemy			
	//			characterTag.turnVisible();
				
	//			//Set the current point in time it has run into a player 
	//			timePassed = Time.time;

	//			//give chase
	//			Enemy.destination = target.GetComponent<Transform> ().position;
				

				
	//		}
			
	//		if(hitColliders[i].tag != "Player_ch" && Time.time > timePassed+5){
	//			//hide the enemy nametag
	//			characterTag.turnInvisible();
	//		}
			
	//		//transform.eulerAngles = target.GetComponent<movement>().getRt();
	//	}
		
		
	//}

	void Awake(){
		
		myTransform = this.gameObject;
		
	}

	void Start(){
		
		GameObject go = GameObject.FindGameObjectWithTag("Player_ch");
		
		target = go;

		GameObject spawn = GameObject.FindGameObjectWithTag ("Respawn");

		startingPosition = spawn; 

		NavMeshAgent agent = GetComponent<NavMeshAgent>();

		Enemy = agent;

		//confirmedHit = false;

		attackReady = true;

		cooldowntimer.startTimer (5);

        

    }


	void Update(){



		//DetectEnemy(transform.position, DetectRange); // create new functing for attacking
		AttackEnemy (transform.position, atkRange); //range 0.5f?
		
	}


}
