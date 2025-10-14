//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using System.ComponentModel.DataAnnotations;
class Student
{
    public string Name {  get; set; }
    public int Age { get; set; }
    public string Grade { get; set; }

    public Student(string name, int age, string grade)
    {
        Name = name;
        Age = age;
        Grade = grade;
    }
    public void Display()
    {
        Console.WriteLine($"name ={Name}");
        Console.WriteLine($"age={Age}");
        Console.WriteLine($"grade={Grade}");
    }
}
class Program
{
    static void Main()
    {
        List<Student> list = new List<Student>();
        Console.WriteLine("how many students do you wan to add");
        int a=Convert.ToInt32(Console.ReadLine());
        for(int i=1;i<=a;i++)
        {
            Console.WriteLine($"enter details of student {i}");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.Write("Grade: ");
            string grade = Console.ReadLine();
            Student s = new Student(name, age, grade);
            list.Add(s);

        }
        Console.WriteLine("datas you entered are");
        foreach(Student s in  list)
        {
            s.Display();
        }
    }
}