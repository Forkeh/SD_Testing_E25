### Driver's license

The operator of the driver's license test support system enters the following information into the system, for a
candidate who is taking the exams for the first time:

- The number of points from the theoretical exam (integer number from 0 to 100)

- The number of errors made by the candidate during the practical exam (integer number 0 or greater)

The candidate must take both exams. A candidate is granted a driver's license if they meet the following two conditions:
they scored at least 85 points on the theoretical test and made no more than two errors on the practical test. If a
candidate fails one of the exams, they must repeat this exam. In addition, if the candidate fails both exams, they are
required to take additional hours of driving lessons.

Use black-box analysis to identify a comprehensive series of test cases:

1. Create the corresponding decision table

| Partition type           | R1 | R2 | R3 | R3 |
|--------------------------|----|----|----|----|
| **Conditions**           |    |    |    |    |
| Atleast 85 points        | T  | F  | T  | F  |
| Less than 3 errors       | T  | T  | F  | F  |
| **Actions**              |    |    |    |    |
| Driver's license granted | Y  | N  | N  | N  |
| Repeat theory exam       | N  | Y  | N  | Y  |
| Repeat practical exam    | N  | N  | Y  | Y  |
| Extra driving lessons    | N  | N  | N  | Y  |

2. Write test cases based on the decision table


3. Identify the corresponding equivalence partitions

Points:

| Partition type | Partitions | Middle test case values | Expected output | Boundary values | Boundary test case values |
|----------------|------------|-------------------------|-----------------|-----------------|---------------------------|
| Invalid        | 0          | 0                       | false           | 0               | 0, 1                      |
| Invalid        | 1-84       | 44                      | false           | 1, 84           | 0, 1, 2, 83, 84, 85       |
| Valid          | 85-100     | 90                      | true            | 85, 100         | 84, 85, 86, 99, 100, 101  |

Practical test errors:

| Partition type | Partitions | Middle test case values | Expected output | Boundary values | Boundary test case values |
|----------------|------------|-------------------------|-----------------|-----------------|---------------------------|
| Valid          | 0          | 0                       | true            | --              | 0, 1                      |
| Valid          | 1-2        | 1                       | true            | 1, 2            | 0, 1, 2, 3                |
| Invalid        | 3-INFINITY | 10                      | false           | 3               | 2, 3, 4                   |

4. Use 3-value boundary value analysis to identify further test cases


5. Identify edge cases
6. List all test case values
7. Implement in code a function that receives as parameters the number of points for the theory exam and the number of
   errors for the practical exam and that returns a data structure with four boolean properties: whether the driver's
   license is granted, whether the theory exam must be repeated, whether the practical exam must be repeated, and
   whether additional driving lessons must be taken. Write the corresponding unit tests based on the above analysis. Use
   the programming language and unit test framework of your choice

---

### Airline discount policy

An airline offers only flights to India and Asia. Under special conditions, a discount is offered on the normal airfare:

- Passengers older than 18 with destinations in India are offered a discount of 20%, as long as the departure is not on
  a Monday or Friday
- For destinations outside of India, passengers are offered a discount of 25%, if the departure is not on a Monday or
  Friday
- Passengers who stay at least 6 days at their destination receive an additional discount of 10%
- Passengers older than 2 but younger than 18 years are offered a discount of 40% for all destinations
- Children 2 and under travel for free

Apply black-box test design:

1. Represent this information in a decision table.


- R1: Free travel
- R2-3: 40% discount, kids
- R4-7: Above 18, Travel to India,
- R8-11: Above 18, Travel outside India

| Partition type         | R1  | R2 | R3 | R4 | R5 | R6 | R7 | R8 | R9 | R10 | R11 |
|------------------------|-----|----|----|----|----|----|----|----|----|-----|-----|
| **Conditions**         |     |    |    |    |    |    |    |    |    |     |     |
| Age ≤ 2                | T   | -  | -  | -  | -  | -  | -  | -  | -  | -   | -   |
| Age 3-18               | -   | T  | T  | -  | -  | -  | -  | -  | -  | -   | -   |
| Age > 18               | -   | -  | -  | T  | T  | T  | T  | T  | T  | T   | T   |
| Destination in India   | -   | -  | -  | T  | T  | T  | T  | F  | F  | F   | F   |
| Departure on Mon/Fri   | -   | -  | -  | F  | F  | T  | T  | T  | T  | F   | F   |
| Staying atleast 6 days | -   | F  | T  | F  | T  | F  | T  | F  | T  | F   | T   |
| **Actions**            |     |    |    |    |    |    |    |    |    |     |     |
| 10% discount           | N/A | N  | Y  | N  | Y  | N  | Y  | N  | Y  | N   | Y   |
| 20% discount           | N/A | N  | N  | Y  | Y  | N  | N  | N  | N  | N   | N   |
| 25% discount           | N/A | N  | N  | N  | N  | N  | N  | N  | N  | Y   | Y   |
| 40% discount           | N/A | Y  | Y  | N  | N  | N  | N  | N  | N  | N   | N   |
| Free travel            | Y   | N  | N  | N  | N  | N  | N  | N  | N  | N   | N   |

2. Write the corresponding unit tests (one test case per business rule) using the programming language and unit test
   framework of your choice

<sub>Adapted from
FlexRule, ["Preparing a decision table"](https://resource.flexrule.com/knowledge-base/preparing-a-decision-table/)</sub>
 