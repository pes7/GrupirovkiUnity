using UnityEngine;
using System.Collections;
using Grupirovki.Classes;
using Grupirovki;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Linq;
using UnityEngine.UI;

public class GenarationZones : MonoBehaviour {
    public List<Zona> Zlist = new List<Zona>();
    // Use this for initialization
    void Start () {

    }

    public List<Zona> get_map_points(string Dir, string DirRes, GameObject hazard)
    {
        XmlDocument xDoc = new XmlDocument();
        xDoc.Load(Dir);
        XmlElement xRoot = xDoc.DocumentElement;
        foreach (XmlNode xnode in xRoot)
        {
            int id = 999;
            string name = "null";
            int type = 1;
            int add_var = 0;
            int add_exp = 0;
            int max_suqads = 0;
            float position_x = 0;
            float position_y = 0;
            int[] ids = { };
            if (xnode.Attributes.Count > 0)
            {
                XmlNode attr = xnode.Attributes.GetNamedItem("id");
                if (attr != null)
                    id = int.Parse(attr.Value);
            }
            foreach (XmlNode childnode in xnode.ChildNodes)
            {
                switch (childnode.Name)
                {
                    case "name":
                        name = childnode.InnerText;
                        break;
                    case "type":
                        type = int.Parse(childnode.InnerText);
                        break;
                    case "add_var":
                        add_var = int.Parse(childnode.InnerText);
                        break;
                    case "add_exp":
                        add_exp = int.Parse(childnode.InnerText);
                        break;
                    case "max_squads":
                        max_suqads = int.Parse(childnode.InnerText);
                        break;
                    case "positions_x":
                        position_x = float.Parse(childnode.InnerText);
                        break;
                    case "positions_y":
                        position_y = float.Parse(childnode.InnerText);
                        break;
                }
            }

            Vector3 spawnPosition = new Vector3(position_x, position_y, 0);

            Quaternion spawnRotation = Quaternion.identity;

            GameObject newobject = Instantiate(hazard, spawnPosition, spawnRotation);
            newobject.name = id+"";

            Zona mew_zona = new Zona(id, 999, newobject, name, type, add_var, add_exp, max_suqads, ids, 0);
            Zlist.Add(mew_zona);
        }
        return Zlist;
    }

    // Update is called once per frame
    void Update () {
	
	}
}
