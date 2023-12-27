using SQLite;
using System;


namespace ASProjektWPF.Models
{
    public class Link
    {
        [PrimaryKey, AutoIncrement]
        public int LinkID { get; set; }
        public int User { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
