using ProjectRecipeBack.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipeBack.Domain
{
    public class Evaluations : BaseDomain
    {
        public string Name { get; set; }
        public GradeEnum Grade { get; set; }
        public int IdRecipe { get; set; }
        public ApprovalEnum Approval { get; set; }

    }
}
