using System;

namespace StadiumProject.Models
{
    public class Answering
    {
        public int id_question { get; set; }
        public int id_answer { get; set; }
        public bool valid_answer { get; set; } = false;
        public int num_answer { get; set; }
        public int weight { get; set; }

    }
}
