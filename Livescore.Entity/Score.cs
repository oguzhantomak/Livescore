using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Entity
{
    public class Score
    {
        public int Id { get; set; }
        /// <summary>
        /// The regular score of the match for home/away team
        /// </summary>
        public int Regular { get; set; }

        /// <summary>
        /// The half-time score of the match for home/away team
        /// </summary>
        public int HalfTime { get; set; }

        /// <summary>
        /// The current score of the match (live and post) for home/away team
        /// </summary>
        public int Current { get; set; }

        /// <summary>
        /// The penalty score of the match for home/away team
        /// </summary>
        public int Penalties { get; set; }

        /// <summary>
        /// The extra time score of the match for home/away team
        /// </summary>
        public int ExtraTime { get; set; }
    }
}
