Drop Table if exists [QuizQuestions]
Go
CREATE TABLE QuizQuestions (
    [QUI_Id] Uniqueidentifier  NOT NULL,
    [QUE_Id] Uniqueidentifier  NOT NULL,

    PRIMARY KEY (QUI_Id , QUE_Id),
    CONSTRAINT Constr_QuestionId_fk
        FOREIGN KEY (QUE_Id) REFERENCES [Question] (QUE_Id)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT Constr_QuizId_fk
        FOREIGN KEY (QUI_Id)  REFERENCES [Quiz] (QUI_Id)
        ON DELETE CASCADE ON UPDATE CASCADE
)
Go

ALTER TABLE QuizQuestions
ADD CONSTRAINT [QQU_QuizQuestions_CreatedDate] DEFAULT(GETDATE()) FOR [QQU_CreatedDate];
GO
ALTER TABLE QuizQuestions
ADD CONSTRAINT [QQU_QuizQuestions_LastModifiedDate] DEFAULT(GETDATE()) FOR [QQU_LastModifiedDate];
GO
