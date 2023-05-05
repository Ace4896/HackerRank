-- Amber's conglomerate corporation just acquired some new companies. Each of the companies follows this hierarchy:
--
-- Founder -> Lead Manager -> Senior Manager -> Manager
--
-- Given the table schemas below, write a query to print the company_code, founder name, total number of lead managers, total number of senior managers, total number of managers, and total number of employees. Order your output by ascending company_code.
--
-- Note:
-- - The tables may contain duplicate records.
-- - The company_code is string, so the sorting should not be numeric. For example, if the company_codes are C_1, C_2, and C_10, then the ascending company_codes will be C_1, C_10, and C_2.
--
-- The following tables contain company data:
--
-- Company: The company_code is the code of the company and founder is the name of the founder of the company.
--
-- Column           Type
-- company_code     String
-- founder          String
--
-- Lead_Manager: The lead_manager_code is the code of the lead manager, and the company_code is the code of the working company.
--
-- Column               Type
-- lead_manager_code    String
-- company_code         String
--
-- Senior_Manager: The senior_manager_code is the code of the senior manager, the lead_manager_code is the code of its lead manager, and the company_code is the code of the working company. 
--
-- Column               Type
-- senior_manager_code  String
-- lead_manager_code    String
-- company_code         String
--
-- Manager: The manager_code is the code of the manager, the senior_manager_code is the code of its senior manager, the lead_manager_code is the code of its lead manager, and the company_code is the code of the working company.
--
-- Column               Type
-- manager_code         String
-- senior_manager_code  String
-- lead_manager_code    String
-- company_code         String
--
-- Employee: The employee_code is the code of the employee, the manager_code is the code of its manager, the senior_manager_code is the code of its senior manager, the lead_manager_code is the code of its lead manager, and the company_code is the code of the working company.
--
-- Column               Type
-- employee_code        String
-- manager_code         String
-- senior_manager_code  String
-- lead_manager_code    String
-- company_code         String

-- MS SQL Server
-- The extra columns in each subtable seem redundant... but can use them to avoid joining

-- Attempt 1: While this works, it's quite janky because there's a lot of subqueries... there's definitely a better way
WITH LM_Totals AS (
    SELECT c.company_code, count = COUNT(DISTINCT lm.lead_manager_code)
    FROM Company c
    JOIN Lead_Manager lm ON c.company_code = lm.company_code
    GROUP BY c.company_code
),
SM_Totals AS (
    SELECT c.company_code, count = COUNT(DISTINCT sm.senior_manager_code)
    FROM Company c
    JOIN Senior_Manager sm ON c.company_code = sm.company_code
    GROUP BY c.company_code
),
M_Totals AS (
    SELECT c.company_code, count = COUNT(DISTINCT m.manager_code)
    FROM Company c
    JOIN Manager m ON c.company_code = m.company_code
    GROUP BY c.company_code
),
E_Totals AS (
    SELECT c.company_code, count = COUNT(DISTINCT e.employee_code)
    FROM Company c
    JOIN Employee e ON c.company_code = e.company_code
    GROUP BY c.company_code
)
SELECT
    c.company_code,
    c.founder,
    lm.count,
    sm.count,
    m.count,
    e.count
FROM Company c
JOIN LM_Totals lm ON lm.company_code = c.company_code
JOIN SM_Totals sm ON sm.company_code = c.company_code
JOIN M_Totals m ON m.company_code = c.company_code
JOIN E_Totals e ON e.company_code = c.company_code
ORDER BY c.company_code;

-- Attempt 2: This works apparently...
-- I think it's because each join was done between the employee table and the company table - we get all the unique combinations anyway
-- If there's multiple founders, we'll end up with multiple rows with the same totals anyway, so no need for subquery
SELECT
    c.company_code,
    c.founder,
    lm_count = COUNT(DISTINCT lm.lead_manager_code),
    sm_count = COUNT(DISTINCT sm.senior_manager_code),
    m_count = COUNT(DISTINCT m.manager_code),
    e_count = COUNT(DISTINCT e.employee_code)
FROM Company c
JOIN Lead_Manager lm ON lm.company_code = c.company_code
JOIN Senior_Manager sm ON sm.company_code = c.company_code
JOIN Manager m ON m.company_code = c.company_code
JOIN Employee e ON e.company_code = c.company_code
GROUP BY c.company_code, c.founder
ORDER BY c.company_code;
