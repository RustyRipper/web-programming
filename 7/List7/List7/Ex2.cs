using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7
{
    class Ex2
    {
        private static void a()
        {
            var students = Generator.GenerateStudentsWithTopicsEasy();
            var topics = from student in students
                         from topic in student.Topics
                         group topic by topic into topicGroup
                         orderby topicGroup.Count() descending
                         select new
                         {
                             Topic = topicGroup.Key,
                             Count = topicGroup.Count()
                         };

            topics.ToList().ForEach(Console.WriteLine);
        }
        private static void b()
        {
            var students = Generator.GenerateStudentsWithTopicsEasy();
            var genders = from student in students
                          group student by student.Gender into genderGroup
                          select new
                          {
                              Gender = genderGroup.Key,
                              Topics = from student in genderGroup
                                       from topic in student.Topics
                                       group topic by topic into topicGroup
                                       orderby topicGroup.Count() descending
                                       select new
                                       {
                                           Topic = topicGroup.Key,
                                           Count = topicGroup.Count()
                                       }
                          };

            foreach (var group in genders)
            {
                Console.WriteLine(group.Gender);
                group.Topics.ToList().ForEach(Console.WriteLine);
            }
        }
        public static void test()
        {
            Console.WriteLine("\n2a)\n");
            a();
            Console.WriteLine("\n2b)\n");
            b();
        }
    }
}
