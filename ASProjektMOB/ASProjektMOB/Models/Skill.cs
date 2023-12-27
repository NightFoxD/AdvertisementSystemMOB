using SQLite;
using System;


namespace ASProjektWPF.Models
{
    public class Skill
    {
        [PrimaryKey, AutoIncrement]
        public int SkillID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
    }
}
