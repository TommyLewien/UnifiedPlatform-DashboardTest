using System.Runtime.Serialization;
using Discom.UP.Backend.UpDash.Comm.Interfaces.Application;

namespace Discom.UP.Backend.UpDash.Comm.Interfaces.Infrastructure
{
    /// <summary>
    /// NOT IMMUTABLE DATACONTRACT WITH PUBLIC DEFAULT CONSTRUCTOR (hybrid between datacontract and appsettings poco)
    /// Base class for the persistence context.
    /// </summary>
    [DataContract]
    public class PersistenceContext : DTOBase
    {
        /// <summary>
        /// The application context of the serialization.
        /// </summary>
        [DataMember(Order = 1)]
        public string Application { get; set; }

        /// <summary>
        /// The user context of the serialization.
        /// </summary>
        [DataMember(Order = 2)]
        public string User { get; set; }

        /// <summary>
        /// The storage class, i.e. the class name of the object to be stored.
        /// </summary>
        [DataMember(Order = 3)]
        public string StorageClass { get; set; }

        /// <summary>
        /// The instance name of the concrete object to be stored.
        /// </summary>
        [DataMember(Order = 4)]
        public string Instance { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public PersistenceContext() { }

        /// <summary>
        /// Abstract base class for the persistence context.
        /// </summary>
        /// <param name="application">The application context of the serialization.</param>
        /// <param name="user">The user context of the serialization.</param>
        /// <param name="storageClass">The storage class, i.e. the class name of the object to be stored.</param>
        /// <param name="instance">The instance name of the concrete object to be stored.</param>
        public PersistenceContext(string application, string user, string storageClass, string instance)
        {
            Application = application;
            User = user;
            StorageClass = storageClass;
            Instance = instance;
        }

        /// <summary>
        /// Gets the context properties.
        /// </summary>
        /// <returns>Returns the context properties as a string array.</returns>
        public virtual string[] GetContextProperties()
        {
            return new string[] { "Application", "User", "StorageClass", "Instance" };
        }

        /// <summary>
        /// Gets the context properties.
        /// </summary>
        /// <returns>Returns the context properties as a string array.</returns>
        public virtual string[] GetPropertyValues()
        {
            return new string[] { Application, User, StorageClass, Instance };
        }
        /// <inheritdoc/>
        protected override DTOBase SerializableInstance()
        {
            return new PersistenceContext("Application", "User", "StorageClass", "Instance");
        }

        ///<inheritdoc/>
        public override string ToString()
        {
            return $"{Application}, {User}, {StorageClass}, {Instance}";
        }
    }

}
