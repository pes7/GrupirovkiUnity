using UnityEngine;
using System.Collections;
using Grupirovki;
using System.Collections.Generic;

public class Game : MonoBehaviour {
    public GameObject hazard;
    public string DirMap = "Assets/Xml/Map_points.xml";
    public string DirObjects = "Assets/Resources";
    public string DirGroup = "Assets/Xml/Grupirovki.xml";

    public static List<Zona> ZList = new List<Zona>();
    public static List<Group> GList = new List<Group>();
    public static List<Squad> SList = new List<Squad>();

    // Use this for initialization
    void Start () {
        GenarationZones gr0 = new GenarationZones();
        ZList = gr0.get_map_points(DirMap, DirObjects, hazard);
        GenerationGroups gr1 = new GenerationGroups();
        GList = gr1.get_groups(DirGroup, ZList);
        UpdateScreenInfo up = new UpdateScreenInfo();
        UpdateZones();
        up.UpdateZonesScreen(ZList);
    }

    public void UpdateZones()
    {
        foreach(Group gr in GList)
        {
            Game.ZList.Find(ds => ds.Id == gr.Id_base_set).Id_capture = gr.Id;
        }
    }

    // Update is called once per frame
    void Update () {
        
	}
}
