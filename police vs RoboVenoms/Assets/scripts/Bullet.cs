using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Use this for initialization
    private Animator anim;
    private float speed = 300;
    public float damage;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            
            anim.SetBool("HasToCollide", true);
            GameObject Target = collider.gameObject;
            HealthManageer healthManageer = Target.GetComponent<HealthManageer>();
            healthManageer.GetDamage(damage);
        }
    }

    public void YouAreDead()
    {
        Destroy(gameObject);

    }

}
