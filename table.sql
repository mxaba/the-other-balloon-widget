CREATE TABLE Colors (
    Id text,
    Name VARCHAR(50) NOT NULL UNIQUE,
    Counter int,
    Type text,
    Timestamp TIMESTAMP without time zone NULL
);