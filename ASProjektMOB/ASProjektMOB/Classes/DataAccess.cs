using ASProjektWPF.Classes;
using ASProjektWPF.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdvertisementSystem.Classes
{
    public class DataAccess
    {
        public readonly SQLiteAsyncConnection _database;
        public DataAccess(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath,true);
            _database.CreateTableAsync<Announcment>().Wait();
            _database.CreateTableAsync<Application>().Wait();
            _database.CreateTableAsync<Category>().Wait();
            _database.CreateTableAsync<Company>().Wait();
            _database.CreateTableAsync<ContractType>().Wait();
            _database.CreateTableAsync<Course>().Wait();
            _database.CreateTableAsync<Education>().Wait();
            _database.CreateTableAsync<Experience>().Wait();
            _database.CreateTableAsync<Language>().Wait();
            _database.CreateTableAsync<Link>().Wait();
            _database.CreateTableAsync<PositionLevel>().Wait();
            _database.CreateTableAsync<Saved>().Wait();
            _database.CreateTableAsync<Skill>().Wait();
            _database.CreateTableAsync<SubCategory>().Wait();
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<WorkTime>().Wait();
            _database.CreateTableAsync<WorkType>().Wait();
        }
        //--------- Announcment ---------//
        public List<Announcment> GetAnnouncmentList()
        {
            return _database.Table<Announcment>().ToListAsync().Result;
        }
        public List<Announcment> GetAnnouncmentList(Company company)
        {
            return _database.Table<Announcment>().Where(item => item.CompanyID == company.CompanyID).ToListAsync().Result;
        }
        public int Add_Announcment(Announcment announcment)
        {
            return _database.InsertAsync(announcment).Result;
        }
        public int Update_Announcment(Announcment announcment)
        {
            return _database.UpdateAsync(announcment).Result;
        }
        public int Delete_Announcment(Announcment announcment)
        {
            return _database.DeleteAsync(announcment).Result;
        }
        //--------- Application ---------//
        public List<Application> GetApplicationList()
        {
            return _database.Table<Application>().ToListAsync().Result;
        }
        public List<Application> GetApplicationList(AnnouncmentItem announcment)
        {
            return _database.Table<Application>().Where(item => item.AnnouncmentID == announcment.AnnouncmentID).ToListAsync().Result;
        }
        public List<Application> GetApplicationList(User user)
        {
            return _database.Table<Application>().Where(item => item.UserID == user.UserID).ToListAsync().Result;
        }
        public int Add_Application(Application application)
        {
            return _database.InsertAsync(application).Result;
        }
        public int Update_Application(Application application)
        {
            return _database.UpdateAsync(application).Result;
        }
        public int Delete_Application(Application application)
        {
            return _database.DeleteAsync(application).Result;
        }
        //--------- Category ---------//
        public List<Category> GetCategoryList()
        {
            return _database.Table<Category>().ToListAsync().Result;
        }
        public int Add_Category(Category category)
        {
            return _database.InsertAsync(category).Result;
        }
        public int Update_Category(Category category)
        {
            return _database.UpdateAsync(category).Result;
        }
        public int Delete_Category(Category category)
        {
            return _database.DeleteAsync(category).Result;
        }
        //--------- Company ---------//
        public List<Company> GetCompanyList()
        {
            return _database.Table<Company>().ToListAsync().Result;
        }
        public Company GetCompany(string Login, string Password)
        {
            try
            {
                return _database.Table<Company>().Where(item => item.Login == Login && item.Password == Password).FirstAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public Company GetCompany(string Login)
        {

            try
            {
                return _database.Table<Company>().Where(item => item.Login == Login).FirstOrDefaultAsync(null).Result;
            }
            catch (Exception)
            {
                return null;
            }

        }
        public Company GetCompanyFromID(int id)
        {
            return _database.Table<Company>().Where(item => item.CompanyID == id).FirstAsync().Result;
        }
        public int Add_Company(Company company)
        {
            return _database.InsertAsync(company).Result;
        }
        public int Update_Company(Company company)
        {
            return _database.UpdateAsync(company).Result;
        }
        public int Delete_Company(Company company)
        {
            return _database.DeleteAsync(company).Result;
        }
        //--------- ContractType ---------//
        public List<ContractType> GetContractList()
        {
            return _database.Table<ContractType>().ToListAsync().Result;
        }
        public int Add_ContractType(ContractType item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_ContractType(ContractType item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_ContractType(ContractType item)
        {
            return _database.DeleteAsync(item).Result;
        }
        //--------- Course ---------//
        public List<Course> GetCourseList()
        {
            return _database.Table<Course>().ToListAsync().Result;
        }
        public int Add_Course(Course course)
        {
            return _database.InsertAsync(course).Result;
        }
        public int Update_Course(Course course)
        {
            return _database.UpdateAsync(course).Result;
        }
        public int Delete_Course(Course course)
        {
            return _database.DeleteAsync(course).Result;
        }
        //--------- Education ---------//
        public List<Education> GetEducationList()
        {
            return _database.Table<Education>().ToListAsync().Result;  
        }
        public List<Education> GetEducationList(User user)
        {
            return _database.Table<Education>().Where(item => item.UserID == user.UserID).ToListAsync().Result;
        }
        public int Add_Education(Education education)
        {
            return _database.InsertAsync(education).Result;
        }
        public int Add_Education(Education education, User user)
        {
            education.UserID = user.UserID;
            return _database.InsertAsync(education).Result;
        }
        public Task Update_Education(Education education)
        {
            return _database.UpdateAsync(education);
        }
        public int Delete_Education(Education education)
        {
            return _database.DeleteAsync(education).Result;
        }
        //--------- Experience ---------//
        public List<Experience> GetExperienceList()
        {
            return _database.Table<Experience>().ToListAsync().Result;
        }
        public List<Experience> GetExperienceList(User user)
        {
            return _database.Table<Experience>().Where(experience => experience.UserID == user.UserID).ToListAsync().Result;
        }
        public Experience GetUserExperience(int id)
        {
            return _database.Table<Experience>().Where(experience => experience.UserID == id).ToListAsync().Result.First();
        }
        public int Add_Experience(Experience experience)
        {
            return _database.InsertAsync(experience).Result;
        }
        public int Update_Experience(Experience experience)
        {
            return _database.UpdateAsync(experience).Result;
        }
        public int Delete_Experience(Experience experience)
        {
            return _database.DeleteAsync(experience).Result;
        }
        //--------- Language ---------//
        public List<Language> GetLanguageList()
        {
            return _database.Table<Language>().ToListAsync().Result;
        }
        public List<Language> GetLanguageList(User user)
        {
            return _database.Table<Language>().Where(item => item.UserID == user.UserID).ToListAsync().Result;
        }
        public int Add_Language(Language language)
        {
            return _database.InsertAsync(language).Result;
        }
        public int Add_Language(Language language, User user)
        {
            language.UserID = user.UserID;
            return _database.InsertAsync(language).Result;
        }
        public int Update_Language(Language language)
        {
            return _database.UpdateAsync(language).Result;
        }
        public int Delete_Language(Language language)
        {
            return _database.DeleteAsync(language).Result;
        }
        //--------- Link ---------//
        public List<Link> GetLinkList()
        {
            return _database.Table<Link>().ToListAsync().Result;
        }
        public List<Link> GetLinkList(User user)
        {
            return _database.Table<Link>().Where(item => item.User == user.UserID).ToListAsync().Result;
        }
        public int Add_Link(Link link)
        {
            return _database.InsertAsync(link).Result;
        }
        public int Add_Link(Link link, User user)
        {
            link.User = user.UserID;
            return _database.InsertAsync(link).Result;
        }
        public Task Update_Link(Link link)
        {
            return _database.UpdateAsync(link);
        }
        public int Delete_Link(Link link)
        {
            return _database.DeleteAsync(link).Result;
        }
        //--------- PositionLevel ---------//
        public List<PositionLevel> GetPositionLevelList()
        {
            return _database.Table<PositionLevel>().ToListAsync().Result;
        }
        public int Add_PositionLevel(PositionLevel item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_PositionLevel(PositionLevel item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_PositionLevel(PositionLevel item)
        {
            return _database.DeleteAsync(item).Result;
        }
        //--------- Saved ---------//
        public List<Saved> GetSavedList()
        {
            return _database.Table<Saved>().ToListAsync().Result;
        }
        public int Add_Saved(Saved saved)
        {
            return _database.InsertAsync(saved).Result;
        }
        public int Update_Saved(Saved saved)
        {
            return _database.UpdateAsync(saved).Result;
        }
        public int Delete_Saved(Saved saved)
        {
            return _database.DeleteAsync(saved).Result;
        }
        //--------- Skill ---------//
        public List<Skill> GetSkillList()
        {
            return _database.Table<Skill>().ToListAsync().Result;
        }
        public List<Skill> GetSkillList(User user)
        {
            return _database.Table<Skill>().Where(item => item.UserID == user.UserID).ToListAsync().Result;
        }
        public int Add_Skills(Skill skill)
        {
            return _database.InsertAsync(skill).Result;
        }
        public int Add_Skills(Skill skill, User user)
        {
            skill.UserID = user.UserID;
            return _database.InsertAsync(skill).Result;
        }
        public int Update_Skills(Skill skill)
        {
            return _database.UpdateAsync(skill).Result;
        }
        public int Delete_Skills(Skill skill)
        {
            return _database.DeleteAsync(skill).Result;
        }
        //--------- Subcategory ---------//
        public List<SubCategory> GetSubcategoryList()
        {
            return _database.Table<SubCategory>().ToListAsync().Result;
        }
        public int Add_SubCategory(SubCategory subCategory)
        {
            return _database.InsertAsync(subCategory).Result;
        }
        public int Update_SubCategory(SubCategory subCategory)
        {
            return _database.UpdateAsync(subCategory).Result;
        }
        public int Delete_SubCategory(SubCategory subCategory)
        {
            return _database.DeleteAsync(subCategory).Result;
        }
        //--------- User ---------//
        public List<User> GetUserList()
        {
            return _database.Table<User>().ToListAsync().Result;
        }
        public User GetUser(string login, string password)
        {
            try
            {
                return _database.Table<User>().Where(item => item.Login == login && item.Password == password).FirstAsync().Result;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public User GetUser(User user)
        {
            return _database.Table<User>().Where(item => item.Login == user.Login && item.Password == user.Password).FirstAsync().Result;
        }
            public int InserUser(User newUser)
        {
            return _database.InsertAsync(newUser).Result;
        }
        public int UpdateUser(User user)
        {
            return _database.UpdateAsync(user).Result;
        }
        public int DelUser(User removeUser)
        {
            return _database.DeleteAsync(removeUser).Result;
        }

        public int SavePersonAsync(User person)
        {
            return _database.InsertAsync(person).Result;
        }
        //--------- WorkTime ---------//
        public List<WorkTime> GetWorkTimeList()
        {
            return _database.Table<WorkTime>().ToListAsync().Result;
        }
        public int Add_WorkTime(WorkTime item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_WorkTime(WorkTime item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_WorkTime(WorkTime item)
        {
            return _database.DeleteAsync(item).Result;
        }
        //--------- WorkType ---------//
        public List<WorkType> GetWorkTypeList()
        {
            return _database.Table<WorkType>().ToListAsync().Result;
        }
        public int Add_WorkType(WorkType item)
        {
            return _database.InsertAsync(item).Result;
        }
        public int Update_WorkType(WorkType item)
        {
            return _database.UpdateAsync(item).Result;
        }
        public int Delete_WorkType(WorkType item)
        {
            return _database.DeleteAsync(item).Result;
        }
    }
}
