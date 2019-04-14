using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceConstable : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    public float damage;
    private GameObject Target;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            anim = GetComponent<Animator>();
            anim.SetBool("HasToAttack", true);
             Target = collider.gameObject;
        }

    }

    public void DealDamage(float damage)
    {
        if (Target)
        {

            HealthManageer healthManageer = Target.GetComponent<HealthManageer>();
            if (healthManageer.health > 0)
                healthManageer.GetDamage(damage);
            else
            {
                anim.SetBool("HasToAttack", false);
            }
        }

    }
}
