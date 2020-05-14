using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ZGAF_DELR_EXAMEN_2P.Models
{
    public class PetModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BornDate { get; set; }
        public string Gender { get; set; }
        public string Breed { get; set; }
        public int Weight { get; set; }
        public string Notes { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string ImageBase64 { get; set; }
        public string Direction { get; set; }
    }

}
