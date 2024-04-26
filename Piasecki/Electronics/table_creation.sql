CREATE TABLE Phone (
                       Id INT AUTO_INCREMENT PRIMARY KEY,
                       Name VARCHAR(255) NOT NULL,
                       Price DECIMAL(10, 2) NOT NULL,
                       Camera VARCHAR(255) NOT NULL
);

CREATE TABLE Monitor (
                         Id INT AUTO_INCREMENT PRIMARY KEY,
                         Name VARCHAR(255) NOT NULL,
                         Price DECIMAL(10, 2) NOT NULL,
                         Diagonal DECIMAL(5, 2) NOT NULL
);

CREATE TABLE Laptop (
                        Id INT AUTO_INCREMENT PRIMARY KEY,
                        Name VARCHAR(255) NOT NULL,
                        Price DECIMAL(10, 2) NOT NULL,
                        CPU VARCHAR(255) NOT NULL,
                        GPU VARCHAR(255) NOT NULL,
                        Size DECIMAL(5, 2) NOT NULL
);

CREATE TABLE GPU (
                     Id INT AUTO_INCREMENT PRIMARY KEY,
                     Name VARCHAR(255) NOT NULL,
                     Price DECIMAL(10, 2) NOT NULL,
                     VRam VARCHAR(255) NOT NULL
);
