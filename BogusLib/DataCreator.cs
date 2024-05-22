using Bogus;
namespace BogusLib;
public static class DataCreator
{
    public static User GetUser()
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

    public static List<User> GetUsers()
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

    public static Address GetAddress()
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

    public static User GetUserWithAddress()
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