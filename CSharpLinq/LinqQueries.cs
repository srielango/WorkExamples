using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLinq
{
    internal class LinqQueries
    {
        static readonly List<Student> students = Student.students;
        public static void SubQuery()
        {
            //var queryGroupMax =
            //    from student in students
            //    group student by student.Year into studentGroup
            //    select new
            //    {
            //        Level = studentGroup.Key,
            //        HighestScore = (
            //            from student2 in studentGroup
            //            select student2.ExamScores.Average()
            //        ).Max()
            //    };

            var queryGroupMax = students
                .GroupBy(student => student.Year)
                .Select(studentGroup => new
                {
                    Level = studentGroup.Key,
                    HighestScore = studentGroup.Select(student2 => student2.ExamScores.Average()).Max()
                });

            foreach (var item in queryGroupMax.OrderBy(x => x.Level))
            {
                Console.WriteLine($"{item.Level}, {item.HighestScore}");
            }
        }

        public static void GroupQuery()
        {
            var groupByLastNamesQuery =
                from student in students
                group student by student.LastName into newGroup
                orderby newGroup.Key
                select newGroup;

            foreach (var nameGroup in groupByLastNamesQuery)
            {
                Console.WriteLine($"Key: {nameGroup.Key}");
                foreach (var student in nameGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }

        public static void GroupByFirstLetter()
        {
            var groupByFirstLetterQuery =
                from student in students
                group student by student.LastName[0];

            foreach (var studentGroup in groupByFirstLetterQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                // Nested foreach is required to access group items.
                foreach (var student in studentGroup)
                {
                    Console.WriteLine($"\t{student.LastName}, {student.FirstName}");
                }
            }
        }

        public static void GroupByRange()
        {
            int GetPercentile(Student s)
            {
                double avg = s.ExamScores.Average();
                return avg > 0 ? (int)avg / 10 : 0;
            }

            var groupByPercentileQuery =
                from student in students
                let percentile = GetPercentile(student)
                group new
                {
                    student.FirstName,
                    student.LastName
                } by percentile into percentGroup
                orderby percentGroup.Key
                select percentGroup;

            // Nested foreach required to iterate over groups and group items.
            foreach (var studentGroup in groupByPercentileQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key * 10}");
                foreach (var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }
        }

        public static void GroupByComparison()
        {
            var groupByComparisonQuery = 
                from student in students
                group student by student.ExamScores.Average() > 75 into studentGroup
                select studentGroup;

            foreach(var studentGroup in groupByComparisonQuery)
            {
                Console.WriteLine($"Key: {studentGroup.Key}");
                foreach(var item in studentGroup)
                {
                    Console.WriteLine($"\t{item.LastName}, {item.FirstName}");
                }
            }    
        }

        public static void GroupByAnonymousType()
        {
            var groupByCompoundKey =
                from student in students
                group new
                {
                    student.FirstName,
                    student.LastName
                } by new
                {
                    FirstLetter = student.LastName[0],
                    IsScoreOver85 = student.ExamScores[0] > 85
                } into studentGroup
                orderby studentGroup.Key.FirstLetter
                select studentGroup;

            foreach (var scoreGroup in groupByCompoundKey)
            {
                string s = scoreGroup.Key.IsScoreOver85 == true ? "more than 85" : "less than 85";
                Console.WriteLine($"Name starts with {scoreGroup.Key.FirstLetter} who scored {s}");
                foreach (var item in scoreGroup)
                {
                    Console.WriteLine($"\t{item.FirstName} {item.LastName}");
                }
            }
        }

        public static void NestedGroup()
        {
            var nestedGroupsQuery =
                from student in students
                group student by student.Year into newGroup1
                from newGroup2 in (
                    from student in newGroup1
                    group student by student.LastName
                )
                group newGroup2 by newGroup1.Key;

            // Three nested foreach loops are required to iterate
            // over all elements of a grouped group. Hover the mouse
            // cursor over the iteration variables to see their actual type.
            foreach (var outerGroup in nestedGroupsQuery)
            {
                Console.WriteLine($"DataClass.Student Level = {outerGroup.Key}");
                foreach (var innerGroup in outerGroup)
                {
                    Console.WriteLine($"\tNames that begin with: {innerGroup.Key}");
                    foreach (var innerGroupElement in innerGroup)
                    {
                        Console.WriteLine($"\t\t{innerGroupElement.LastName} {innerGroupElement.FirstName}");
                    }
                }
            }
        }
    }
}
