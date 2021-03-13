using System;
using System.Collections.Generic;
using System.Text;

namespace Find.Me.Api.Repository.Entities
{
    public class AddressValueObject
    {
        /// <summary>
        /// Address latitude
        /// </summary>
        public double Lat  { get; set; }

        /// <summary>
        /// Address longitude
        /// </summary>
        public double Lng { get; set; }

        /// <summary>
        /// Address name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Address with pets or not
        /// </summary>
        public bool WithPets { get; set; }

        /// <summary>
        /// Photo url of pet
        /// </summary>
        public string PetPhoto { get; set; }
    }
}
