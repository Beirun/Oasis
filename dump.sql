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
INSERT INTO __EFMigrationsHistory VALUES('20250309164007_Migrate','9.0.2');
CREATE TABLE IF NOT EXISTS "Amenity" (
    "amenity_id" INTEGER NOT NULL CONSTRAINT "PK_Amenity" PRIMARY KEY AUTOINCREMENT,
    "amenity_name" TEXT NULL,
    "amenity_price" REAL NULL
);
CREATE TABLE IF NOT EXISTS "Discount" (
    "discount_id" INTEGER NOT NULL CONSTRAINT "PK_Discount" PRIMARY KEY AUTOINCREMENT,
    "discount_name" TEXT NULL,
    "discount_rate" REAL NULL
);
CREATE TABLE IF NOT EXISTS "RoomType" (
    "type_id" INTEGER NOT NULL CONSTRAINT "PK_RoomType" PRIMARY KEY AUTOINCREMENT,
    "type_category" TEXT NULL,
    "type_price" REAL NULL
);
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
CREATE TABLE IF NOT EXISTS "Guest" (
    "guest_id" INTEGER NOT NULL CONSTRAINT "PK_Guest" PRIMARY KEY,
    "registration_date" TEXT NULL,
    CONSTRAINT "FK_Guest_User_guest_id" FOREIGN KEY ("guest_id") REFERENCES "User" ("user_id")
);
INSERT INTO Guest VALUES(1,'2025-03-10 10:42:10.4063201');
INSERT INTO Guest VALUES(17,'2025-03-12 10:13:39.7632189');
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
INSERT INTO Staff VALUES(5,'Receptionist','2025-03-10 10:39:04');
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
CREATE TABLE IF NOT EXISTS "Room" (
    "room_id" INTEGER NOT NULL CONSTRAINT "PK_Room" PRIMARY KEY AUTOINCREMENT,
    "room_no" INTEGER NULL,
    "type_id" INTEGER NULL,
    "room_status" INTEGER NULL,
    "guest_id" INTEGER NULL,
    CONSTRAINT "FK_Room_Guest_guest_id" FOREIGN KEY ("guest_id") REFERENCES "Guest" ("guest_id"),
    CONSTRAINT "FK_Room_RoomType_type_id" FOREIGN KEY ("type_id") REFERENCES "RoomType" ("type_id")
);
CREATE TABLE IF NOT EXISTS "Payment" (
    "payment_id" INTEGER NOT NULL CONSTRAINT "PK_Payment" PRIMARY KEY AUTOINCREMENT,
    "payment_amount" REAL NULL,
    "discount_id" INTEGER NULL,
    "payment_method" TEXT NULL,
    "payment_date" TEXT NULL,
    "staff_id" INTEGER NULL,
    CONSTRAINT "FK_Payment_Discount_discount_id" FOREIGN KEY ("discount_id") REFERENCES "Discount" ("discount_id"),
    CONSTRAINT "FK_Payment_Staff_staff_id" FOREIGN KEY ("staff_id") REFERENCES "Staff" ("staff_id")
);
CREATE TABLE IF NOT EXISTS "HouseKeeping" (
    "house_keeping_id" INTEGER NOT NULL CONSTRAINT "PK_HouseKeeping" PRIMARY KEY AUTOINCREMENT,
    "room_id" INTEGER NULL,
    "staff_id" INTEGER NULL,
    "house_keeping_date" TEXT NULL,
    CONSTRAINT "FK_HouseKeeping_Room_room_id" FOREIGN KEY ("room_id") REFERENCES "Room" ("room_id"),
    CONSTRAINT "FK_HouseKeeping_Staff_staff_id" FOREIGN KEY ("staff_id") REFERENCES "Staff" ("staff_id")
);
CREATE TABLE IF NOT EXISTS "Reservation" (
    "rsv_id" INTEGER NOT NULL CONSTRAINT "PK_Reservation" PRIMARY KEY AUTOINCREMENT,
    "room_id" INTEGER NULL,
    "guest_id" INTEGER NULL,
    "rsv_checkin" TEXT NULL,
    "rsv_checkout" TEXT NULL,
    "payment_id" INTEGER NULL,
    "rsv_status" TEXT NULL,
    CONSTRAINT "FK_Reservation_Guest_guest_id" FOREIGN KEY ("guest_id") REFERENCES "Guest" ("guest_id"),
    CONSTRAINT "FK_Reservation_Room_room_id" FOREIGN KEY ("room_id") REFERENCES "Room" ("room_id")
);
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
INSERT INTO sqlite_sequence VALUES('User',17);
CREATE INDEX "IX_HouseKeeping_room_id" ON "HouseKeeping" ("room_id");
CREATE INDEX "IX_HouseKeeping_staff_id" ON "HouseKeeping" ("staff_id");
CREATE INDEX "IX_Notification_user_id" ON "Notification" ("user_id");
CREATE INDEX "IX_Payment_discount_id" ON "Payment" ("discount_id");
CREATE INDEX "IX_Payment_staff_id" ON "Payment" ("staff_id");
CREATE INDEX "IX_Reservation_guest_id" ON "Reservation" ("guest_id");
CREATE INDEX "IX_Reservation_room_id" ON "Reservation" ("room_id");
CREATE INDEX "IX_Review_guest_id" ON "Review" ("guest_id");
CREATE INDEX "IX_Review_room_id" ON "Review" ("room_id");
CREATE INDEX "IX_Room_guest_id" ON "Room" ("guest_id");
CREATE INDEX "IX_Room_type_id" ON "Room" ("type_id");
CREATE INDEX "IX_Service_rsv_id" ON "Service" ("rsv_id");
CREATE INDEX "IX_Service_staff_id" ON "Service" ("staff_id");
CREATE INDEX "IX_Service_type_id" ON "Service" ("type_id");
COMMIT;
