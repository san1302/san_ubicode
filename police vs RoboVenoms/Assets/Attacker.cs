using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueEnemyMovement : MonoBehaviour
{


    [Range(1f, 50f)] public float currentspeed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * currentspeed * Time.deltaTime);
    }

    void speedchanger(float tellspeed)
    {
        currentspeed = tellspeed;
    }




}
