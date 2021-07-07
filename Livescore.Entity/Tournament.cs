using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Entity
{
    public class Tournament
    {
        /// <summary>
        /// The id of the stage
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// The name of the tournament
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The short name of the tournament
        /// </summary>
        public string ShortName { get; set; }
    }
}
