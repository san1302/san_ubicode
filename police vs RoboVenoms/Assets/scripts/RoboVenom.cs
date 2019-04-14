using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attackers))]
public class RoboVenom : MonoBehaviour {


    public GameObject projectile, firePoint;
    private GameObject projectileParent;
    private Animator anim;
    private Attackers attackers;
    private GameObject obj, Target;
    private GameObject SpawnedLaneHero;
    private int flag = 0,flag1 = 0;
    // Use this for initialization
    void Start()
    {

        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        anim = GetComponent<Animator>();
        attackers = GetComponent<Attackers>();

    }

    // Update is called once per frame
    void Update()
    {
        flag = 0;
        SpawnedLaneHero = GameObject.Find("Defenders");
        if(SpawnedLaneHero)
      
        {
         
            foreach(Transform hero in SpawnedLaneHero.transform)
            {

               // Debug.Log(hero.transform.position.y);
               // Debug.Log("enter");
                if(hero.transform.position.y == transform.position.y)
                {
                    flag = 1;
                    anim.SetBool("HasToWalk", false);   
                    anim.SetBool("HasToAttackNWalk", true);
                    break;
                }
                
            }

            if (flag == 0)
            {
                anim.SetBool("HasToAttackNWalk", false);
                anim.SetBool("HasToWalk", true);
            }
                
                
        }
    }

  
    void OnTriggerEnter2D(Collider2D collider)
    {
        obj = collider.gameObject;
        if (obj.tag == "Weapon")
            Debug.Log(obj);
        if (obj.tag == "Hero")
        {
            // Debug.Log("hi");
            Target = obj;
            flag1 = 1;
            anim.SetBool("HasToAttackNNoWalk", true);

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
                anim.SetBool("HasToAttackNNoWalk", false);
                anim.SetBool("HasToWalk", true);
            }
        }

    }

    public void Fire()
    {
        Debug.Log("fire");
        GameObject Bullet = Instantiate(projectile) as GameObject;
        Bullet.transform.parent = projectileParent.transform;
        Bullet.transform.position = firePoint.transform.position;
        if (Target)
        {
            HealthManageer healthManageer = Target.GetComponent<HealthManageer>();
            if (healthManageer.health < 0)
            {
                flag1 = 0;
                anim.SetBool("HasToAttackNoWalk", false);
                anim.SetBool("HasToWalk", true);
            }
        }
    }
}
