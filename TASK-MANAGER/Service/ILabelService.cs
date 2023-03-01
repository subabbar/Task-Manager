using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.Models;

namespace TASK_MANAGER.Service
{
    public interface ILabelService
    {
        ResponseModel AddLabel(LabelRequest labelModel, int issueId);
        ResponseModel DeleteLabel(int issueid);
    }
}