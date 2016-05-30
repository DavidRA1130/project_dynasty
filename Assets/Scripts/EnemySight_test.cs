//CURRENT GOAL:
//Current goal is to make an evade function. To do this, we'll need to find a way to gather whether we've been struck or not


using UnityEngine;
using System.Collections;

public class EnemySight_test : MonoBehaviour {


	public GameObject target;
	private GameObject myTransform;
	//public GameObject sword;
	public int moveSpeed;
	public float DetectRange;
	public float atkRange;
	public CharacterTag characterTag;
	float timePassed, atkTimePassed;
	NavMeshAgent Enemy;
	public float attackSpeed;
	public DWeapon dWeapon;
	public CooldownTimer cooldowntimer;
	bool confirmedHit;
	bool attackReady;
    int offense;
    int defense;

    //bool isHit = false;

    void Evade() {
        //FIX THIS LINE
        //Enemy.transform.position = Vector3.MoveTowards(avoid, avoid + 100 , Time.deltaTime * speed);
        Enemy.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(-950, 0, 0));
    }

    void AggroMeter() { //goal here is to evaluate damage taken versus damage recieved and then formulate the next move based on this data

        if (defense > offense) {
            Evade();
        }

    }

	void AttackEnemy(Vector3 center, float radius){
		
		Collider[] atkColliders = Physics.OverlapSphere(center, radius);
		
		for (var i = 0; i < atkColliders.Length; i++) {

			if(cooldowntimer.getRestSeconds() <=0){
				attackReady = true;
				confirmedHit = false;
			}else if(confirmedHit == true){
				Enemy.speed = 0f;
			}else{
				Enemy.speed = 3.5f;
			}


			if(atkColliders[i].tag == "Player_ch" && attackReady == true){
				print ("Begin attack");

				atkTimePassed = Time.time;

				Enemy.speed = Enemy.speed + attackSpeed;

                if (dWeapon.trackHit(true)) {//fixed but now needs to slow down even if it misses //NOTE: it does already
                    print("Completed attack");

                    confirmedHit = true;//needed for stopping after each hit?

                    attackReady = false;

                    Enemy.speed = 0f;

                    offense += 1;
                    defense -= 1;

                    cooldowntimer.RestartTime(5);

                } else if (dWeapon.trackDmg(true)) { //resets attack if hit. Simulates stunlock
                    attackReady = false;
                    offense -= 1;
                    defense += 1;
                    cooldowntimer.RestartTime(5);

                } else {
                    print("Hasn't struck");

                    if (Time.time > atkTimePassed + 3 && attackReady == true)
                        attackReady = false;
                    cooldowntimer.RestartTime(5);
                    //Enemy.speed = 3.5f;
                }
			}
			else if (atkColliders[i].tag != "Player_ch" && attackReady == false && confirmedHit == false){//&& Time.time > atkTimePassed+5
				print ("Too long since last struck");
				
				Enemy.speed = 3.5f;
			}

		}
	}
	
	void DetectEnemy(Vector3 center, float radius){
		
		Collider[] hitColliders = Physics.OverlapSphere(center, radius);
		
		
		
		
		for (var i = 0; i < hitColliders.Length; i++) {
			// collect information on the hits here
			//print(hitColliders[i].tag);
			
			if (hitColliders[i].tag == "Player_ch"){
				
				//print ("Found Player!");
				
				//activate nametag for this enemy			
				characterTag.turnVisible();
				
				//Set the current point in time it has run into a player 
				timePassed = Time.time;

				//give chase
				Enemy.destination = target.GetComponent<Transform> ().position;
				

				
			}
			
			if(hitColliders[i].tag != "Player_ch" && Time.time > timePassed+5){
				//hide the enemy nametag
				characterTag.turnInvisible();
			}
			
			//transform.eulerAngles = target.GetComponent<movement>().getRt();
		}
		
		
	}

	void Awake(){
		
		myTransform = this.gameObject;
		
	}

	void Start(){
		
		GameObject go = GameObject.FindGameObjectWithTag("Player_ch");
		
		target = go;

//		GameObject weapon = GameObject.FindGameObjectWithTag ("Sword");
//
//		sword = weapon; 

		NavMeshAgent agent = GetComponent<NavMeshAgent>();

		Enemy = agent;

		//confirmedHit = false;

		attackReady = true;

		cooldowntimer.startTimer (5);

		//isHit = dWeapon.trackHit ();
		 
		
	}


	void Update(){



		DetectEnemy(transform.position, DetectRange); // create new function for attacking
		AttackEnemy (transform.position, atkRange); //range 0.5f?
        Debug.Log("offense: " + offense + " | defense: " + defense);
	}


}
