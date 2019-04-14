using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackers))]
public class BlueEnemy : MonoBehaviour {

    private Animator anim;
    private Attackers attackers;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        attackers = GetComponent<Attackers>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

     void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject obj = collider.gameObject;
        if (obj.tag == "Weapon")
            Debug.Log(obj);
        if (obj.tag == "Hero")
            anim.SetBool("HasToAttack", true);

         
    }
}
