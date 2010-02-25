using NHibernate.Validator.Constraints;
namespace ValidationResourceMessages.Models
{
    public class Customer
    {
        [NotNullNotEmpty]
        [Length(64)]
        public string FirstName { get; set; }

        [NotNullNotEmpty]
        [Length(128)]
        public string Title { get; set; }

        [NotNullNotEmpty]
        [Length(64)]
        public string LastName { get; set; }

        [Range(1, 120)]
        public int Age { get; set; }
    }
}