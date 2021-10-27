using GPACalculator.Model;
using System.Collections.Generic;

namespace GPACalculator.Data
{
    public class GPACalculatorList
    {
        public static List<GradingSystem> grading { get; set; } = new List<GradingSystem>();
        public static List<CourseDetails> courseDetails { get; set; } = new List<Model.CourseDetails>();
    }
}