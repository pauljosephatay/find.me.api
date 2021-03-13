using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Find.Me.Api.ViewModels
{
    public class UserSummary
    {
        /// <summary>
        /// Id of the user
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Name of the user
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address coordinates of the user
        /// </summary>
        public AddressVM Address { get; set; }
    }
}
