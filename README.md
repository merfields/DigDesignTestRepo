# DigDesignTestRepo
Задание №1

1)	SELECT * FROM employee WHERE salary = (SELECT max(salary) from employee)

2)	WITH treeDepths AS (
   	SELECT 1 AS depth, chief_id, id
  	FROM employee
   	WHERE chief_id IS NULL
  
  	UNION ALL
  
  	SELECT depth + 1, employee.chief_id, employee.id
   	FROM employee
   	JOIN treeDepths
     	ON employee.chief_id = treeDepths.id
	)
	SELECT MAX(depth)
	FROM treeDepths;

3)	WITH department_sum_salary AS 
	(SELECT department_id, sum(salary) AS sum_salary
	FROM employee 
	GROUP BY department_id)
	SELECT department_id, department.name, sum_salary
	FROM department_sum_salary JOIN department ON department_sum_salary.department_id = department.id 
	WHERE department_sum_salary.sum_salary = (SELECT max(sum_salary) FROM department_sum_salary);

4) 	SELECT * FROM employee WHERE name LIKE "Р%н" (если необходимо найти всех)
	SELECT * FROM employee WHERE name LIKE "Р%н" LIMIT 1 (если необходимо найти одного)

Задание № 2
При запуске консольного приложения в качестве аргумента ввести путь к текстовому файлу
