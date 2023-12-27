using AdvertisementSystem;
using ASProjektWPF.Models;

namespace ASProjektWPF.Classes
{
    public class ApplicationItem
    {
        public User User { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public Announcment Announcment { get; set; }
        public string AnnouncmentName { get; set; }
        public string PositionName { get; set; }
        
        public ApplicationItem(AnnouncmentItem announcmentItem, User user)
        {
            User = user;
            Announcment = announcmentItem.Announcment;
            if (User.Name != null)
            {
                UserName = User.Name;
            }
            if (User.Surname != null)
            {
                UserSurname = User.Surname;
            }
            if(announcmentItem.Name != null)
            {
                AnnouncmentName = announcmentItem.Name;
            }
            if (announcmentItem.PositionName != null)
            {
                PositionName = announcmentItem.PositionName;
            }
        }
    }
}
