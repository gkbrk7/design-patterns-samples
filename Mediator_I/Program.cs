using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    // Farklı sistemleri birbiriyle görüştürme görevi üstlenmesidir.
    class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();

            Teacher teacher = new Teacher(mediator) { Name= "Gokberk"};
            mediator.Teacher = teacher;

            Student student = new Student(mediator) { Name = "Guven" };
            Student student1 = new Student(mediator) { Name = "Gulcin" };

            mediator.Students = new List<Student> {student,student1};
            teacher.SendNewImageUrl("slide1.jpg");
            teacher.RecieveQuestion("Is it true ?", student);
            

        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;
        public CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public string Name { get; set; }

        public Teacher(Mediator mediator): base(mediator)
        {

        }
        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine($"Teacher received question from {student.Name}, Question: {question}");
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher changed slide : {0}", url);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine($"Teacher answered question {answer}, Student: {student.Name}");
        }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {

        }
        public string Name { get; internal set; }

        public void RecieveImage(string url)
        {
            Console.WriteLine($"{Name} received image: {url}");
        }

        public void RecieveAnswer(string answer, Student student)
        {
            Console.WriteLine($"Student({student}) received answer: {answer}");
        }
    }

    class Mediator
    {
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; }
        public void UpdateImage(string url)
        {
            foreach (var student in Students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            Teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer, student);
        }
    }
}
