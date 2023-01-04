using Microsoft.EntityFrameworkCore;
using OuglaWebApp.Models;

namespace OuglaWebApp.DataLogic
{
    public class SiteControll
    {
        private readonly OuglaContext _context = null;
        public SiteControll(OuglaContext context)
        {
            _context = context;
        }
        public bool ValidateSiteName(string site)
        {
            if (_context.Infos.Any(o => o.Sitename == site))
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
