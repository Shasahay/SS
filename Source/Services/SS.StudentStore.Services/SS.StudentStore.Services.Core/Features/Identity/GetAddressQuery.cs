using MediatR;
using SS.StudentStore.Services.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace SS.StudentStore.Services.Core.Features.Identity
{
    public class GetAddressQuery : IRequest<AddressResponse>
    {

    }
}
