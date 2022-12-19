namespace Banken;
class Program
{
    static void Main(string[] args)
    {
        bool repeatMain = true;

        // Metod för att skapa klass-användare från textdokument
        // Samt öppna olika antal konton att förvara pengar inom till vardera inhämtad användare
        UserAccount[] userAccounts = ImportUsers();

        // do-while STARTMENY
        do
        {
            Console.Clear();
            //for (int i = 0; i < userAccounts.Length; i++)
            //{
            //    Console.WriteLine("{0} {1}", userAccounts[i].Username, userAccounts[i].Password);
            //}

            //foreach (UserAccount user in userAccounts)
            //{
            //    foreach (MoneyAccount moneyAccount in user.MoneyAccounts)
            //    {
            //        Console.WriteLine("Konto: {0} | Saldo: {1} ", moneyAccount.Accountname, moneyAccount.Balance + "\n");
            //    }
            //}

            int optionStart = PrintStartMenu();

            // switch STARTMENY
            switch (optionStart)
            {
                case 1:
                    UserAccount currentUser = LogIn(userAccounts);

                    if (currentUser is UserAccount)
                    {
                        bool repeatUser = true;

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

                                    foreach (MoneyAccount saving in currentUser.MoneyAccounts)
                                    {
                                        Console.WriteLine("{0} | Total saldo: {1}\n", saving.Accountname, saving.Balance);
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
                                    ChangePassword(currentUser);
                                    break;

                                case 5:
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
                    string newUser = CreateAccount();
                    userAccounts = AddUser(userAccounts, ParseRow(newUser));
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
    static UserAccount[] ImportUsers()
    {
        // Deklaration av array med användarkonton
        UserAccount[] userAccounts = new UserAccount[0];

        // Inhämtning av användarnamn & lösenord från textfil
        string input = "";
        try
        {
            input = File.ReadAllText(@"C:\Users\Steven\OneDrive\Dokument\Utbildning\Chas Academy\Programmering i C# (v46 2022 - v8 2023)\source\repos\Chas Academy\Banken-v2\useraccounts.txt");
        }
        catch
        {
            Console.WriteLine("File not found.");
        }

        // Skapar instanser av "class UserAccount" och lagrar dem i array
        var rows = input.Split('\n');
        foreach (var row in rows)
        {
            userAccounts = AddUser(userAccounts, ParseRow(row));
        }

        // Öppnar nya pengarkonton till varje instans av "class UserAccount"
        // som hämtats från textfilen och lagrar dem i en list
        int iterations = 0;
        foreach (UserAccount user in userAccounts)
        {
            switch (iterations)
            {
                case 0:
                    MoneyAccount user0MoneyAccount0 = new MoneyAccount("Privatkonto", 5000);
                    MoneyAccount user0MoneyAccount1 = new MoneyAccount("Sparkonto", 10000);
                    user.MoneyAccounts.Add(user0MoneyAccount0);
                    user.MoneyAccounts.Add(user0MoneyAccount1);
                    break;
                case 1:
                    MoneyAccount user1MoneyAccount0 = new MoneyAccount("Privatkonto", 10000);
                    MoneyAccount user1MoneyAccount1 = new MoneyAccount("Sparkonto 1", 20000);
                    MoneyAccount user1MoneyAccount2 = new MoneyAccount("Sparkonto 2", 5000);
                    user.MoneyAccounts.Add(user1MoneyAccount0);
                    user.MoneyAccounts.Add(user1MoneyAccount1);
                    user.MoneyAccounts.Add(user1MoneyAccount2);
                    break;
                case 2:
                    MoneyAccount user2MoneyAccount0 = new MoneyAccount("Privatkonto", 5000);
                    MoneyAccount user2MoneyAccount1 = new MoneyAccount("Sparkonto 1", 20000);
                    MoneyAccount user2MoneyAccount2 = new MoneyAccount("Sparkonto 2", 15000);
                    MoneyAccount user2MoneyAccount3 = new MoneyAccount("ISK-konto", 25000);
                    user.MoneyAccounts.Add(user2MoneyAccount0);
                    user.MoneyAccounts.Add(user2MoneyAccount1);
                    user.MoneyAccounts.Add(user2MoneyAccount2);
                    user.MoneyAccounts.Add(user2MoneyAccount3);
                    break;
                case 3:
                    MoneyAccount user3MoneyAccount0 = new MoneyAccount("Privatkonto", 2000);
                    MoneyAccount user3MoneyAccount1 = new MoneyAccount("Sparkonto 1", 50000);
                    MoneyAccount user3MoneyAccount2 = new MoneyAccount("Sparkonto 2", 20000);
                    MoneyAccount user3MoneyAccount3 = new MoneyAccount("ISK-konto", 30000);
                    MoneyAccount user3MoneyAccount4 = new MoneyAccount("Räkningskonto", 10000);
                    user.MoneyAccounts.Add(user3MoneyAccount0);
                    user.MoneyAccounts.Add(user3MoneyAccount1);
                    user.MoneyAccounts.Add(user3MoneyAccount2);
                    user.MoneyAccounts.Add(user3MoneyAccount3);
                    user.MoneyAccounts.Add(user3MoneyAccount4);
                    break;
                case 4:
                    MoneyAccount user4MoneyAccount0 = new MoneyAccount("Privatkonto", 4000);
                    MoneyAccount user4MoneyAccount1 = new MoneyAccount("Sparkonto 1", 100000);
                    MoneyAccount user4MoneyAccount2 = new MoneyAccount("Sparkonto 2", 20000);
                    MoneyAccount user4MoneyAccount3 = new MoneyAccount("ISK-konto", 120000);
                    MoneyAccount user4MoneyAccount4 = new MoneyAccount("Räkningskonto", 8000);
                    MoneyAccount user4MoneyAccount5 = new MoneyAccount("Barnens Sparkonto", 50000);
                    user.MoneyAccounts.Add(user4MoneyAccount0);
                    user.MoneyAccounts.Add(user4MoneyAccount1);
                    user.MoneyAccounts.Add(user4MoneyAccount2);
                    user.MoneyAccounts.Add(user4MoneyAccount3);
                    user.MoneyAccounts.Add(user4MoneyAccount4);
                    user.MoneyAccounts.Add(user4MoneyAccount5);
                    break;
            }
            iterations++;
        }
        return userAccounts;
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
            Console.WriteLine("===================================\n");
            Console.WriteLine("            Användarmeny           \n");
            Console.WriteLine("===================================\n");
            Console.WriteLine("1. Se dina konton och saldo");
            Console.WriteLine("2. Överföring mellan konton");
            Console.WriteLine("3. Ta ut pengar");
            Console.WriteLine("4. Ändra lösenord");
            Console.WriteLine("5. Logga ut");

            Console.Write("---> ");
            option = Console.ReadLine();

            success = int.TryParse(option, out result);

            if (success)
            {
                if (result == 1 || result == 2 || result == 3 || result == 4 || result == 5)
                {
                    success = true;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Vänligen ange ett alternativ mellan 1 - 5.");
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

    static UserAccount ParseRow(string userRow)
    {
        var cols = userRow.Split(':');
        UserAccount newUser = new UserAccount("", "");

        for (int i = 0; i < cols.Length; i++)
        {
            switch (i)
            {
                case 0:
                    newUser.Username = cols[i].Trim();
                    break;

                case 1:
                    newUser.Password = cols[i].Trim();
                    break;
            }
        }
        return newUser;
    }

    static UserAccount[] AddUser(UserAccount[] oldUsers, UserAccount userToAdd)
    {
        int numberOfUsers = oldUsers.Length;
        UserAccount[] newUsers = new UserAccount[numberOfUsers + 1];

        for (int l = 0; l < numberOfUsers; l++)
        {
            newUsers[l] = oldUsers[l];
        }

        newUsers[numberOfUsers] = userToAdd;
        return newUsers;
    }

    static string CreateAccount()
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
        }
        while (repeat == true);

        string user = username + ":" + password;

        return user;
    }

    static UserAccount? LogIn(UserAccount[] userAccounts)
    {
        int attempts = 3;
        string username, password;

        Console.Clear();

        while (attempts > 0)
        {
            Console.Write("Användarnamn: ");
            username = Console.ReadLine();

            Console.Write("\nLösenord: ");
            password = Console.ReadLine();

            foreach (var account in userAccounts)
            {
                if (account.Username == username && account.Password == password)
                {
                    return account;
                }
            }
            attempts--;
            Console.WriteLine("Detta konto är inte registrerat.");
            Console.WriteLine(">" + attempts + "< försök kvar.\n");
        }
        return null;
    }

    static void ChangePassword(UserAccount currentUser)
    {
        bool repeat = true;

        Console.Clear();
        do
        {
            Console.WriteLine("Vänligen ange ett nytt lösenord.");
            Console.Write("---> ");
            string newPassword = Console.ReadLine();

            bool success = String.IsNullOrEmpty(newPassword);

            if (success == false)
            {
                Console.Clear();
                currentUser.Password = newPassword;
                Console.WriteLine("Lösenordet har ändrats.");
                Console.Write("Tryck enter för att komma till användarmenyn.");
                Console.ReadLine();
                repeat = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Fältet får inte vara tomt. Vänligen försök igen.");
            }

        } while (repeat);
    }

    static void TransferMoney(UserAccount currentUser)
    {
        int iterations = 0;
        int result, result2;
        double transferAmount;
        bool success, success2, success3;
        string option, option2, option3;

        // Frågar efter vilket konto användaren vill överföra pengar ifrån
        Console.Clear();
        Console.WriteLine("Vänligen ange vilket konto du vill överföra pengar > IFRÅN <.\n");

        foreach (MoneyAccount moneyAccount in currentUser.MoneyAccounts)
        {
            iterations++;
            Console.WriteLine("{0}. {1} | Total saldo: {2} ", iterations, moneyAccount.Accountname, moneyAccount.Balance + "\n");
        }
        Console.Write("---> ");
        option = Console.ReadLine();
        success = int.TryParse(option, out result);

        iterations = 0;
        Console.Clear();

        // Frågar efter vilket konto användaren vill överföra pengar till
        Console.WriteLine("Vänligen ange vilket konto du vill överföra pengar > TILL <.\n");

        foreach (MoneyAccount moneyAccount in currentUser.MoneyAccounts)
        {
            iterations++;
            if (iterations == result)
            {
                Console.WriteLine("{0}. {1} | Total saldo: {2} ", iterations, moneyAccount.Accountname, moneyAccount.Balance + " <---\n");
                continue;
            }
            Console.WriteLine("{0}. {1} | Total saldo: {2} ", iterations, moneyAccount.Accountname, moneyAccount.Balance + "\n");
        }

        Console.Write("---> ");
        option2 = Console.ReadLine();
        success2 = int.TryParse(option2, out result2);

        // Felhanterare & hantering av överföring
        if (success && success2 && result != result2)
        {
            if (result <= iterations && result > 0 && result2 <= iterations && result2 > 0)
            {
                MoneyAccount accountOut = currentUser.MoneyAccounts.ElementAt(result - 1);
                MoneyAccount accountIn = currentUser.MoneyAccounts.ElementAt(result2 - 1);

                Console.WriteLine("\nVänligen ange det belopp du vill överföra.\n");
                Console.Write("---> ");
                option3 = Console.ReadLine();

                success3 = double.TryParse(option3, out transferAmount);

                if (success3 && transferAmount > 0 && transferAmount <= accountOut.Balance)
                {
                    Console.Clear();
                    accountOut.Balance -= transferAmount;
                    accountIn.Balance += transferAmount;

                    foreach (MoneyAccount moneyAccount in currentUser.MoneyAccounts)
                    {
                        Console.WriteLine("{0} | Total saldo: {1} ", moneyAccount.Accountname, moneyAccount.Balance + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDu kan inte överföra det belopp du har angett.\nKontrollera ditt totala saldo innan du anger ett belopp att överföra mellan dina konton.");
                }

            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange ett nummer mellan 1 - {0}.", iterations);
            }
        }
        else if (result == result2)
        {
            Console.WriteLine("\nDu kan inte genomföra en överföring till och från samma konto.");
            Console.WriteLine("Vänligen försök igen.");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange ditt alternativ med siffror.");
        }
        Console.Write("\nTryck enter för att komma till användarmenyn.");
        Console.ReadLine();
    }

    static void WithdrawMoney(UserAccount currentUser)
    {
        int iterations = 0;
        int result;
        double withdrawAmount;
        string option, option2;
        bool success, success2;

        // Frågar efter vilket konto användaren vill ta ut pengar ifrån
        Console.Clear();
        Console.WriteLine("Vänligen ange ett konto att ta ut pengar ifrån.\n");

        foreach (MoneyAccount moneyAccount in currentUser.MoneyAccounts)
        {
            iterations++;
            Console.WriteLine("{0}. {1} | Total saldo: {2} ", iterations, moneyAccount.Accountname, moneyAccount.Balance + "\n");
        }
        Console.Write("---> ");
        option = Console.ReadLine();
        success = int.TryParse(option, out result);

        // Felhanterare & hantering av uttagg
        if (success)
        {
            if (result <= iterations && result > 0)
            {
                MoneyAccount accountOut = currentUser.MoneyAccounts.ElementAt(result - 1);

                Console.WriteLine("\nVänligen ange ett belopp du vill ta ut.\n");
                Console.Write("---> ");
                option2 = Console.ReadLine();

                success2 = double.TryParse(option2, out withdrawAmount);

                if (success2 && withdrawAmount > 0 && withdrawAmount <= accountOut.Balance)
                {
                    Console.Clear();
                    accountOut.Balance -= withdrawAmount;

                    foreach (MoneyAccount moneyAccount in currentUser.MoneyAccounts)
                    {
                        Console.WriteLine("{0} | Total saldo: {1} ", moneyAccount.Accountname, moneyAccount.Balance + "\n");
                    }
                }
                else
                {
                    Console.WriteLine("\nDu kan inte ta ut det belopp du har angett.\nKontrollera ditt totala saldo innan du anger ett belopp att ta ut.");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Vänligen ange ett nummer mellan 1 - {0}.", iterations);
            }
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Vänligen ange ditt alternativ med siffror.");
        }
        Console.Write("\nTryck enter för att komma till användarmenyn.");
        Console.ReadLine();
    }
}

class UserAccount
{
    private string _userName;
    private string _passWord;
    private List<MoneyAccount> _moneyAccount = new List<MoneyAccount>();

    public UserAccount(string username, string password)
    {
        Username = username;
        Password = password;
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
    public List<MoneyAccount> MoneyAccounts
    {
        get { return _moneyAccount; }
        set { _moneyAccount = value; }
    }
}

class MoneyAccount
{
    private string _accountName = "Privatkonto";
    private double _balance = 0;

    public MoneyAccount(string accountname, double balance)
    {
        _accountName = accountname;
        _balance = balance;
    }
    public string Accountname
    {
        get { return _accountName; }
        set { _accountName = value; }
    }
    public double Balance
    {
        get { return _balance; }
        set { _balance = Math.Truncate(value * 100) / 100; }
    }
}