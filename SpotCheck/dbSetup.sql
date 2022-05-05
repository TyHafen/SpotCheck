CREATE TABLE IF NOT EXISTS accounts(
	id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
	createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
	updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
	name varchar(255) COMMENT 'User Name',
	email varchar(255) COMMENT 'User Email',
	picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

SELECT * FROM accounts;

CREATE TABLE IF NOT EXISTS spots(
	id int NOT NULL AUTO_INCREMENT primary key COMMENT 'primary key',
	createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
	updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
	name VARCHAR(255) COMMENT "Spot Name",
	address VARCHAR(255) COMMENT "Spot Address",
	description TEXT NOT NULL,
	price TEXT NOT NULL,
	creatorId VARCHAR(255) NOT NULL,
	FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 COMMENT '';

SELECT * FROM spots;

DROP TABLE spots;

INSERT INTO
	spots (name, address, description, creatorId, price)
VALUES
	(
		"The house",
		"600 West Linden street Boise Id",
		"Lovely place to park, close to BSU",
		"6271b0dae49cd9bf1c178c4e",
		"20"
	);

SELECT LAST_INSERT_ID();