using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    public Camera myCamera;
    private GameObject Parent;
	// Use this for initialization
	void Start () {

        Parent = GameObject.Find("Defenders");
        if (!Parent)
        {
            Parent = new GameObject("Defenders");
        }

       
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Vector2 roundUP = SnapToGrid(CalculateWorldPointOfMouseClick());
        float Rx = roundUP.x % 100;
        //Debug.Log(Rx);
        float Ry = roundUP.y % 100;
        
        if(Rx == Mathf.Abs(Rx))
        Rx = roundUP.x - Rx + 50;
        else
            Rx = roundUP.x - Rx - 50;

        if (Ry == Mathf.Abs(Ry))
            Ry = roundUP.y - Ry + 50;

        else
            Ry = roundUP.y - Ry - 50;

        Vector2 finalVal = new Vector2(Rx, Ry);
       GameObject newDef =  Instantiate(DefendersSelector.selectedDefender, finalVal,Quaternion.identity) as GameObject;
        newDef.transform.parent = Parent.transform;
       // print(CalculateWorldPointOfMouseClick());
       // print(finalVal);
    }

    Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float cameraDistance = 10f;

        Vector3 wierdT = new Vector3(mouseX, mouseY, cameraDistance);
        Vector2 worldPos = myCamera.ScreenToWorldPoint(wierdT);

        return worldPos;
    }
}
