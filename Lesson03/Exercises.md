
### Driver's license

The operator of the driver's license test support system enters the following information into the system, for a candidate who is taking the exams for the first time:

-   The number of points from the theoretical exam (integer number from 0 to 100)

-   The number of errors made by the candidate during the practical exam (integer number 0 or greater)

The candidate must take both exams. A candidate is granted a driver's license if they meet the following two conditions: they scored at least 85 points on the theoretical test and made no more than two errors on the practical test. If a candidate fails one of the exams, they must repeat this exam. In addition, if the candidate fails both exams, they are required to take additional hours of driving lessons.

Use black-box analysis to identify a comprehensive series of test cases:

1. Create the corresponding decision table

| Partition type           | R1  | R2  | R3  | R4  |
| ------------------------ | --- | --- | --- | --- |
| **Conditions**           |     |     |     |     |
| Atleast 85 points        | T   | F   | T   | F   |
| Less than 3 errors       | T   | T   | F   | F   |
| **Actions**              |     |     |     |     |
| Driver's license granted | Y   | N   | N   | N   |
| Repeat theory exam       | N   | Y   | N   | Y   |
| Repeat practical exam    | N   | N   | Y   | Y   |
| Extra driving lessons    | N   | N   | N   | Y   |

2. Write test cases based on the decision table

|     | Th ex points | Pr ex errors | Rule |
| --- | ------------ | ------------ | ---- |
| 1   | 90           | 1            | R1   |
| 2   | 50           | 2            | R2   |
| 3   | 90           | 4            | R3   |
| 4   | 50           | 4            | R4   |

3. Identify the corresponding equivalence partitions

Points:

| Partition type | Partitions | Middle test case values | Expected output | Boundary values | Boundary test case values |
| -------------- | ---------- | ----------------------- | --------------- | --------------- | ------------------------- |
| Invalid        | 0          | 0                       | false           | 0               | 0, 1                      |
| Invalid        | 1-84       | 44                      | false           | 1, 84           | 0, 1, 2, 83, 84, 85       |
| Valid          | 85-100     | 90                      | true            | 85, 100         | 84, 85, 86, 99, 100, 101  |

Practical test errors:

| Partition type | Partitions | Middle test case values | Expected output | Boundary values | Boundary test case values |
| -------------- | ---------- | ----------------------- | --------------- | --------------- | ------------------------- |
| Valid          | 0          | 0                       | true            | --              | 0, 1                      |
| Valid          | 1-2        | 1                       | true            | 1, 2            | 0, 1, 2, 3                |
| Invalid        | 3-INFINITY | 10                      | false           | 3               | 2, 3, 4                   |

4. Use 3-value boundary value analysis to identify further test cases

5. Identify edge cases

Points: `-1`, `101`, `MAX INTEGER`,
Errors: `-1`, `MAX INTEGER`,

6. List all test case values
7. Implement in code a function that receives as parameters the number of points for the theory exam and the number of errors for the practical exam and that returns a data structure with four boolean properties: whether the driver's license is granted, whether the theory exam must be repeated, whether the practical exam must be repeated, and whether additional driving lessons must be taken. Write the corresponding unit tests based on the above analysis. Use the programming language and unit test framework of your choice 
