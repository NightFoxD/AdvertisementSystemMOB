using SQLite;
using System;


namespace ASProjektWPF.Models
{
    public class Company
    {
        [PrimaryKey, AutoIncrement]
        public int CompanyID { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(100)]
        public string Password { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string CompanyImage { get; set; }
        public string Adress { get; set; }
        public string LocalizationLink { get; set; }
        public string Description { get; set; }
    }
}
