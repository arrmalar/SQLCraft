using SQLCraftFront.Models;

namespace SQLCraftFront.Repositories
{
    public static class QueryRiddleRepository
    {
        private static List<QueryRiddle> QueryRiddles = new List<QueryRiddle> {
            new QueryRiddle { QueryRiddleID = 1, Title = "Basic SELECT", Difficulty = "Easy", IsCompleted = false, Question = "How do you select all columns from a table named 'Employees'?", Answer = "SELECT * FROM Employees;" },
            new QueryRiddle { QueryRiddleID = 2, Title = "WHERE Clause", Difficulty = "Easy", IsCompleted = false, Question = "Write a query to find all employees with a salary greater than 5000.", Answer = "SELECT * FROM Employees WHERE Salary > 5000;" },
            new QueryRiddle { QueryRiddleID = 3, Title = "ORDER BY Clause", Difficulty = "Medium", IsCompleted = false, Question = "How would you sort the 'Employees' table by 'LastName' in ascending order?", Answer = "SELECT * FROM Employees ORDER BY LastName ASC;" },
            new QueryRiddle { QueryRiddleID = 4, Title = "JOIN Operation", Difficulty = "Medium", IsCompleted = true, Question = "Write a query to retrieve employee names and their department names using 'Employees' and 'Departments' tables.", Answer = "SELECT Employees.Name, Departments.Name FROM Employees INNER JOIN Departments ON Employees.DepartmentID = Departments.ID;" },
            new QueryRiddle { QueryRiddleID = 5, Title = "GROUP BY Clause", Difficulty = "Medium", IsCompleted = false, Question = "How do you find the total number of employees in each department?", Answer = "SELECT DepartmentID, COUNT(*) FROM Employees GROUP BY DepartmentID;" },
            new QueryRiddle { QueryRiddleID = 6, Title = "HAVING Clause", Difficulty = "Hard", IsCompleted = false, Question = "How do you find departments with more than 10 employees?", Answer = "SELECT DepartmentID, COUNT(*) FROM Employees GROUP BY DepartmentID HAVING COUNT(*) > 10;" },
            new QueryRiddle { QueryRiddleID = 7, Title = "Subquery", Difficulty = "Hard", IsCompleted = false, Question = "Write a query to find employees who earn more than the average salary of their department.", Answer = "SELECT * FROM Employees WHERE Salary > (SELECT AVG(Salary) FROM Employees);" },
            new QueryRiddle { QueryRiddleID = 8, Title = "DELETE Statement", Difficulty = "Easy", IsCompleted = false, Question = "How do you delete records from the 'Employees' table where the 'DepartmentID' is NULL?", Answer = "DELETE FROM Employees WHERE DepartmentID IS NULL;" },
            new QueryRiddle { QueryRiddleID = 9, Title = "UPDATE Statement", Difficulty = "Medium", IsCompleted = false, Question = "How would you update all employee salaries by 10%?", Answer = "UPDATE Employees SET Salary = Salary * 1.1;" },
            new QueryRiddle { QueryRiddleID = 10, Title = "LEFT JOIN", Difficulty = "Medium", IsCompleted = false, Question = "Write a query to find all employees and their department names, including employees without departments.", Answer = "SELECT Employees.Name, Departments.Name FROM Employees LEFT JOIN Departments ON Employees.DepartmentID = Departments.ID;" },
            new QueryRiddle { QueryRiddleID = 11, Title = "DISTINCT Clause", Difficulty = "Easy", IsCompleted = false, Question = "How do you select unique job titles from the 'Employees' table?", Answer = "SELECT DISTINCT JobTitle FROM Employees;" },
            new QueryRiddle { QueryRiddleID = 12, Title = "Union Operator", Difficulty = "Hard", IsCompleted = true, Question = "Write a query to combine the results of two tables 'Employees_2023' and 'Employees_2024' with identical columns.", Answer = "SELECT * FROM Employees_2023 UNION SELECT * FROM Employees_2024;" },
            new QueryRiddle { QueryRiddleID = 13, Title = "INNER JOIN with WHERE Clause", Difficulty = "Medium", IsCompleted = false, Question = "Find employees who work in the 'Sales' department using 'Employees' and 'Departments' tables.", Answer = "SELECT Employees.Name FROM Employees INNER JOIN Departments ON Employees.DepartmentID = Departments.ID WHERE Departments.Name = 'Sales';" },
            new QueryRiddle { QueryRiddleID = 14, Title = "Creating a Table", Difficulty = "Hard", IsCompleted = false, Question = "How do you create a table named 'Projects' with columns 'ID' (integer), 'Name' (string), and 'StartDate' (date)?", Answer = "CREATE TABLE Projects (ID INT, Name VARCHAR(100), StartDate DATE);" },
            new QueryRiddle { QueryRiddleID = 15, Title = "ALTER TABLE", Difficulty = "Medium", IsCompleted = false, Question = "Write a query to add a new column 'Email' to the 'Employees' table.", Answer = "ALTER TABLE Employees ADD Email VARCHAR(255);" },
            new QueryRiddle { QueryRiddleID = 16, Title = "RIGHT JOIN", Difficulty = "Hard", IsCompleted = false, Question = "How do you find all departments and their employees, including departments without employees?", Answer = "SELECT Departments.Name, Employees.Name FROM Departments RIGHT JOIN Employees ON Employees.DepartmentID = Departments.ID;" },
            new QueryRiddle { QueryRiddleID = 17, Title = "Index Creation", Difficulty = "Medium", IsCompleted = false, Question = "How do you create an index on the 'LastName' column in the 'Employees' table?", Answer = "CREATE INDEX idx_lastname ON Employees(LastName);" },
            new QueryRiddle { QueryRiddleID = 18, Title = "ROLLBACK and COMMIT", Difficulty = "Medium", IsCompleted = false, Question = "Explain the difference between COMMIT and ROLLBACK in SQL.", Answer = "COMMIT permanently saves changes made in a transaction. ROLLBACK undoes changes made in the current transaction." },
            new QueryRiddle { QueryRiddleID = 19, Title = "Self Join", Difficulty = "Easy", IsCompleted = false, Question = "How do you find employees who share the same manager using a self-join on the 'Employees' table?", Answer = "SELECT e1.Name, e2.Name AS Manager FROM Employees e1 INNER JOIN Employees e2 ON e1.ManagerID = e2.ID;" },
            new QueryRiddle { QueryRiddleID = 20, Title = "Full Outer Join", Difficulty = "Hard", IsCompleted = true, Question = "How do you retrieve all records from two tables 'Employees' and 'Departments', even if they do not match?", Answer = "SELECT * FROM Employees FULL OUTER JOIN Departments ON Employees.DepartmentID = Departments.ID;" },
            new QueryRiddle { QueryRiddleID = 21, Title = "CREATE VIEW", Difficulty = "Medium", IsCompleted = false, Question = "How do you create a view 'ActiveEmployees' showing only employees with 'IsActive' status?", Answer = "CREATE VIEW ActiveEmployees AS SELECT * FROM Employees WHERE IsActive = 1;" },
            new QueryRiddle { QueryRiddleID = 22, Title = "Dropping a Table", Difficulty = "Easy", IsCompleted = false, Question = "Write a query to delete the 'Projects' table from the database.", Answer = "DROP TABLE Projects;" },
            new QueryRiddle { QueryRiddleID = 23, Title = "Triggers in SQL", Difficulty = "Medium", IsCompleted = false, Question = "What is a trigger in SQL and when would you use it?", Answer = "A trigger is a special kind of stored procedure that automatically runs when specific events occur in a database, like INSERT, UPDATE, or DELETE." },
            new QueryRiddle { QueryRiddleID = 24, Title = "Foreign Key Constraint", Difficulty = "Hard", IsCompleted = false, Question = "How do you create a foreign key constraint between 'Employees' and 'Departments'?", Answer = "ALTER TABLE Employees ADD CONSTRAINT fk_department FOREIGN KEY (DepartmentID) REFERENCES Departments(ID);" }
        };

        private static int UsedQueryRiddleIndex = 1;

        public static List<QueryRiddle> GetAllQueryRiddles() => QueryRiddles;

        public static QueryRiddle GetById(int id) => QueryRiddles.FirstOrDefault(qr => qr.QueryRiddleID == id);

        public static int GetUsedQueryRiddleIndex() => UsedQueryRiddleIndex;

        public static void ChangeUsedQueryRiddleIndex(int index) {
            UsedQueryRiddleIndex = index;
        }
    }
}
