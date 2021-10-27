### Students GPA Calculator
**Grading System :**
The result should be displayed in a tabular form as shown below:
```c#
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
 ```c#
70-100 A 5 Excellent

60-69  B   4 Very Good

50-59  C   3   Good

45-49  D   2   Fair

40-44  E   1   Pass

0-39   F   0   Fail
```
Task requirements

- [x] All user stories completed.

**Functional requirements**

- [x] The calculator has a grading system that grades the score dynamically

Task Story

As a ** User **
- [x] I want to be able to input course name and code, course unit, course score; one after the other

- [x] so that the calculator will calculate the score grade and record it before the total result and GPA is displayed.
