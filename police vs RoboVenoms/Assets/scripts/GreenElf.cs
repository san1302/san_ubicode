using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenElf : MonoBehaviour {

    public GameObject projectile,firePoint;
    private GameObject projectileParent;
    
    // Use this for initialization
    void Start () {

        projectileParent = GameObject.Find("Projectiles");
        if(!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Fire()
    {
        GameObject Arrow = Instantiate(projectile) as GameObject;
        Arrow.transform.parent = projectileParent.transform;
        Arrow.transform.position = firePoint.transform.position;
    }
}
