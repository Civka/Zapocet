using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using Zapocet.Data;
using Zapocet.Data.Dto;
using Zapocet.Data.Model;
using Zapocet.Services.Interfaces;

namespace Zapocet.Services
{

    public class IdentityService : MasterService, IIdentityService
    {
        public IdentityService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool TokenisValid(string token)
        {


            var result = _context.CompanyKeys
                .Where(x => x.CompanyHash.Equals(token))
                .Any();

            return result;

        }
    }
}
