namespace XoperoTaskMVVM.Model
{
    public abstract class Contract
    {
        /// <summary>
        /// Lista pól zawierających właściwości programu
        /// </summary>
        protected abstract decimal baseSalary {get;}
        protected int overtimeHoursOfWork;

        public Contract()
        {
            this.overtimeHoursOfWork = 0;
        }
        public abstract decimal Salary(); // Abstrakcyjna klasa zwracająca wynagrodzenie
    }
}
