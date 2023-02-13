using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discom.UP.Backend.UpDash.Base.Interfaces.MediatorSimulation
{
    //
    // Summary:
    //     Allows for generic type constraints of objects implementing IRequest or IRequest{TResponse}
    public interface IBaseRequest
    {
    }
    //
    // Summary:
    //     Marker interface to represent a request with a response
    //
    // Type parameters:
    //   TResponse:
    //     Response type
    public interface IRequest<out TResponse> : IBaseRequest
    {
    }
}
