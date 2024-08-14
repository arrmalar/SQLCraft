using Microsoft.AspNetCore.Mvc.Rendering;

namespace SQLCraft.Models.VM
{
    public class ManageQueryRiddle
    {
        public QueryRiddle QueryRiddle { get; set; }

        public IEnumerable<SelectListItem> DBSchemas { get; set; }

        public ICollection<SelectListItem> QuestionLevels { get; set; }
    }
}
