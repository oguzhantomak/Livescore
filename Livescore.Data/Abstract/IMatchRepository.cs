using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livescore.Entity;

namespace Livescore.Data.Abstract
{
    public interface IMatchRepository
    {
        Task<bool> ControlMatchDetails(Match match);

        Task<List<Match>> AllMatches();
    }
}
