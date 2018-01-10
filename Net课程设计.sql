-- CREATE DATABASE NetDesign IF NOT EXISTS;



--ѡ�ι���ϵͳ
-- ��ʦ��	��ı�ţ���ʦ�ţ���ʦ���ƣ���ʦ����Ժ��ţ���ʦ����ϵ����
-- Ժ��		��ı�ţ�Ժ�ı�ţ�Ժ������
-- ϵ��		��ı�ţ�ϵ�ı�ţ�ϵ����Ժ�ı�ţ�ϵ������
-- �༶��        ��ı�ţ��༶��ţ��༶����Ժ���༶����ϵ

-- ѧ����	��ı�ţ�ѧ�ţ����������룬�Ա�סַ��Ժ��ţ�ϵ��ţ��༶
-- ------��ţ�ѧ��״̬��

-- �γ�����    ��ı�ţ��γ����ı�ţ��γ��������
-- �γ̱�	��ı�ţ��γ̱�ţ��γ���𣬿γ����ƣ���ʦ��ţ�ѧ�֣���ʱ
-- ѧ���γ̳ɼ���	��ı�ţ�ѧ����ţ��γ̱�ţ���ʦ��ţ��ɼ����ɼ���




-- ѧԺ��
CREATE TABLE College
(
	cid int primary key identity(1,1),
	c_id CHAR(18) unique not null,
	c_name varchar(30) unique not null
);

-- ��ʦ��
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

-- ϵ����
CREATE TABLE System
(
	sid int primary key identity(1,1),
	s_id CHAR(18) unique not null,
	c_id CHAR(18)  not null,
	s_name VARCHAR(50) unique not null
	foreign key(c_id) references College(c_id)
);

-- �༶��
CREATE TABLE Class
(
	cid int primary key identity(1,1),
	c_id CHAR(18) unique not null,
	co_id CHAR(18)  not null,
	s_id CHAR(18)  not null,
	foreign key(co_id) references College(c_id),
	foreign key(s_id) references System(s_id)
);

-- ѧ����
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

-- �γ�����:��ı�ţ��γ����ı�ţ��γ��������
CREATE TABLE Type
(
	tid int primary key identity(1,1),
	t_id CHAR(18) not null unique,
	t_name varchar(30) not null
);

-- �γ̱���ı�ţ��γ̱�ţ��γ���𣬿γ����ƣ���ʦ��ţ�ѧ�֣���ʱ,�γ��������γ��������
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

-- ѧ���γ̳ɼ���	��ı�ţ�ѧ����ţ��γ̱�ţ���ʦ��ţ��ɼ���
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

INSERT INTO college VALUES ( '000001', '�����ѧԺ');
INSERT INTO system VALUES ( '1', '000001', '����������ϵ');
INSERT INTO class VALUES ( '1501', '000001', '1');
INSERT INTO student VALUES ( '15408500122', '����', '1018222wxw', '��', 'ɽ��ʡ˷���л�����', '000001', '1', '1501', '1');
INSERT INTO type VALUES ('1001', '�����');
INSERT INTO type VALUES ( '1002', '���ù���');
INSERT INTO type VALUES ( '1003', '��ѧ');
INSERT INTO teacher VALUES ( '1001', '123456', '����', '000001', '1', 1);
INSERT INTO course VALUES ( '1000001', '1001', 'Python��ѧ������ά���ӻ�', '1001', '5.0', '50', 200, 200);
INSERT INTO course VALUES ( '1000002', '1001', 'Python��������', '1001', '3.5', '48', 150, 150);
INSERT INTO SC(s_id, c_id, t_id, sc_status) VALUES('15408500126', '1000001', '1001', 0);
