using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLinq
{
    class ComplexQueries
    {
        private List<StudentInfo> studentList = new List<StudentInfo>();
        private List<Standard> standardList = new List<Standard>();
        public ComplexQueries()
        {
            studentList.Add(new StudentInfo { StudentId = 1, StudentName = "John", Age = 13, StandardId = 1  } );
            studentList.Add(new StudentInfo { StudentId = 2, StudentName = "Moin", Age = 21, StandardId = 1 });
            studentList.Add(new StudentInfo { StudentId = 3, StudentName = "Bill", Age = 18, StandardId = 2 });
            studentList.Add(new StudentInfo { StudentId = 4, StudentName = "Ram", Age = 20, StandardId = 2 });
            studentList.Add(new StudentInfo { StudentId = 5, StudentName = "Ron", Age = 15 });

            standardList.Add(new Standard { StandardId = 1, StandardName = "Standard 1" });
            standardList.Add(new Standard { StandardId = 2, StandardName = "Standard 2" });
            standardList.Add(new Standard { StandardId = 3, StandardName = "Standard 3" });
        }
    }
    class StudentInfo
    {
        public int StudentId {get; set;}
        public string StudentName { get; set; }
        public int Age { get; set; }
        public int StandardId { get; set; }
    }
    class Standard
    {
        public int StandardId { get; set; }
        public string StandardName { get; set; }
    }
}
