using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SQLCraft.Models.VM
{
    public class ManageQueryRiddle
    {
        public QueryRiddle QueryRiddle { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> DBSchemas { get; set; }

        [ValidateNever]
        public IEnumerable<SelectListItem> QuestionLevels { get; set; }
    }
}
