namespace BogusLib;
public class User
{
    public int ID { get; set; }
    public UserStatus UserState { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public DateTime BirthDate { get; set; }
    public Address Address { get; set; }
}