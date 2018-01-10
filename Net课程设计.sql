-- CREATE DATABASE NetDesign IF NOT EXISTS;



--选课管理系统
-- 教师表	表的编号，教师号，教师名称，教师所属院编号，教师所属系办编号
-- 院表		表的编号，院的编号，院的名称
-- 系表		表的编号，系的编号，系所属院的编号，系的名称
-- 班级表        表的编号，班级编号，班级所属院，班级所属系

-- 学生表	表的编号，学号，姓名，密码，性别，住址，院编号，系编号，班级
-- ------编号，学生状态，

-- 课程类别表    表的编号，课程类别的编号，课程类别名称
-- 课程表	表的编号，课程编号，课程类别，课程名称，老师编号，学分，课时
-- 学生课程成绩表	表的编号，学生编号，课程编号，教师编号，成绩，成绩登




-- 学院表
CREATE TABLE College
(
	cid int primary key identity(1,1),
	c_id CHAR(18) unique not null,
	c_name varchar(30) unique not null
);

-- 老师表
CREATE TABLE Teacher
(
	tid int primary key identity(1,1),
	t_id CHAR(18) unique not null,
	t_pwd VARCHAR(50) not null,
	t_name varchar(30) not null,
	c_id CHAR(18) not null,
	x_id VARCHAR(50) not null,
	t_status int not null,
	foreign key(c_id) references College(c_id)
);

-- 系部表
CREATE TABLE System
(
	sid int primary key identity(1,1),
	s_id CHAR(18) unique not null,
	c_id CHAR(18)  not null,
	s_name VARCHAR(50) unique not null
	foreign key(c_id) references College(c_id)
);

-- 班级表
CREATE TABLE Class
(
	cid int primary key identity(1,1),
	c_id CHAR(18) unique not null,
	co_id CHAR(18)  not null,
	s_id CHAR(18)  not null,
	foreign key(co_id) references College(c_id),
	foreign key(s_id) references System(s_id)
);

-- 学生表
CREATE TABLE Student
(
	sid int primary key identity(1,1),
	s_id CHAR(18) unique not null,
	s_name varchar(30) not null,
	s_pwd varchar(50) not null,
	s_gender varchar(2) not null,
	s_address varchar(50) not null,
	co_id CHAR(18) not null ,
	sy_id CHAR(18) not null ,
	c_id CHAR(18) not null ,
	s_status int not null,
	foreign key(co_id) references College(c_id),
	foreign key(sy_id) references System(s_id),
	foreign key(c_id) references Class(c_id)
);

-- 课程类别表:表的编号，课程类别的编号，课程类别名称
CREATE TABLE Type
(
	tid int primary key identity(1,1),
	t_id CHAR(18) not null unique,
	t_name varchar(30) not null
);

-- 课程表：表的编号，课程编号，课程类别，课程名称，老师编号，学分，课时,课程容量，课程容量余额
CREATE TABLE Course
(
	cid int primary key identity(1,1),
	c_id CHAR(18) not null unique,
	ty_id CHAR(18) not null ,
	c_name varchar(30) not null,
	te_id CHAR(18) not null,
	c_score numeric(2,1) not null,
	c_time int ,
	c_number int,
	c_balannumber int,
	foreign key(ty_id) references Type(t_id),
	foreign key(te_id) references Teacher(t_id)
);

-- 学生课程成绩表	表的编号，学生编号，课程编号，教师编号，成绩，
CREATE TABLE SC
(
	scid int primary key identity(1,1),
	s_id CHAR(18) not null,
	c_id CHAR(18) not null,
	t_id CHAR(18) not null,
	sc_score float ,
	sc_status int not null,
	foreign key(s_id) references Student(s_id),
	foreign key(c_id) references Course(c_id),
	foreign key(t_id) references Teacher(t_id)
);

INSERT INTO college VALUES ( '000001', '计算机学院');
INSERT INTO system VALUES ( '1', '000001', '物联网工程系');
INSERT INTO class VALUES ( '1501', '000001', '1');
INSERT INTO student VALUES ( '15408500122', '孙鹏', '1018222wxw', '男', '山西省朔州市怀仁县', '000001', '1', '1501', '1');
INSERT INTO type VALUES ('1001', '计算机');
INSERT INTO type VALUES ( '1002', '经济管理');
INSERT INTO type VALUES ( '1003', '工学');
INSERT INTO teacher VALUES ( '1001', '123456', '嵩天', '000001', '1', 1);
INSERT INTO course VALUES ( '1000001', '1001', 'Python科学计算三维可视化', '1001', '5.0', '50', 200, 200);
INSERT INTO course VALUES ( '1000002', '1001', 'Python网络爬虫', '1001', '3.5', '48', 150, 150);
INSERT INTO SC(s_id, c_id, t_id, sc_status) VALUES('15408500126', '1000001', '1001', 0);
