using System;
using System.Collections.Generic;
using System.Text;
using Discom.UP.Backend.UpDash.Base.Interfaces.MediatorSimulation;

namespace Discom.UP.Backend.UpDash.Base.Interfaces.Application
{
    /// <summary>
    /// Add unique identifyier for request.
    /// </summary>
    public interface IIdentifiableRequest<out TRequest> : IRequest<TRequest>
    {
        /// <summary>
        /// Unique identifyier of request.
        /// </summary>
        Guid RequestId { get; }
    }

    /// <summary>
    /// Add unique identifyier for request.
    /// </summary>
    public interface IIdentifiableRequest : IIdentifiableRequest<Unit>
    {
    }
}
