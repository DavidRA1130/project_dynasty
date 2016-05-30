using UnityEngine;
using System;
using System.Collections;

public class EnemyRangedAttack : MonoBehaviour {

    public Transform Owner;
    public GameObject Weapon;
    private bool isSheathed;
    private Renderer rend;
   // public PositionCollector rangedRadius;

    private Rigidbody rb;
    private Collider tg;
    private const float FORCE = 250.0f;
    private float timePassed;

    ulong currentMillis;
    ulong previousMillis = 1000;  
    const long interval = 1000;

    public float fireRate = 0.5F;
    private float nextFire = 0.0F;

    public CooldownTimer countDown;


    void OnTriggerStay(Collider target)
    {
        tg = target;

        if (tg.tag == "Player"  && countDown.getRestSeconds() <=0)
        {
            LaunchProjectile();
        }
    }

    void OnTriggerExit()
    {
        tg = null;
        CancelInvoke("PrepareProjectile");
    }

    void PrepareProjectile()
     {
     
    }

    void Awake()
    {
        countDown.Reset();
    }


    // Use this for initialization
    void Start()
    {
        countDown.startTimer(5);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LaunchProjectile()
    {
        if ((int)countDown.getRestSeconds() <= 0)
        {
            GameObject bolt = Instantiate(Weapon, GameObject.Find("GameObject").transform.position, transform.rotation) as GameObject;
            Vector3 dir = tg.transform.position - Owner.position;
            bolt.GetComponent<Rigidbody>().AddForce(dir * FORCE);
            countDown.RestartTime(5);
        }
    }
}

