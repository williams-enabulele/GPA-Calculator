# week-1-enabsdigital
week-1-enabsdigital created by GitHub Classroom
**Week 1 - Task**

**Intro :**

This task is aimed at evaluating your understanding of programing with C# language and the fundamental syntax and structures.

**Challenge**

You are required to write a console application that models a Grade Point Average (GPA) calculator and prints the result.

The result should be displayed in a tabular form as shown below:
```
|----------------------------|-----------------------|------------|---------------------|------------------|-------------------|

| COURSE & CODE              | COURSE UNIT           | GRADE      | GRADE-UNIT          | WEIGHT Pt.       | REMARK            |

|----------------------------|-----------------------|------------|---------------------|------------------|-------------------|

| MATH 101                   | 5                     | B          | 4                   | 20               | Very Good         |

| GS 101                     | 3                     | A          | 5                   | 15               | Excellent         |

| .NET 101                   | 5                     | C          | 3                   | 15               | Good              |

| C# 101                     | 5                     | B          | 4                   | 20               | Very Good         |

| HCI 101                    | 3                     | A          | 5                   | 15               | Excellent         |

|---------------------------------------------------------------------------------------|------------------|-------------------|

Total Grade Unit Registered is 21

Total Grade Unit Passed is 21

Total Weight Point is 85

Your GPA is = 4.10 to 2 decimal places.
```
For reference, GPA is calculated as follows:

GPA = (total weight point) / (total grade unit);

where:

(Weight point) = (course unit) * (grade unit);

See grading system below:

Score Grade Point Remark
 ```
70-100 A 5 Excellent

60-69  B   4 Very Good

50-59  C   3   Good

45-49  D   2   Fair

40-44  E   1   Pass

0-39   F   0   Fail
```
Task requirements

- [x] All stories should be completed.

- [x] Task should be submitted on or before Wednesday, July 7, 2021.

- [x] Submission should be made to this github classroom link: https://classroom.github.com/a/wgn0luwG

**Functional requirements**

- [x] The calculator should have a grading system that grades the score dynamically

Task Story

As a ** User **

- [x] I want to be able to input course name and code, course unit, course score; one after the other

- [x] so that the calculator will calculate the score grade and record it before the total result and GPA is displayed.
