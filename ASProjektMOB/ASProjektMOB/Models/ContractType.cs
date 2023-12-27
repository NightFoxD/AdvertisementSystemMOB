using SQLite;
using System;

namespace ASProjektWPF.Models
{
    public class ContractType
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
