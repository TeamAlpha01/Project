using IMS.Models;
using IMS.DataAccessLayer;
using System.ComponentModel.DataAnnotations;
using IMS.Validations;

namespace IMS.Service
{
    public class EmployeeDriveResponseService : IEmployeeDriveResponseService
    {
        private IEmployeeDriveResponseDataAccess _employeeDriveResponseDataAcess;
        private ILogger _logger;

        public EmployeeDriveResponseService(ILogger logger)
        {
            _logger = logger;
            _employeeDriveResponseDataAcess = DataFactory.EmployeeDriveResponseDataFactory.GetEmployeeDriveResponseDataAccessLayerObject(logger);
        }

        public bool AddResponse(EmployeeDriveResponse response)
        {
            if (response == null) throw new ValidationException("Response cannnot be null");

            try
            {
                return _employeeDriveResponseDataAcess.AddResponseToDatabase(response) ? true : false;
            }
            catch (ValidationException responseNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {responseNotValid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                 _logger.LogInformation($"EmployeeDriveResponse Service : AddResponse(EmployeeDriveResponse response) : {exception.Message}");
                return false;
            }
        }

        public bool UpdateResponse(int employeeId, int driveId, int responseType)
        {
            if (driveId <= 0 || employeeId <= 0 || responseType <= 0) throw new ValidationException("DriveId or EmployeeId or Response Type is not valid");

            try
            {
                return _employeeDriveResponseDataAcess.UpdateResponseToDatabase(employeeId, driveId, responseType) ? true : false;
            }
            catch (ValidationException updateResponseNotValid)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : UpdateResponse(int employeeId, int driveId, int responseType) : {updateResponseNotValid.Message}");
                return false;
            }
            catch (Exception exception)
            {
                _logger.LogInformation($"EmployeeDriveResponse Service : UpdateResponse(int employeeId, int driveId, int responseType) : {exception.Message}");
                return false;
            }
        }
    }
}

