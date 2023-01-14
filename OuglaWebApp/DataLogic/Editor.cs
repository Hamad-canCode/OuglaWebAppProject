using Microsoft.Data.SqlClient;
using OuglaWebApp.Models;
using System.Reflection.Metadata;

namespace OuglaWebApp.DataLogic
{
    public class Editor
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M4962FO\MSSQLSERVER03;Initial Catalog=ougla;Integrated Security=True;TrustServerCertificate=true");
        
        public void UploadContent(Content content,string siteName)
        {
            con.Open();
            //if (content.Image != null)
            //{
            //    string varBinary = ToVarbinary(content.Image);
            //    //SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',(Select BulkColumn FROM OPENROWSET(BULK N'C:\\Users\\lenovo\\Downloads\\Blank.png', SINGLE_BLOB)  as img));", con);
            //    //  SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',CONVERT(VARBINARY(MAX), '{blog.Image}'))", con);
            //    SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{content.Title}', '{content.Content}',{varBinary})", con);

            //    cmd.ExecuteNonQuery();
            //}
            //else
            //{
            //    SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',(Select BulkColumn FROM OPENROWSET(BULK N'C:\\Users\\lenovo\\source\\repos\\OuglaWebApp\\OuglaWebApp\\wwwroot\\Default.png', SINGLE_BLOB)  as img));", con);
            //    cmd.ExecuteNonQuery();
            //}

            con.Close();
        }
    }
}
