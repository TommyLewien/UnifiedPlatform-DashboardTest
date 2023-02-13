
using System.Runtime.Serialization;
using Discom.UP.Backend.UpDash.Base.Entities.Common;
using Discom.UP.Backend.UpDash.Base.Interfaces.MediatorSimulation;

namespace Discom.UP.Backend.UpDash.Base.Interfaces.Application
{
    /// <summary>
    /// Request Base
    /// </summary>
    [DataContract]
    public class RequestBase : RequestBase<Unit>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected RequestBase() : base()
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        protected RequestBase(Guid id) : base(id)
        {
        }

    }
    /// <summary>
    /// Request Base
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    [DataContract]
    public class RequestBase<TResult> : IIdentifiableRequest<TResult>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        protected RequestBase()
        {
            RequestId = Guid.NewGuid();
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id"></param>
        protected RequestBase(Guid id)
        {
            RequestId = id;
        }
        /// <summary>
        /// Unique Request Id
        /// </summary>
        public Guid RequestId { get; private set; }

    }

    /// <summary>
    /// Processing Request Base
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    [DataContract]
    public abstract class ProcessingRequestBase<TResult> : RequestBase<TResult>
    {
        /// <summary>
        /// Method which yields the processing context.
        /// </summary>
        /// <returns>Returns the specific processing context.</returns>
        public abstract ProcessingContext Context();
        /// <summary>
        /// Returns a default Instance for Testing purposes
        /// </summary>
        /// <returns></returns>
        protected abstract ProcessingRequestBase<TResult> SerializableInstance();
    }
}
