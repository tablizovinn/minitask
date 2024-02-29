using System;
using System.Collections.Generic;

namespace Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Comsci> comsciStud = new List<Comsci>()
            {
                new Comsci() { Name = "Vin", ID = 12345, Section = "A"},
                new Comsci() { Name = "Maxelle", ID = 114433, Section = "A"},
                new Comsci() { Name = "JP", ID = 11345, Section = "B"},
                new Comsci() { Name = "Arman", ID = 54321, Section = "A"},
                new Comsci() { Name = "Johnny", ID = 98765, Section = "A"},
                new Comsci() { Name = "Devina", ID = 67890, Section = "B"},
                new Comsci() { Name = "James", ID = 77777, Section = "A"},
                new Comsci() { Name = "JD", ID = 88888, Section = "A"},
                new Comsci() { Name = "Cha", ID = 99999, Section = "B"}
            };

            Dictionary<int, Comsci> studentDictionary = new Dictionary<int, Comsci>();

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
                        StudentDirectories studentSelect = new StudentDirectories(studentDictionary);
                        studentSelect.Select();
                        break;
                    case "3":
                        AddStudent(comsciStud);
                        break;
                    case "4":
                        deleteStudent(studentDictionary, comsciStud);
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
        static void AddStudent(List<Comsci> addStud)
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
            addStud.Add(new Comsci { Name = name, ID = id, Section = section });

            Console.WriteLine("Student added successfully.");
        }

        //Function to delete student by ID
        
        static void deleteStudent(Dictionary<int, Comsci> deleteStud, List<Comsci> comsciStud)
        {
            Console.Write("Enter student ID to delete: ");
            int searchID;
            if (int.TryParse(Console.ReadLine(), out searchID))
            {
                if (deleteStud.ContainsKey(searchID))
                {
                    deleteStud.Remove(searchID);

                    //To check if the student is existing by their id
                    Comsci studentToRemove = comsciStud.Find(student => student.ID == searchID);
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

    // Class for BSCS-4A
    class Comsci
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Section { get; set; }
    }

    // Class to display the students
    class Displaystud
    {
        private List<Comsci> Stud { get; set; }

        public Displaystud(List<Comsci> students)
        {
            Stud = students;
        }

        // Function to display students
        public void Display()
        {
            Console.WriteLine("\nAll Students:");
            foreach (Comsci student in Stud)
            {
                Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Section: {student.Section}");
            }
        }
    }

    // Class to select student
    class StudentDirectories
    {
        private Dictionary<int, Comsci> studentDictionary;

        public StudentDirectories(Dictionary<int, Comsci> directories)
        {
            studentDictionary = directories;
        }

        // Function to select students by ID
        public void Select()
        {
            Console.Write("Enter student ID: ");
            int searchID;
            if (int.TryParse(Console.ReadLine(), out searchID))
            {
                if (studentDictionary.ContainsKey(searchID))
                {
                    Comsci student = studentDictionary[searchID];
                    Console.WriteLine($"Student found: Name: {student.Name}, ID: {student.ID}, Section: {student.Section}");
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }
}
