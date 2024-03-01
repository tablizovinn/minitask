using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq
{
   public class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Section { get; set; }
        public Course EnrolledCourse { get; set; }
    }

   public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }

        // Constructor with ID and Name parameters
        public Course(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
