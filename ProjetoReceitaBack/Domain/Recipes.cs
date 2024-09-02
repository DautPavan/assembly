using ProjectRecipeBack.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRecipeBack.Domain
{
    public class Recipes : BaseDomain
    {
        public string Title { get; set; }
        public string Preparation { get; set; }
        public string Classification { get; set; }
        public string Time { get; set; }
        public string Photo { get; set; }
        public GastronomyEnum Gastronomy { get; set; }
        public int IdUser { get; set; }
        public int IdDifficulty { get; set; }
        public int IdCategory { get; set; }
        public ApprovalEnum Approval { get; set; }
        public FavoriteEnum Favorite { get; set; }






    }
}
