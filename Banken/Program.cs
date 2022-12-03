namespace Banken;
class Program
{
    static void Main(string[] args)
    {
        bool repeatMain = true;
        UserAccount? currentUser;

        // Deklaration av lista med användarkonton
        List<UserAccount> userAccountList = new List<UserAccount>();

        // Hårdkodad användare #1
        UserAccount user0 = new UserAccount("Greger", "123");
        user0.SavingsAccounts.Add(new SavingsAccount(5000));
        user0.PayrollAccounts.Add(new PayrollAccount(1000));
        userAccountList.Add(user0);

        // Hårdkodad användare #2
        UserAccount user1 = new UserAccount("Kristian", "abc");
        user1.SavingsAccounts.Add(new SavingsAccount(10000));
        user1.PayrollAccounts.Add(new PayrollAccount(2000));
        userAccountList.Add(user1);

        // Hårdkodad användare #3
        UserAccount user2 = new UserAccount("Erik", "fabel2");
        user2.SavingsAccounts.Add(new SavingsAccount(20000));
        user2.PayrollAccounts.Add(new PayrollAccount(4000));
        userAccountList.Add(user2);

        // Hårdkodad användare #4
        UserAccount user3 = new UserAccount("Anton", "anteh52");
        user3.SavingsAccounts.Add(new SavingsAccount(40000));
        user3.PayrollAccounts.Add(new PayrollAccount(8000));
        userAccountList.Add(user3);

        // Hårdkodad användare #5
        UserAccount user4 = new UserAccount("Mohammed", "98hamed89");
        user4.SavingsAccounts.Add(new SavingsAccount(80000));
        user4.PayrollAccounts.Add(new PayrollAccount(16000));
        userAccountList.Add(user4);

        // do-while STARTMENY
        do
        {
            Console.Clear();

            int optionStart = PrintStartMenu();

            // switch STARTMENY
            switch (optionStart)
            {
                case 1:
                    UserAccount success = LogIn(userAccountList);

                    if (success is UserAccount)
                    {
                        bool repeatUser = true;
                        currentUser = success;

                        // do-while ANVÄNDARMENY
                        do
                        {
                            Console.Clear();

                            int optionUser = PrintUserMenu();

                            // switch ANVÄNDARMENY
                            switch (optionUser)
                            {
                                case 1:
                                    Console.Clear();

                                    foreach (SavingsAccount saving in currentUser.SavingsAccounts)
                                    {
                                        Console.WriteLine("{0}\nTotal saldo: {1}\n", saving.Accountname, saving.Balance);
                                    }

                                    foreach (PayrollAccount payroll in currentUser.PayrollAccounts)
                                    {
                                        Console.WriteLine("{0}\nTotal saldo: {1}", payroll.Accountname, payroll.Balance);
                                    }

                                    Console.Write("\nTryck enter för att komma till användarmenyn.");
                                    Console.ReadLine();
                                    break;

                                case 2:
                                    TransferMoney(currentUser);
                                    break;

                                case 3:
                                    WithdrawMoney(currentUser);
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
                        Console.Write("\nTryck enter för att komma till huvudmenyn.");
                        Console.ReadLine();
                    }
                    break;

                case 2:
                    userAccountList.Add(CreateAccount());
                    break;

                case 3:
                    Console.WriteLine("\nTack för att du använt banken, Välkommen åter.");
                    repeatMain = false;
                    break;

                default:
                    Console.WriteLine("\nEtt fel har uppstått, kontakta utvecklaren.");
                    break;
            }
        } while (repeatMain);
    }

    static int PrintStartMenu()
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

    static int PrintUserMenu()
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

    static UserAccount CreateAccount()
    {
        bool repeat = true;
        string username, password;

        do
        {
            Console.Clear();
            Console.Write("Användarnamn: ");
            username = Console.ReadLine();

            Console.Write("\nLösenord: ");
            password = Console.ReadLine();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                Console.WriteLine("\nDu måste ange ett användarnamn och lösenord.");
                Console.Write("Tryck enter för att försöka igen.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nEn ny användare har skapats!");
                Console.Write("Tryck enter för att komma till huvudmenyn.");
                Console.ReadLine();
                repeat = false;
            }
        } while (repeat == true);

        return new UserAccount(username, password);
    }

    static UserAccount? LogIn(List<UserAccount> userAccountList)
    {
        int attempts = 3;

        Console.Clear();

        while (attempts > 0)
        {
            Console.Write("Användarnamn: ");
            string username = Console.ReadLine();

            Console.Write("\nLösenord: ");
            string password = Console.ReadLine();

            foreach (UserAccount account in userAccountList)
            {
                if (username == account.Username && password == account.Password)
                {
                    return account;
                }

            }
            attempts--;
            Console.Clear();
            Console.WriteLine("Detta konto är inte registrerat.");
            Console.WriteLine(">" + attempts + "< försök kvar.\n");
        }
        return null;
    }

    static void TransferMoney(UserAccount currentUser)
    {
        bool success;
        string option, amount;

        do
        {
            int iterations = 0;

            Console.Clear();
            Console.WriteLine("Lista med konton för att hantera överföring.");

            foreach (SavingsAccount saving in currentUser.SavingsAccounts)
            {
                iterations++;
                Console.WriteLine(iterations + ". {0}", saving.Accountname);
            }

            foreach (PayrollAccount payroll in currentUser.PayrollAccounts)
            {
                iterations++;
                Console.WriteLine(iterations + ". {0}", payroll.Accountname);
            }
            Console.WriteLine("\nVänligen ange ett konto: ");
            Console.Write("--->");
            option = Console.ReadLine();

            success = float.TryParse(option, out float result);

            switch (result)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Ange belopp att överföra till lönekonto.");
                    Console.Write("---> ");
                    amount = Console.ReadLine();

                    success = float.TryParse(amount, out result);

                    if (success)
                    {
                        Console.Clear();
                        foreach (SavingsAccount savingsAccount in currentUser.SavingsAccounts)
                        {
                            if (savingsAccount.Balance >= result && result >= 0)
                            {
                                savingsAccount.Balance -= result;
                                Console.WriteLine("{0}\nTotal saldo: {1}\n", savingsAccount.Accountname, savingsAccount.Balance);

                                foreach (PayrollAccount payrollAccount in currentUser.PayrollAccounts)
                                {
                                    payrollAccount.Balance += result;
                                    Console.WriteLine("{0}\nTotal saldo: {1}\n", payrollAccount.Accountname, payrollAccount.Balance);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Du har inte tillräckligt mycket pengar på kontot för att genomföra detta ärende.");
                            }
                        }
                        Console.Write("\nTryck enter för att komma till användarmenyn.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange ett giltigt belopp.");
                        Console.Write("\nTryck enter för att gå tillbaka.");
                        Console.ReadLine();
                    }
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Ange belopp att överföra till sparkonto.");
                    Console.Write("---> ");
                    amount = Console.ReadLine();

                    success = float.TryParse(amount, out result);

                    if (success)
                    {
                        Console.Clear();
                        foreach (PayrollAccount payrollAccount in currentUser.PayrollAccounts)
                        {
                            if (payrollAccount.Balance >= result && result >= 0)
                            {
                                payrollAccount.Balance -= result;
                                Console.WriteLine("{0}\nTotal saldo: {1}\n", payrollAccount.Accountname, payrollAccount.Balance);
                                foreach (SavingsAccount savingsAccount in currentUser.SavingsAccounts)
                                {
                                    savingsAccount.Balance += result;
                                    Console.WriteLine("{0}\nTotal saldo: {1}\n", savingsAccount.Accountname, savingsAccount.Balance);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Du har inte tillräckligt mycket pengar på kontot för att genomföra detta ärende.");
                            }
                        }
                        Console.Write("\nTryck enter för att komma till användarmenyn.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange ett giltigt belopp.");
                        Console.Write("\nTryck enter för att försöka igen.");
                        Console.ReadLine();
                    }
                    break;

                default:
                    Console.WriteLine("Vänligen ange ett alternativ mellan 1-3.");
                    break;
            }

        } while (!success);
    }

    static void WithdrawMoney(UserAccount currentUser)
    {
        bool success;
        string option, amount;

        do
        {
            int iterations = 0;

            Console.Clear();
            Console.WriteLine("Lista med konton för att hantera uttag.");

            foreach (SavingsAccount saving in currentUser.SavingsAccounts)
            {
                iterations++;
                Console.WriteLine(iterations + ". {0}", saving.Accountname);
            }

            foreach (PayrollAccount payroll in currentUser.PayrollAccounts)
            {
                iterations++;
                Console.WriteLine(iterations + ". {0}", payroll.Accountname);
            }

            Console.WriteLine("\nVänligen ange ett konto: ");
            Console.Write("--->");
            option = Console.ReadLine();

            success = float.TryParse(option, out float result);

            switch (result)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Ange belopp för uttag från sparkonto.");
                    Console.Write("---> ");
                    amount = Console.ReadLine();

                    success = float.TryParse(amount, out result);

                    if (success)
                    {
                        Console.Clear();
                        foreach (SavingsAccount savingsAccount in currentUser.SavingsAccounts)
                        {
                            if (savingsAccount.Balance >= result && result >= 0)
                            {
                                savingsAccount.Balance -= result;
                                Console.WriteLine("Konto: {0}\nTotal saldo: {1}\n", savingsAccount.Accountname, savingsAccount.Balance);
                            }
                            else
                            {
                                Console.WriteLine("Du har inte tillräckligt mycket pengar på kontot för att genomföra detta ärende.");
                            }
                        }
                        Console.Write("\nTryck enter för att komma till användarmenyn.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange ett giltigt belopp.");
                        Console.Write("\nTryck enter för att gå tillbaka.");
                        Console.ReadLine();
                    }
                    break;

                case 2:
                    Console.Clear();
                    Console.WriteLine("Ange belopp för uttag från sparkonto.");
                    Console.Write("---> ");
                    amount = Console.ReadLine();

                    success = float.TryParse(amount, out result);

                    if (success)
                    {
                        Console.Clear();
                        foreach (PayrollAccount payrollAccount in currentUser.PayrollAccounts)
                        {
                            if (payrollAccount.Balance >= result && result >= 0)
                            {
                                payrollAccount.Balance -= result;
                                Console.WriteLine("Konto: {0}\nTotal saldo: {1}\n", payrollAccount.Accountname, payrollAccount.Balance);
                            }
                            else
                            {
                                Console.WriteLine("Du har inte tillräckligt mycket pengar på kontot för att genomföra detta ärende.");
                            }
                        }
                        Console.Write("\nTryck enter för att komma till användarmenyn.");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Vänligen ange ett giltigt belopp.");
                        Console.Write("\nTryck enter för att gå tillbaka.");
                        Console.ReadLine();
                    }
                    break;

                default:

                    break;
            }

        } while (!success);
    }
}

class UserAccount
{
    private string _userName;
    private string _passWord;
    private List<SavingsAccount> _savingsAccounts = new List<SavingsAccount>();
    private List<PayrollAccount> _payrollAccounts = new List<PayrollAccount>();

    public UserAccount(string username, string password)
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

    public List<SavingsAccount> SavingsAccounts
    {
        get { return _savingsAccounts; }
        set { _savingsAccounts = value; }
    }

    public List<PayrollAccount> PayrollAccounts
    {
        get { return _payrollAccounts; }
        set { _payrollAccounts = value; }
    }
}

class SavingsAccount
{
    private string _accountName = "Savings account";
    private float _balance = 5000;

    public SavingsAccount(float balance)
    {
        _balance = balance;
    }
    public string Accountname
    {
        get { return _accountName; }
        set { _accountName = value; }
    }
    public float Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
}

class PayrollAccount
{
    private string _accountName = "Payroll account";
    private float _balance = 1000;

    public PayrollAccount(float balance)
    {
        _balance = balance;
    }
    public string Accountname
    {
        get { return _accountName; }
        set { _accountName = value; }
    }

    public float Balance
    {
        get { return _balance; }
        set { _balance = value; }
    }
}
