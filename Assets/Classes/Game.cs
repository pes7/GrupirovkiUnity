using UnityEngine;
using System.Collections;
using Grupirovki;
using System.Collections.Generic;
using System;

public class Game : MonoBehaviour {
    public GameObject hazard;
    public GameObject squad;
    public UnityEngine.UI.Text textline1;
    public UnityEngine.UI.Text textline2;
    public string DirMap = "Assets/Xml/Map_points.xml";
    public string DirObjects = "Assets/Resources";
    public string DirGroup = "Assets/Xml/Grupirovki.xml";

    public List<Zona> ZList = new List<Zona>();
    public List<Group> GList = new List<Group>();
    public List<Squad> SList = new List<Squad>();

    // Use this for initialization
    void Start () {
        GenarationZones gr0 = new GenarationZones();
        ZList = gr0.get_map_points(DirMap, DirObjects, hazard);
        GenerationGroups gr1 = new GenerationGroups();
        GList = gr1.get_groups(DirGroup, ZList);
        UpdateScreenInfo up = new UpdateScreenInfo();
        UpdateZones();
        up.UpdateZonesScreen(ZList);
        Squad sq = new Squad(0, 999, 0, 999, 999, 0, 0);
        SList.Add(sq);
        create_default_squads(GList.Count);
    }

    public void create_default_squads(int count)
    {
        for (int i = 0; i < count; i++)
        {
            int[] ids_array = new int[3];
            for (int g = 0; g < 3; g++)
            {
                Vector3 spawnPosition = new Vector3(((GameObject)ZList[GList[i].Id_base_set].Object).transform.position.x, ((GameObject)ZList[GList[i].Id_base_set].Object).transform.position.y, 0);
                Quaternion spawnRotation = Quaternion.identity;
                GameObject newobject = Instantiate(squad, spawnPosition, spawnRotation);

                Squad sq = new Squad(SList.Count, i, GList[i].National_soled_count, GList[i].Id_base_set, GList[i].Id_base_set, 0, 0, newobject);
                ids_array[g] = SList.Count;
                SList.Add(sq);
            }
            GList[i].Id_suqad_of_solders = ids_array;
        }
    }

    public void UpdateZones()
    {
        foreach(Group gr in GList)
        {
            this.ZList.Find(ds => ds.Id == gr.Id_base_set).Id_capture = gr.Id;
        }
    }

    public void think()
    {
        /*
        //Debg.listBox1.Items.Clear();
        for (int i = 0; i < Glist.Count; i++)
        {
            //Просчитка уровня снабжения групировки
            int lvl = charge_var_lvl(i);
            Glist[i].Level_of_var_resource = lvl;
            //Просчитка боевых характеристик сквадов групировки
            int[] dd = charge_attak(lvl, i);
            Glist[i].Attak_min = dd[0];
            Glist[i].Attak_max = dd[1];
            Glist[i].Defence = charge_defend(lvl, i);
            //Просчитака ближайших целей для атаки
            think_attak_aims(i);
            //Получить коливо сквадов на локациях
            get_squads_in_zones(i);
            //Посчитать сколько сквадов нужно, и нанять коливо людей
            reqruit(i);
            //Создать новые сквады(Сложно) //Послать сквады на оборону позиций(Средне)
            create_squads(i);
            //Выплатить жалование сквадам(Легко) Оставим на конец
            pay_my_money();
            //Послать сквады на оборону позиций(Очень сложно)

            //Послать сквады на атаку позиций(Сложно)
            attak(i);
            //Собрать ресурсы с локаций(Легко)
            take_resources(i);
            //Продать експортный ресурс(Легко)
            sell_export(i);
        }
        */
    }

    // Update is called once per frame
    void Update () {
        
	}
}
