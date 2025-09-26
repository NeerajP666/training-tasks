create database neerajdb;

use neerajdb;

create table employee(
Id int,
EmpName varchar(255),
City varchar(255),
Salary int
);

insert into employee(Id,EmpName,City,Salary) values (1,'Neeraj','Adoor',10000);

select * from employee;

insert into employee(Id,EmpName,City,Salary) values (2,'Kaiz','Kottayam',25000);

select * from employee;
select EmpName,Salary from employee;

insert into employee(Id,EmpName,City,Salary) values (3,'Karthik','Kollam',2500);
insert into employee(Id,EmpName,City,Salary) values (4,'Aswin','Thiruvananthapuram',12000);
insert into employee(Id,EmpName,City,Salary) values (5,'Aswin KT','Kannur',24000);
insert into employee(Id,EmpName,City,Salary) values (6,'Robin','Wayanad',11000);
insert into employee(Id,EmpName,City,Salary) values (7,'Adwaith','Kannur',1500);
insert into employee(Id,EmpName,City,Salary) values (8,'Dev','Thiruvananthapuram',50000);

select * from employee;

select distinct city from employee;
select city from employee;

select EmpName from employee where city='adoor';
select * from employee where city='thiruvananthapuram';

select EmpName from employee order by EmpName;
select EmpName from employee order by city;
select EmpName from employee order by city desc;

select * from employee where city='thiruvananthapuram' and EmpName like 'D%';
select * from employee where city='thiruvananthapuram' and EmpName like 'D%' or EmpName like 'A%';
select * from employee where city='thiruvananthapuram' and (EmpName like 'D%' or EmpName like 'A%');

select EmpName from employee where not city='kannur';

select * from employee where city is null;
select * from employee where city is not null;

update employee set city='Pathanamthitta' where EmpName='neeraj';
select * from employee;

delete from employee where city='wayanad';

select top 3* from employee;

select top 1 EmpName from employee;

select max(salary) from employee;
select avg(salary) from employee;
select min(salary) from employee;
select sum(salary) from employee;

select EmpName from employee where city in ('thiruvananthapuram','pathanamthitta');
select EmpName from employee where city not in ('thiruvananthapuram','pathanamthitta');

select EmpName from employee where salary between 11000 and 50000;

create database studentdb;

use studentdb;

create table students(
studentid int primary key,
name varchar(100),
age int,
city varchar(100)
);

create table course(
courseid int primary key,
studentid int,
coursename varchar(100),
grade char(1),
foreign key(studentid) references students(studentid)
);

insert into students(studentid,name,age,city) values
(101, 'Neeraj Premchand', 24, 'Pathanamthitta'),
(102, 'Rahul Kumar', 23, 'Kochi'),
(103, 'Anjali Nair', 22, 'Kozhikode'),
(104, 'Arjun Menon', 21, 'Trivandrum');

insert into course(courseid,studentid,coursename,grade) values
(201, 101, 'DBMS', 'A'),
(202, 101, 'JAVA', 'B'),
(203, 102, 'OS', 'A'),
(204, 103, 'AI', 'C'),
(205, 104, 'AI', 'B');

select * from students;
select * from course;

select name from students where city='pathanamthitta';
select name , age from students where age>20;
select coursename from course where grade='B';

select distinct city from students;
select distinct grade from course; 

select count(distinct city) from students;
select count(distinct city) as 'number of city' from students;

select name from students order by name;
select name,city from students order by name;
select name, city from students order by name desc;
select * from students order by name,city;

select name from students where age=22 and city='trivandrum';
select coursename,grade from course where grade='a' or grade='b';

select name from students where age is null;
select name from students where age is not null;
 
update students set name='Rahul R Kumar' where studentid=102;
select * from students;

insert into students(studentid,name,age,city) values
(105,'karthik u',25,'kollam');

select * from students;

delete from students where studentid=105;

select * from students;

select max(age) from students;
select name from students order by age;
select top 1 name from students order by age desc;
select * from students;
select top 1 name from students order by age;
select top 2 name from students order by age;
select top 1 name from students where age<(select max(age) from students) order by age desc;
select * from students;
select top 1 name from students where age>(select min(age) from students) order by age ;

select sum(age) as 'sum of age' from students;
select avg(age) as 'average of age' from students;

select name from students where name like 'a%';
select name from students where name like '_e%';
select * from students where name like '%d';
select * from students where name like '%e%';

select * from course where grade in ('a','b');
select * from course where grade not in ('a','b');

select * from students where studentid in(select studentid from course);
select * from students where studentid not in(select studentid from course);

select * from students where age between 22 and 25;
select * from students where age not between 22 and 25;

select students.name,course.coursename from students inner join course on students.studentid=course.studentid;
select students.* ,course.* from students inner join course on students.studentid=course.studentid;
select * from course;

use studentdb;
select * from course;
select students.* ,course.* from students inner join course on students.studentid=course.studentid;

select s.name,c.coursename from students s inner join course c on s.studentid=c.studentid;

select s.* ,c.* from students s left join course c on s.studentid=c.studentid;
select s.* ,c.* from students s right join course c on s.studentid=c.studentid;

insert into students(studentid,name,age,city) values
(105,'aswin','25','kannur');
select* from students;

select s.* ,c.* from students s right join course c on s.studentid=c.studentid;
select s.* ,c.* from students s left join course c on s.studentid=c.studentid;

select s.* ,c.* from students s full outer join course c on s.studentid=c.studentid;

select s.* ,c.* from students s left join course c  on s.studentid=c.studentid where age<23;

select name,age from students union select coursename,courseid from course;
select name from students where age<23 union select coursename from course where coursename not in('java');

select name from students union all select coursename from course;
select * from course;

select count(studentid) from course group by coursename;

select count(studentid) as 'number of students',coursename from course group by coursename;

select count(studentid) as 'number of students',coursename from course group by coursename order by count(studentid);
select count(studentid) as 'number of students',coursename from course group by coursename order by count(studentid)desc;

select* from students;

select count(studentid) as 'number of students',coursename from course group by coursename having count(studentid)>1;
select count(studentid) as 'number of students',coursename from course group by coursename having count(studentid)>1 order by count(studentid) desc;

select name from students where exists(select age from students where age>21);
select name from students where exists (select students.name,course.coursename from students inner join course on students.studentid=course.studentid);

select name from students where exists (select grade from course where grade='e');
-- exist 

/* exist
used for 
checking record*/
