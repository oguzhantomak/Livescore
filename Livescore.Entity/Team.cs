using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livescore.Entity
{
    public class Team
    {
        /// <summary>
        /// The id of the home/away team
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The full name of the home/away team
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The short name of the home/away team
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// The medium name of the home/away team
        /// </summary>
        public string MediumName { get; set; }

        public Score Score { get; set; }
    }
}
