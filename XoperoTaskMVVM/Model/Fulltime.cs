using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XoperoTaskMVVM.Model
{
    public class Fulltime : Contract
    {
        protected override decimal baseSalary => 3600.00m;

        public Fulltime(): base()
        {
        }

        public override decimal Salary() // Metoda zwraca końcową kwotę wedle wzoru
        {
            return baseSalary + (overtimeHoursOfWork * (3600.00m / 60));
        }
    }
}
