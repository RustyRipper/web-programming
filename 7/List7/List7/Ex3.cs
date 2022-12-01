using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7
{
    class Ex3
    {
        public class Student
        {
            public int Id { get; set; }
            public int Index { get; set; }
            public string Name { get; set; }
            public Gender Gender { get; set; }
            public bool Active { get; set; }
            public int DepartmentId { get; set; }
            public List<int> Topics { get; set; }

            public Student(int id, int index, string name, Gender gender, bool active, int departmentId, List<int> topics)
            {
                this.Id = id;
                this.Index = index;
                this.Name = name;
                this.Gender = gender;
                this.Active = active;
                this.DepartmentId = departmentId;
                this.Topics = topics;

            }
            public override string ToString()
            {
                var result = $"{Id,2}) {Index,5}, {Name,11}, {Gender,6},{(Active ? "active" : "no active"),9},{DepartmentId,2}, topics: ";
                foreach (var id in Topics)
                    result += id + ", ";
                return result;
            }
        }

        public class Topic
        {
            public int Id { get; set; }
            public String Name { get; set; }

            public Topic(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public override string ToString()
            {
                return $" Name: {Name}, Id: {Id}";
            }
        }

        public static void test()
        {
            Console.WriteLine("\n3)\n");
            var topics = new List<Topic>() {
                new Topic(1,"C#"),
                new Topic(2,"PHP"),
                new Topic(3,"algorithms"),
                new Topic(4,"C++"),
                new Topic(5,"fuzzy logic"),
                new Topic(6,"Basic"),
                new Topic(7,"Java"),
                new Topic(8,"JavaScript"),
                new Topic(9,"neural networks"),
                new Topic(10,"web programming")
            };

            var newStudents =
                from students in Generator.GenerateStudentsWithTopicsEasy()
                select new Student(
                    students.Id,
                    students.Index,
                    students.Name,
                    students.Gender,
                    students.Active,
                    students.DepartmentId,
                    (
                        from studTopics in students.Topics
                        join topic in topics
                        on studTopics equals topic.Name
                        select topic.Id).ToList()
                     );

            newStudents.ToList().ForEach(Console.WriteLine);
        }
    }
}
