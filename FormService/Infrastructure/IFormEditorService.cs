﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using totalhr.Shared.Models;
using totalhr.data.EF;

namespace FormService.Infrastructure
{
    public interface IFormEditorService
    {
        int CreateForm(string schema, string name, int formTypeId, int userId);

        int CreateForm(FormInfo info);

        IEnumerable<Form> ListFormsOfType(int formTypeId);

        IEnumerable<ListItemStruct> ListFormsOfTypeSimple(int formTypeId);

        Form GetForm(int id);
       
        ResultInfo SaveFormFields(FormInfo info);

        ResultInfo SaveFieldData(ContractFillViewInfo model);

        int UpdateForm(FormInfo info);
    }
}
