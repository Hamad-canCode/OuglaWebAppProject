using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using OuglaWebApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Text;

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
            if (blog.Image != null)
            {
                string varBinary = ToVarbinary(blog.Image);
                //SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',(Select BulkColumn FROM OPENROWSET(BULK N'C:\\Users\\lenovo\\Downloads\\Blank.png', SINGLE_BLOB)  as img));", con);
              //  SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',CONVERT(VARBINARY(MAX), '{blog.Image}'))", con);
                SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',{varBinary})", con);

                cmd.ExecuteNonQuery();
            }
            else
            {
                SqlCommand cmd = new SqlCommand($"INSERT INTO BlogsOf{siteName} (Title, Content,img) VALUES('{blog.Title}', '{blog.Content}',(Select BulkColumn FROM OPENROWSET(BULK N'C:\\Users\\lenovo\\source\\repos\\OuglaWebApp\\OuglaWebApp\\wwwroot\\Default.png', SINGLE_BLOB)  as img));", con);
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }
        string ToVarbinary(byte[] data)
        {
            var sb = new StringBuilder((data.Length * 2) + 2);
            sb.Append("0x");

            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("X2"));
            }

            return sb.ToString();
        }
        public void GetBlogs(string siteName)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand($"select * from BlogOf{siteName}", con);
            con.Close();

        }
        public DataTable GetBlogData(string siteName)
        {

            var dataset = new DataTable();

            con.Open();
            using (SqlCommand com = new SqlCommand($"select * from BlogsOf{siteName}", con))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                {
                    adapter.Fill(dataset);
                }
            }
            con.Close();
            return dataset;
        }
        public DataTable Blog(int id, string siteName)
        {
            var dataset = new DataTable();

            con.Open();
            using (SqlCommand com = new SqlCommand($"select * from BlogsOf{siteName} where blogid={id}", con))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                {
                    adapter.Fill(dataset);
                }
            }
            con.Close();
            return dataset;
        }
    }
}
