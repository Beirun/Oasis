dotnet ef migrations add Migrate
dotnet ef database update

sqlite3.exe app.db

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

INSERT INTO Guest VALUES(1,'2025-03-10 10:42:10.4063201');
INSERT INTO Guest VALUES(17,'2025-03-12 10:13:39.7632189');

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
