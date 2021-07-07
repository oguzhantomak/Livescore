using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Entity
{
    public class Round
    {
        /// <summary>
        /// The id of the round
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the round
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The short name of the round
        /// </summary>
        public string ShortName { get; set; }

        public virtual ICollection<Match> Matches { get; set; }
    }
}
