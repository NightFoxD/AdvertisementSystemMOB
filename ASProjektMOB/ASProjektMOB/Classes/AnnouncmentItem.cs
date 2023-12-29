using AdvertisementSystem;
using ASProjektMOB;
using ASProjektWPF.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Xamarin.Forms;

namespace ASProjektWPF.Classes
{
    public class AnnouncmentItem
    {
        public int AnnouncmentID { get; set; }
        public Announcment Announcment { get; set; }
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string CompanyImage { get; set; }
        public Company Company { get; set; }
        public string CategoryID { get ;set;}
        public string Name { get; set; }
        public string    Description { get; set; }
        public string PositionName { get; set; }
        public string PositionLevel { get; set; }
        public string ContractType { get; set; }
        public string WorkingTime { get; set; }
        public string WorkType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public List<Item> Responsibilities = new List<Item> { };
        public List<Item> Requirements = new List<Item> { };
        public List<Item> Benefits = new List<Item> { };
        public string City { get; set; }
        public AnnouncmentItem() { }
        public AnnouncmentItem(Announcment item)
        {
            AnnouncmentID = item.AnnouncmentID;
            Announcment = item;
            CompanyID = item.CompanyID;
            CategoryID = item.CategoryID;
            Name = item.Name;
            Description = item.Description;
            PositionName = item.PositionName;
            PositionLevel = item.PositionLevel;
            string[] table = { };
            ContractType = item.ContractType;
            
            WorkingTime = item.WorkingTime;
            WorkType = item.WorkType;
           
            EndDate = item.EndDate;
            if (item.Responsibilities != null && item.Responsibilities !="")
            {
                table = item.Responsibilities.Split(';');
                foreach (var itemResponsibility in table)
                {
                    Responsibilities.Add(new Item(itemResponsibility));
                }
            }
            if (item.Requirements != null && item.Requirements != "")
            {
                table = item.Requirements.Split(';');
                foreach (var itemResponsibility in table)
                {
                    Requirements.Add(new Item(itemResponsibility));
                }
            }
            if (item.Benefits != null && item.Benefits !="")
            {
                table = item.Benefits.Split(';');
                foreach (var itemBenefit in table)
                {
                    Benefits.Add(new Item(itemBenefit));
                }
            }
            
            City = item.City;
            Company = App.DataAccess.GetCompanyFromID(item.CompanyID);
            CompanyName = Company.Name;
            CompanyImage = Company.CompanyImage;
        }
    }
}
