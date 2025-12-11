using System;

namespace GPACalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // gets the students name
            Console.Write("Student name: ");
            string studentName = Console.ReadLine();

            // gets the number of grades needed to calculate the gpa and turns into an int
            Console.Write("Number of grades for calculation: ");
            string stringTotalGradesNum = Console.ReadLine();
            int totalGradesNum = int.Parse(stringTotalGradesNum);

            // creates an array of doubles with size being the number of total grades
            double[] gradesArray = new double[totalGradesNum];

            double weightSum = 0;
            double gradeSum = 0;

            // runs the array with a for loop, storing each grade on its corresponding index inside the array
            for (int i = 0; i < gradesArray.Length; i++)
            {
                Console.Clear();
                string suffix = GetOrdinalSuffix(i + 1);

                Console.Write($"{i+1}{suffix} subject name: ");
                string subject = Console.ReadLine();

                Console.Write($"{subject}'s weight (1-5): ");
                string stringSubjectWeight = Console.ReadLine();
                double subjectWeight = double.Parse(stringSubjectWeight);

                weightSum += subjectWeight;

                Console.Write($"{studentName}'s {i+1}{suffix} grade - {subject}: ");
                string stringSubjectGrade = Console.ReadLine();
                double subjectGrade = double.Parse(stringSubjectGrade);

                double gradeSubtotal = subjectGrade * subjectWeight;
                gradeSum += gradeSubtotal;
                gradesArray[i] = subjectGrade;

            }

            double GPA = gradeSum / weightSum;

            Console.WriteLine($"{studentName}'s GPA: {GPA}");

            // ADICIONAR CODIGO PARA LIMPAR TERMINAL E CALCULAR GPA FINAL
        }

        static string GetOrdinalSuffix(int number)
        {
            int lastTwo = number % 100;

            if (lastTwo >= 11 && lastTwo <= 13)
            {
                return "th";
            }

            int lastDigit = number % 10;

            switch (lastDigit)
            {
                case 1:
                    return "st";
                case 2:
                    return "nd";
                case 3:
                    return "rd";
                default:
                    return "th";
            }
        }
    }
}