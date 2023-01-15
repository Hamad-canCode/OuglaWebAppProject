using Microsoft.Data.SqlClient;
using OuglaWebApp.Models;
using System;
using System.Reflection.Metadata;

namespace OuglaWebApp.DataLogic
{
    public class Editor
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M4962FO\MSSQLSERVER03;Initial Catalog=ougla;Integrated Security=True;TrustServerCertificate=true");
        
        public void UploadContent(Content content,string siteName)
        {
            con.Open();
            if (true)
            {

            }
            con.Close();
        }
        public void upadateAbout(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET About = '{content}' WHERE sitename = '{sitename}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateTwitter(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET TwitterLink = '{content}' WHERE sitename = '{content}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateInsta(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET InstagramLink = '{content}' WHERE sitename = '{content}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateLinkedIn(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET LinkedInLink = '{content}' WHERE sitename = '{content}", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateThemeColorCode(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET ThemeColorCode = '{content}' WHERE sitename = '{content}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateLogoImg(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET logoImg = {content} WHERE sitename = '{content}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateBanner(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET BannerImg = {content} WHERE sitename = '{content}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateObjImg(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET ObjectImg = {content} WHERE sitename = '{content}';", con);
            cmd.ExecuteNonQuery();
        }
    }
}
