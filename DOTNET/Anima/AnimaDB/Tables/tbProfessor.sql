CREATE TABLE [dbo].[tbProfessor]
(
	[codFuncionario] INT NOT NULL
	,[CPF] NVARCHAR(11)	 NOT NULL, 
    
	CONSTRAINT [PK_tbProfessor_CPF] PRIMARY KEY ([CPF]),
	CONSTRAINT [FK_tbProfessor_tbUsuario] FOREIGN KEY ([CPF]) REFERENCES [tbUsuario]([CPF]),
	CONSTRAINT [UK_tbProfessor_CodFuncionario] UNIQUE ([codFuncionario])
)
