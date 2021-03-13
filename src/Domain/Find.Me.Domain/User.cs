using System;

namespace Find.Me.Domain
{
    /// <summary>
    /// User domain model
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets the id of the user
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Gets the name of the user
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the address coordinates
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException"></exception>
        public User(string id, string name, Address address)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentException(nameof(id));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException(nameof(name));
            }

            if (address == null)
            {
                throw new ArgumentException(nameof(address));
            }

            Id = id;
            Name = name;
            Address = address;
        }
    }
}
