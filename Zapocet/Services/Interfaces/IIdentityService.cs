using Microsoft.EntityFrameworkCore;
using Zapocet.Data;
using Zapocet.Data.Dto;
using Zapocet.Data.Model;

namespace Zapocet.Services.Interfaces
{
    public interface IIdentityService
    {

        bool TokenisValid(string token);

    }
}
