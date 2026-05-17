using MultiLangDemo.Data;
using System.Globalization;

namespace MultiLangDemo.Services
{
    public class DatabaseLocalizer
    {
        private readonly ApplicationDbContext _context;

        public DatabaseLocalizer(ApplicationDbContext context)
        {
            _context = context;
        }

        public string Get(string key)
        {
            var culture = CultureInfo.CurrentUICulture.Name;
            var value = _context.LocalizationResources.FirstOrDefault(x => x.Key == key && x.Culture == culture);
            return value?.Value ?? key;
        }
    }
}
