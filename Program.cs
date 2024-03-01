using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;


using Newtonsoft.Json;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Student> comsciStud = new List<Student>()
            {
                new Student() { Name = "Vin", ID = 12345, Section = "A"},
                new Student() { Name = "Maxelle", ID = 114433, Section = "A"},
                new Student() { Name = "JP", ID = 11345, Section = "B"},
                new Student() { Name = "Arman", ID = 54321, Section = "A"},
                new Student() { Name = "Johnny", ID = 98765, Section = "A"},
                new Student() { Name = "Devina", ID = 67890, Section = "B"},
                new Student() { Name = "James", ID = 77777, Section = "A"},
                new Student() { Name = "JD", ID = 88888, Section = "A"},
                new Student() { Name = "Cha", ID = 99999, Section = "B"}
            };


           

            comsciStud[0].EnrolledCourse = new Course(13232, "Computer Science");
            comsciStud[1].EnrolledCourse = new Course(13232, "Computer Science");
            comsciStud[2].EnrolledCourse = new Course(13232, "Computer Science");
            comsciStud[3].EnrolledCourse = new Course(13232, "Computer Science");
            comsciStud[4].EnrolledCourse = new Course(13232313, "Information Technology");
            comsciStud[5].EnrolledCourse = new Course(13232, "Information System");
            comsciStud[6].EnrolledCourse = new Course(13232, "Computer Science");
            comsciStud[7].EnrolledCourse = new Course(13232313, "Information Technology");
            comsciStud[8].EnrolledCourse = new Course(13232, "Information System");


            Dictionary<int, Student> studentDictionary = new Dictionary<int, Student>();

            foreach (var student in comsciStud)
            {
                studentDictionary.Add(student.ID, student);
            }

            // Main loop
            bool transaction = true;
            while (transaction)
            {
                // Displaying User's prompt
                Console.WriteLine("\nTUP STUDENT DIRECTORY");
                Console.WriteLine("\nChoose an option:\n");
                Console.WriteLine("\n1. Display all students\n");
                Console.WriteLine("2. Search for a student by ID\n");
                Console.WriteLine("3. Add student\n");
                Console.WriteLine("4. Delete student\n");
                Console.WriteLine("5. Json Output\n");
                Console.Write("\nEnter option number: ");

                // Read user input
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Displaystud displayStud = new Displaystud(comsciStud);
                        displayStud.Display();
                        break;
                    case "2":
                        Studentselect studentSelect = new Studentselect(studentDictionary);
                        studentSelect.Select();
                        break;
                    case "3":
                        AddStudent(comsciStud);
                        break;
                    case "4":
                        DeleteStudent(studentDictionary, comsciStud);
                        break;
                    case "5":

                        
                            string json = JsonConvert.SerializeObject(comsciStud, Formatting.Indented);
                            Console.WriteLine(json);

                            foreach(var list in comsciStud)
                        {
                            string json1 = JsonConvert.SerializeObject(list, Formatting.Indented);
                            Console.WriteLine(json1);
                        }
                      

                        break;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                // Prompt user if they want to perform another transaction
                Console.WriteLine("\nDo you want to perform another transaction? (yes/no)");
                string continueOption = Console.ReadLine();

                if (continueOption.ToLower() != "yes")
                {
                    // Exit the loop if the user does not want to continue
                    transaction = false; 
                }
            }
        }

        // Function to add a new student to the list
        static void AddStudent(List<Student> addStud)
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();
            Console.Write("Enter student ID: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for ID.");
                Console.Write("Enter student ID: ");
            }
            Console.Write("Enter student section: ");
            string section = Console.ReadLine();

            // Create a new student object and add it to the list
            addStud.Add(new Student { Name = name, ID = id, Section = section });

            Console.WriteLine("Student added successfully.");
        }

        //Function to delete student by ID
        
        static void DeleteStudent(Dictionary<int, Student> deleteStud, List<Student> comsciStud)
        {
            Console.Write("Enter student ID to delete: ");
            int searchID;
            if (int.TryParse(Console.ReadLine(), out searchID))
            {
                if (deleteStud.ContainsKey(searchID))
                {
                    deleteStud.Remove(searchID);

                    //To check if the student is existing by their id
                    Student studentToRemove = comsciStud.Find(student => student.ID == searchID);
                    if (studentToRemove != null)
                    {
                        comsciStud.Remove(studentToRemove);
                        Console.WriteLine("Student deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found in the list.");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found in the dictionary.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer for ID.");
            }
        }

    }  
}
