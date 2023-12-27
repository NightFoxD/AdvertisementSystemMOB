using SQLite;
using System;
namespace ASProjektWPF.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public int UserDataID { get; set; }
        public int? AccountTypeID { get; set; }
        [MaxLength(50)]
        public string Login { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        [MaxLength(9)]
        public int TelephoneNumber { get; set; }
        public string Pfp { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(50)]
        public string Country { get; set; }
        [MaxLength(50)]
        public string CurrentOccupation { get; set; }
        public string Summary { get; set; }

    }
}
