using Microsoft.EntityFrameworkCore;
using Zapocet.Data;
using Zapocet.Data.Dto;
using Zapocet.Data.Model;

namespace Zapocet.Services.Interfaces
{
    public interface IEshopService
    {
       GenericResponseDto AddEshopData(List<EshopDto> eshopsDto);
        List<EshopExport> GetEshopData();
    }
}
