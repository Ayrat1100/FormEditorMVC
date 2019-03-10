use FormEditorDB;


IF NOT EXISTS (select * from sysobjects WHERE sysobjects.name = 'AuditInfo')
CREATE TABLE AuditInfo
(
	Id INT PRIMARY KEY IDENTITY,
	RequestTime varchar(15),
	FormId  varchar(40),
	ClientIP varchar(15)
)