
Drop Table if exists [QuestionOptions]
Go
CREATE TABLE QuestionOptions (
    [QUE_Id] Uniqueidentifier  NOT NULL,
    [OPT_Id] Uniqueidentifier  NOT NULL,
    PRIMARY KEY (QUE_Id , OPT_Id),
    CONSTRAINT Constr_Question_fk
        FOREIGN KEY (QUE_Id) REFERENCES [Question] (QUE_Id)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT Constr_Option_fk
        FOREIGN KEY (OPT_Id)  REFERENCES [Option] (OPT_Id)
        ON DELETE CASCADE ON UPDATE CASCADE
)
Go