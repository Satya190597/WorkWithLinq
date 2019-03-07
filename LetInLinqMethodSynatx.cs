using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLinq
{
    class LetInLinqMethodSynatx
    {
        private List<Student> datasource = new List<Student>();
        public LetInLinqMethodSynatx()
        {
            datasource.Add(new Student { StudentId = 1, StudentName = "Satya Prakash Nandy", StudentAge = 21 });
            datasource.Add(new Student { StudentId = 2, StudentName = "Ravi Kumar", StudentAge = 22 });
            datasource.Add(new Student { StudentId = 3, StudentName = "Rajan Panda", StudentAge = 35 });
            datasource.Add(new Student { StudentId = 4, StudentName = "Altamash", StudentAge = 18 });
            datasource.Add(new Student { StudentId = 5, StudentName = "Manoj Kumar", StudentAge = 22 });
            datasource.Add(new Student { StudentId = 6, StudentName = "Pooja Purty", StudentAge = 21 });
        }
        /// <summary>
        /// Using Of Let In Linq Method
        /// </summary>
        public void ExampleOne()
        {
            var result = datasource.Select(s => new { namelength = s.StudentName.Length, s}).Where( s => s.namelength > 5).OrderBy( s => s.namelength).Select( s => s.s.StudentName);
            Console.Write("Results : ");
            foreach(string studentName in result)
            {
                Console.Write(studentName+" | ");
            }
            Console.WriteLine();
        }
    }
}
