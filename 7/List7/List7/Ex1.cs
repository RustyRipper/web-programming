using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List7
{
    class Ex1
    {
        public static void test(int n)
        {
            Console.WriteLine("\n1)\n");
            var students = Generator.GenerateStudentsWithTopicsEasy();
            var groupedStudents = from student in students
                                  orderby student.Name, student.Index
                                  group student by student.Name into studentGroup
                                  select new
                                  {
                                      Name = studentGroup.Key,
                                      Students = studentGroup.Take(n)
                                  };

            foreach (var group in groupedStudents)
            {
                Console.WriteLine("-------" + group.Name);
                group.Students.ToList().ForEach(gr => Console.WriteLine(gr));
            }




            int index = 0;
            Console.WriteLine("\n1b)\n");
            var students2 = Generator.GenerateStudentsWithTopicsEasy();
            var groupedStudents2 = from student in students
                                   orderby student.Name, student.Index
                                   group student by (index++ / n);

            foreach (var group in groupedStudents2)
            {
                Console.WriteLine("-------" + group.Key);
                group.ToList().ForEach(gr => Console.WriteLine(gr));
            }
        }
    }
}
