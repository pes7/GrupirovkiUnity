using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Grupirovki
{
    public class Squad
    {
        public int Id { get; set; }
        public int Id_relate { get; set; }
        public int Count_of_solders { get; set; }
        public int Point_from { get; set; }
        public int Point_to { get; set; }
        
        public GameObject Object { get; set; }

        public int State { get; set; }//Стоит ли отряд или же идёт куда то

        public int Alive { get; set; }
        /// <summary>
        /// Объект хранящий переменные связаные с сквадами (Slist)
        /// </summary>
        /// <param name="id">Id сквада</param>
        /// <param name="id_relate">Id (Glist) которому принадлежит отряд</param>
        /// <param name="count_of_solders">Количество солдат в отряде</param>
        /// <param name="point_from">Id (Zlist) точки от куда вышел отряд</param>
        /// <param name="point_to">Id (Zlist) точки от куда идёт отряд</param>
        /// <param name="state">Стату отряда</param>
        /// <param name="alive">Жив ли отряд</param>
        /// <param name="picturebox">Image - визуализация отряда</param>
        public Squad(int id, int id_relate, int count_of_solders, int point_from, int point_to, int state, int alive, GameObject obj = null)
        {
            Id = id;
            Id_relate = id_relate;
            Object = obj;
            Count_of_solders = count_of_solders;
            Point_from = point_from;
            Point_to = point_to;
            State = state;
            Alive = alive;
        }
    }
}
