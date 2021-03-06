﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using totalhr.data.EF;
using totalhr.Shared.Models;

namespace totalhr.services.Infrastructure
{
    public interface IContractService
    {
        IEnumerable<UserContract> ListContracts();

        IEnumerable<ContractTemplate> ListContractTemplates(SortingInfo info);

        IEnumerable<ListItemStruct> ListContractTemplates();

        FormInfo GetDefaultTemplate(int languageId);

        int CreateContractTemplate(TemplateInfo info);

        ContractTemplate GetTemplate(int id);

        void UpdateContractTemplate(TemplateInfo info);

        UserContract GetUserContract(int userId);

        UserContract CreateUserContract(UserContractInfo info);

        UserContract UpdateUserContract(UserContractInfo info);

        UserContract GetContract(int contractId);

        Form GetTemplateForm(int templateId);

        UserContractData SaveUserContractData(ContractFillViewInfo model);

        GetUserContractDetails_Result GetUserContractDetails(int userId, int? contractId = null);

        EmployeeContractModel GetEmployeeContractDisplay(int employeeId);
    }
}
