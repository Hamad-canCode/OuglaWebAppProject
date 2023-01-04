using Microsoft.Data.SqlClient;
using OuglaWebApp.Models;

namespace OuglaWebApp.DataLogic
{
    public class BlogHandling
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M4962FO\MSSQLSERVER03;Initial Catalog=ougla;Integrated Security=True;TrustServerCertificate=true");

        public BlogHandling()
        {

        }

        public void UploadBlog(BlogModel blog,string siteName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',(Select BulkColumn FROM OPENROWSET(BULK N'C:\\Users\\lenovo\\Downloads\\Blank.png', SINGLE_BLOB)  as img));", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
