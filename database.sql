CREATE SCHEMA IF NOT EXISTS flightbooking;
USE flightbooking;

CREATE TABLE IF NOT EXISTS Users (
    UserId INT AUTO_INCREMENT PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Phone VARCHAR(20)
);

CREATE TABLE IF NOT EXISTS Flights (
    FlightId INT AUTO_INCREMENT PRIMARY KEY,
    FlightNumber VARCHAR(20) NOT NULL,
    DepartureCity VARCHAR(100) NOT NULL,
    ArrivalCity VARCHAR(100) NOT NULL,
    DepartureTime DATETIME NOT NULL,
    ArrivalTime DATETIME NOT NULL,
    Price DECIMAL(10,2) NOT NULL,
    AvailableSeats INT NOT NULL
);

CREATE TABLE IF NOT EXISTS Bookings (
    BookingId INT AUTO_INCREMENT PRIMARY KEY,
    FlightId INT NOT NULL,
    UserId INT NOT NULL,
    BookingDate DATETIME NOT NULL,
    Status VARCHAR(50) NOT NULL,
    PassengerName VARCHAR(100) NOT NULL,
    FOREIGN KEY (FlightId) REFERENCES Flights(FlightId)
        ON DELETE CASCADE
        ON UPDATE CASCADE,
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);

CREATE TABLE IF NOT EXISTS Payments (
    PaymentId INT AUTO_INCREMENT PRIMARY KEY,
    BookingId INT NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,
    PaymentDate DATETIME NOT NULL,
    PaymentMethod VARCHAR(50) NOT NULL,
    Status VARCHAR(50) NOT NULL,
    FOREIGN KEY (BookingId) REFERENCES Bookings(BookingId)
        ON DELETE CASCADE
        ON UPDATE CASCADE
);


INSERT INTO Users (FullName, Email, Phone) VALUES
('Иван Иванов', 'ivan@example.com', '+79161234567'),
('Мария Петрова', 'maria@example.com', '+79162345678'),
('Алексей Сидоров', 'alexey@example.com', '+79163456789'),
('Елена Кузнецова', 'elena@example.com', '+79164567890'),
('Дмитрий Морозов', 'dmitry@example.com', '+79165678901'),
('Ольга Николаева', 'olga@example.com', '+79166789012'),
('Сергей Васильев', 'sergey@example.com', '+79167890123'),
('Анна Смирнова', 'anna@example.com', '+79168901234'),
('Павел Орлов', 'pavel@example.com', '+79169012345'),
('Татьяна Лебедева', 'tatiana@example.com', '+79160123456');

INSERT INTO Flights (FlightNumber, DepartureCity, ArrivalCity, DepartureTime, ArrivalTime, Price, AvailableSeats) VALUES
('SU123', 'Москва', 'Санкт-Петербург', '2025-06-09 08:00', '2025-06-09 09:30', 5000.00, 150),
('SU124', 'Санкт-Петербург', 'Москва', '2025-06-09 10:00', '2025-06-09 11:30', 5000.00, 150),
('SU125', 'Москва', 'Сочи', '2025-06-10 12:00', '2025-06-10 15:00', 8000.00, 120),
('SU126', 'Сочи', 'Москва', '2025-06-10 16:00', '2025-06-10 19:00', 8000.00, 120),
('SU127', 'Екатеринбург', 'Новосибирск', '2025-06-11 09:00', '2025-06-11 12:30', 6000.00, 100),
('SU128', 'Новосибирск', 'Екатеринбург', '2025-06-11 13:30', '2025-06-11 17:00', 6000.00, 100),
('SU129', 'Казань', 'Москва', '2025-06-12 07:00', '2025-06-12 09:00', 4500.00, 130),
('SU130', 'Москва', 'Казань', '2025-06-12 10:00', '2025-06-12 12:00', 4500.00, 130),
('SU131', 'Ростов', 'Краснодар', '2025-06-13 14:00', '2025-06-13 15:30', 5500.00, 110),
('SU132', 'Краснодар', 'Ростов', '2025-06-13 16:30', '2025-06-13 18:00', 5500.00, 110);

INSERT INTO Bookings (FlightId, UserId, BookingDate, Status, PassengerName) VALUES
(1, 1, '2025-06-08 17:00', 'Подтверждено', 'Иван Иванов'),
(2, 2, '2025-06-08 17:05', 'Ожидает', 'Мария Петрова'),
(3, 3, '2025-06-08 17:10', 'Подтверждено', 'Алексей Сидоров'),
(4, 4, '2025-06-08 17:15', 'Отменено', 'Елена Кузнецова'),
(5, 5, '2025-06-08 17:20', 'Подтверждено', 'Дмитрий Морозов'),
(6, 6, '2025-06-08 17:25', 'Ожидает', 'Ольга Николаева'),
(7, 7, '2025-06-08 17:30', 'Подтверждено', 'Сергей Васильев'),
(8, 8, '2025-06-08 17:35', 'Отменено', 'Анна Смирнова'),
(9, 9, '2025-06-08 17:40', 'Подтверждено', 'Павел Орлов'),
(10, 10, '2025-06-08 17:45', 'Ожидает', 'Татьяна Лебедева');

INSERT INTO Payments (BookingId, Amount, PaymentDate, PaymentMethod, Status) VALUES
(1, 5000.00, '2025-06-08 17:10', 'Кредитная карта', 'Оплачено'),
(2, 5000.00, '2025-06-08 17:15', 'Наличные', 'Ожидает'),
(3, 8000.00, '2025-06-08 17:20', 'Банковский перевод', 'Оплачено'),
(4, 8000.00, '2025-06-08 17:25', 'Кредитная карта', 'Отменено'),
(5, 6000.00, '2025-06-08 17:30', 'Наличные', 'Оплачено'),
(6, 6000.00, '2025-06-08 17:35', 'Банковский перевод', 'Ожидает'),
(7, 4500.00, '2025-06-08 17:40', 'Кредитная карта', 'Оплачено'),
(8, 4500.00, '2025-06-08 17:45', 'Наличные', 'Отменено'),
(9, 5500.00, '2025-06-08 17:50', 'Банковский перевод', 'Оплачено'),
(10, 5500.00, '2025-06-08 17:55', 'Кредитная карта', 'Ожидает');