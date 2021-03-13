using System;
using System.Collections.Generic;
using System.Text;

namespace Find.Me.Domain
{
    public class Address
    {
        /// <summary>
        /// Address latitude
        /// </summary>
        public double Lat { get; }

        /// <summary>
        /// Address longitude
        /// </summary>
        public double Lng { get; }

        /// <summary>
        /// Address name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Address with pets or not
        /// </summary>
        public bool WithPets { get; }

        /// <summary>
        /// Photo url of pet
        /// </summary>
        public string PetPhoto { get; }

        /// <summary>
        /// Create an instance of Address
        /// </summary>
        /// <param name="lat">The latitude position</param>
        /// <param name="lng">The longitude position</param>
        /// <param name="name">The name of the address</param>
        /// <param name="withPets">Is the address with pets or not</param>
        /// <param name="petPhoto">The photo url of the pet</param>
        public Address(double lat, double lng, string name, bool withPets, string petPhoto)
        {
            Lat = lat;
            Lng = lng;
            Name = name;
            WithPets = withPets;
            PetPhoto = petPhoto;
        }
    }
}
