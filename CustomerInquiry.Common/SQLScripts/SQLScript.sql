--DROP TABLE CustomerTransaction
--DROP TABLE Customers
--DROP TABLE Transactions



CREATE TABLE Customers (    
	CustomerID INT IDENTITY(1,1) NOT NULL,
	CustomerName NVARCHAR(30) NOT NULL,
	ContactEmail NVARCHAR(25) NULL,
	MobileNo NUMERIC(10) NULL  

CONSTRAINT PK_Customers PRIMARY KEY CLUSTERED (CustomerID)  
);

CREATE TABLE Transactions(
	TransactionID INT IDENTITY(1,1) NOT NULL,
	TransactionDate  DATETIME,
	Amount NUMERIC(18,2),
	CurrencyCode NVARCHAR(3),
	Status NUMERIC(1)

CONSTRAINT PK_Transactions PRIMARY KEY CLUSTERED (TransactionID)  
);

CREATE TABLE CustomerTransaction
(
	CustomerTransactionID INT IDENTITY(1,1) NOT NULL,
	CustomerID INT NOT NULL,
	TransactionID INT NOT NULL,

	CONSTRAINT PK_CustomerTransaction PRIMARY KEY CLUSTERED (CustomerTransactionID),

	CONSTRAINT FK_Customer_CustomerID FOREIGN KEY (CustomerID)     
	REFERENCES Customers(CustomerID) ON DELETE CASCADE ON UPDATE CASCADE, 

	CONSTRAINT FK_Transaction_TransactionID FOREIGN KEY (TransactionID)     
	REFERENCES Transactions(TransactionID) ON DELETE CASCADE ON UPDATE CASCADE   
);
