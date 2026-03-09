using System;

namespace StadiumProject.Models
{
    public class Survey
    {
        public int id { get; set; }
        public string title { get; set; }
        public int id_theme { get; set; }
        public string name { get; set; } // Propriété pour le nom du thème
        public int nb_questions { get; set; }
        public bool publish { get; set; } = false;
    }
}
