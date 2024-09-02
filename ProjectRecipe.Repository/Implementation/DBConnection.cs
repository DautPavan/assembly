using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectRecipe.Repository
{
    public class DBConnection
    {
        //private static readonly string _connectionString = "Server=db.assembly.pt;Database=JD_YV_DD_Recipe;User Id=Students;Password=SkillUpForTomorrow";

        //private static readonly string _connectionString = "Data Source = DESKTOP-P4BHM2A" +
        //"Initial Catalog=JD_YV_DD_Recipe;" +
        //"Integrated Security = True;Encrypt=False";

        private static readonly string _connectionString = "Server=localhost\\SQLEXPRESS01;Database=JD_YV_DD_Recipe;Trusted_Connection=True;";

        //Server=localhost\SQLEXPRESS01;Database=master;Trusted_Connection=True;

        public static string Open()
        {
            return _connectionString;
        }

    }
}
