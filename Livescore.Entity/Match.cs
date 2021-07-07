using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Entity
{
    public class Match
    {
        public Match()
        {
            SystemUpdateDate=DateTime.Now;
        }
        /// <summary>
        /// The id of the match
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The kick-off date of the match, includes also time
        /// </summary>
        public DateTime Date { get; set; }

        public Team HomeTeam { get; set; }

        public Team AwayTeam { get; set; }

        /// <summary>
        /// Datanın çekildiği tarih set edilecek.
        /// </summary>
        public DateTime SystemUpdateDate { get; set; }

        public int StatusId { get; set; }
        public Status Status { get; set; }

        public int StageId { get; set; }
        public Stage Stage { get; set; }

        public int RoundId { get; set; }
        public virtual Round Round { get; set; }

        public int TournamentId { get; set; }
        public Tournament Tournament { get; set; }

        //public Times Times { get; set; }
        public virtual ICollection<Times> Times { get; set; }

        //public int HomeTeamScoreId { get; set; }
        //public Score HomeTeamScore { get; set; }

        //public int AwayTeamScoreId { get; set; }
        //public Score AwayTeamScore { get; set; }


    }
}
