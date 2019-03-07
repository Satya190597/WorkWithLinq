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
        public void ExampleOne()
        {
            var result = studentList.Where(s => s.Age > 18 && s.StandardId == 2).Select(s => new { s.StudentName, s.StudentId });
            foreach(var name in result)
            {
                Console.WriteLine(name.StudentId+" "+name.StudentName);
            }
        }
        public void ExampleTwo()
        {
            var result = studentList.Join(standardList, stu => stu.StandardId, stan => stan.StandardId,(stu,stan) => new { stu , stan});
            Console.WriteLine("Student Id,Student Name,Student Age,Standard Id,Standard Name + [Normal Join] +");
            foreach(var element in result)
            {
                Console.WriteLine("{0} | {1} | {2} | {3} | {4}",element.stu.StudentId,element.stu.StudentName,element.stu.Age,element.stan.StandardId,element.stan.StandardName);
            }
        }
        /// <summary>
        /// Left Outer Join
        /// </summary>
        public void ExampleThree()
        {
            var result = studentList.GroupJoin(standardList,stu => stu.StandardId,stan => stan.StandardId,(stu,stan) => new { stu,stan});
            foreach(var element in result)
            {
                Console.WriteLine("Name : "+element.stu.StudentName);
                foreach(var nextElement in element.stan)
                {
                    Console.WriteLine("Satandard : " + nextElement.StandardName);
                }
            }
        }
        /// <summary>
        /// Right Outer Join
        /// </summary>
        public void ExampleFour()
        {
            var result = standardList.GroupJoin(studentList,stan => stan.StandardId,stu => stu.StandardId,(stan,stu) => new { stan,stu});
            foreach (var element in result)
            {
                Console.WriteLine("Name : " + element.stan.StandardName);
                foreach (var nextElement in element.stu)
                {
                    Console.WriteLine("Satandard : " + nextElement.StudentName);
                }
            }
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
