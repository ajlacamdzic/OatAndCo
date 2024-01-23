using OatAndCo.Models;

namespace OatAndCo.Services
{
    public class KaseService
    {
        private readonly static IEnumerable<Kase> _kase = new List<Kase>
        {
            new Kase
            {
                Name = "Nova Gvineja",
                Image = "bananazobena",
                Price = 4
            },
            new Kase
            {
                Name = "Grcka",
                Image = "malinazobena",
                Price = 4
            },
            new Kase
            {
                Name = "Amerika",
                Image = "borovnicazobena",
                Price = 5
            },
            new Kase
            {
                Name = "Kina",
                Image = "kivizobena",
                Price = 5
            },
            new Kase
            {
                Name = "Orasasti san",
                Image = "orasastazobena",
                Price = 4.5
            },
        };

        public IEnumerable<Kase> GetAllKase() => _kase;

        public IEnumerable<Kase> GetPopularKase(int count = 6) => _kase.OrderBy(p => Guid.NewGuid()).Take(count);

        public IEnumerable<Kase> SearchKases(string searchTerm) => string.IsNullOrWhiteSpace(searchTerm)
            ? _kase
            : _kase.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));
    }
}
