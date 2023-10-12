using System;
class Build
{
    protected double height; //поле (висота в метрах)
    public Build(double height) //конструктор
    {       
        this.height = height; 
    }
    public void Print() //виведення на екран
    {
        Console.WriteLine($"\nВисота в метрах: {height}");
    }
    public double Foundation() //обчислення глибини фундамента
    {
        return height * 0.03;
    }
}
class Office : Build
{
    int floor; //кількість поверхів
    public Office(double height, int floor) : base(height) //конструктор
    {
        this.floor = floor;
    }
    public new void Print() //виведення на екран
    {
        base.Print(); //викликаємо метод з батьківського класу
        Console.WriteLine($"Кiлькiсть поверхiв: {floor}");
    }
    public new double Foundation()
    {
        double depth = base.Foundation(); //викликаємо метод з батьківського класу
        if (floor > 10) return depth + floor * 0.005;
        else return depth;
    }
}
class Factory : Build
{
    double weight; //вага в тонах
    public Factory (double height, double weight) : base(height) //конструктор
    {
        this.weight = weight;
    } 
    public new void Print() //виведення на екран
    {
        base.Print(); //викликаємо метод з батьківського класу
        Console.WriteLine($"Вага в тонах: {weight}");
    }
    public new double Foundation()
    {
        double depth = base.Foundation(); //викликаємо метод з батьківського класу
        return depth + weight * 0.000002;
    }
}
class Program
{
    static void Main(string[] args)
    {
        //об'єкт батьківського класу
        Build bd = new Build(76);
        bd.Print();
        Console.WriteLine($"Глибина фундамента {bd.Foundation():F2} м");
        //об'єкт дочірнього класу Office
        Office of = new Office(125, 35);
        of.Print();
        Console.WriteLine($"Глибина фундамента офiсу {of.Foundation():F2} м");
        //об'єкт дочірнього класу Factory
        Factory fc = new Factory(30, 500000);
        fc.Print();
        Console.WriteLine($"Глибина фундамента завода {fc.Foundation():F2} м");
    }
}