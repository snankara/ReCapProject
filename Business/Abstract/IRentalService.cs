using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IRentalService : IServiceRepository<Rental>
    {
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<List<RentalDetailDto>> GetRentalByCarId(int carId);
        IDataResult<List<RentalDetailDto>> GetRentalByCustomerId(int customerId);

    }
}
