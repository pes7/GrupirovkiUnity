using UnityEngine;
using System.Collections;
using System;

public class OnZoneClick : MonoBehaviour
{
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }

    void OnMouseDown()
    {
        GameObject gm = GameObject.Find("System");
        Game GB = gm.GetComponent<Game>();
        int id = int.Parse(gameObject.name);
        string name = "ps";
        if (GB.ZList[id].Id_capture != 999)
        {
            name = GB.GList.Find(ds=>ds.Id==GB.ZList[id].Id_capture).Name;
        } else {
            name = "Незанята";
        }
        GB.textline1.text = "[" + name + "] " + GB.ZList[id].Name;
        GB.textline2.text = "Отрядов: " + GB.ZList[id].Squads_in + "/" + GB.ZList[id].Max_suqads;
    }
}
