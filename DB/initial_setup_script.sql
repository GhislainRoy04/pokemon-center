CREATE DATABASE pokemoncenter;
USE pokemoncenter;

CREATE TABLE pokemon(
	Id INT,
    Name VARCHAR(250) NOT NULL,
    Type1 VARCHAR(250) NOT NULL,
    Type2 VARCHAR(250),
    Total INT NOT NULL,
    HP INT NOT NULL,
    Attack INT NOT NULL,
    Defense INT NOT NULL,
    SpecialAttack INT NOT NULL,
    SpecialDefense INT NOT NULL,
    Speed INT NOT NULL,
    Generation INT NOT NULL,
    Legendary VARCHAR(250) NOT NULL
);

CREATE USER 'testUser'@'localhost' IDENTIFIED BY 'Test1234';
GRANT SELECT, CREATE, INSERT, UPDATE, DELETE ON pokemoncenter.pokemon TO 'testUser'@'localhost';

-- Put the path to where it's allowed to upload. Can be shown with SHOW VARIABLES LIKE "secure_file_priv"; command
LOAD DATA INFILE 'C:/ProgramData/MySQL/MySQL Server 8.0/Uploads/pokemon.csv'
INTO TABLE pokemon
COLUMNS TERMINATED BY ','
OPTIONALLY ENCLOSED BY '"'
ESCAPED BY '"'
LINES TERMINATED BY '\n'
IGNORE 1 LINES;
