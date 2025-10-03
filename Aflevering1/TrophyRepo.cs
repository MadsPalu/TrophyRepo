using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aflevering1
{
    public class TrophyRepo
    {
        private readonly List<Trophy> _trophies = new List<Trophy>();
        private int _nextId = 1;

        public List<Trophy> Get(int? year = null, string? sortBy = null)
        {
            IEnumerable<Trophy> query = _trophies;

            //Filter
            if (year.HasValue)
                query = query.Where(t => t.Year == year.Value);

            //Sort
            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "year":
                        query = query.OrderBy(t => t.Year);
                        break;
                    case "competition":
                        query = query.OrderBy(t => t.Competition);
                        break;
                }
            }

            //Return copy repo
            return query.Select(t => new Trophy(t)).ToList();
        }


        public Trophy? GetById(int id)
        {
            return _trophies.FirstOrDefault(a => a.Id == id);
        }

        public Trophy Add(Trophy trophy)
        {
            trophy.Id = _nextId++;
            _trophies.Add(trophy);
            return trophy;
        }

        public Trophy? Remove(int id)
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                _trophies.Remove(trophy);
            }
            return trophy;
        }

        public Trophy? Update(int id, Trophy values) 
        {
            var trophy = GetById(id);
            if (trophy != null)
            {
                trophy.Competition = values.Competition;
                trophy.Year = values.Year;
                return trophy;
            }
            return null;
        }


    }
}
