namespace GPACalculator.Model
{
    public class CourseDetails
    {
        public string CourseNameCode { get; set; }
        public int CourseUnit { get; set; }
        public int CourseScore { get; set; }

        public CourseDetails(string courseNameCode, int courseUnit, int courseScore)
        {
            CourseNameCode = courseNameCode;
            CourseUnit = courseUnit;
            CourseScore = courseScore;
        }
    }
}