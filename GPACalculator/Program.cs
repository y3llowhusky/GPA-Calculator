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

                // 
                Console.Write($"{i+1}{suffix} subject name: ");
                string subject = Console.ReadLine();

                Console.Write($"{subject}'s weight (0-4): ");
                string stringSubjectWeight = Console.ReadLine();
                double subjectWeight = double.Parse(stringSubjectWeight);

                weightSum += subjectWeight;

                Console.Write($"{studentName}'s {i+1}{suffix} grade - {subject} (0-4): ");
                string stringSubjectGrade = Console.ReadLine();
                double subjectGrade = double.Parse(stringSubjectGrade);

                double gradeSubtotal = subjectGrade * subjectWeight;
                gradeSum += gradeSubtotal;
                gradesArray[i] = subjectGrade;

            }

            Console.Clear();
            double GPA = CalculateGPA(gradeSum, weightSum);

            int situation = EvaluateApproval(GPA);

            Console.WriteLine($"{studentName}'s GPA: {GPA}");

            switch (situation)
            {
                case 1:
                    Console.WriteLine($"Student {studentName} failed!");
                    break;
                case 2:
                    Console.WriteLine($"Student {studentName} is under retention!");
                    break;
                case 3:
                    Console.WriteLine($"Student {studentName} passed!");
                    break;
                case 4:
                    Console.WriteLine($"Student {studentName} strongly passed - congratulations!");
                    break;
                default:
                    Console.WriteLine($"There was a problem evaluating {studentName}'s GPA. Please try again.");
                    break;
            }
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

        static double CalculateGPA(double totalGrade, double totalWeight)
        {
            return totalGrade / totalWeight;
        }

        static int EvaluateApproval(double gpa)
        {
            int studentSituation;

            // 0 = fail
            // 1 = retention
            // 2 = pass
            // 3 = strong pass

            if (gpa < 1.7) {
                studentSituation = 0;
            } else if (1.7 <= gpa && gpa <= 1.9)
            {
                studentSituation = 1;
            } else if (2 <= gpa && gpa <= 2.9)
            {
                studentSituation = 2;
            } else
            {
                studentSituation = 3;
            }

            return studentSituation;
        } 
    }
}