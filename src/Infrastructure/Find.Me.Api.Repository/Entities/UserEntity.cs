using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Find.Me.Api.Repository.Entities
{
    /// <summary>
    /// User entitty model
    /// </summary>
    public class UserEntity: DocumentBase
    {
        /// <summary>
        /// Gets the name of the user
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// Gets the address coordinates of the user
        /// </summary>
        
        public AddressValueObject Address { get; set; }
    }
}
