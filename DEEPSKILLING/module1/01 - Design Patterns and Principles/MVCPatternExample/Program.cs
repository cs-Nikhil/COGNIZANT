using MVCPatternExample.Models;
using MVCPatternExample.Views;
using MVCPatternExample.Controllers;

namespace MVCPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Raushan", 101, "A");

            StudentView view = new StudentView();

            StudentController controller =
                new StudentController(student, view);

            controller.UpdateView();

            controller.SetStudentName("Rahul");
            controller.SetStudentGrade("A+");

            controller.UpdateView();
        }
    }
}