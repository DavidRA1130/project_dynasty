using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    [Header("Stats")]
    public string name;
    public int health;
    public int mana;

    [Header("Leveling")]
    [Space(10)]
    public int level;
    public int experiencePoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
