using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceCommisioner : MonoBehaviour {

    private Animator anim;
    public GameObject projectile, firePoint;
    private GameObject projectileParent;
    private GameObject obj, Target;
    public static int cnt = 0;
    private Spawner MyLaneSpawner;
    private int cnt1;
    // Use this for initialization
    void Start()
    {


        anim = GetComponent<Animator>();
        projectileParent = GameObject.Find("Projectiles");
        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
        cnt++;
        cnt1 = cnt;

        SetlaneSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsEnemyInLane())
        {
            anim.SetBool("HasToAttack", true);
        }
        else
        {
            anim.SetBool("HasToAttack", false);
        }
    }

    void SetlaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();
        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                MyLaneSpawner = spawner;
                return;
            }
        }
    }

    bool IsEnemyInLane()
    {
        if (MyLaneSpawner.transform.childCount <= 0)
            return false;

        foreach (Transform enemy in MyLaneSpawner.transform)
        {
            if (enemy.transform.position.x < transform.position.x)
                return true;
        }

        return false;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Enemy")
        {
            anim.SetBool("HasToAttack", true);
            Target = collider.gameObject;
        }
        if (collider.tag == "Hero")
        {
            if (cnt == cnt1)
            {
                Destroy(gameObject);
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
                anim.SetBool("HasToAttack", false);
            }
        }
    }
}
