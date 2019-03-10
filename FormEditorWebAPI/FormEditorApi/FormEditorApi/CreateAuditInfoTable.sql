use FormEditorDB;


IF NOT EXISTS (select * from sysobjects WHERE sysobjects.name = 'AuditInfo')
CREATE TABLE AuditInfo
(
	Id INT PRIMARY KEY IDENTITY,
	RequestTime TIME,
	FormId  varchar(40),
	ClientIP varchar(15)
)