using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TASK_MANAGER.DbContexts;
using TASK_MANAGER.Models;

namespace TASK_MANAGER.Service
{
    public class LabelService : ILabelService
    {   
        private ProjectContext _context;
        public LabelService(ProjectContext context)
        {
            _context = context;
        }

        public ResponseModel AddLabel(LabelRequest labelModel, int issueId)
        {
             ResponseModel model = new ResponseModel();
            try
            {
                Issue issue;
                issue = _context.Find<Issue>(issueId);
                Label label = new Label()
                {
                    desc=labelModel.desc,
                    Issue=issue
                };
                _context.Add<Label>(label);
                _context.SaveChanges();
                issue.Labels.Add(label);
                model.Messsage = "Label Inserted Successfully";
                _context.SaveChanges();
                model.IsSuccess = true;
            }
            catch (Exception ex)
            {
                model.IsSuccess = false;
                model.Messsage = "Error : " + ex.Message;
            }
            return model;
        }

        public ResponseModel DeleteLabel(int labelid)
        {
            ResponseModel model = new ResponseModel();
        try {
            Label label=_context.Find<Label>(labelid);
            Issue issue = _context.Find<Issue>(label.Issue.Id);
            if (issue != null) {
                _context.Remove < Label > (label);
                issue.Labels.Remove(label);
                _context.SaveChanges();
                model.IsSuccess = true;
                model.Messsage = "Label Deleted Successfully";
            } else {
                model.IsSuccess = false;
                model.Messsage = "Label Not Found";
            }
        } catch (Exception ex) {
            model.IsSuccess = false;
            model.Messsage = "Error : " + ex.Message;
        }
        return model;
        }
    }
}