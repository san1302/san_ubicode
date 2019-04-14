using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {

    private Animator anim;
    // Use this for initialization
    private float speed = 300; 
     public float damage;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);	
	}

    public void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.tag == "Enemy")
        { 
            Destroy(gameObject);
            GameObject Target = collider.gameObject;
            HealthManageer healthManageer = Target.GetComponent<HealthManageer>();
            healthManageer.GetDamage(damage);
        }
        
    }
}
