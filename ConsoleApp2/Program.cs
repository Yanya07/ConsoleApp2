using System;

class BankAccount
{
    private string accountNumber; // Номер счета
    private string owner;          // Владелец
    private decimal balance;       // Баланс

    // Конструктор для инициализации
    public BankAccount(string accountNumber, string owner, decimal initialBalance)
    {
        this.accountNumber = accountNumber;
        this.owner = owner;
        this.balance = initialBalance;
    }

    // Методы для получения значений
    public string GetAccountNumber() => accountNumber;
    public string GetOwner() => owner;
    public decimal GetBalance() => balance;

    // Методы для пополнения и снятия средств
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Пополнение на {amount}. Текущий баланс: {balance}");
        }
        else
        {
            Console.WriteLine("Сумма пополнения должна быть положительной.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= balance)
        {
            balance -= amount;
            Console.WriteLine($"Снятие {amount}. Текущий баланс: {balance}");
        }
        else
        {
            Console.WriteLine("Недостаточно средств или неверная сумма снятия.");
        }
    }

    public void DisplayAccountInfo()
    {
        Console.WriteLine($"Номер счета: {accountNumber}, Владелец: {owner}, Баланс: {balance}");
    }
}

class Program
{
    static void Main()
    {
        // Создаем объект класса BankAccount
        BankAccount account = new BankAccount("123456789", "Янка Бу", 1000m);

        account.DisplayAccountInfo(); // Отображаем информацию о счете
        account.Deposit(500m);        // Пополняем счет
        account.Withdraw(300m);       // Снимаем средства
        account.Withdraw(2000m);      // Пытаемся снять больше, чем есть
        account.DisplayAccountInfo(); // Отображаем информацию о счете
        Console.ReadLine();
    }
}
