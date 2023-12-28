using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASProjektMOB.Models
{
    public class MyApplication
    {
        [PrimaryKey, AutoIncrement]
        public int ApplicationID { get; set; }
        public int AnnouncmentID { get; set; }
        public int UserID { get; set; }
    }
}
