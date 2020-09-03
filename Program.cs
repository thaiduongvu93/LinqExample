using System;
using System.Linq;
using System.Collections.Generic;

class Student
{
    public int StudentID { get; set; }
    public string StudentName { get; set; }
    public int Age { get; set; }

	public Student(int id, string name, int age)
	{
		StudentID = id;
		StudentName = name;
		Age = age;
	}

	public void printStudent()
	{
		Console.WriteLine("Name:{0}		ID:{1}		Age:{2}", StudentName, StudentID, Age);
	}
}

class Program
{
    static void Main(string[] args)
    {
        List<Student> studentList = new List<Student>() { 
            new Student(1,"Duong",21),
            new Student(3,"Bill",18),
            new Student(4,"Watson",22),
            new Student(2,"Tom",23),
            new Student(7,"Jerry",22),
            new Student(6,"Zac",23),
            new Student(5,"John",19),
        }; 

		AgeOverTwenty(studentList);
		OrderByID(studentList);
		GroupByAge(studentList);
    }

	public static void AgeOverTwenty(List<Student> studentList)
	{
		var list = 	from s in studentList
					where s.Age>20
					select s;
		Console.WriteLine("List of students with age over 20");
		foreach(Student s in list)
		{
			s.printStudent();
		}
	}

	public static void OrderByID(List<Student> studentList)
	{
		var list = 	from s in studentList
					orderby s.StudentID
					select s;
		Console.WriteLine("List of students by id");
		foreach(Student s in list)
		{
			s.printStudent();
		}
	}

	public static void GroupByAge(List<Student> studentList)
	{
		var group = from s in studentList
					group s by s.Age>20;

		Console.WriteLine("List of students group by age");
		foreach(var ageGroup in group)
		{
			Console.WriteLine("Over 20: {0}", ageGroup.Key);
			foreach(var s in ageGroup)
			{
				s.printStudent();
			}
		}
	}

	
	
}