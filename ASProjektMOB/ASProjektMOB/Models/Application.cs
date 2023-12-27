using SQLite;
using System;

namespace ASProjektWPF.Models
{
    public class Application
    {
        [PrimaryKey, AutoIncrement]
        public int ApplicationID { get; set; }
        public int AnnouncmentID { get; set; }
        public int UserID { get; set; }
    }
}
