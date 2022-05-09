.Select(e => new
                {
                    EmployeeAvailabilityId = e.EmployeeAvailabilityId,
                    DriveName = e.Drive.Name,
                    PoolName = e.Drive.Pool.PoolName,
                    IntervieDate = e.InterviewDate,
                    Mode = "Online",
                    LocationName = e.Drive.Location.LocationName,
                   