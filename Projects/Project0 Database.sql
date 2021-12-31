--Creating DB--
CREATE DATABASE REIApp;


--Creating Tables--
CREATE TABLE Store(
StoreID INT PRIMARY KEY IDENTITY(1,1),
StoreLocation nvarchar(50) NOT NULL);

CREATE TABLE Customers(
CustomerID INT PRIMARY KEY IDENTITY(1,1),
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(10) NOT NULL,
Email nvarchar(50) NOT NULL,
LastOrderDate date NULL);

CREATE TABLE Products(
ProductID INT PRIMARY KEY IDENTITY(1,1),
ProductName nvarchar(50) NOT NULL,
Price INT NOT NULL,
ProductDescription nvarchar(500) NOT NULL,
StoreID INT NOT NULL FOREIGN KEY REFERENCES Store(StoreID) ON DELETE CASCADE);

--ALTER TABLE Products
--ALTER COLUMN StoreID INT NULL;

CREATE TABLE Orders(
OrderID INT PRIMARY KEY IDENTITY(1,1),
CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID) ON DELETE CASCADE,
StoreID INT NULL FOREIGN KEY REFERENCES Store(StoreID) ON DELETE CASCADE,
Total INT NOT NULL);

--ALTER TABLE Orders
--ALTER COLUMN StoreID INT NULL;


--Populating Tables--
--SET IDENTITY_INSERT Store ON
INSERT INTO Store(StoreLocation)
VALUES ('Austin,TX');
INSERT INTO Store(StoreLocation)
VALUES ('Salt Lake City,UT');
INSERT INTO Store(StoreLocation)
VALUES ('Sandy,UT');

SET IDENTITY_INSERT Customers ON
INSERT INTO Customers(CustomerID, FirstName, LastName, Email)
VALUES (1, 'Jake', 'Burton', 'jburton@gmail.com');
INSERT INTO Customers(CustomerID, FirstName, LastName, Email)
VALUES (2, 'Chloe', 'Kim', 'chloekim123@yahoo.com');
INSERT INTO Customers(CustomerID, FirstName, LastName, Email)
VALUES (3, 'Rubi', 'Vera', 'rubi.vera@revature.net');

--SET IDENTITY_INSERT Products ON
--SET ANSI_WARNINGS OFF;
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Rossignol Gala Snowboard', 280, 'Womens Board Size:154cm Core:Wood 5620 Personality: Happy Medium Terrain: all-mountain Flex: Directional Bend: 40% rocker and 20% camber in the middle');
--SET ANSI_WARNINGS ON;
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Anon M4 Googles + extra lens - M/L', 235, 'UNISEX | MAGNA-TECH | Fits medium to large faces | Wide view and low profile style of cylindrical snow goggles.');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Anon M4 Googles + extra lens - S/M', 235, 'UNISEX | MAGNA-TECH | Fits small to medium faces | Wide view and low profile style of cylindrical snow goggles.');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Anon M4 Googles + MFI Face Mask + extra lens', 320, 'UNISEX | MAGNA-TECH | Fits medium to large faces | Includes goggles, 2 lens, and MFI face mask, all with MAGNA-TECH');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Anon Logan WaveCel Helmet - S', 240, 'Color: Black | Size: S | Weight: 424g | Designed for a closer fit. Passive ventilation channels. Fidlock® snap helmet buckle uses magnets. Compatible with audio accessories.');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Anon Logan WaveCel Helmet - M', 240, 'Color: Black | Size: M | Weight: 424g | Designed for a closer fit. Passive ventilation channels. Fidlock® snap helmet buckle uses magnets. Compatible with audio accessories.');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Anon Logan WaveCel Helmet - L', 240, 'Color: Black | Size: L | Weight: 424g | Designed for a closer fit. Passive ventilation channels. Fidlock® snap helmet buckle uses magnets. Compatible with audio accessories.');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Mens Burton Custom X Camber Snowboard', 800, 'Mens Board | Size:162cm | Core:Dragonfly 600G | Personality: Slightly more stiff and aggressive | Terrain: all-mountain | Flex: Twin | Bend: All Camber');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Womens Solomon Freeride Snowboard', 450, 'Womens Board | Size:145cm | Core:Popster | Personality: Stiff and aggressive | Terrain: all-mountain/Powder | Flex: Medium| Bend: All Camber');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Montec Doom Women', 260, 'Burgandy - Small | Waterproofing: 20.000mm | Breathability: 20.000g | Medium-weight all mountain insulation for perfect balance between warmth and performance (60gsm body, 40gsm sleeves and hood)');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Montec Doom Women', 260, 'Burgandy - Medium | Waterproofing: 20.000mm | Breathability: 20.000g | Medium-weight all mountain insulation for perfect balance between warmth and performance (60gsm body, 40gsm sleeves and hood)');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Montec Doom Women', 260, 'Burgandy - Large | Waterproofing: 20.000mm | Breathability: 20.000g | Medium-weight all mountain insulation for perfect balance between warmth and performance (60gsm body, 40gsm sleeves and hood)');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Montec Dune Men', 220, 'Light Grey - Small | Waterproofing: 20.000mm | Breathability: 20.000g | Medium-weight all mountain insulation for perfect balance between warmth and performance (60gsm body, 40gsm sleeves and hood)');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Montec Dune Men', 220, 'Light Grey - Medium | Waterproofing: 20.000mm | Breathability: 20.000g | Medium-weight all mountain insulation for perfect balance between warmth and performance (60gsm body, 40gsm sleeves and hood)');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Montec Dune Men', 220, 'Light Grey - Large | Waterproofing: 20.000mm | Breathability: 20.000g | Medium-weight all mountain insulation for perfect balance between warmth and performance (60gsm body, 40gsm sleeves and hood)');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('DAKINE Tour Snowboard Bag', 95, '157 cm | Color: Red Earh | Material: 600-denier polyester | Weight: 3lbs | Wheeled: Yes | Holds 1 board, 1 pair of boots and outerwear');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('DAKINE Tour Snowboard Bag', 95, '165 cm | Color: Red Earh | Material: 600-denier polyester | Weight: 3lbs | Wheeled: Yes | Holds 1 board, 1 pair of boots and outerwear');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('CamelBak Zoid Hydration Pack', 70, 'Color: Red | Material: 81% polyester/19% nylon | Weight: 10oz | Gear Capacity: 1L | Liquid Capacity: 2 L | Snowshed back panel repels snow | Therminator™ harness routes the insulated drinking tube through an insulated sleeve in the shoulder strap');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('Burton Day Hiker 28L Snow Pack', 100, 'Color: Barren Camo Print | Material: Ripstop polyester with a polyurethane backing | Weight: 1lb 9oz | Gear Capacity: 28L |Dimensions: 19.5 x 12 x 5.5 inches | Top Loading | Pockets: 5 + main compartment | Hipbelt');
INSERT INTO Products(ProductName, Price, ProductDescription)
VALUES ('DAKINE Titan GORE-TEX Gloves - Mens', 70, 'Size: Small | Color: Black | Material: GORE-TEX waterproof/breathable fabric + GORE Warm technology (38% nylon/62% ePTFE) | Removable Liner: Yes | Touch-Screen Compatible: Yes | Nose wipe thumb panels | One-hand cinch gauntlet cuffs');
