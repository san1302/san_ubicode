using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendersSelector : MonoBehaviour {

    public GameObject defenderPrefab;
    private DefendersSelector[] defendersSelectorArray;
    public static GameObject selectedDefender;
   
	// Use this for initialization
	void Start () {
        defendersSelectorArray = GameObject.FindObjectsOfType<DefendersSelector>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnMouseDown()
    {
        foreach(DefendersSelector thisButton in defendersSelectorArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
        //print(selectedDefender);

    }

   
}
