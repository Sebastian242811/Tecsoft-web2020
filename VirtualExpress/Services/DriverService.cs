using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualExpress.Domain.Models;
using VirtualExpress.Domain.Repositories;
using VirtualExpress.Domain.Services;
using VirtualExpress.Domain.Services.Communications;

namespace VirtualExpress.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DriverService(IDriverRepository driverRepository, IUnitOfWork unitOfWork)
        {
            _driverRepository = driverRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<DriveResponse> DeleteAsync(int id)
        {
            var existingDriver = await _driverRepository.FindById(id);
            if (existingDriver == null)
                return new DriveResponse("Driver not found");
            try
            {
                _driverRepository.Remove(existingDriver);
                await _unitOfWork.CompleteAsync();

                return new DriveResponse(existingDriver);
            }
            catch(Exception e)
            {
                return new DriveResponse($"An error ocurred while deleting the Driver: {e.Message}");
            }
        }

        public async Task<DriveResponse> GetById(int id)
        {
            var existingDriver = await _driverRepository.FindById(id);
            if (existingDriver == null)
                return new DriveResponse("Driver not found");
            return new DriveResponse(existingDriver);
        }

        public async Task<IEnumerable<Driver>> ListAsync()
        {
            return await _driverRepository.ListAsync();
        }

        public async Task<IEnumerable<Driver>> ListByCompanyId(int companyId)
        {
            return await _driverRepository.ListByCompanyId(companyId);
        }

        public async Task<DriveResponse> SaveAsync(Driver driver)
        {
            try
            {
                await _driverRepository.AddAsync(driver);
                await _unitOfWork.CompleteAsync();

                return new DriveResponse(driver);
            }
            catch (Exception e)
            {
                return new DriveResponse($"An error ocurred while saving the Driver: {e.Message}");
            }
        }

        public async Task<DriveResponse> UpdateAsync(int id, Driver driver)
        {
            var existingDriver = await _driverRepository.FindById(id);
            if (existingDriver == null)
                return new DriveResponse("Driver not found");
            existingDriver.Name = driver.Name;
            try
            {
                _driverRepository.Update(existingDriver);
                await _unitOfWork.CompleteAsync();

                return new DriveResponse(existingDriver);
            }
            catch (Exception e)
            {
                return new DriveResponse($"An error ocurred while updating the Driver: {e.Message}");
            }
        }
    }
}
