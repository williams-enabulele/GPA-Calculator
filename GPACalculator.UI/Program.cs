using GPACalculator.Core;
using GPACalculator.Model;
using System;
using System.Text.RegularExpressions;

namespace GPACalculator.UI
{
    internal class Program
    {
        public static string courseCode, start, startApp;
        public static int courseUnit = 0, courseScore = 0;
        public static GPACalculatorRepo records = new GPACalculatorRepo();

        private static void Main(string[] args)
        {
            // saves Grading System
            SaveGradingSystem();
            // Declare and Initialise startApp Variable
            startApp = "1";
            // Displays UI
            UserUI();
            // Starts App
            while (startApp == "1")
            {
                Menu();
                // Reads User Input
                Console.Write(">>> "); string menu = Console.ReadLine();
                switch (menu)
                {
                    case "1":

                        UserValidation();
                        break;

                    case "2":
                        // Ensures Records Are in the List First Before Calling The Print Method
                        int count = Data.GPACalculatorList.courseDetails.Count;
                        if (count >= 2)
                        {
                            Console.WriteLine();
                            records.PrintStudentTable();
                            Console.WriteLine();
                            Console.WriteLine($"Total Grade Unit Registered is {records.totalCourseUnit}");
                            Console.WriteLine($"Total Grade Unit Passed is {records.totalGradePoint}");
                            Console.WriteLine($"Total Weight Point is {records.totalWeightPoint}");
                            Console.WriteLine($"Your GPA is {records.gpaPoint.ToString("0.00")}");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nEnter Records First!\n");
                            Console.ResetColor();
                        }

                        break;

                    default:

                        Environment.Exit(0);
                        
                        break;
                }
            }
        }

        // User UI
        private static void UserUI()
        {
            Console.WriteLine();
            Console.WriteLine("\rWelcome To The Students Grade Point Average Calculator");
            Console.WriteLine("\rThe System Will Prompt You To Enter Your Course Code, Course Unit And Course Score\nPress Any Key to Start");
            Console.Write(">>> "); start = Console.ReadLine();
            Console.Clear();
        }

        // Start-Up Menu
        private static void Menu()
        {
            Console.WriteLine("Press 1 To Add Scores");
            Console.WriteLine("Press 2 To Calculate And Print GPA");
            Console.WriteLine("Press Any Key To Exit Application");
        }

        private static void UserValidation()
        {
            string moreInputs = "1";
            while (moreInputs == "1")
            {
                // Regular Expression To Match CourseCode
                var regex = new Regex("[A-Z]{3}[0-9]{3}");
                Console.WriteLine();
                Console.WriteLine("Enter Course Code");
                Console.Write(">>> "); courseCode = Console.ReadLine();
                while (regex.IsMatch(courseCode) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Course Code Not In Recognized Format  Eg. STU123 , Try Again! ");
                    Console.ResetColor();
                    Console.Write(">>> "); courseCode = Console.ReadLine();
                }
                // Validates Course Unit is between 1 and 5
                var regex2 = new Regex("^[1-5]?$");
                Console.WriteLine("Enter Course Unit");
                Console.Write(">>> "); string tempCourseUnit = Console.ReadLine();
                while (regex2.IsMatch(tempCourseUnit) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Must be a valid number and between 1 and 5, Try Again");
                    Console.ResetColor();
                    Console.Write(">>> "); tempCourseUnit = Console.ReadLine();
                }
                // Validates Course Score is between 0 and 100
                var regex3 = new Regex("^[0-9][0-9]?$|^100$");
                Console.WriteLine("Enter Course Score");
                Console.Write(">>> "); string tempCourseScore = Console.ReadLine();

                while (regex3.IsMatch(tempCourseScore) == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Course Score Must Be Between 0 to 100, Try Again!");
                    Console.ResetColor();
                    tempCourseScore = Console.ReadLine();
                }

                // Converts To ints
                int.TryParse(tempCourseUnit, out courseUnit);
                int.TryParse(tempCourseScore, out courseScore);
                // Adds Entry to data object
                CourseDetails data = new CourseDetails(courseCode, courseUnit, courseScore);
                // Adds Record To List
                records.AddCourseDetails(data);
                // Clears Variables After Successful Entry In List
                courseCode = ""; courseUnit = 0; courseScore = 0;
                Console.Clear();
                // Print Records
                records.PrintUserRecords();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Record Successfully Saved!");
                Console.ResetColor();
                Console.WriteLine();
                Console.WriteLine("Enter 1 To Add More or Any Key To Go Back To Menu");
                Console.Write(">>> "); moreInputs = Console.ReadLine();
            }
        }

        private static void SaveGradingSystem()
        {
            // Instantiate GPACalculatorRepo Class To Make Available Methods And Properties
            var record1 = new GPACalculatorRepo();
            var record2 = new GPACalculatorRepo();
            var record3 = new GPACalculatorRepo();
            var record4 = new GPACalculatorRepo();
            var record5 = new GPACalculatorRepo();
            var record6 = new GPACalculatorRepo();
            // Saving Grading System To List, In a real App This would be persisted in a database and subject to change at any time without breaking codes
            record1.PreSaveGradingSystem(70, 100, 'A', 5, "Excellent");
            record2.PreSaveGradingSystem(60, 69, 'B', 4, "Very Good");
            record3.PreSaveGradingSystem(50, 59, 'C', 3, "Good");
            record4.PreSaveGradingSystem(45, 49, 'D', 2, "Fair");
            record5.PreSaveGradingSystem(40, 44, 'E', 1, "Pass");
            record6.PreSaveGradingSystem(0, 39, 'F', 0, "Fail");
        }
    }
}