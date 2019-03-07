using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLinq
{
    class Program
    {
        private List<Student> datasource = new List<Student>();
        private List<Student> secondDatasource = new List<Student>();
        public Program()
        {
            datasource.Add(new Student { StudentId = 1, StudentName = "Satya Prakash Nandy", StudentAge = 21 });
            datasource.Add(new Student { StudentId = 2, StudentName = "Ravi Kumar", StudentAge = 22 });
            datasource.Add(new Student { StudentId = 3, StudentName = "Rajan Panda", StudentAge = 35 });
            datasource.Add(new Student { StudentId = 4, StudentName = "Altamash", StudentAge = 18 });
            datasource.Add(new Student { StudentId = 5, StudentName = "Manoj Kumar", StudentAge = 22 });
            datasource.Add(new Student { StudentId = 6, StudentName = "Pooja Purty", StudentAge = 21 });

            secondDatasource.Add(new Student { StudentId = 7, StudentName = "Tara Pada Nandy", StudentAge = 21});
            secondDatasource.Add(new Student { StudentId = 3, StudentName = "Sabita Nandy", StudentAge = 18 });
            secondDatasource.Add(new Student { StudentId = 4, StudentName = "Ranjit", StudentAge = 11 });


        }
        static void Main(string[] args)
        {
            Program obj = new Program();

            DeferredExecution defferedExecution = new DeferredExecution();

            //-- Calling Deferred Execution --
            defferedExecution.FirstExample();
            // -------------------------------

            Student studentObject = obj.datasource.FirstOrDefault();
            Console.WriteLine("FIRST STUDENT NAME {0}, AGE {1}, ID {2}", studentObject.StudentName,studentObject.StudentAge,studentObject.StudentAge);

            // Project Operation Start
            // +  Make A List
            List<Student> studentNames = new List<Student>();
            var studentNamesResult = obj.datasource.Select(e => new { StudentName = e.StudentName});
            Console.WriteLine("First "+studentNamesResult.First());
            foreach(var element in studentNamesResult)
            {
                Console.WriteLine(element.StudentName);
            }
            // Project Operation End

            //Projection Using Select Many
            //var selectManyResult = obj.datasource.SelectMany<Student,Student>(e => new { StudentName = e.StudentName });
            //Console.WriteLine("First " + selectManyResult.First());
            //Projection


            // -- Using OfType --
            List<string> names = new List<string>();
            names = obj.datasource.OfType<string>().ToList();
            foreach(string name in names)
            {
                Console.WriteLine("Name : "+name);
            }

            // -- Order By Age --
            IEnumerable<Student> studentOderList = obj.datasource.OrderBy(s => s.StudentAge);
            foreach(Student element in studentOderList)
            {
                Console.WriteLine("Age {0} Name {1} ID {2}",element.StudentAge,element.StudentName,element.StudentAge);
            }

            // -- Used Of Group By --
            Console.WriteLine("++ Group By Example ++");
            var groupResult = obj.datasource.GroupBy(s=>s.StudentAge);
            foreach(var group in groupResult)
            {
                Console.WriteLine("Age Group {0}",group.Key);
                foreach(Student student in group)
                {
                    Console.WriteLine("Student : Id {0}, Name {1}, Age {2}",student.StudentId,student.StudentName,student.StudentAge);
                }
            }

            // -- Contains Vs Any --
            Console.WriteLine("Use Of Any");
            // + returns True
            var anyBoolResult = obj.datasource.Any(s => s.StudentName == "Satya Prakash Nandy");
            Console.WriteLine("Satya Prakash Nandy Present  : {0}", anyBoolResult);

            Student searchStudent = new Student { StudentName = "Satya Prakash Nandy", StudentAge = 21, StudentId = 1};
            // + returns False
            var containsBoolResult = obj.datasource.Contains(searchStudent);
            Console.WriteLine("Satya Prakash Nandy Present : {0}",containsBoolResult);

            // -- Element At --
            Console.WriteLine("--------------------------");
            Console.WriteLine("++ Use Of Element At ++");
            Student secondSmallestStudent = obj.datasource.OrderBy(s => s.StudentAge).ElementAt(1);
            Console.WriteLine("Second Smallest Student Id : {0}, Name : {1}, Age : {2}",secondSmallestStudent.StudentId,secondSmallestStudent.StudentName,secondSmallestStudent.StudentAge);

            // -- Element At Generate Error --
            try
            {
                Student secondSmallestStudentError = obj.datasource.OrderBy(s => s.StudentAge).ElementAt(50);
            }
            catch(Exception e)
            {
                Console.WriteLine(">> Error Generated For Element At : {0}",e);
            }
            // -- Elemnet At Generate Error --
            try
            {
                Console.WriteLine("--------------------------");
                Console.WriteLine("++ Use Of Element AtOrDefault ++");
                Student secondSmallestStudentNull = obj.datasource.OrderBy(s => s.StudentAge).ElementAtOrDefault(50);
                Console.WriteLine("We Got Null As A Result  : "+secondSmallestStudentNull);
            }
            catch(Exception e)
            {
                Console.WriteLine("Unable To Generate Error : {0}",e);
            }

            // -- Use Of Distict --

            // >> Working With List
            List<int> numberList = new List<int>() { 1,2,3,4,5,6,7,8,9,1,2,3,4,5,6,7,8,9 };
            Console.Write("List Number After Distinct : ");
            foreach(int number in numberList.Distinct())
            {
                Console.Write(number+" ");
            }

            // >> Working With Multiple List

            List<int> numberListTwo = new List<int>() { 5, 5, 6, 6, 9, 9 };
            Console.WriteLine("\nFirst List");
            foreach(int number in numberList)
            {
                Console.Write(number + " ");
            }
            Console.WriteLine("\nSecond List");
            foreach(int number in numberListTwo)
            {
                Console.Write(number + " ");
            }
            Console.Write("\nTwo List After Distinct : ");
            foreach(int number in numberList.Union(numberListTwo).Distinct())
            {
                Console.Write(number + " ");
            }

            // -- Distinct On Complex Object --

            Console.WriteLine("\n This is my student List Without Custom Equality");
            foreach(Student student in obj.datasource.Distinct())
            {
                Console.Write(student.StudentName+" ");
            }

            Console.WriteLine("\n This is my student List With Custom Equality");
            foreach (Student student in obj.datasource.Distinct(new StudentComparer()))
            {
                Console.Write(student.StudentName+" ");
            }
            // --------------------

            // -- Working With Except --

            Console.WriteLine("\n Working With Except On Complex Type [Using Projection Method]");
            var data = obj.datasource.Select(s => new { StudentAge = s.StudentAge }).Except(obj.secondDatasource.Select(s => new { StudentAge = s.StudentAge }));
            

            // -------------------------


            // -- Stop Console --
            Console.Read();
        }
    }
    class StudentComparer : IEqualityComparer<Student>
    {
        public bool Equals(Student x, Student y)
        {
            return x.StudentAge == y.StudentAge ? true : false;
        }

        public int GetHashCode(Student obj)
        {
            return obj.StudentAge.GetHashCode();
        }
    }
}
