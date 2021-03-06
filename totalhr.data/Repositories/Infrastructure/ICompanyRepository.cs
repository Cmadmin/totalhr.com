﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using totalhr.data.EF;

namespace totalhr.data.Repositories.Infrastructure
{
    public interface ICompanyRepository :IGenericRepository<Company>
    {
        List<Department> GetCompanyDepartments(int companyid);

        List<string> GetCompanyDepartmentsByIds(List<int> ids);

        IEnumerable<Shared.Models.ListItemStruct> GetDeparmentSimple(int companyId);

        int CreateDepartment(int companyId, int userId, string departmentName, string description);

        IEnumerable<User> ListEmployees(int companyId);
    }
}
