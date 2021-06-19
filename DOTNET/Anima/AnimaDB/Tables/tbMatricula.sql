CREATE TABLE [dbo].[tbMatricula]
(
	[RA] INT NOT NULL
	,[CodGrade] INT NOT NULL,
	
    CONSTRAINT [FK_tbMatricula_tbAluno] FOREIGN KEY ([RA]) REFERENCES [tbAluno]([RA]) ,
    CONSTRAINT [UK_tbMatricula_RA_CodGrade] UNIQUE ([RA], [CodGrade]),
    CONSTRAINT [FK_tbMatricula_tbGrade] FOREIGN KEY ([CodGrade]) REFERENCES [tbGrade]([CodGrade]),
    CONSTRAINT [PK_tbMatricula] PRIMARY KEY ([CodGrade], [RA])
)

GO

CREATE TRIGGER [dbo].[t_tbMatricula_insert]  
    ON [dbo].[tbMatricula]  
    INSTEAD OF INSERT  
    AS  
    BEGIN  
        IF EXISTS (  
            SELECT 1   
            FROM tbMatricula A(NOLOCK)  
            INNER JOIN INSERTED I ON A.codGrade = I.codGrade  
            GROUP BY A.codGrade  
            HAVING COUNT(1) >= 10  
        )  
        BEGIN  
  
            IF EXISTS (  
                SELECT 1  
                FROM INSERTED I  
                INNER JOIN tbGrade G (NOLOCK) ON I.codGrade= G.CodParentGrade  
                GROUP BY CodParentGrade  
                HAVING COUNT(1) < 10  
            )  
            BEGIN  
                  
                DECLARE @codChildGrade INT  
  
                SELECT TOP 1  
                   @codChildGrade  = G.CodGrade  
                FROM INSERTED I  
                INNER JOIN tbGrade G (NOLOCK) ON I.codGrade= G.CodParentGrade  
                GROUP BY G.CodGrade  
                HAVING COUNT(1) < 10  
                ORDER BY 1  
  
                INSERT INTO tbMatricula(codGrade, RA)  
                SELECT @codChildGrade, RA  
                FROM INSERTED  
  
            END  
            ELSE  
            BEGIN  
             DECLARE @minID INT  
             SELECT  
              @minID = IIF(MIN(codGrade) = 1, 0, MIN(codGrade)) - 1  
             FROM tbGrade (NOLOCK)  
  
  
             INSERT INTO tbGrade ([CodGrade], [NomeCurso], [NomeDisciplina], [NomeTurma], [CodFuncionario], [CodParentGrade])  
             SELECT  
              @minID  
              ,[NomeCurso]  
              ,[NomeDisciplina]  
              ,[NomeTurma]  
              ,[CodFuncionario]  
              ,I.[CodGrade]    
             FROM tbGrade G (ROWLOCK)  
             INNER JOIN INSERTED I ON G.[CodGrade] = I.[CodGrade]  
  
            
                INSERT INTO tbMatricula(codGrade, RA)  
                SELECT @minID, RA  
                FROM INSERTED  
  
            END  
  
        END  
        ELSE  
        BEGIN  
            INSERT INTO tbMatricula(codGrade, RA)  
            SELECT codGrade, RA  
            FROM INSERTED  
        END  
    END  
GO

