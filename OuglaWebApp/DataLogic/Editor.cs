using Microsoft.Data.SqlClient;
using OuglaWebApp.Models;
using System;
using System.Reflection.Metadata;
using System.Text;

namespace OuglaWebApp.DataLogic
{
    public class Editor
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-M4962FO\MSSQLSERVER03;Initial Catalog=ougla;Integrated Security=True;TrustServerCertificate=true");
        
        public void UploadContent(Content content,string siteName)
        {
            bool condition=false;
            con.Open();
            if (content.about!=null)
            {
                upadateAbout(content.about,siteName);
            }
            if (content.TwitterLink != null)
            {
                upadateTwitter(content.TwitterLink, siteName);
            }
            if (content.InstagramLink != null)
            {
                upadateInsta(content.InstagramLink, siteName);
            }
            if (content.LinkedInLink != null)
            {
                upadateLinkedIn(content.LinkedInLink, siteName);
            }
            if (content.ThemeColorCode != null)
            {
                upadateThemeColorCode(content.ThemeColorCode, siteName);
            }
            if (content.logoImg != null)
            {
                upadateLogoImg(content.logoImg, siteName);
            }
            if (content.BannerImg != null)
            {
                upadateBanner(content.BannerImg, siteName);
            }
            if (content.ObjectImg != null)
            {
                upadateObjImg(content.ObjectImg, siteName);
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
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET TwitterLink = '{content}' WHERE sitename = '{sitename}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateInsta(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET InstagramLink = '{content}' WHERE sitename = '{sitename}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateLinkedIn(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET LinkedInLink = '{content}' WHERE sitename = '{sitename}'", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateThemeColorCode(string content, string sitename)
        {
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET ThemeColorCode = '{content}' WHERE sitename = '{sitename}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateLogoImg(byte[] content, string sitename)
        {
            string varBinary = ToVarbinary(content);
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET logoImg = {varBinary} WHERE sitename = '{sitename}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateBanner(byte[] content, string sitename)
        {
            string varBinary = ToVarbinary(content);
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET BannerImg = {varBinary} WHERE sitename = '{sitename}';", con);
            cmd.ExecuteNonQuery();
        }
        public void upadateObjImg(byte[] content, string sitename)
        {
            string varBinary = ToVarbinary(content);
            SqlCommand cmd = new SqlCommand($"UPDATE PageContent SET ObjectImg = {varBinary} WHERE sitename = '{sitename}';", con);
            cmd.ExecuteNonQuery();
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
    }
}
