using RealState.Model.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace RealState.Model.Sale
{
    public class SalesPerson : Person
    {
        public SalesPerson(string firstName, string firstSurname) : base(firstName, firstSurname)
        {

        }

        public int SeniorityLevel { get; set; }

        public override string IntroduceHimself()
        {
            return base.IntroduceHimself() + ". How can I help you?";
        }
    }
}
