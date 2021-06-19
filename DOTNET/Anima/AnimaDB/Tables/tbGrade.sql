CREATE TABLE [dbo].[tbGrade]
(
	[CodGrade] INT NOT NULL
	,[NomeCurso] NVARCHAR(200) NOT NULL
	,[NomeDisciplina] NVARCHAR(200) NOT NULL
	,[NomeTurma] NVARCHAR(200) NOT NULL
	,[CodFuncionario] INT NOT NULL
	,[CodParentGrade] INT,
    
	CONSTRAINT [PK_tbGrade_CodGrade] PRIMARY KEY ([CodGrade]),
	CONSTRAINT [FK_tbGrade_tbProfessor] FOREIGN KEY ([CodFuncionario]) REFERENCES [tbProfessor]([CodFuncionario]),
	CONSTRAINT [FK_tbGrade_tbGrade] FOREIGN KEY ([CodParentGrade]) REFERENCES [tbGrade]([CodGrade])

)
