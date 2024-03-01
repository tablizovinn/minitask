using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Studentselect
    {
        private Dictionary<int, Student> studentDictionary;

        public Studentselect(Dictionary<int, Student> directories)
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
                    Student student = studentDictionary[searchID];
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
