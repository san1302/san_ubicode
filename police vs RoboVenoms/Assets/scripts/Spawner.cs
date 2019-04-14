using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] AttackerArray;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        foreach(GameObject thisAttacker in AttackerArray)
        {
            if( isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    bool isTimeToSpawn(GameObject AttackerGameObject)
    {
        Attackers attackers = AttackerGameObject.GetComponent<Attackers>();

        float MeanSpawnDelay = attackers.SeenEverySeconds;
        float SpawnsPerSecond = 1 / MeanSpawnDelay;

        float threshold = SpawnsPerSecond * Time.deltaTime /4;

        if (Random.value < threshold)
        {
            return true;
        }
        else
            return false;


        return true;
    }

    void Spawn(GameObject AttackerGameObject)
    {
        GameObject MyAttacker = Instantiate(AttackerGameObject) as GameObject;
        MyAttacker.transform.parent = transform;
        MyAttacker.transform.position = transform.position;
    }
}
