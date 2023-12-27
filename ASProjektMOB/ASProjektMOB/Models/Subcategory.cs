using SQLite;
using System;


namespace ASProjektWPF.Models
{
    public class SubCategory
    {
        [PrimaryKey, AutoIncrement]
        public int SubCategoryID { get; set; }
        public int Category { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
