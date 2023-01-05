using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OuglaWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace OuglaWebApp.DataLogic
{
    public class BlogHandling
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M4962FO\MSSQLSERVER03;Initial Catalog=ougla;Integrated Security=True;TrustServerCertificate=true");

        public BlogHandling()
        {

        }

        public void UploadBlog(BlogModel blog, string siteName)
        {

            con.Open();
            if (blog.Image!=null)
            {
                //SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',(Select BulkColumn FROM OPENROWSET(BULK N'C:\\Users\\lenovo\\Downloads\\Blank.png', SINGLE_BLOB)  as img));", con);
                SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOfadmin (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',CONVERT(VARBINARY(MAX), '{blog.Image}'))", con);
                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOfadmin (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',(Select BulkColumn FROM OPENROWSET(BULK N'C:\\Users\\lenovo\\source\\repos\\OuglaWebApp\\OuglaWebApp\\wwwroot\\Default.png', SINGLE_BLOB)", con);
                cmd.ExecuteNonQuery();
            }
            
            con.Close();
        }
    }
}
