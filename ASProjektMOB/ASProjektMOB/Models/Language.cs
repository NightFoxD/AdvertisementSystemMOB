using SQLite;
using System;


namespace ASProjektWPF.Models
{
    public class Language
    {
        [PrimaryKey, AutoIncrement]
        public int LanguageID { get; set; }
        public int UserID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Level { get; set; }
    }
}
