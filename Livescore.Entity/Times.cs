using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Entity
{
    public class Times
    {
        public int Id { get; set; }
        /// <summary>
        /// Current minute of the match
        /// </summary>
        public int CurrentMinute { get; set; }

        /// <summary>
        /// Stoppage minute of the match
        /// </summary>
        public int Stoppage { get; set; }
    }
}
