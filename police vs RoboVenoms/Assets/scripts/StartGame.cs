using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Start : MonoBehaviour {

	
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Loadlevel(string name)
    {
        Debug.Log("loaded level: " + name);
        Application.LoadLevel(name);
    }
}
