using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace PMEXAMENP1.Models
{
    public class Direcciones
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        [MaxLength(70)]
        public string longitud { get; set; }

        [MaxLength(70)]
        public string latitud { get; set; }
        
        public string longdirection { get; set; }

        [MaxLength(50)]
        public string shortdirection { get; set; }
    }
}
