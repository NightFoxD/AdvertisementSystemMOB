using SQLite;
using System;


namespace ASProjektWPF.Models
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int CategoryID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
