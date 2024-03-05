CREATE TABLE UserCredential (
                                Uid TEXT PRIMARY KEY,
                                UserProfileUid CHAR(36) NOT NULL,
                                Created DATETIME NOT NULL,
                                Password NVARCHAR(255) NOT NULL,
                                Salt NVARCHAR(255) NOT NULL,
                                Hash NVARCHAR(255) NOT NULL
);