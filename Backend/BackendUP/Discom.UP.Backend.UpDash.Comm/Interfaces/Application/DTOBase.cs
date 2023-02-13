using System.Reflection;
using System.Runtime.Serialization;

namespace Discom.UP.Backend.UpDash.Comm.Interfaces.Application
{
    /// <summary>
    /// Base Class for all DTOs
    /// </summary>
    [DataContract]
    public abstract class DTOBase
    {
        /// <summary>
        /// Returns a default Instance for Testing purposes
        /// </summary>
        /// <returns></returns>
        protected abstract DTOBase SerializableInstance();
    }
    /// <summary>
    /// Utility To Create Instance
    /// </summary>
    public static class DTOBaseUtility
    {
        /// <summary>
        /// Template for Creation
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T SerializableInstance<T>() where T : DTOBase
        {
            var obj = typeof(T).GetMethod("SerializableInstance", BindingFlags.NonPublic | BindingFlags.Instance).Invoke((T)FormatterServices.GetUninitializedObject(typeof(T)), null);
            return (T)obj;
        }
    }
}
