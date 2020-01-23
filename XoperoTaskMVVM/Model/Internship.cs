namespace XoperoTaskMVVM.Model
{
    public class Internship : Contract
    {
        protected override decimal baseSalary => 1500.00m;
        public Internship() : base()
        {
        }
        public override decimal Salary() // Metoda zwraca końcową kwotę Wynagrodzenia stażysty
        {
           return baseSalary;
        }
    }
}
