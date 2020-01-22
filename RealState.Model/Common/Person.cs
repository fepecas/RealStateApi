namespace RealState.Model.Common
{
    public abstract class Person
    {
        public Person()
        {

        }

        public Person(string firstName, string firstSurname)
        {
            FirstName = firstName;
            FirstSurname = firstSurname;
        }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstSurname { get; set; }
        public string SecondSurname { get; set; }
        public string FullName
        {
            get
            {
                var fullName = FirstName + " " +
                       (string.IsNullOrEmpty(SecondName) ? "" : SecondName + " ") +
                       FirstSurname + " " +
                       (string.IsNullOrEmpty(SecondSurname) ? "" : SecondSurname);

                return fullName.Trim();
            }
        }        

        public virtual string IntroduceHimself()
        {
            return "Hi. I'm " + FullName;
        }
    }
}
