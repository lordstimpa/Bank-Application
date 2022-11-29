namespace Banken;
class Program
{
    static void Main(string[] args)
    {
        bool repeat = true;

        List<Account> accountList = new List<Account>();

        do
        {
            Console.Clear();

            int optionStart = printStartMenu();

            switch (optionStart)
            {
                case 1:
                    bool success = logIn(accountList);

                    if (success == true)
                    {
                        bool repeatUser = true;

                        do
                        {
                            Console.Clear();

                            int optionUser = printUserMenu();

                            switch (optionUser)
                            {
                                case 1:
                                    Console.Clear();
                                    foreach (var account in accountList)
                                    {
                                        Console.WriteLine("Användarnamn: {0}\nSaldo: {1}", account.Username, account.Balance) ;
                                    }
                                    Console.Write("\nTryck enter för att komma till användarmenyn.");
                                    Console.ReadLine();

                                    break;

                                case 2:

                                    break;

                                case 3:

                                    break;

                                case 4:
                                    repeatUser = false;
                                    break;

                                default:
                                    Console.WriteLine("Ett fel har uppstått, kontakta utvecklaren.");
                                    break;
                            }

                        } while (repeatUser);
                    }
                    else
                    {
                        Console.WriteLine("Du har inga försök kvar.");
                        Console.Write("Tryck enter för att komma till huvudmenyn.");
                        Console.ReadLine();
                    }
                    break;

                case 2:
                    accountList = createAccount(accountList);
                    break;

                case 3:
                    Console.WriteLine("\nTack för att du använt banken, Välkommen åter.");
                    repeat = false;
                    break;

                default:
                    Console.WriteLine("\nEtt fel har uppstått, kontakta utvecklaren.");
                    break;
            }
        } while (repeat);
    }

    static int printStartMenu()
    {
        bool success;
        int result;
        string option;

        do
        {
            Console.WriteLine("===================================\n");
            Console.WriteLine("       Välkommen till banken!      \n");
            Console.WriteLine("===================================\n");
            Console.WriteLine("Vänligen ange ett alternativ nedan:");
            Console.WriteLine("1. Logga in");
            Console.WriteLine("2. Skapa konto");
            Console.WriteLine("3. Avsluta");

            Console.Write("---> ");
            option = Console.ReadLine();

            success = int.TryParse(option, out result);
            
            if (success)
            {
                if (result == 1 || result == 2 || result == 3)
                {
                    return result;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Vänligen ange ett alternativ mellan 1 - 3.");
                    success = false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange ditt alternativ med siffror.");
            }

        } while (!success);

        return result;
    }
    
    static int printUserMenu()
    {
        bool success;
        int result;
        string option;

        do
        {
            Console.Clear();
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Logga ut");

            Console.Write("---> ");
            option = Console.ReadLine();

            success = int.TryParse(option, out result);

            if (success)
            {
                if (result == 1 || result == 2 || result == 3 || result == 4)
                {
                    success = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Vänligen ange ett alternativ mellan 1 - 4.");
                    success = false;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange ditt alternativ med siffror.");
            }
        } while (!success);

        return result;
    }

    static List<Account> createAccount(List<Account> accountList)
    {
        Console.Clear();
        Console.Write("Användarnamn: ");
        string username = Console.ReadLine();

        Console.Write("\nLösenord: ");
        string password = Console.ReadLine();

        accountList.Add(new Account(username, password));

        Console.WriteLine("\nEn ny användare har skapats!");
        Console.Write("Tryck enter för att komma till huvudmenyn.");
        Console.ReadLine();

        return accountList;
    }

    static bool logIn(List<Account> accountList)
    {
        int attempts = 5;
        bool success = false;

        Console.Clear();

        if (accountList.Count() == 0)
        {
            attempts = 0;
            success = false;
        }

        while (attempts > 0)
        {
            Console.Write("Användarnamn: ");
            string userName = Console.ReadLine();

            Console.Write("\nLösenord: ");
            string passWord = Console.ReadLine();

            foreach (var account in accountList)
            {
                if (userName == account.Username && passWord == account.Password)
                {
                    attempts = 0;
                    success = true;
                    break;
                }
                else
                {
                    attempts--;
                    success = false;
                    Console.Clear();
                    Console.WriteLine("Detta konto är inte registrerat.");
                    Console.WriteLine(attempts + " försök kvar.");
                    break;
                }
            }
        }
        return success;
    }

    static void transferMoney()
    {

    }

    static void withdrawMoney()
    {

    }
}

public class Account
{
    string _userName;
    string _passWord;
    double _balance;

    public Account(string username, string password)
    {
        _userName = username;
        _passWord = password;
    }

    public string Username
    {
        get { return _userName; }
        set { _userName = value; }
    }

    public string Password
    {
        get { return _passWord; }
        set { _passWord = value; }
    }

    public double Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }

}