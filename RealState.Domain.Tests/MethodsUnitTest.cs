using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace RealState.Domain.Tests
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    [TestClass]
    public class MethodsUnitTest
    {
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Sum => Number1 + Number2;

        #region Tests
        [TestMethod]
        public void MethodLambdaSum()
        {
            Number1 = 7;
            Number2 = 9;

            Debug.WriteLine(Sum);
        }

        [TestMethod]
        public void MethodLookupLambda()
        {
            //This doesn't make much sense but it works. A silly use of lambda.
            var averages = new List<int> { 2, 3, 4 };
            var bestAverage = averages.Find(a => a == 3);

            //This uses a lambda to retrieve students with the condition
            var students = new List<string>
            {
                "Alberto",
                "Juan Pablo",
                "Rayo",
                "Damian",
                "Amaranta"
            };

            var studentsWithA = students.FindAll(t => t.StartsWith("A"));

            //This uses a lambda to retrieve teachers with the condition
            var teachers = new List<Person>
            {
                new Person("Andrea", 42),
                new Person("Alejandro", 24),
                new Person("James", 43),
                new Person("Sandra", 39)
            };

            var overForthyTeachers = from teacher in teachers
                                  where teacher.Age > 40
                                  select teacher;
        }
        #endregion Tests
    }
}
