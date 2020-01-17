namespace RealState.Model.Property
{
    public class Apartment : Property
    {
        public Apartment(string code)
        {
            Code = code;
        }

        public Tower Tower { get; set; }
    }
}
