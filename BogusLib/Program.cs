namespace BogusLib;

public class Program
{
    static void Main(string[] args)
    {
        var user = DataCreator.GetUser();
        var users = DataCreator.GetUsers();
        var address = DataCreator.GetAddress();
        var userWithAddress = DataCreator.GetUserWithAddress();
        Console.ReadKey();
    }
}