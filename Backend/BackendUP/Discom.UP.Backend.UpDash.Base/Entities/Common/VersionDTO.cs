using System.Reflection;
using System.Runtime.Serialization;
using Discom.UP.Backend.UpDash.Base.Interfaces.Application;

namespace Discom.UP.Backend.UpDash.Base.Entities.Common
{

    [DataContract]
    public class VersionDTO : DTOBase
    {
        /// <summary>
        /// Major
        /// </summary>
        [DataMember(Order = 1)]
        public int Major { get; private set; }

        /// <summary>
        /// Minor
        /// </summary>
        [DataMember(Order = 2)]
        public int Minor { get; private set; }

        /// <summary>
        /// Patch
        /// </summary>
        [DataMember(Order = 3)]
        public int Patch { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="major"></param>
        /// <param name="minor"></param>
        /// <param name="patch"></param>
        public VersionDTO(int major, int minor, int patch = 0)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }

        /// <summary>
        /// Constructor for Serialization
        /// </summary>
        private VersionDTO() { }

        /// <inheritdoc/>
        protected override DTOBase SerializableInstance()
        {
            return new VersionDTO(2, 0, 23);
        }

        /// <summary>
        /// Returns the System Version Object
        /// </summary>
        /// <returns></returns>
        public Version Version()
        {
            return new Version(Major, Minor, Patch);
        }
    }
}
