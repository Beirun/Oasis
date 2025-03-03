using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oasis.Migrations
{
    /// <inheritdoc />
    public partial class Migrate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AmenityItem",
                columns: table => new
                {
                    item_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    item_name = table.Column<string>(type: "TEXT", nullable: false),
                    item_price = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityItem", x => x.item_id);
                });

            migrationBuilder.CreateTable(
                name: "Discount",
                columns: table => new
                {
                    discount_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    discount_name = table.Column<string>(type: "TEXT", nullable: false),
                    discount_rate = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discount", x => x.discount_id);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    guest_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    guest_fname = table.Column<string>(type: "TEXT", nullable: true),
                    guest_lname = table.Column<string>(type: "TEXT", nullable: true),
                    guest_gender = table.Column<string>(type: "TEXT", nullable: true),
                    guest_dob = table.Column<DateOnly>(type: "TEXT", nullable: true),
                    guest_email = table.Column<string>(type: "TEXT", nullable: true),
                    guest_contactno = table.Column<string>(type: "TEXT", nullable: true),
                    guest_password = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.guest_id);
                });

            migrationBuilder.CreateTable(
                name: "RoomType",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type_category = table.Column<string>(type: "TEXT", nullable: false),
                    type_price = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomType", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceType",
                columns: table => new
                {
                    type_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type_name = table.Column<string>(type: "TEXT", nullable: false),
                    type_price = table.Column<float>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceType", x => x.type_id);
                });

            migrationBuilder.CreateTable(
                name: "Staff",
                columns: table => new
                {
                    staff_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    staff_fname = table.Column<string>(type: "TEXT", nullable: false),
                    staff_lname = table.Column<string>(type: "TEXT", nullable: false),
                    staff_position = table.Column<string>(type: "TEXT", nullable: false),
                    staff_email = table.Column<string>(type: "TEXT", nullable: false),
                    staff_contactno = table.Column<string>(type: "TEXT", nullable: false),
                    staff_gender = table.Column<string>(type: "TEXT", nullable: false),
                    staff_dob = table.Column<string>(type: "TEXT", nullable: false),
                    staff_password = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Staff", x => x.staff_id);
                });

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    room_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    room_no = table.Column<int>(type: "INTEGER", nullable: false),
                    type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    room_status = table.Column<int>(type: "INTEGER", nullable: false),
                    guest_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.room_id);
                    table.ForeignKey(
                        name: "FK_Room_Guest_guest_id",
                        column: x => x.guest_id,
                        principalTable: "Guest",
                        principalColumn: "guest_id");
                    table.ForeignKey(
                        name: "FK_Room_RoomType_type_id",
                        column: x => x.type_id,
                        principalTable: "RoomType",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    notif_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    notif_title = table.Column<string>(type: "TEXT", nullable: false),
                    notif_date = table.Column<string>(type: "TEXT", nullable: false),
                    notif_content = table.Column<string>(type: "TEXT", nullable: false),
                    notif_status = table.Column<string>(type: "TEXT", nullable: false),
                    guest_id = table.Column<int>(type: "INTEGER", nullable: true),
                    staff_id = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.notif_id);
                    table.ForeignKey(
                        name: "FK_Notification_Guest_guest_id",
                        column: x => x.guest_id,
                        principalTable: "Guest",
                        principalColumn: "guest_id");
                    table.ForeignKey(
                        name: "FK_Notification_Staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "Staff",
                        principalColumn: "staff_id");
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    payment_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    payment_amount = table.Column<float>(type: "REAL", nullable: false),
                    discount_id = table.Column<int>(type: "INTEGER", nullable: true),
                    payment_method = table.Column<string>(type: "TEXT", nullable: false),
                    payment_date = table.Column<DateTime>(type: "TEXT", nullable: true),
                    staff_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.payment_id);
                    table.ForeignKey(
                        name: "FK_Payment_Discount_discount_id",
                        column: x => x.discount_id,
                        principalTable: "Discount",
                        principalColumn: "discount_id");
                    table.ForeignKey(
                        name: "FK_Payment_Staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Review",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    room_id = table.Column<int>(type: "INTEGER", nullable: false),
                    guest_id = table.Column<int>(type: "INTEGER", nullable: false),
                    review_date = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    review_rating = table.Column<int>(type: "INTEGER", nullable: false),
                    review_feedback = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_Review_Guest_guest_id",
                        column: x => x.guest_id,
                        principalTable: "Guest",
                        principalColumn: "guest_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Review_Room_room_id",
                        column: x => x.room_id,
                        principalTable: "Room",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    rsv_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    room_id = table.Column<int>(type: "INTEGER", nullable: false),
                    guest_id = table.Column<int>(type: "INTEGER", nullable: false),
                    rsv_checkin = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    rsv_checkout = table.Column<DateOnly>(type: "TEXT", nullable: false),
                    payment_id = table.Column<int>(type: "INTEGER", nullable: false),
                    rsv_status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.rsv_id);
                    table.ForeignKey(
                        name: "FK_Reservation_Guest_guest_id",
                        column: x => x.guest_id,
                        principalTable: "Guest",
                        principalColumn: "guest_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Payment_payment_id",
                        column: x => x.payment_id,
                        principalTable: "Payment",
                        principalColumn: "payment_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservation_Room_room_id",
                        column: x => x.room_id,
                        principalTable: "Room",
                        principalColumn: "room_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Amenity",
                columns: table => new
                {
                    amenity_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    rsv_id = table.Column<int>(type: "INTEGER", nullable: false),
                    item_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenity", x => x.amenity_id);
                    table.ForeignKey(
                        name: "FK_Amenity_AmenityItem_item_id",
                        column: x => x.item_id,
                        principalTable: "AmenityItem",
                        principalColumn: "item_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amenity_Reservation_rsv_id",
                        column: x => x.rsv_id,
                        principalTable: "Reservation",
                        principalColumn: "rsv_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    service_id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type_id = table.Column<int>(type: "INTEGER", nullable: false),
                    service_date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    rsv_id = table.Column<int>(type: "INTEGER", nullable: false),
                    staff_id = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.service_id);
                    table.ForeignKey(
                        name: "FK_Service_Reservation_rsv_id",
                        column: x => x.rsv_id,
                        principalTable: "Reservation",
                        principalColumn: "rsv_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_ServiceType_type_id",
                        column: x => x.type_id,
                        principalTable: "ServiceType",
                        principalColumn: "type_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_Staff_staff_id",
                        column: x => x.staff_id,
                        principalTable: "Staff",
                        principalColumn: "staff_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amenity_item_id",
                table: "Amenity",
                column: "item_id");

            migrationBuilder.CreateIndex(
                name: "IX_Amenity_rsv_id",
                table: "Amenity",
                column: "rsv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_guest_id",
                table: "Notification",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_staff_id",
                table: "Notification",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_discount_id",
                table: "Payment",
                column: "discount_id");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_staff_id",
                table: "Payment",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_guest_id",
                table: "Reservation",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_payment_id",
                table: "Reservation",
                column: "payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_room_id",
                table: "Reservation",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_guest_id",
                table: "Review",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_room_id",
                table: "Review",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_guest_id",
                table: "Room",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_Room_type_id",
                table: "Room",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_rsv_id",
                table: "Service",
                column: "rsv_id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_staff_id",
                table: "Service",
                column: "staff_id");

            migrationBuilder.CreateIndex(
                name: "IX_Service_type_id",
                table: "Service",
                column: "type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amenity");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "Review");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "AmenityItem");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "ServiceType");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.DropTable(
                name: "Discount");

            migrationBuilder.DropTable(
                name: "Staff");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "RoomType");
        }
    }
}
