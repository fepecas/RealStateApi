using RealState.Model.Common;

namespace RealState.Model.Sale
{
    public class Customer : Person
    {
        public Customer(string firstName, string firstSurname) : base(firstName, firstSurname)
        {

        }

        public decimal MonthlyIncome { get; set; }

        public override string IntroduceHimself()
        {
            return base.IntroduceHimself() + ". I'm looking for a new property";
        }
    }
}
