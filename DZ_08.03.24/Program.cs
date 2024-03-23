using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Задание  1
Запрограммируйте класс Money (объект класса оперирует одной валютой) для работы с деньгами.
В классе должны быть предусмотрены поле для хранения целой части денег(доллары, евро, гривны и т.д.) и поле
для хранения копеек (центы, евроценты, копейки и т.д.).
Реализовать методы для вывода суммы на экран, задания значений для частей.
На базе класса Money создать класс Product для работы
с продуктом или товаром. Реализовать метод, позволяющий уменьшить цену на заданное число.
Для каждого из классов реализовать необходимые
методы и поля.*/
//using System;

public class Money
{
    public int Rubles { get; set; }
    public int kopecks { get; set; }

    public Money(int Ruble, int kopecks)
    {
        this.Rubles = Ruble;
        this.kopecks = kopecks;
    }

    public void DisplayAmount()
    {
        Console.WriteLine($"Сумма: {Rubles} руб. {kopecks} коп.");
    }

}

public class Product
{
    public string Name { get; set; }
    public Money Price { get; set; }

    public Product(string name, Money price)
    {
        this.Name = name;
        this.Price = price;
    }

    public void ReducePrice(int reductionAmount)
    {
        int totalkopecks = this.Price.Rubles * 100 + this.Price.kopecks;
        totalkopecks -= reductionAmount;

        this.Price.Rubles = totalkopecks / 100;
        this.Price.kopecks = totalkopecks % 100;
    }
}

class Program
{
    static void Main()
    {
        Money money = new Money(10, 50);
        money.DisplayAmount();

        Money productPrice = new Money(25, 99);
        Product product = new Product("Товара", productPrice);

        Console.WriteLine($"Первоначальная цена {product.Name}:");
        product.Price.DisplayAmount();

        product.ReducePrice(200);
        Console.WriteLine($"Цена после снижения на 200 копеек:");
        product.Price.DisplayAmount();

        Console.ReadKey();
    }
}

/* Задание 2
Создать базовый класс «Устройство» и производные
классы «Чайник», «Микроволновка», «Автомобиль», «Пароход». С помощью конструктора установить имя каждого
устройства и его характеристики.
Реализуйте для каждого из классов методы:
■ Sound — издает звук устройства (пишем текстом в
консоль);
■ Show — отображает название устройства;
■ Desc — отображает описание устройства*/
class Device
{
    protected string name;
    public Device(string name)
    {
        this.name = name;
    }

    public virtual void Sound()
    {
        Console.WriteLine("Устройство издает звук");
    }

    public void Show()
    {
        Console.WriteLine("Устройство: " + name);
    }

    public virtual void Desc()
    {
        Console.WriteLine("Это устройство");
    }
}

class Kettle : Device
{
    public Kettle(string name) : base(name) { }


    public override void Sound()
    {
        Console.WriteLine("Чайник издает свист при закипании");
    }

    public override void Desc()
    {
        Console.WriteLine("Кипятит воду");
    }
}

class Microwave : Device
{
    public Microwave(string name) : base(name) { }


    public override void Sound()
    {
        Console.WriteLine("Микроволновка пикает при завершении");
    }

    public override void Desc()
    {
        Console.WriteLine("Разогревает еду");
    }
}

class Car : Device
{
    public Car(string name) : base(name) { }

    public override void Sound()
    {
        Console.WriteLine("Автомобиль издает рычащий звук при запуске двигателя");
    }

    public override void Desc()
    {
        Console.WriteLine("Перевозит людей по суше");
    }
}

class Ship : Device
{
    public Ship(string name) : base(name) { }
    public override void Sound()
    {
        Console.WriteLine("Пароход издает гудок");
    }

    public override void Desc()
    {
        Console.WriteLine("Перевозит людей по воде.");
    }
}

class Program
{
    static void Main()
    {
        Device kettle = new Kettle("Электрический чайник");
        kettle.Show();
        kettle.Sound();
        kettle.Desc();
        Console.WriteLine("\n");

        Device microwave = new Microwave("Микроволновая печь");
        microwave.Show();
        microwave.Sound();
        microwave.Desc();
        Console.WriteLine("\n");

        Device car = new Car("Автомобиль");
        car.Show();
        car.Sound();
        car.Desc();
        Console.WriteLine("\n");

        Device ship = new Ship("Пароход");
        ship.Show();
        ship.Sound();
        ship.Desc();
        Console.WriteLine("\n");

        Console.ReadKey();
    }
}

/* Задание 3
Создать базовый класс «Музыкальный инструмент»
и производные классы «Скрипка», «Тромбон», «Укулеле»,
«Виолончель». С помощью конструктора установить имя
каждого музыкального инструмента и его характеристики.
Реализуйте для каждого из классов методы:
■ Sound — издает звук музыкального инструмента
(пишем текстом в консоль);
■ Show — отображает название музыкального инструмента;
■ Desc — отображает описание музыкального инструмента;
■ History — отображает историю создания музыкального инструмента.*/

class MusicalInstrument
{
    protected string name;

    public MusicalInstrument(string name)
    {
        this.name = name;
    }

    public virtual void Sound()
    {
        Console.WriteLine($"{name}");
    }

    public void Show()
    {
        Console.WriteLine($"Музыкальный инструмент: {name}");
    }

    public virtual void Desc()
    {
        Console.WriteLine($"Описание {name}");
    }

    public virtual void History()
    {
        Console.WriteLine($"История {name}");
    }
}

class Violin : MusicalInstrument
{
    public Violin(string name) : base(name) { }

    public override void Sound()
    {
        Console.WriteLine($"{name} издает изящный и напористый звук");
    }

    public override void Desc()
    {
        Console.WriteLine($"Описание {name}:  струнный смычковый музыкальный инструмент высокого регистра.");
    }

    public override void History()
    {
        Console.WriteLine($"История {name}: Возник в 16 веке.");
    }
}

class Trombone : MusicalInstrument
{
    public Trombone(string name) : base(name) { }

    public override void Sound()
    {
        Console.WriteLine($"{name} издает мощный и отчётливый звук.");
    }

    public override void Desc()
    {
        Console.WriteLine($"Описание {name}: европейский духовой амбушюрный инструмент.");
    }

    public override void History()
    {
        Console.WriteLine($"История {name}: Возник в 16 веке.");
    }
}

class Ukulele : MusicalInstrument
{
    public Ukulele(string name) : base(name) { }

    public override void Sound()
    {
        Console.WriteLine($"{name} звучание легкое, мелодичное и жизнерадостное.");
    }

    public override void Desc()
    {
        Console.WriteLine($"Описание {name}: небольшой струнный щипковый музыкальный инструмент.");
    }

    public override void History()
    {
        Console.WriteLine($"История {name}: Возник в 19 веке.");
    }
}
class Cello : MusicalInstrument
{
    public Cello(string name) : base(name) { }

    public override void Sound()
    {
        Console.WriteLine($"{name} звук густой, сочный, певучий и напряжённый.");
    }

    public override void Desc()
    {
        Console.WriteLine($"Описание {name}: струнно-смычковый инструмент.");
    }

    public override void History()
    {
        Console.WriteLine($"История {name}: Возникла в 16 веке.");
    }
}
class Program
{
    static void Main()
    {
        Violin violin = new Violin("Скрипка");
        violin.Show();
        violin.Sound();
        violin.Desc();
        violin.History();
        Console.WriteLine("\n");

        Trombone trombone = new Trombone("Тромбон");
        trombone.Show();
        trombone.Sound();
        trombone.Desc();
        trombone.History();
        Console.WriteLine("\n");

        Ukulele ukulele = new Ukulele("Укулеле");
        ukulele.Show();
        ukulele.Sound();
        ukulele.Desc();
        ukulele.History();
        Console.WriteLine("\n");

        Cello cello = new Cello("Виолончель");
        cello.Show();
        cello.Sound();
        cello.Desc();
        cello.History();
        Console.WriteLine("\n");

        Console.ReadKey();
    }
}

/* Задание 4
Создать абстрактный базовый классWorker(работника)
с методом Print(). Создайте четыре производных класса:
President, Security, Manager, Engineer. Переопределите метод
Print() для вывода информации, соответствующей
каждому типу работника.*/

public abstract class Worker
{
    public abstract void Print();
}

public class President : Worker
{
    public override void Print()
    {
        Console.WriteLine("Президент: Решает все вопросы текущей деятельности компании.");
    }
}

public class Security : Worker
{
    public override void Print()
    {
        Console.WriteLine("Охраник: осуществляет контроль и надзор за прохождением посетителей, транспорта и грузов на территорию организации.");
    }
}

public class Manager : Worker
{
    public override void Print()
    {
        Console.WriteLine("Менеджер: управляет коммерческой деятельностью компании, направленной на удовлетворение запросов клиентов и получение прибыли.");
    }
}

public class Engineer : Worker
{
    public override void Print()
    {
        Console.WriteLine("Инженер: Выполняет работы по проектированию, строительству, информационному обслуживанию, организации производства, труда и управления, метрологическому обеспечению и техническому контролю.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        President president = new President();
        Security security = new Security();
        Manager manager = new Manager();
        Engineer engineer = new Engineer();

        president.Print();
        Console.WriteLine("\n");
        security.Print();
        Console.WriteLine("\n");
        manager.Print();
        Console.WriteLine("\n");
        engineer.Print();
        Console.WriteLine("\n");

        Console.ReadKey();
    }
}