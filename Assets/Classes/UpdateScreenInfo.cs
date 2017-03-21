using UnityEngine;
using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using Grupirovki;

public class UpdateScreenInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateZonesScreen(List<Zona> ZList)
    {
        GameObject[] loadedObjects = Resources.LoadAll<GameObject>("");
        for (int i = 0; i < ZList.Count; i++)
        {
            print("loaded: "+loadedObjects.Length);
            System.Random rd = new System.Random();
            GameObject gm = (GameObject)ZList[i].Object;
            int u = ZList[i].Id_capture == 999 ? loadedObjects.Length-1 : ZList[i].Id_capture;
            gm.GetComponent<SpriteRenderer>().sprite = loadedObjects[u].GetComponent<SpriteRenderer>().sprite;
            //ZList[i].Object.GetComponent<SpriteRenderer>().sprite = loadedObjects[rd.Next(0,loadedObjects.Length)].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
