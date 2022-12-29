using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OuglaWebApp.Models;

namespace OuglaWebApp.DataLogic
{
    public class SignUp
    {
        public bool validSiteName = true;
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M4962FO\MSSQLSERVER03;Initial Catalog=ougla;Integrated Security=True;TrustServerCertificate=true");
        private readonly OuglaContext _context = null;
        public SignUp(OuglaContext context)
        {
            _context = context;
        }


        public void AddNewUser(Info infoModel)
        {
            try
            {
                _context.Infos.Add(infoModel);
                _context.SaveChanges();
            }
            catch (Exception e1)
            {
                validSiteName = false;
            }
        }
        public void CreateBlogTable(Info infoModel)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(
                $"Create Table BlogsOf{infoModel.Sitename}(BlogId int identity(1,1) not null primary key, Title varchar(200) not null, Content varchar(max) not null, img varbinary(max) not null)"
                , con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool LogIn(Info infoModel)
        {
            var tempUser = _context.Infos.FirstOrDefault(u => u.Ownername == infoModel.Ownername && u.Password == infoModel.Password && u.Sitename == infoModel.Sitename);

            if (tempUser != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
