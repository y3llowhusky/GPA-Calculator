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

            double weightSum = 0;
            double gradeSum = 0;

            // runs the array with a for loop, storing each grade on its corresponding index inside the array
            for (int i = 0; i < totalGradesNum; i++)
            {
                Console.Clear();
                string suffix = GetOrdinalSuffix(i + 1);

                // reads the name of the subject
                Console.Write($"{i+1}{suffix} subject name: ");
                string subject = Console.ReadLine();

                // reads the weight of the subject
                Console.Write($"{subject}'s weight (0-4): ");
                string stringSubjectWeight = Console.ReadLine();
                double subjectWeight = double.Parse(stringSubjectWeight);

                // adds the weight of the subject to the total weight of all subjects added
                weightSum += subjectWeight;

                // reads the student's grade in said subject
                Console.Write($"{studentName}'s {i+1}{suffix} grade - {subject} (0-4): ");
                string stringSubjectGrade = Console.ReadLine();
                double subjectGrade = double.Parse(stringSubjectGrade);

                // gets the student's subtotal grade on said subject, based on its weight
                double gradeSubtotal = subjectGrade * subjectWeight;
                gradeSum += gradeSubtotal;
            }

            Console.Clear();

            // calls out method to calculate gpa based on the sum of grades subtotals and their respective weight
            // and assign the output to the GPA variable
            double GPA = CalculateGPA(gradeSum, weightSum);

            // calls out method to evaluate the student's approval situation based on the GPA
            // and assign the output to the situation variable
            int situation = EvaluateApproval(GPA);

            Console.WriteLine($"{studentName}'s GPA: {GPA}");

            // displays a different output based off of the student's situation
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

        // method for getting the right suffix on the ordinal number, based off of it's last digit
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

        // method for calculating the GPA score based off of the subtotal grade sum and the subjects weights sum
        static double CalculateGPA(double totalGrade, double totalWeight)
        {
            return totalGrade / totalWeight;
        }

        // method for assigning a value for the student's approval situation, based off of his GPA score
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