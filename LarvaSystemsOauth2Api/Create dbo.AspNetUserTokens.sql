USE aspnet-test-6A411E7D-120F-474A-8950-DEB5999932AE
GO

/****** Object: Table dbo.AspNetUserTokens Script Date: 2/13/2019 8:44:31 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE dbo.AspNetUserTokens (
    UserId        NVARCHAR (450) NOT NULL,
    LoginProvider NVARCHAR (450) NOT NULL,
    Name          NVARCHAR (450) NOT NULL,
    Value         NVARCHAR (MAX) NULL
);


