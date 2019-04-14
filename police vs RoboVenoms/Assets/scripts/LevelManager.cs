using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


    public void Loadlevel(string name)
    {
        Debug.Log("loaded level: " + name);
        Application.LoadLevel(name);
    }

    public void Quitrequest()
    {
        Debug.Log("Quit request!");
        Application.Quit();
    }

    public void loadnextlevel()
    {
        Application.LoadLevel(Application.loadedLevel + 1);
    }
}
