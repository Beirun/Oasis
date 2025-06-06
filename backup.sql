PRAGMA foreign_keys=OFF;
BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "__EFMigrationsLock" (

    "Id" INTEGER NOT NULL CONSTRAINT "PK___EFMigrationsLock" PRIMARY KEY,

    "Timestamp" TEXT NOT NULL

);
CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (

    "MigrationId" TEXT NOT NULL CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY,

    "ProductVersion" TEXT NOT NULL

);
INSERT INTO __EFMigrationsHistory VALUES('20250504072948_Migrate','9.0.2');
CREATE TABLE IF NOT EXISTS "AmenityItem" (

    "item_id" INTEGER NOT NULL CONSTRAINT "PK_AmenityItem" PRIMARY KEY AUTOINCREMENT,

    "amenity_name" TEXT NULL,

    "amenity_price" REAL NULL

);
INSERT INTO AmenityItem VALUES(1,'Air Conditioning (AC)',375.0);
INSERT INTO AmenityItem VALUES(2,'Mini Fridge',188.0);
INSERT INTO AmenityItem VALUES(3,'Electric Kettle',113.0);
INSERT INTO AmenityItem VALUES(4,'Iron & Ironing Board',113.0);
INSERT INTO AmenityItem VALUES(5,'Desk Fan',75.0);
INSERT INTO AmenityItem VALUES(6,'Universal Adapter',75.0);
INSERT INTO AmenityItem VALUES(7,'Smart TV Upgrade',375.0);
INSERT INTO AmenityItem VALUES(8,'Hair Dryer',188.0);
INSERT INTO AmenityItem VALUES(9,'Portable Heater',450.0);
INSERT INTO AmenityItem VALUES(10,'Microwave',525.0);
INSERT INTO AmenityItem VALUES(11,'Coffee Maker',450.0);
CREATE TABLE IF NOT EXISTS "RoomType" (

    "type_id" INTEGER NOT NULL CONSTRAINT "PK_RoomType" PRIMARY KEY AUTOINCREMENT,

    "type_category" TEXT NULL,

    "type_price" REAL NULL

);
INSERT INTO RoomType VALUES(1,'Standard',2500.0);
INSERT INTO RoomType VALUES(2,'Deluxe',5000.0);
INSERT INTO RoomType VALUES(3,'Suite',7500.0);
CREATE TABLE IF NOT EXISTS "ServiceType" (

    "type_id" INTEGER NOT NULL CONSTRAINT "PK_ServiceType" PRIMARY KEY,

    "type_name" TEXT NULL,

    "type_price" REAL NULL

);
CREATE TABLE IF NOT EXISTS "User" (

    "user_id" INTEGER NOT NULL CONSTRAINT "PK_User" PRIMARY KEY AUTOINCREMENT,

    "user_fname" TEXT NULL,

    "user_lname" TEXT NULL,

    "user_gender" TEXT NULL,

    "user_dob" TEXT NULL,

    "user_email" TEXT NULL,

    "user_contactno" TEXT NULL,

    "user_password" TEXT NULL,

    "user_type" TEXT NULL

);
INSERT INTO User VALUES(1,'Christina','Diamante','Female','2003-11-05','christinadiamante113@gmail.com','09329413158','123','Guest');
INSERT INTO User VALUES(2,'Bernard Jay','Orillo','Male','2004-04-14','orillobernardjay@gmail.com','09086350171','123','Staff');
INSERT INTO User VALUES(3,'Kenneth James','Batuhan','Male','2003-08-15','batuhankennethjames@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(4,'Johnny','Dildoe','Male','2004-01-10','dildoe@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(5,'Phil','McCraken','Male','2004-02-14','phil@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(6,'Moe','Lester','Male','2004-06-09','moelester@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(7,'Julia','Smitler','Female','2002-10-01','juliasmith@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(8,'Deon Niel','Jaca','Female','2002-10-01','deonniel@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(9,'Pussy','Cat','Male','2004-06-17','pussycat@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(10,'Ed Jaymar','Pilapil','Male','2004-05-14','edpilapil@gmail.com','09876543210','123','Staff');
INSERT INTO User VALUES(11,'Eric John','Lobo','Female','2025-03-05','eric@gmail.com','09123456789','1234','Staff');
INSERT INTO User VALUES(12,'Matt','Cabrillos','Male','2022-07-20','matt@gmail.com','09123456789','123','Staff');
INSERT INTO User VALUES(13,'Jean','Diamante','Female','1980-06-19','jeandiamante@gmail.com','09123456789','1234','Staff');
INSERT INTO User VALUES(14,'Harry','Dyck','Male','1999-05-13','harrydyck@gmail.com','09876543210','123','Staff');
INSERT INTO User VALUES(15,'Ben','Dover','Male','2025-03-10','bendover@gmail.com','09876543210','12345','Staff');
INSERT INTO User VALUES(16,'Hugh','Janice','Female','2025-03-05','hughjanice@gmail.com','09876543210','1234','Staff');
INSERT INTO User VALUES(17,'McLovin','Mohammed','Male','2025-03-05','mclovin@gmail.com','09123456789','123','Guest');
INSERT INTO User VALUES(18,'Leo','Bermudez',NULL,NULL,NULL,NULL,NULL,'Guest');
INSERT INTO User VALUES(19,'Martino','Tabares',NULL,NULL,NULL,NULL,NULL,'Guest');
INSERT INTO User VALUES(20,'Mark Jason','Tabares',NULL,NULL,NULL,NULL,NULL,'Guest');
CREATE TABLE IF NOT EXISTS "Amenity" (

    "amenity_id" INTEGER NOT NULL CONSTRAINT "PK_Amenity" PRIMARY KEY AUTOINCREMENT,

    "type_id" INTEGER NOT NULL,

    "item_id" INTEGER NOT NULL,

    CONSTRAINT "FK_Amenity_AmenityItem_item_id" FOREIGN KEY ("item_id") REFERENCES "AmenityItem" ("item_id") ON DELETE CASCADE,

    CONSTRAINT "FK_Amenity_RoomType_type_id" FOREIGN KEY ("type_id") REFERENCES "RoomType" ("type_id") ON DELETE CASCADE

);
INSERT INTO Amenity VALUES(1,1,1);
INSERT INTO Amenity VALUES(2,1,2);
INSERT INTO Amenity VALUES(3,1,3);
INSERT INTO Amenity VALUES(4,1,4);
INSERT INTO Amenity VALUES(5,1,5);
INSERT INTO Amenity VALUES(6,1,6);
INSERT INTO Amenity VALUES(7,1,7);
INSERT INTO Amenity VALUES(8,2,1);
INSERT INTO Amenity VALUES(9,2,2);
INSERT INTO Amenity VALUES(10,2,3);
INSERT INTO Amenity VALUES(11,2,8);
INSERT INTO Amenity VALUES(12,2,4);
INSERT INTO Amenity VALUES(13,2,5);
INSERT INTO Amenity VALUES(14,2,9);
INSERT INTO Amenity VALUES(15,2,6);
INSERT INTO Amenity VALUES(16,2,7);
INSERT INTO Amenity VALUES(17,3,1);
INSERT INTO Amenity VALUES(18,3,10);
INSERT INTO Amenity VALUES(19,3,2);
INSERT INTO Amenity VALUES(20,3,11);
INSERT INTO Amenity VALUES(21,3,3);
INSERT INTO Amenity VALUES(22,3,8);
INSERT INTO Amenity VALUES(23,3,4);
INSERT INTO Amenity VALUES(24,3,5);
INSERT INTO Amenity VALUES(25,3,9);
INSERT INTO Amenity VALUES(26,3,6);
INSERT INTO Amenity VALUES(27,3,7);
CREATE TABLE IF NOT EXISTS "Room" (

    "room_id" INTEGER NOT NULL CONSTRAINT "PK_Room" PRIMARY KEY AUTOINCREMENT,

    "room_no" INTEGER NULL,

    "type_id" INTEGER NULL,

    "room_status" TEXT NULL,

    CONSTRAINT "FK_Room_RoomType_type_id" FOREIGN KEY ("type_id") REFERENCES "RoomType" ("type_id")

);
INSERT INTO Room VALUES(1,101,1,'Available');
INSERT INTO Room VALUES(2,102,1,'Available');
INSERT INTO Room VALUES(3,103,1,'Available');
INSERT INTO Room VALUES(4,104,1,'Available');
INSERT INTO Room VALUES(5,105,1,'Available');
INSERT INTO Room VALUES(6,106,1,'Available');
INSERT INTO Room VALUES(7,107,1,'Available');
INSERT INTO Room VALUES(8,108,2,'Available');
INSERT INTO Room VALUES(9,109,2,'Available');
INSERT INTO Room VALUES(10,110,2,'Available');
INSERT INTO Room VALUES(11,111,2,'Available');
INSERT INTO Room VALUES(12,112,2,'Available');
INSERT INTO Room VALUES(13,113,3,'Available');
INSERT INTO Room VALUES(14,114,3,'Available');
INSERT INTO Room VALUES(15,115,3,'Available');
INSERT INTO Room VALUES(16,201,1,'Available');
INSERT INTO Room VALUES(17,202,1,'Available');
INSERT INTO Room VALUES(18,203,1,'Available');
INSERT INTO Room VALUES(19,204,1,'Reserved');
INSERT INTO Room VALUES(20,205,1,'Available');
INSERT INTO Room VALUES(21,206,1,'Available');
INSERT INTO Room VALUES(22,207,1,'Available');
INSERT INTO Room VALUES(23,208,2,'Available');
INSERT INTO Room VALUES(24,209,2,'Available');
INSERT INTO Room VALUES(25,210,2,'Available');
INSERT INTO Room VALUES(26,211,2,'Available');
INSERT INTO Room VALUES(27,212,2,'Available');
INSERT INTO Room VALUES(28,213,3,'Available');
INSERT INTO Room VALUES(29,214,3,'Reserved');
INSERT INTO Room VALUES(30,215,3,'Available');
INSERT INTO Room VALUES(31,301,1,'Available');
INSERT INTO Room VALUES(32,302,1,'Available');
INSERT INTO Room VALUES(33,303,1,'Available');
INSERT INTO Room VALUES(34,304,1,'Available');
INSERT INTO Room VALUES(35,305,1,'Available');
INSERT INTO Room VALUES(36,306,1,'Available');
INSERT INTO Room VALUES(37,307,1,'Available');
INSERT INTO Room VALUES(38,308,2,'Available');
INSERT INTO Room VALUES(39,309,2,'Available');
INSERT INTO Room VALUES(40,310,2,'Available');
INSERT INTO Room VALUES(41,311,2,'Available');
INSERT INTO Room VALUES(42,312,2,'Available');
INSERT INTO Room VALUES(43,313,3,'Available');
INSERT INTO Room VALUES(44,314,3,'Available');
INSERT INTO Room VALUES(45,315,3,'Available');
INSERT INTO Room VALUES(46,401,1,'Available');
INSERT INTO Room VALUES(47,402,1,'Available');
INSERT INTO Room VALUES(48,403,1,'Available');
INSERT INTO Room VALUES(49,404,1,'Available');
INSERT INTO Room VALUES(50,405,1,'Available');
INSERT INTO Room VALUES(51,406,1,'Available');
INSERT INTO Room VALUES(52,407,1,'Available');
INSERT INTO Room VALUES(53,408,2,'Available');
INSERT INTO Room VALUES(54,409,2,'Available');
INSERT INTO Room VALUES(55,410,2,'Available');
INSERT INTO Room VALUES(56,411,2,'Available');
INSERT INTO Room VALUES(57,412,2,'Available');
INSERT INTO Room VALUES(58,413,3,'Available');
INSERT INTO Room VALUES(59,414,3,'Available');
INSERT INTO Room VALUES(60,415,3,'Available');
INSERT INTO Room VALUES(61,501,1,'Available');
INSERT INTO Room VALUES(62,502,1,'Available');
INSERT INTO Room VALUES(63,503,1,'Available');
INSERT INTO Room VALUES(64,504,1,'Available');
INSERT INTO Room VALUES(65,505,1,'Available');
INSERT INTO Room VALUES(66,506,1,'Available');
INSERT INTO Room VALUES(67,507,1,'Available');
INSERT INTO Room VALUES(68,508,2,'Available');
INSERT INTO Room VALUES(69,509,2,'Available');
INSERT INTO Room VALUES(70,510,2,'Available');
INSERT INTO Room VALUES(71,511,2,'Unavailable');
INSERT INTO Room VALUES(72,512,2,'Available');
INSERT INTO Room VALUES(73,513,3,'Available');
INSERT INTO Room VALUES(74,514,3,'Available');
INSERT INTO Room VALUES(75,515,3,'Available');
INSERT INTO Room VALUES(76,601,1,'Available');
INSERT INTO Room VALUES(77,602,1,'Available');
INSERT INTO Room VALUES(78,603,1,'Available');
INSERT INTO Room VALUES(79,604,1,'Available');
INSERT INTO Room VALUES(80,605,1,'Available');
INSERT INTO Room VALUES(81,606,1,'Available');
INSERT INTO Room VALUES(82,607,1,'Available');
INSERT INTO Room VALUES(83,608,2,'Available');
INSERT INTO Room VALUES(84,609,2,'Unavailable');
INSERT INTO Room VALUES(85,610,2,'Available');
INSERT INTO Room VALUES(86,611,2,'Available');
INSERT INTO Room VALUES(87,612,2,'Available');
INSERT INTO Room VALUES(88,613,3,'Available');
INSERT INTO Room VALUES(89,614,3,'Available');
INSERT INTO Room VALUES(90,615,3,'Available');
INSERT INTO Room VALUES(91,701,1,'Available');
INSERT INTO Room VALUES(92,702,1,'Available');
INSERT INTO Room VALUES(93,703,1,'Available');
INSERT INTO Room VALUES(94,704,1,'Available');
INSERT INTO Room VALUES(95,705,1,'Available');
INSERT INTO Room VALUES(96,706,1,'Reserved');
INSERT INTO Room VALUES(97,707,1,'Available');
INSERT INTO Room VALUES(98,708,2,'Available');
INSERT INTO Room VALUES(99,709,2,'Reserved');
INSERT INTO Room VALUES(100,710,2,'Available');
INSERT INTO Room VALUES(101,711,2,'Available');
INSERT INTO Room VALUES(102,712,2,'Available');
INSERT INTO Room VALUES(103,713,3,'Available');
INSERT INTO Room VALUES(104,714,3,'Available');
INSERT INTO Room VALUES(105,715,3,'Unavailable');
INSERT INTO Room VALUES(106,801,1,'Available');
INSERT INTO Room VALUES(107,802,1,'Available');
INSERT INTO Room VALUES(108,803,1,'Available');
INSERT INTO Room VALUES(109,804,1,'Available');
INSERT INTO Room VALUES(110,805,1,'Available');
INSERT INTO Room VALUES(111,806,1,'Available');
INSERT INTO Room VALUES(112,807,1,'Available');
INSERT INTO Room VALUES(113,808,2,'Available');
INSERT INTO Room VALUES(114,809,2,'Available');
INSERT INTO Room VALUES(115,810,2,'Available');
INSERT INTO Room VALUES(116,811,2,'Available');
INSERT INTO Room VALUES(117,812,2,'Available');
INSERT INTO Room VALUES(118,813,3,'Available');
INSERT INTO Room VALUES(119,814,3,'Available');
INSERT INTO Room VALUES(120,815,3,'Available');
INSERT INTO Room VALUES(121,901,1,'Available');
INSERT INTO Room VALUES(122,902,1,'Available');
INSERT INTO Room VALUES(123,903,1,'Available');
INSERT INTO Room VALUES(124,904,1,'Available');
INSERT INTO Room VALUES(125,905,1,'Available');
INSERT INTO Room VALUES(126,906,1,'Available');
INSERT INTO Room VALUES(127,907,1,'Available');
INSERT INTO Room VALUES(128,908,2,'Available');
INSERT INTO Room VALUES(129,909,2,'Available');
INSERT INTO Room VALUES(130,910,2,'Available');
INSERT INTO Room VALUES(131,911,2,'Available');
INSERT INTO Room VALUES(132,912,2,'Available');
INSERT INTO Room VALUES(133,913,3,'Available');
INSERT INTO Room VALUES(134,914,3,'Available');
INSERT INTO Room VALUES(135,915,3,'Available');
INSERT INTO Room VALUES(136,1001,1,'Available');
INSERT INTO Room VALUES(137,1002,1,'Available');
INSERT INTO Room VALUES(138,1003,1,'Available');
INSERT INTO Room VALUES(139,1004,1,'Available');
INSERT INTO Room VALUES(140,1005,1,'Available');
INSERT INTO Room VALUES(141,1006,1,'Available');
INSERT INTO Room VALUES(142,1007,1,'Available');
INSERT INTO Room VALUES(143,1008,2,'Available');
INSERT INTO Room VALUES(144,1009,2,'Available');
INSERT INTO Room VALUES(145,1010,2,'Available');
INSERT INTO Room VALUES(146,1011,2,'Available');
INSERT INTO Room VALUES(147,1012,2,'Available');
INSERT INTO Room VALUES(148,1013,3,'Available');
INSERT INTO Room VALUES(149,1014,3,'Available');
INSERT INTO Room VALUES(150,1015,3,'Available');
INSERT INTO Room VALUES(151,1101,1,'Available');
INSERT INTO Room VALUES(152,1102,1,'Available');
INSERT INTO Room VALUES(153,1103,1,'Available');
INSERT INTO Room VALUES(154,1104,1,'Available');
INSERT INTO Room VALUES(155,1105,1,'Available');
INSERT INTO Room VALUES(156,1106,1,'Available');
INSERT INTO Room VALUES(157,1107,1,'Available');
INSERT INTO Room VALUES(158,1108,2,'Available');
INSERT INTO Room VALUES(159,1109,2,'Available');
INSERT INTO Room VALUES(160,1110,2,'Available');
INSERT INTO Room VALUES(161,1111,2,'Available');
INSERT INTO Room VALUES(162,1112,2,'Available');
INSERT INTO Room VALUES(163,1113,3,'Available');
INSERT INTO Room VALUES(164,1114,3,'Available');
INSERT INTO Room VALUES(165,1115,3,'Available');
INSERT INTO Room VALUES(166,1201,1,'Available');
INSERT INTO Room VALUES(167,1202,1,'Available');
INSERT INTO Room VALUES(168,1203,1,'Available');
INSERT INTO Room VALUES(169,1204,1,'Available');
INSERT INTO Room VALUES(170,1205,1,'Available');
INSERT INTO Room VALUES(171,1206,1,'Available');
INSERT INTO Room VALUES(172,1207,1,'Available');
INSERT INTO Room VALUES(173,1208,2,'Available');
INSERT INTO Room VALUES(174,1209,2,'Available');
INSERT INTO Room VALUES(175,1210,2,'Available');
INSERT INTO Room VALUES(176,1211,2,'Reserved');
INSERT INTO Room VALUES(177,1212,2,'Available');
INSERT INTO Room VALUES(178,1213,3,'Available');
INSERT INTO Room VALUES(179,1214,3,'Available');
INSERT INTO Room VALUES(180,1215,3,'Available');
INSERT INTO Room VALUES(181,1301,1,'Available');
INSERT INTO Room VALUES(182,1302,1,'Available');
INSERT INTO Room VALUES(183,1303,1,'Available');
INSERT INTO Room VALUES(184,1304,1,'Available');
INSERT INTO Room VALUES(185,1305,1,'Available');
INSERT INTO Room VALUES(186,1306,1,'Available');
INSERT INTO Room VALUES(187,1307,1,'Available');
INSERT INTO Room VALUES(188,1308,2,'Available');
INSERT INTO Room VALUES(189,1309,2,'Available');
INSERT INTO Room VALUES(190,1310,2,'Available');
INSERT INTO Room VALUES(191,1311,2,'Available');
INSERT INTO Room VALUES(192,1312,2,'Available');
INSERT INTO Room VALUES(193,1313,3,'Available');
INSERT INTO Room VALUES(194,1314,3,'Available');
INSERT INTO Room VALUES(195,1315,3,'Available');
INSERT INTO Room VALUES(196,1401,1,'Available');
INSERT INTO Room VALUES(197,1402,1,'Available');
INSERT INTO Room VALUES(198,1403,1,'Available');
INSERT INTO Room VALUES(199,1404,1,'Available');
INSERT INTO Room VALUES(200,1405,1,'Available');
INSERT INTO Room VALUES(201,1406,1,'Available');
INSERT INTO Room VALUES(202,1407,1,'Available');
INSERT INTO Room VALUES(203,1408,2,'Unavailable');
INSERT INTO Room VALUES(204,1409,2,'Available');
INSERT INTO Room VALUES(205,1410,2,'Available');
INSERT INTO Room VALUES(206,1411,2,'Available');
INSERT INTO Room VALUES(207,1412,2,'Reserved');
INSERT INTO Room VALUES(208,1413,3,'Available');
INSERT INTO Room VALUES(209,1414,3,'Available');
INSERT INTO Room VALUES(210,1415,3,'Available');
INSERT INTO Room VALUES(211,1501,1,'Available');
INSERT INTO Room VALUES(212,1502,1,'Available');
INSERT INTO Room VALUES(213,1503,1,'Available');
INSERT INTO Room VALUES(214,1504,1,'Available');
INSERT INTO Room VALUES(215,1505,1,'Available');
INSERT INTO Room VALUES(216,1506,1,'Available');
INSERT INTO Room VALUES(217,1507,1,'Available');
INSERT INTO Room VALUES(218,1508,2,'Available');
INSERT INTO Room VALUES(219,1509,2,'Available');
INSERT INTO Room VALUES(220,1510,2,'Available');
INSERT INTO Room VALUES(221,1511,2,'Available');
INSERT INTO Room VALUES(222,1512,2,'Available');
INSERT INTO Room VALUES(223,1513,3,'Reserved');
INSERT INTO Room VALUES(224,1514,3,'Available');
INSERT INTO Room VALUES(225,1515,3,'Available');
CREATE TABLE IF NOT EXISTS "Guest" (

    "guest_id" INTEGER NOT NULL CONSTRAINT "PK_Guest" PRIMARY KEY,

    "registration_date" TEXT NULL,

    CONSTRAINT "FK_Guest_User_guest_id" FOREIGN KEY ("guest_id") REFERENCES "User" ("user_id")

);
INSERT INTO Guest VALUES(1,'2025-03-10 10:42:10.4063201');
INSERT INTO Guest VALUES(17,'2025-03-12 10:13:39.7632189');
INSERT INTO Guest VALUES(18,'2025-05-04 16:25:38.1946109');
INSERT INTO Guest VALUES(19,'2025-05-04 16:27:12.8186236');
INSERT INTO Guest VALUES(20,'2025-05-04 16:33:22.1791204');
CREATE TABLE IF NOT EXISTS "Notification" (

    "notif_id" INTEGER NOT NULL CONSTRAINT "PK_Notification" PRIMARY KEY AUTOINCREMENT,

    "notif_title" TEXT NULL,

    "notif_date" TEXT NULL,

    "notif_content" TEXT NULL,

    "notif_status" TEXT NULL,

    "user_id" INTEGER NULL,

    CONSTRAINT "FK_Notification_User_user_id" FOREIGN KEY ("user_id") REFERENCES "User" ("user_id")

);
CREATE TABLE IF NOT EXISTS "Staff" (

    "staff_id" INTEGER NOT NULL CONSTRAINT "PK_Staff" PRIMARY KEY,

    "position" TEXT NULL,

    "employment_date" TEXT NULL,

    CONSTRAINT "FK_Staff_User_staff_id" FOREIGN KEY ("staff_id") REFERENCES "User" ("user_id")

);
INSERT INTO Staff VALUES(2,'Admin','2025-03-10 09:50:42');
INSERT INTO Staff VALUES(3,'HouseKeeper','2025-03-10 09:53:09');
INSERT INTO Staff VALUES(4,'Receptionist','2025-03-10 10:36:30');
INSERT INTO Staff VALUES(5,'HouseKeeper','2025-03-10 10:39:04');
INSERT INTO Staff VALUES(6,'Receptionist','2025-03-10 10:40:41');
INSERT INTO Staff VALUES(7,'HouseKeeper','2025-03-10 10:44:06');
INSERT INTO Staff VALUES(8,'Receptionist','2025-03-10 10:45:18');
INSERT INTO Staff VALUES(9,'Receptionist','2025-03-11 13:42:07.7007007');
INSERT INTO Staff VALUES(10,'HouseKeeper','2025-03-11 13:44:01.730148');
INSERT INTO Staff VALUES(11,'Receptionist','2025-03-11 13:47:24.1830362');
INSERT INTO Staff VALUES(12,'HouseKeeper','2025-03-11 13:53:18.938994');
INSERT INTO Staff VALUES(13,'Receptionist','2025-03-11 17:45:53.7095699');
INSERT INTO Staff VALUES(14,'Receptionist','2025-03-11 17:48:18.9620664');
INSERT INTO Staff VALUES(15,'HouseKeeper','2025-03-11 17:51:06.2182428');
INSERT INTO Staff VALUES(16,'HouseKeeper','2025-03-11 18:07:51.7176769');
CREATE TABLE IF NOT EXISTS "Review" (

    "review_id" INTEGER NOT NULL CONSTRAINT "PK_Review" PRIMARY KEY AUTOINCREMENT,

    "room_id" INTEGER NULL,

    "guest_id" INTEGER NULL,

    "review_date" TEXT NULL,

    "review_rating" INTEGER NULL,

    "review_feedback" TEXT NULL,

    CONSTRAINT "FK_Review_Guest_guest_id" FOREIGN KEY ("guest_id") REFERENCES "Guest" ("guest_id"),

    CONSTRAINT "FK_Review_Room_room_id" FOREIGN KEY ("room_id") REFERENCES "Room" ("room_id")

);
CREATE TABLE IF NOT EXISTS "HouseKeeping" (

    "house_keeping_id" INTEGER NOT NULL CONSTRAINT "PK_HouseKeeping" PRIMARY KEY AUTOINCREMENT,

    "room_id" INTEGER NULL,

    "staff_id" INTEGER NULL,

    "house_keeping_starttime" TEXT NULL,

    "house_keeping_endtime" TEXT NULL,

    CONSTRAINT "FK_HouseKeeping_Room_room_id" FOREIGN KEY ("room_id") REFERENCES "Room" ("room_id"),

    CONSTRAINT "FK_HouseKeeping_Staff_staff_id" FOREIGN KEY ("staff_id") REFERENCES "Staff" ("staff_id")

);
INSERT INTO HouseKeeping VALUES(1,88,5,'2025-05-05 17:36:35.9453373','2025-05-05 17:57:10.2465835');
CREATE TABLE IF NOT EXISTS "Payment" (

    "payment_id" INTEGER NOT NULL CONSTRAINT "PK_Payment" PRIMARY KEY AUTOINCREMENT,

    "payment_amount" REAL NULL,

    "payment_date" TEXT NULL,

    "staff_id" INTEGER NULL,

    CONSTRAINT "FK_Payment_Staff_staff_id" FOREIGN KEY ("staff_id") REFERENCES "Staff" ("staff_id")

);
INSERT INTO Payment VALUES(1,21952.0,'2025-05-04 15:31:48.5347878',4);
INSERT INTO Payment VALUES(2,51952.0,'2025-05-04 15:35:55.4344715',4);
INSERT INTO Payment VALUES(3,36952.0,'2025-05-04 16:13:44.9814565',4);
INSERT INTO Payment VALUES(4,7500.0,'2025-05-04 16:17:57.7441341',NULL);
INSERT INTO Payment VALUES(5,24452.0,'2025-05-04 16:19:34.4897718',4);
INSERT INTO Payment VALUES(6,16952.0,'2025-05-04 16:25:38.2756226',4);
INSERT INTO Payment VALUES(7,56952.0,'2025-05-04 16:27:12.8422374',4);
INSERT INTO Payment VALUES(8,16952.0,'2025-05-04 16:33:22.2002747',4);
INSERT INTO Payment VALUES(9,25427.0,'2025-05-04 17:02:43.6584743',NULL);
INSERT INTO Payment VALUES(10,17927.0,'2025-05-04 17:53:48.326448',4);
INSERT INTO Payment VALUES(11,21952.0,'2025-05-05 00:25:31.8846428',NULL);
INSERT INTO Payment VALUES(12,18814.0,'2025-05-05 07:37:39.0615138',NULL);
INSERT INTO Payment VALUES(13,16952.0,'2025-05-05 07:43:01.2010772',NULL);
INSERT INTO Payment VALUES(14,32927.0,'2025-05-05 08:00:28.7872791',NULL);
INSERT INTO Payment VALUES(15,56952.0,'2025-05-05 08:12:05.6069324',NULL);
INSERT INTO Payment VALUES(16,8814.0,'2025-05-05 08:13:35.5960562',NULL);
INSERT INTO Payment VALUES(17,17927.0,'2025-05-05 08:17:49.6169008',NULL);
CREATE TABLE IF NOT EXISTS "Reservation" (

    "rsv_id" INTEGER NOT NULL CONSTRAINT "PK_Reservation" PRIMARY KEY AUTOINCREMENT,

    "room_id" INTEGER NULL,

    "guest_id" INTEGER NULL,

    "rsv_checkin" TEXT NULL,

    "rsv_checkout" TEXT NULL,

    "payment_id" INTEGER NULL,

    "rsv_status" TEXT NULL,

    CONSTRAINT "FK_Reservation_Guest_guest_id" FOREIGN KEY ("guest_id") REFERENCES "Guest" ("guest_id"),

    CONSTRAINT "FK_Reservation_Payment_rsv_id" FOREIGN KEY ("rsv_id") REFERENCES "Payment" ("payment_id"),

    CONSTRAINT "FK_Reservation_Room_room_id" FOREIGN KEY ("room_id") REFERENCES "Room" ("room_id")

);
INSERT INTO Reservation VALUES(1,185,17,'2025-05-04','2025-05-07',4,'Cancelled');
INSERT INTO Reservation VALUES(2,203,18,'2025-05-04','2025-05-12',6,'Checked In');
INSERT INTO Reservation VALUES(3,84,19,'2025-05-06','2025-05-20',7,'Checked In');
INSERT INTO Reservation VALUES(4,71,20,'2025-05-04','2025-05-07',8,'Checked In');
INSERT INTO Reservation VALUES(5,105,17,'2025-05-04','2025-05-08',9,'Checked In');
INSERT INTO Reservation VALUES(6,88,19,'2025-05-07','2025-05-09',10,'Checked Out');
INSERT INTO Reservation VALUES(7,176,17,'2025-05-05','2025-05-09',11,'Booked');
INSERT INTO Reservation VALUES(8,19,17,'2025-05-07','2025-05-14',12,'Booked');
INSERT INTO Reservation VALUES(9,207,17,'2025-05-05','2025-05-08',13,'Booked');
INSERT INTO Reservation VALUES(10,29,17,'2025-05-05','2025-05-09',14,'Booked');
INSERT INTO Reservation VALUES(11,99,17,'2025-05-05','2025-05-16',15,'Booked');
INSERT INTO Reservation VALUES(12,96,17,'2025-05-05','2025-05-08',16,'Booked');
INSERT INTO Reservation VALUES(13,223,17,'2025-05-07','2025-05-09',17,'Booked');
CREATE TABLE IF NOT EXISTS "Service" (

    "service_id" INTEGER NOT NULL CONSTRAINT "PK_Service" PRIMARY KEY AUTOINCREMENT,

    "type_id" INTEGER NULL,

    "service_date" TEXT NULL,

    "rsv_id" INTEGER NULL,

    "staff_id" INTEGER NULL,

    CONSTRAINT "FK_Service_Reservation_rsv_id" FOREIGN KEY ("rsv_id") REFERENCES "Reservation" ("rsv_id"),

    CONSTRAINT "FK_Service_ServiceType_type_id" FOREIGN KEY ("type_id") REFERENCES "ServiceType" ("type_id"),

    CONSTRAINT "FK_Service_Staff_staff_id" FOREIGN KEY ("staff_id") REFERENCES "Staff" ("staff_id")

);
DELETE FROM sqlite_sequence;
INSERT INTO sqlite_sequence VALUES('AmenityItem',11);
INSERT INTO sqlite_sequence VALUES('RoomType',3);
INSERT INTO sqlite_sequence VALUES('Amenity',27);
INSERT INTO sqlite_sequence VALUES('Room',225);
INSERT INTO sqlite_sequence VALUES('User',20);
INSERT INTO sqlite_sequence VALUES('Payment',17);
INSERT INTO sqlite_sequence VALUES('Reservation',13);
INSERT INTO sqlite_sequence VALUES('HouseKeeping',1);
CREATE INDEX "IX_Amenity_item_id" ON "Amenity" ("item_id");
CREATE INDEX "IX_Amenity_type_id" ON "Amenity" ("type_id");
CREATE INDEX "IX_HouseKeeping_room_id" ON "HouseKeeping" ("room_id");
CREATE INDEX "IX_HouseKeeping_staff_id" ON "HouseKeeping" ("staff_id");
CREATE INDEX "IX_Notification_user_id" ON "Notification" ("user_id");
CREATE INDEX "IX_Payment_staff_id" ON "Payment" ("staff_id");
CREATE INDEX "IX_Reservation_guest_id" ON "Reservation" ("guest_id");
CREATE INDEX "IX_Reservation_room_id" ON "Reservation" ("room_id");
CREATE INDEX "IX_Review_guest_id" ON "Review" ("guest_id");
CREATE INDEX "IX_Review_room_id" ON "Review" ("room_id");
CREATE INDEX "IX_Room_type_id" ON "Room" ("type_id");
CREATE INDEX "IX_Service_rsv_id" ON "Service" ("rsv_id");
CREATE INDEX "IX_Service_staff_id" ON "Service" ("staff_id");
CREATE INDEX "IX_Service_type_id" ON "Service" ("type_id");
COMMIT;
