using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livescore.Business.Abstract;
using Livescore.Data.Abstract;
using Livescore.Entity;

namespace Livescore.Business.Concreate
{
    public class MatchManager : IMatchService
    {
        private readonly IMatchRepository _matchRepository;

        public MatchManager(IMatchRepository matchRepository)
        {
            _matchRepository = matchRepository;
        }

        public async Task<bool> ControlMatchDetails(Match match)
        {
            return await _matchRepository.ControlMatchDetails(match);
        }

        public async Task<List<Match>> AllMatches()
        {
            return await _matchRepository.AllMatches();
        }
    }
}
