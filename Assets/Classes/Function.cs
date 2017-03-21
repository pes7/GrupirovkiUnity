using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UnityEngine;

namespace Grupirovki.Classes
{
    class Function
    {
        public GameObject hazard;
        public Vector3 spawnValues;

        static List<Zona> Zlist = new List<Zona>();

        void Start()
        {
            
        }

        static List<Group> Glist = new List<Group>();
        public List<Group> get_groups()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Xmls/Grupirovki.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlNode xnode in xRoot)
            {
                int id = 999;
                string name = "null";
                int id_mine_base = 0;
                int national_attak_bonus = 0;
                int national_defend_bonus = 0;
                int national_solders_count = 0;

                int[] ids_zone_capture = { };
                int[] ids_squads = { };
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
                        case "id_mine_base":
                            id_mine_base = int.Parse(childnode.InnerText);
                            break;
                        case "national_attak_bonus":
                            national_attak_bonus = int.Parse(childnode.InnerText);
                            break;
                        case "national_defend_bonus":
                            national_defend_bonus = int.Parse(childnode.InnerText);
                            break;
                        case "national_solders_count":
                            national_solders_count = int.Parse(childnode.InnerText);
                            break;
                    }
                }
                //Group group = new Group(id,name,, 10, 0, 60, 1, 0, 70, 0, 0, 0, id_mine_base, ids_zone_capture, ids_squads,0, national_attak_bonus, national_defend_bonus, 9999, national_solders_count);
                //Glist.Add(group);
            }
            return Glist;
        }

        void Update()
        {

        }
    }
}
