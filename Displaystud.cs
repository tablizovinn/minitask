using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
    internal class Displaystud
    {

        private List<Student> Stud { get; set; }

        public Displaystud(List<Student> students)
        {
            Stud = students;
        }

        // Function to display students
        public void Display()
        {
            Console.WriteLine("\nAll Students:");
            foreach (Student student in Stud)
            {
                Console.WriteLine($"Name: {student.Name}, ID: {student.ID}, Section: {student.Section}");
            }
        }
    }
}
