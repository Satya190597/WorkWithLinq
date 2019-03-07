using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseLinq
{
    class DeferredExecution
    {
        private List<User> dataSource = new List<User>();
        public DeferredExecution()
        {
            dataSource.Add(new User { UserId = 1, UserName = "Satya Prakash Nandy", UserEmail = "nandy@yahoo.in", UserDiscription = "Like To Watch Anime" });
            dataSource.Add(new User { UserId = 2, UserName = "Rahul Kumar", UserEmail = "rahul@yahoo.in", UserDiscription = "Like To Watch Cricket" });
            dataSource.Add(new User { UserId = 3, UserName = "Mukesh", UserEmail = "mukesh@yahoo.in", UserDiscription = "Like To Watch Football" });
            dataSource.Add(new User { UserId = 4, UserName = "Ranjit", UserEmail = "ranjit@yahoo.in", UserDiscription = "Like To Watch Movies" });
        }
        /// <summary>
        /// Deferred Execution Re-Evaluates On Each Execution
        /// </summary>
        public void FirstExample()
        {
            var result = dataSource.Select(row => row);
            Console.Write("User Names : ");
            // -- Adding New Record --
            dataSource.Add(new User { UserId = 5, UserName = "Sanmitra", UserEmail = "sanmitra@yahoo.in", UserDiscription = "Like To Watch GOT" });
            // -----------------------
            foreach(User user in result)
            {
                Console.Write(user.UserName+" | ");
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Custom Defereed Execution Example Using yield Keyword
        /// </summary>
        public void SecondExample()
        {
            Console.Write("User Names : ");
            var result = CustomDeferredFunction(dataSource);
            foreach(User user in result)
            {
                Console.Write(user.UserName+" | ");
            }
            Console.WriteLine();
        }
        public IEnumerable<User> CustomDeferredFunction(IEnumerable<User> users)
        {
            foreach(User user in users)
            {
                yield return user;
            }
        }
        /// <summary>
        /// Simple Example Of yield keyword
        /// </summary>
        public void ThirdExample()
        {
            Console.Write("Numbers : ");
            foreach(int number in GetNumbers())
            {
                Console.Write(number+" | ");
            }
            Console.WriteLine();
        }
        public IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
    }
    class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserDiscription { get; set; }
    }
}
