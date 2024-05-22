using Bogus;

namespace BogusLib;

internal class Program
{
    static void Main(string[] args)
    {
        var user = GetUser();
        var users = GetUsers();
        var address = GetAddress();
        var userWithAddress = GetUserWithAddress();
        Console.ReadKey();
    }

    private static User GetUser()
    {
        var userFaker = new Faker<User>()
            .RuleFor(q => q.ID, q => q.Random.Int())
            .RuleFor(q => q.FirstName, q => q.Name.FirstName())
            .RuleFor(q => q.LastName, q => q.Name.LastName())
            .RuleFor(q => q.EmailAddress, q => q.Internet.Email())
            .RuleFor(q => q.BirthDate, q => q.Date.Past(60))
            .RuleFor(q => q.UserState, q => q.PickRandom<UserStatus>());
        var user = userFaker.Generate();
        return user;
    }

    private static List<User> GetUsers()
    {
        var userFaker = new Faker<User>()
                        .RuleFor(q => q.ID, q => q.Random.Int())
                        .RuleFor(q => q.FirstName, q => q.Name.FirstName())
                        .RuleFor(q => q.LastName, q => q.Name.LastName())
                        .RuleFor(q => q.EmailAddress, q => q.Internet.Email())
                        .RuleFor(q => q.BirthDate, q => q.Date.Past(60))
                        .RuleFor(q => q.UserState, q => q.PickRandom<UserStatus>());
        var users = userFaker.Generate(10);
        return users;
    }

    private static Address GetAddress()
    {
        var addressFaker = new Faker<Address>()
                           .RuleFor(q => q.ID, q => q.Random.Int())
                           .RuleFor(q => q.State, q => q.Address.State())
                           .RuleFor(q => q.City, q => q.Address.City())
                           .RuleFor(q => q.ZipCode, q => q.Address.ZipCode())
                           .RuleFor(q => q.Street, q => q.Address.StreetAddress());
        var address = addressFaker.Generate();
        return address;
    }

    private static User GetUserWithAddress()
    {
        var addressFaker = new Faker<Address>()
                           .RuleFor(q => q.ID, q => q.Random.Int())
                           .RuleFor(q => q.State, q => q.Address.State())
                           .RuleFor(q => q.City, q => q.Address.City())
                           .RuleFor(q => q.ZipCode, q => q.Address.ZipCode())
                           .RuleFor(q => q.Street, q => q.Address.StreetAddress());

        var userFaker = new Faker<User>()
                        .RuleFor(q => q.ID, q => q.Random.Int())
                        .RuleFor(q => q.FirstName, q => q.Name.FirstName())
                        .RuleFor(q => q.LastName, q => q.Name.LastName())
                        .RuleFor(q => q.EmailAddress, q => q.Internet.Email())
                        .RuleFor(q => q.BirthDate, q => q.Date.Past(60))
                        .RuleFor(q => q.UserState, q => q.PickRandom<UserStatus>())
                        .RuleFor(q => q.Address, q => addressFaker.Generate());
        var user = userFaker.Generate();
        return user;
    }
}

public enum UserStatus
{
    Active = 1,
    Deactive,
    Ban
}

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

public class Address
{
    public int ID { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Street { get; set; }
}
