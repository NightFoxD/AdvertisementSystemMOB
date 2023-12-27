using SQLite;
using System;


namespace ASProjektWPF.Models
{
    public class Saved
    {
        [PrimaryKey, AutoIncrement]
        public int SavedID { get; set; }
        public int Company { get; set; }
        public int User { get; set; }
    }
}
