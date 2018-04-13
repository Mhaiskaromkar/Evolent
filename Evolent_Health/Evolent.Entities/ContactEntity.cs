namespace Evolent.Entities
{
    /// <summary>
    /// <see cref="ContactEntity"/> Class
    /// </summary>
    public class ContactEntity
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
