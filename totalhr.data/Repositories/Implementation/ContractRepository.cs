﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using totalhr.data.EF;
using totalhr.data.Repositories.Infrastructure;
using totalhr.Shared;
using totalhr.Shared.Models;

namespace totalhr.data.Repositories.Implementation
{
    public class ContractRepository : GenericRepository<TotalHREntities, UserContract>, IContractRepository
    {
        public int AddTemplate(ContractTemplate template)
        {
            try
            {
                Context.ContractTemplates.Add(template);
                return Context.SaveChanges();
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public UserContractData SaveContractData(ContractFillViewInfo model)
        {
            UserContractData contractData = null;

            if (model.ContractId > 0)
            {
                contractData = Context.UserContractDatas.FirstOrDefault(x => x.ContractId == model.ContractId && x.UserId == model.UserId);
            }
           
            //if contract data not found or contract not existent.
            if (contractData == null)
            {
                contractData = new UserContractData
                    {
                        UserId = model.UserId,
                        ContractId = model.ContractId,
                        Created = DateTime.Now,
                        CreatedBy = model.CreatedBy,
                        Data = model.Data
                    }; 
                Context.UserContractDatas.Add(contractData);
            }
            else
            {
                contractData.LastUpdated = DateTime.Now;
                contractData.LastUpdatedBy = model.CreatedBy;
                contractData.Data = model.Data;
            }
           
            Context.SaveChanges();

            return contractData;
        }

        public void SaveContractFieldData(List<UserContractFieldData> lstFieldData)
        {
            Context.UserContractFieldDatas.AddRange(lstFieldData);
            Context.SaveChanges();
        }

        public IEnumerable<GetUserContractDetails_Result> GetUserContractDetails(int userId, int? contractId = null)
        {
            return this.Context.GetUserContractDetails(userId, contractId);
        }

        public IEnumerable<EmployeeContractModel.FieldData> GetEmployeeContractDisplay(int employeeId)
        {
            var contract = this.Context.UserContracts.FirstOrDefault(x => x.Userid == employeeId);
            IEnumerable<EmployeeContractModel.FieldData> query = null;

            if (contract != null)
            {
                var fieldDatas = this.Context.UserContractFieldDatas;
                var formFieldJSon = this.Context.FormFieldJSons;

                query = from formField in formFieldJSon
                            join fieldData in fieldDatas on formField.id equals fieldData.FieldId
                        select new EmployeeContractModel.FieldData { Label = formField.DisplayName, Content = fieldData.Data };
            }


            return query;
        } 
    }
}
