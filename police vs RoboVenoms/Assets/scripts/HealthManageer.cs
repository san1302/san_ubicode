using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManageer : MonoBehaviour {

    private Animator anim;
    public float health = 100f;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            anim = GetComponent<Animator>();
            anim.SetBool("HasToDie", true);
        }
    }

    public void YouAreDead()
    {
        Destroy(gameObject);
        
    }
}
