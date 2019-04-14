using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackers))]
public class blueEnemy : MonoBehaviour {

    private Animator anim;
    private Attackers attackers;
    private GameObject obj,Target;
    // Use this for initialization
    void Start() {

        anim = GetComponent<Animator>();
        attackers = GetComponent<Attackers>();

    }

    // Update is called once per frame
    void Update() {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
         obj = collider.gameObject;
        if (obj.tag == "Weapon")
            Debug.Log(obj);
        if (obj.tag == "Hero")
        {
            Target = obj;
            anim.SetBool("HasToAttack", true);

        }


    }

    public void DealDamage(float damage)
    {
        if(Target)
        {
            
            HealthManageer healthManageer = Target.GetComponent<HealthManageer>();
            if(healthManageer.health > 0)
            healthManageer.GetDamage(damage);    
            else
            {
                anim.SetBool("HasToAttack", false);     
            }
        }
        
    }
}
    