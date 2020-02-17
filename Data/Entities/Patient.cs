namespace WeCare.Data.Entities
{
    public class Patient
    {
        public int Id { get; protected set; }
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string SocialSecurityNumber { get;  set; }

        public Journal Journal { get; protected set; }

        public Patient()
        {

        }
        public Patient(string firstName, string lastName, string socialSecurityNumber)
        {
            // TODO: Verify that params are valid.
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
        }

        public Patient(int id, string firstName, string lastName, string socialSecurityNumber)
           : this(firstName, lastName, socialSecurityNumber)
        {
            Id = id;
        }
    }
}
