using GPACalculator.Data;
using GPACalculator.Model;

namespace GPACalculator.Core
{
    public class GPACalculatorRepo
    {
        // Instantiate Grading System Class Model
        private GradingSystem gradingSystem = new GradingSystem();

        // variables To Hold Accumulated Data;
        public int totalGradePoint = 0, totalGradePointPassed = 0, totalCourseUnit = 0, totalFailedGradePoint = 0, totalWeightPoint = 0;

        public float gpaPoint = 0.00f;

        /// <summary>
        /// Configurable Grading System, Made flexible to accomodate change at any time.
        /// </summary>
        /// <param name="minScore"></param>
        /// <param name="maxScore"></param>
        /// <param name="grade"></param>
        /// <param name="GradePoint"></param>
        /// <param name="remark"></param>
        /// <returns></returns>
        public string PreSaveGradingSystem(int minScore, int maxScore, char grade, int GradePoint, string remark)
        {
            // Assigns values
            gradingSystem.MinScore = minScore;
            gradingSystem.MaxScore = maxScore;
            gradingSystem.Grade = grade;
            gradingSystem.GradePoint = GradePoint;
            gradingSystem.Remark = remark;
            // Adds Grading Records To Grading List
            GPACalculatorList.grading.Add(gradingSystem);
            return "Successfully Saved!";
        }

        // Save Grading Records

        /// <summary>
        /// Adds Records To List
        /// </summary>
        /// <param name="courseDetails"></param>
        public void AddCourseDetails(CourseDetails courseDetails)
        {
            // Adds course details objects to CourseDetails List
            GPACalculatorList.courseDetails.Add(courseDetails);
        }

        /// <summary>
        /// Dynamically Calculates Students Grade Point Average and Prints Out In well Formatted table.
        /// </summary>
        public void PrintStudentTable()
        {
            // Instantiate TablePrinter Utility Class And Creates Table Headers
            TablePrinter prints = new TablePrinter("COURSE CODE", "COURSE UNIT", "GRADE", "GRADE UNIT", "WEIGHT PT", "REMARK");
            // Nested Each Loops To Compare Entered Course Details In List With Grading Configuration in Grading system list
            foreach (var course in GPACalculatorList.courseDetails)
            {
                foreach (var grading in GPACalculatorList.grading)
                {
                    if (course.CourseScore >= grading.MinScore && course.CourseScore <= grading.MaxScore)
                    {
                        // Gets WeightPoint
                        int weightPoint = WeightPoint(course.CourseUnit, grading.GradePoint);
                        totalGradePoint += grading.GradePoint;
                        // Gets Total Weight Point
                        totalWeightPoint += weightPoint;

                        // Adds Rows To Table At Each Iteration
                        prints.AddRow($"{course.CourseNameCode}",
                            $"{course.CourseUnit}", $"{grading.Grade}",
                            $"{grading.GradePoint}", $"{weightPoint}", $"{grading.Remark}");
                    }
                }
                // Gets Total Course unit
                totalCourseUnit += course.CourseUnit;
            }

            // Calculates GPA And Assigns To a global variable gpaPoint
            gpaPoint = GPAPoint(totalWeightPoint, totalCourseUnit);
            // Prints Records
            prints.Print();
        }

        /// <summary>
        /// Sub Methods To Calculate Students Weight Point From Dynamic Data
        /// </summary>
        /// <param name="courseUnit"></param>
        /// <param name="GradePoint"></param>
        /// <returns></returns>
        public static int WeightPoint(int courseUnit, int GradePoint)
        {
            return courseUnit * GradePoint;
        }

        /// <summary>
        /// Calculates Students GPA Dynamically
        /// </summary>
        /// <param name="totalWeightPt"></param>
        /// <param name="totalGradePoints"></param>
        /// <returns></returns>
        public static float GPAPoint(float totalWeightPt, float totalCourseUnit)
        {
            return (totalWeightPt / totalCourseUnit);
        }

        /// <summary>
        /// Prints Course Entails Entered At Intervals By Users
        /// </summary>
        public void PrintUserRecords()
        {
            TablePrinter prints = new TablePrinter("COURSE CODE", "COURSE UNIT", "COURSE SCORE");
            foreach (var item in GPACalculatorList.courseDetails)
            {
                prints.AddRow($"{item.CourseNameCode}", $"{item.CourseUnit}", $"{item.CourseScore}");
            }
            prints.Print();
        }

        /// <summary>
        /// Prints Grading System
        /// </summary>
        public void PrintRecords()
        {
            TablePrinter prints = new TablePrinter("MIN SCORE", "MAX SCORE", "GRADE", "GRADE UNIT", "REMARK");
            foreach (var item in GPACalculatorList.grading)
            {
                prints.AddRow($"{item.MinScore}", $"{item.MaxScore}", $"{item.Grade}", $"{item.GradePoint}", $"{item.Remark}");
            }
            prints.Print();
        }
    }
}