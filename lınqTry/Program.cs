using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Console.WriteLine("lınqtemellerı");

        // Öğrencileri koleksiyon başlatıcı ile manuel olarak ekliyoruz
        List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Çelebi", Age = 23, Grade = 77, City = "Çorum" },
            new Student { Id = 2, Name = "Ali", Age = 22, Grade = 85, City = "İstanbul" },
            new Student { Id = 3, Name = "Ayşe", Age = 21, Grade = 90, City = "Ankara" },
            new Student { Id = 4, Name = "Fatma", Age = 24, Grade = 65, City = "İzmir" },
            new Student { Id = 5, Name = "Mehmet", Age = 23, Grade = 70, City = "Bursa" },
            new Student { Id = 6, Name = "Zeynep", Age = 22, Grade = 80, City = "Antalya" }
        };
        Console.WriteLine("***************");

        Console.WriteLine("Tüm Öğrenciler:");
        Console.WriteLine("***************");

        // Tüm öğrencileri yazdırma
        foreach (var student in students)
        {
            Console.WriteLine($"Id: {student.Id}, Name: {student.Name}, Age: {student.Age}, Grade: {student.Grade}, City: {student.City}");
        }

        // Yaşı 22'den büyük olan öğrencileri filtreleme
        var olderStudents = students.Where(x => x.Age > 22).ToList();

        // Yaşı 22'den büyük olan öğrenciler
        Console.WriteLine("\nYaşı 22'den büyük olan öğrenciler:");
        PrintStudents(olderStudents);

        Console.WriteLine("***************");

        var HighGradeStudents = students.Where(s => s.Grade > 70);
        Console.WriteLine("\nNotu 70den yukarı olan");
        PrintStudents(HighGradeStudents);
    }

    // Öğrencileri yazdıran metot
    static void PrintStudents(IEnumerable<Student> students)
    {
        foreach (var student in students)
        {
            Console.WriteLine($"- {student.Name}: {student.Age} yaş, {student.Grade} not, {student.City}");
        }
    }

    // Öğrenci sınıfı
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string City { get; set; }
    }
}
