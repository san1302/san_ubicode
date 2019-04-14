using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackers))]
public class RoboEnemy : MonoBehaviour {
    private Animator anim;
    private Attackers attackers;
    private GameObject obj, Target;
    HealthManageer healthManageer;
    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        attackers = GetComponent<Attackers>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        obj = collider.gameObject;
        if (obj.tag == "Weapon")
            Debug.Log(obj);
        if (obj.tag == "Hero" )
        {
           // Debug.Log("hi");
            Target = obj;
            anim.SetBool("HasToAttackNNoWalk", true);

        }


    }

    public void DealDamage(float damage)
    {
        if (Target)
        {

            healthManageer = Target.GetComponent<HealthManageer>();
            if (healthManageer.health > 0)
            {
                if (Target.tag == "Hero")
                    healthManageer.GetDamage(damage);
            }
            else
            {
                anim.SetBool("HasToAttackNNoWalk", false);
                anim.SetBool("HasToWalk", true);
            }
        }

    }
}
