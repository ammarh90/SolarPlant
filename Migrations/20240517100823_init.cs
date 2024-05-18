using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SolarPlant.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SolarPowerPlants",
                columns: table => new
                {
                    SolarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstalledPowerInKW = table.Column<double>(type: "float", nullable: false),
                    DateOfInstallation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarPowerPlants", x => x.SolarId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionDatas",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateOfProduction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualProductionPowerOutputKW = table.Column<double>(type: "float", nullable: false),
                    ForcastProductionPowerOutputKW = table.Column<double>(type: "float", nullable: false),
                    Weather = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SolarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionDatas", x => x.ProductionId);
                    table.ForeignKey(
                        name: "FK_ProductionDatas_SolarPowerPlants_SolarId",
                        column: x => x.SolarId,
                        principalTable: "SolarPowerPlants",
                        principalColumn: "SolarId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SolarPowerPlants",
                columns: new[] { "SolarId", "DateOfInstallation", "InstalledPowerInKW", "Latitude", "Longitude", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 8, 2, 37, 20, 544, DateTimeKind.Local).AddTicks(4064), 3073.0, 48.546700000000001, -28.778500000000001, "Parker LLC" },
                    { 2, new DateTime(2024, 5, 15, 19, 56, 27, 968, DateTimeKind.Local).AddTicks(2196), 1357.0, 49.919199999999996, -145.602, "Harvey - Nikolaus" },
                    { 3, new DateTime(2024, 5, 15, 21, 30, 17, 143, DateTimeKind.Local).AddTicks(9323), 4867.0, 86.664299999999997, 78.893500000000003, "Cummings and Sons" },
                    { 4, new DateTime(2024, 5, 13, 6, 58, 56, 504, DateTimeKind.Local).AddTicks(7934), 1491.0, -1.5041, 57.924500000000002, "Auer, Volkman and Bruen" },
                    { 5, new DateTime(2024, 5, 8, 2, 56, 42, 440, DateTimeKind.Local).AddTicks(1763), 4279.0, 10.7883, -152.3339, "Kuvalis - Okuneva" },
                    { 6, new DateTime(2024, 5, 16, 15, 40, 20, 690, DateTimeKind.Local).AddTicks(8492), 3121.0, 80.007000000000005, 127.191, "O'Hara - Skiles" },
                    { 7, new DateTime(2024, 5, 13, 0, 7, 53, 48, DateTimeKind.Local).AddTicks(4497), 4127.0, 58.8782, -69.053100000000001, "Harvey, Torp and Dibbert" },
                    { 8, new DateTime(2024, 5, 10, 23, 17, 27, 369, DateTimeKind.Local).AddTicks(5578), 2302.0, 48.587800000000001, -145.07679999999999, "Huel, Haley and Lesch" },
                    { 9, new DateTime(2024, 5, 13, 0, 10, 11, 240, DateTimeKind.Local).AddTicks(2170), 3863.0, -38.287300000000002, 119.9601, "Green, Schuster and Schmidt" },
                    { 10, new DateTime(2024, 5, 12, 14, 16, 17, 927, DateTimeKind.Local).AddTicks(4000), 1457.0, -43.100299999999997, 57.203899999999997, "D'Amore, Dicki and Krajcik" },
                    { 11, new DateTime(2024, 5, 9, 16, 21, 17, 537, DateTimeKind.Local).AddTicks(3928), 3611.0, 23.916899999999998, 113.8385, "Haley Group" },
                    { 12, new DateTime(2024, 5, 16, 15, 51, 0, 527, DateTimeKind.Local).AddTicks(7909), 3498.0, 1.0161, 35.638399999999997, "Kassulke, Bruen and Vandervort" },
                    { 13, new DateTime(2024, 5, 9, 14, 23, 56, 955, DateTimeKind.Local).AddTicks(3016), 3613.0, 37.855600000000003, 76.405699999999996, "Runolfsdottir - Rippin" },
                    { 14, new DateTime(2024, 5, 11, 8, 23, 33, 202, DateTimeKind.Local).AddTicks(7265), 1211.0, 16.784099999999999, -48.738300000000002, "Lesch Group" },
                    { 15, new DateTime(2024, 5, 11, 3, 28, 42, 54, DateTimeKind.Local).AddTicks(8312), 1415.0, 74.703900000000004, -65.477500000000006, "Schmeler, Marvin and Spencer" },
                    { 16, new DateTime(2024, 5, 16, 20, 42, 12, 178, DateTimeKind.Local).AddTicks(6806), 3993.0, 13.689500000000001, -90.570999999999998, "Spinka - Lang" },
                    { 17, new DateTime(2024, 5, 15, 7, 16, 11, 527, DateTimeKind.Local).AddTicks(4631), 1644.0, -1.8829, -31.061499999999999, "Stanton Group" },
                    { 18, new DateTime(2024, 5, 17, 5, 28, 11, 725, DateTimeKind.Local).AddTicks(9649), 3529.0, 62.677700000000002, -28.573599999999999, "Schamberger Inc" },
                    { 19, new DateTime(2024, 5, 15, 9, 10, 3, 881, DateTimeKind.Local).AddTicks(9242), 2672.0, 46.550899999999999, 136.5633, "Hahn Group" },
                    { 20, new DateTime(2024, 5, 17, 0, 6, 2, 30, DateTimeKind.Local).AddTicks(9852), 2267.0, -50.200699999999998, -26.709599999999998, "Dickens - Johnson" },
                    { 21, new DateTime(2024, 5, 16, 8, 52, 59, 598, DateTimeKind.Local).AddTicks(9217), 3246.0, -29.860399999999998, 125.31059999999999, "Bauch LLC" },
                    { 22, new DateTime(2024, 5, 10, 20, 2, 2, 575, DateTimeKind.Local).AddTicks(4759), 4162.0, 19.672599999999999, 151.7715, "Bode and Sons" },
                    { 23, new DateTime(2024, 5, 7, 23, 4, 42, 852, DateTimeKind.Local).AddTicks(2579), 2489.0, -66.191100000000006, 117.9192, "Krajcik LLC" },
                    { 24, new DateTime(2024, 5, 10, 15, 34, 25, 303, DateTimeKind.Local).AddTicks(4259), 1674.0, -58.128399999999999, 5.9657999999999998, "Fritsch Inc" },
                    { 25, new DateTime(2024, 5, 11, 2, 35, 13, 559, DateTimeKind.Local).AddTicks(1870), 3833.0, -64.668599999999998, 62.573399999999999, "Lockman - Gottlieb" },
                    { 26, new DateTime(2024, 5, 12, 10, 4, 25, 427, DateTimeKind.Local).AddTicks(2151), 4646.0, 54.660800000000002, 97.153700000000001, "Macejkovic - Crona" },
                    { 27, new DateTime(2024, 5, 14, 16, 47, 39, 69, DateTimeKind.Local).AddTicks(2979), 1114.0, 26.768799999999999, 15.096500000000001, "Hammes, Fritsch and Quigley" },
                    { 28, new DateTime(2024, 5, 8, 23, 6, 7, 716, DateTimeKind.Local).AddTicks(7962), 2633.0, 3.9197000000000002, 147.6831, "Wunsch - Conn" },
                    { 29, new DateTime(2024, 5, 11, 4, 25, 49, 423, DateTimeKind.Local).AddTicks(3104), 3041.0, 20.764299999999999, -97.717600000000004, "Kautzer Inc" },
                    { 30, new DateTime(2024, 5, 11, 17, 58, 41, 766, DateTimeKind.Local).AddTicks(641), 1632.0, -22.3748, 9.9337, "Schamberger - Sporer" },
                    { 31, new DateTime(2024, 5, 13, 11, 18, 22, 895, DateTimeKind.Local).AddTicks(4569), 2008.0, 51.229399999999998, 1.3640000000000001, "Botsford LLC" },
                    { 32, new DateTime(2024, 5, 16, 3, 28, 31, 875, DateTimeKind.Local).AddTicks(3947), 4765.0, 81.847999999999999, -143.23990000000001, "Gottlieb - Jenkins" },
                    { 33, new DateTime(2024, 5, 7, 22, 15, 30, 962, DateTimeKind.Local).AddTicks(3555), 2418.0, 88.002300000000005, -99.583399999999997, "Langosh, O'Reilly and Bode" },
                    { 34, new DateTime(2024, 5, 7, 13, 28, 2, 643, DateTimeKind.Local).AddTicks(9209), 3601.0, 79.510900000000007, 142.71520000000001, "O'Conner - Waelchi" },
                    { 35, new DateTime(2024, 5, 15, 7, 35, 30, 481, DateTimeKind.Local).AddTicks(2231), 4910.0, 87.170599999999993, 9.5298999999999996, "Zboncak and Sons" },
                    { 36, new DateTime(2024, 5, 9, 1, 2, 1, 518, DateTimeKind.Local).AddTicks(5251), 2519.0, -64.683000000000007, -58.954700000000003, "Hodkiewicz - Greenfelder" },
                    { 37, new DateTime(2024, 5, 12, 8, 11, 46, 972, DateTimeKind.Local).AddTicks(8504), 4738.0, -77.147199999999998, -169.4836, "Stanton, Hayes and Wilkinson" },
                    { 38, new DateTime(2024, 5, 15, 3, 29, 7, 287, DateTimeKind.Local).AddTicks(1493), 4331.0, 80.509100000000004, 91.376900000000006, "Sporer, Blanda and Schinner" },
                    { 39, new DateTime(2024, 5, 11, 14, 38, 24, 264, DateTimeKind.Local).AddTicks(2024), 4516.0, 39.078600000000002, -147.71360000000001, "Stokes LLC" },
                    { 40, new DateTime(2024, 5, 8, 17, 12, 23, 562, DateTimeKind.Local).AddTicks(9759), 3572.0, 3.8639000000000001, 166.25829999999999, "Veum, Marquardt and Hahn" },
                    { 41, new DateTime(2024, 5, 10, 12, 27, 15, 518, DateTimeKind.Local).AddTicks(5620), 4241.0, 53.321199999999997, -14.5489, "Swift - Stiedemann" },
                    { 42, new DateTime(2024, 5, 7, 19, 21, 49, 77, DateTimeKind.Local).AddTicks(7793), 3490.0, -46.5488, 90.285399999999996, "Crist LLC" },
                    { 43, new DateTime(2024, 5, 9, 11, 28, 28, 808, DateTimeKind.Local).AddTicks(9784), 4645.0, -24.900300000000001, -27.726900000000001, "Johns - Fay" },
                    { 44, new DateTime(2024, 5, 16, 8, 7, 35, 38, DateTimeKind.Local).AddTicks(4430), 2142.0, 7.524, 30.2653, "Blanda, Marquardt and Rolfson" },
                    { 45, new DateTime(2024, 5, 8, 0, 33, 8, 858, DateTimeKind.Local).AddTicks(3199), 1080.0, 58.490499999999997, -170.4418, "Lowe, Brakus and Kunde" },
                    { 46, new DateTime(2024, 5, 16, 14, 23, 22, 406, DateTimeKind.Local).AddTicks(1202), 1375.0, -48.2637, -16.587900000000001, "Armstrong, Heaney and Windler" },
                    { 47, new DateTime(2024, 5, 9, 23, 36, 9, 741, DateTimeKind.Local).AddTicks(9726), 4790.0, -75.594300000000004, 174.6576, "Sanford - Klein" },
                    { 48, new DateTime(2024, 5, 16, 19, 42, 56, 103, DateTimeKind.Local).AddTicks(7191), 1915.0, 35.870699999999999, -93.670699999999997, "Dooley, Kiehn and Weber" },
                    { 49, new DateTime(2024, 5, 9, 1, 22, 32, 883, DateTimeKind.Local).AddTicks(9342), 3542.0, -71.534999999999997, -138.3569, "Cronin LLC" },
                    { 50, new DateTime(2024, 5, 16, 5, 33, 36, 41, DateTimeKind.Local).AddTicks(2155), 4940.0, 68.889799999999994, -38.263199999999998, "Simonis LLC" },
                    { 51, new DateTime(2024, 5, 11, 13, 57, 24, 339, DateTimeKind.Local).AddTicks(7822), 4839.0, -58.307699999999997, 160.2604, "Treutel - Reinger" },
                    { 52, new DateTime(2024, 5, 15, 13, 43, 1, 872, DateTimeKind.Local).AddTicks(1621), 3412.0, 57.944299999999998, 1.3591, "Fritsch - Koepp" },
                    { 53, new DateTime(2024, 5, 15, 16, 20, 23, 321, DateTimeKind.Local).AddTicks(2760), 1542.0, 35.781300000000002, -75.932599999999994, "Hodkiewicz, Marquardt and Cartwright" },
                    { 54, new DateTime(2024, 5, 17, 11, 34, 4, 349, DateTimeKind.Local).AddTicks(4882), 2699.0, 26.613900000000001, 70.529600000000002, "Collins, Murray and Stracke" },
                    { 55, new DateTime(2024, 5, 13, 16, 29, 45, 119, DateTimeKind.Local).AddTicks(3492), 1104.0, -25.9862, 165.93360000000001, "O'Reilly Inc" },
                    { 56, new DateTime(2024, 5, 11, 18, 2, 41, 475, DateTimeKind.Local).AddTicks(1567), 3568.0, 48.819099999999999, 106.35590000000001, "Mueller, Robel and Wisozk" },
                    { 57, new DateTime(2024, 5, 8, 1, 48, 19, 477, DateTimeKind.Local).AddTicks(7011), 1710.0, -72.721999999999994, 139.09139999999999, "Kautzer, Kling and D'Amore" },
                    { 58, new DateTime(2024, 5, 15, 19, 0, 16, 851, DateTimeKind.Local).AddTicks(8689), 2394.0, 36.212400000000002, -45.493099999999998, "Gorczany, Block and Moen" },
                    { 59, new DateTime(2024, 5, 10, 6, 27, 50, 546, DateTimeKind.Local).AddTicks(5990), 2143.0, 29.048500000000001, 11.540900000000001, "Shanahan, Rath and Price" },
                    { 60, new DateTime(2024, 5, 8, 1, 11, 22, 521, DateTimeKind.Local).AddTicks(3712), 4104.0, -0.59740000000000004, -20.956099999999999, "O'Hara, Johnston and Williamson" },
                    { 61, new DateTime(2024, 5, 8, 4, 7, 59, 255, DateTimeKind.Local).AddTicks(5154), 1172.0, -67.197900000000004, -108.5223, "Schulist, Kirlin and McKenzie" },
                    { 62, new DateTime(2024, 5, 10, 22, 40, 45, 961, DateTimeKind.Local).AddTicks(2434), 1061.0, 3.8521000000000001, -116.9742, "Kozey Inc" },
                    { 63, new DateTime(2024, 5, 8, 7, 38, 59, 604, DateTimeKind.Local).AddTicks(1938), 3464.0, -10.568, -105.1409, "Jaskolski, Gislason and Schulist" },
                    { 64, new DateTime(2024, 5, 8, 1, 19, 17, 820, DateTimeKind.Local).AddTicks(878), 3729.0, 80.6751, 93.522999999999996, "Bauch LLC" },
                    { 65, new DateTime(2024, 5, 17, 8, 44, 7, 688, DateTimeKind.Local).AddTicks(6297), 2117.0, -5.3875000000000002, 9.8062000000000005, "Schowalter, Johns and Farrell" },
                    { 66, new DateTime(2024, 5, 17, 9, 21, 49, 172, DateTimeKind.Local).AddTicks(344), 2199.0, -26.454599999999999, 145.8663, "Senger LLC" },
                    { 67, new DateTime(2024, 5, 15, 17, 20, 2, 326, DateTimeKind.Local).AddTicks(6013), 4897.0, -20.1356, 150.12119999999999, "Torphy - Gutmann" },
                    { 68, new DateTime(2024, 5, 12, 8, 33, 29, 840, DateTimeKind.Local).AddTicks(6924), 4709.0, 12.3544, 7.0119999999999996, "Tremblay - Pollich" },
                    { 69, new DateTime(2024, 5, 10, 23, 53, 17, 173, DateTimeKind.Local).AddTicks(4622), 3633.0, 69.996700000000004, -10.731299999999999, "Breitenberg LLC" },
                    { 70, new DateTime(2024, 5, 17, 9, 45, 40, 227, DateTimeKind.Local).AddTicks(8794), 2710.0, -72.289900000000003, -97.5458, "Heller and Sons" },
                    { 71, new DateTime(2024, 5, 14, 21, 44, 31, 972, DateTimeKind.Local).AddTicks(3642), 4660.0, -78.218999999999994, -71.414599999999993, "Kautzer - Rutherford" },
                    { 72, new DateTime(2024, 5, 12, 14, 52, 43, 75, DateTimeKind.Local).AddTicks(9899), 2049.0, -43.485999999999997, 92.489900000000006, "Shanahan Inc" },
                    { 73, new DateTime(2024, 5, 9, 16, 44, 44, 655, DateTimeKind.Local).AddTicks(6462), 2835.0, 83.8934, 123.08540000000001, "Barrows and Sons" },
                    { 74, new DateTime(2024, 5, 15, 10, 19, 26, 835, DateTimeKind.Local).AddTicks(992), 4618.0, 45.9497, 45.369100000000003, "Robel, Abernathy and Shanahan" },
                    { 75, new DateTime(2024, 5, 16, 18, 53, 28, 768, DateTimeKind.Local).AddTicks(1400), 2041.0, 47.179099999999998, 133.62469999999999, "Dicki, Spinka and Macejkovic" },
                    { 76, new DateTime(2024, 5, 15, 7, 16, 50, 742, DateTimeKind.Local).AddTicks(7053), 4878.0, 41.002499999999998, 31.249199999999998, "Kassulke, Smith and Halvorson" },
                    { 77, new DateTime(2024, 5, 13, 9, 4, 46, 122, DateTimeKind.Local).AddTicks(3946), 2902.0, 65.731399999999994, -39.7547, "McClure Inc" },
                    { 78, new DateTime(2024, 5, 15, 8, 2, 27, 307, DateTimeKind.Local).AddTicks(4247), 4295.0, -66.646900000000002, 46.114899999999999, "Rutherford, Jerde and Blanda" },
                    { 79, new DateTime(2024, 5, 11, 10, 28, 1, 932, DateTimeKind.Local).AddTicks(2897), 1926.0, 65.927300000000002, 176.7465, "Nolan Group" },
                    { 80, new DateTime(2024, 5, 13, 3, 21, 18, 146, DateTimeKind.Local).AddTicks(3014), 3882.0, -87.186099999999996, 80.200100000000006, "Wolf Inc" },
                    { 81, new DateTime(2024, 5, 9, 18, 24, 9, 347, DateTimeKind.Local).AddTicks(802), 3476.0, 7.6820000000000004, -73.468900000000005, "Barton and Sons" },
                    { 82, new DateTime(2024, 5, 14, 22, 9, 48, 962, DateTimeKind.Local).AddTicks(4313), 1804.0, 19.2789, 11.451599999999999, "Schultz Inc" },
                    { 83, new DateTime(2024, 5, 15, 16, 16, 46, 193, DateTimeKind.Local).AddTicks(7976), 2272.0, -54.006599999999999, -34.050600000000003, "West and Sons" },
                    { 84, new DateTime(2024, 5, 10, 7, 26, 10, 29, DateTimeKind.Local).AddTicks(9955), 4883.0, 67.334900000000005, 74.925399999999996, "Jenkins - Hermann" },
                    { 85, new DateTime(2024, 5, 13, 8, 23, 43, 576, DateTimeKind.Local).AddTicks(5747), 1162.0, -7.8554000000000004, -92.772000000000006, "Haley LLC" },
                    { 86, new DateTime(2024, 5, 11, 20, 14, 31, 424, DateTimeKind.Local).AddTicks(5582), 1642.0, 16.293700000000001, -82.612499999999997, "Bergstrom and Sons" },
                    { 87, new DateTime(2024, 5, 8, 3, 27, 26, 205, DateTimeKind.Local).AddTicks(474), 3977.0, -74.843900000000005, 138.40039999999999, "Hudson - White" },
                    { 88, new DateTime(2024, 5, 10, 16, 7, 24, 826, DateTimeKind.Local).AddTicks(9991), 3446.0, -33.922600000000003, 124.5518, "Hahn Group" },
                    { 89, new DateTime(2024, 5, 15, 0, 34, 57, 319, DateTimeKind.Local).AddTicks(3515), 4289.0, -88.962299999999999, -68.916700000000006, "Kunze LLC" },
                    { 90, new DateTime(2024, 5, 16, 12, 48, 5, 258, DateTimeKind.Local).AddTicks(1931), 2621.0, -23.5855, 164.68960000000001, "Harber - Senger" },
                    { 91, new DateTime(2024, 5, 10, 15, 11, 12, 642, DateTimeKind.Local).AddTicks(2268), 4906.0, -70.698499999999996, 68.759699999999995, "Kozey, Prosacco and Grimes" },
                    { 92, new DateTime(2024, 5, 17, 2, 7, 25, 236, DateTimeKind.Local).AddTicks(2610), 3005.0, 25.2195, 34.104999999999997, "Graham, Flatley and Bauch" },
                    { 93, new DateTime(2024, 5, 17, 9, 28, 48, 785, DateTimeKind.Local).AddTicks(3129), 2101.0, -34.932200000000002, -96.594499999999996, "Tromp and Sons" },
                    { 94, new DateTime(2024, 5, 11, 23, 20, 32, 867, DateTimeKind.Local).AddTicks(7598), 1821.0, -16.738199999999999, -153.13499999999999, "Gleason - Boyle" },
                    { 95, new DateTime(2024, 5, 14, 20, 0, 3, 994, DateTimeKind.Local).AddTicks(3189), 3672.0, -57.015099999999997, 94.813699999999997, "Jones - Stoltenberg" },
                    { 96, new DateTime(2024, 5, 8, 5, 24, 26, 161, DateTimeKind.Local).AddTicks(554), 1627.0, 88.575900000000004, -166.24760000000001, "MacGyver - Schmitt" },
                    { 97, new DateTime(2024, 5, 9, 19, 34, 8, 408, DateTimeKind.Local).AddTicks(9981), 3578.0, 32.021599999999999, 45.995699999999999, "Nitzsche and Sons" },
                    { 98, new DateTime(2024, 5, 8, 9, 59, 20, 877, DateTimeKind.Local).AddTicks(5893), 3377.0, -36.065199999999997, -104.9127, "Becker Group" },
                    { 99, new DateTime(2024, 5, 15, 10, 49, 7, 656, DateTimeKind.Local).AddTicks(6711), 1639.0, 11.2837, 171.7236, "Brakus - Abbott" },
                    { 100, new DateTime(2024, 5, 11, 9, 47, 52, 99, DateTimeKind.Local).AddTicks(1374), 3376.0, 84.460599999999999, -85.403599999999997, "Swift - Hickle" }
                });

            migrationBuilder.InsertData(
                table: "ProductionDatas",
                columns: new[] { "ProductionId", "ActualProductionPowerOutputKW", "DateOfProduction", "ForcastProductionPowerOutputKW", "SolarId", "Weather" },
                values: new object[,]
                {
                    { 1, 2970.791667706731, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2174.9928948867655, 1, "cloudy" },
                    { 2, 411.89959712886912, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 216.74097422927474, 2, "windy" },
                    { 3, 2551.2014338656572, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2805.6026831920026, 3, "cloudy" },
                    { 4, 4720.4929499676027, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3933.5706988444663, 4, "rainy" },
                    { 5, 4442.0370228124148, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1069.8262841599214, 5, "cloudy" },
                    { 6, 3094.6962375908597, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3336.4765239491635, 6, "rainy" },
                    { 7, 1517.9099899081527, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4263.1581595569241, 7, "windy" },
                    { 8, 919.45642778712261, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3824.6819754382077, 8, "sunny" },
                    { 9, 2269.065213437304, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1129.8104400054233, 9, "sunny" },
                    { 10, 2915.112740828979, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4705.9511688029297, 10, "windy" },
                    { 11, 37.153124191640075, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3723.6787998771792, 11, "sunny" },
                    { 12, 3917.0084484304239, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2332.0114423899063, 12, "windy" },
                    { 13, 3316.7510880704554, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4047.1126534931882, 13, "rainy" },
                    { 14, 199.43152658964792, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 614.00953174531094, 14, "sunny" },
                    { 15, 3671.4926775991626, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2917.07283699036, 15, "cloudy" },
                    { 16, 443.71034722713978, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4833.5733030827414, 16, "rainy" },
                    { 17, 140.00631522940176, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3679.1353233813584, 17, "sunny" },
                    { 18, 1776.3807241479278, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4714.4408085557034, 18, "windy" },
                    { 19, 129.18501958246731, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1390.803351091427, 19, "windy" },
                    { 20, 2004.9536732028917, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 693.11922084485718, 20, "rainy" },
                    { 21, 1830.8372984888742, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3461.6586630046977, 21, "cloudy" },
                    { 22, 4481.1871362624288, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4765.673583076763, 22, "rainy" },
                    { 23, 2528.5767438466091, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1563.9970426397576, 23, "rainy" },
                    { 24, 3988.2256153474259, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2848.2713733096352, 24, "windy" },
                    { 25, 1586.4705105743283, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 175.46109490109262, 25, "rainy" },
                    { 26, 4156.7224581176051, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2566.1774015070428, 26, "sunny" },
                    { 27, 2981.4994427248389, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3898.1806639382489, 27, "cloudy" },
                    { 28, 3588.1371005769047, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3851.6599246534588, 28, "rainy" },
                    { 29, 1077.8413716189921, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3402.3288733494546, 29, "cloudy" },
                    { 30, 115.23674078693924, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2872.7477327408801, 30, "sunny" },
                    { 31, 2726.3234077268671, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4586.3468362851536, 31, "cloudy" },
                    { 32, 3775.0807382526273, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4476.2108258834878, 32, "sunny" },
                    { 33, 2125.5215613008713, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4027.682930917812, 33, "rainy" },
                    { 34, 2345.4358734158113, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4695.9864356968747, 34, "sunny" },
                    { 35, 2607.4112628344842, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3694.625792148468, 35, "cloudy" },
                    { 36, 2820.1642180270792, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1305.2080647468051, 36, "sunny" },
                    { 37, 2227.3042106507523, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1300.2945575858744, 37, "rainy" },
                    { 38, 2990.7825711457867, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1546.7615237856708, 38, "sunny" },
                    { 39, 675.16451073229064, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3498.4079288996577, 39, "sunny" },
                    { 40, 1993.2505094204812, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 980.99582897772484, 40, "windy" },
                    { 41, 858.27448686022262, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 69.747838832510126, 41, "sunny" },
                    { 42, 3269.1469878761932, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3946.5245148841209, 42, "cloudy" },
                    { 43, 4945.4405219939645, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 799.36507010568596, 43, "rainy" },
                    { 44, 2998.7759974680457, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4518.0489902468998, 44, "windy" },
                    { 45, 2125.8654011168042, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 729.44217029437652, 45, "sunny" },
                    { 46, 2633.8009476821458, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2802.4978153161269, 46, "windy" },
                    { 47, 3728.7480192834528, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 689.31570698872008, 47, "cloudy" },
                    { 48, 2616.4183109246433, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4624.0478399420963, 48, "cloudy" },
                    { 49, 2946.4117888327924, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2209.5147277481574, 49, "windy" },
                    { 50, 292.42796067072032, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1911.0415764497345, 50, "cloudy" },
                    { 51, 1809.9000284126021, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2655.9512898443986, 51, "windy" },
                    { 52, 3024.4035675226824, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 306.85212939262686, 52, "windy" },
                    { 53, 4078.1931178209725, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4320.388764134098, 53, "sunny" },
                    { 54, 3306.3220211770545, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3209.9839510023121, 54, "rainy" },
                    { 55, 2313.3251759532618, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4409.3601123973276, 55, "windy" },
                    { 56, 2331.0292004117196, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2662.1021626364222, 56, "windy" },
                    { 57, 301.32406877978025, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 915.968285037187, 57, "sunny" },
                    { 58, 3272.7714131868652, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2241.1042630326879, 58, "sunny" },
                    { 59, 3417.8824524901365, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4625.7311364809375, 59, "rainy" },
                    { 60, 3741.1089652338674, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1801.5595769731708, 60, "cloudy" },
                    { 61, 4162.9063232142762, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1688.3875109726732, 61, "windy" },
                    { 62, 848.3948730146318, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 668.84231160124762, 62, "cloudy" },
                    { 63, 4250.2314817880424, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4817.8436593518245, 63, "cloudy" },
                    { 64, 2379.4044207243246, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 544.59819432464974, 64, "sunny" },
                    { 65, 3428.1247027382251, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3112.0771096475009, 65, "sunny" },
                    { 66, 1889.9955411636788, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 483.30295020974859, 66, "windy" },
                    { 67, 4035.3189448412591, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2164.3157262896952, 67, "sunny" },
                    { 68, 3650.5154094596296, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1020.0043792315817, 68, "sunny" },
                    { 69, 2454.0225973261527, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3328.0845864765561, 69, "rainy" },
                    { 70, 2224.6692440031052, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 668.75918646072569, 70, "sunny" },
                    { 71, 398.76031532288636, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3498.2220913242249, 71, "sunny" },
                    { 72, 3309.6840752328981, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2892.1192209659048, 72, "windy" },
                    { 73, 1506.8385695561615, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2263.9438477670819, 73, "cloudy" },
                    { 74, 4153.2247607594327, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 318.34652751736468, 74, "rainy" },
                    { 75, 426.30520573441464, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3655.8713716719726, 75, "windy" },
                    { 76, 2261.1645826324038, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1612.5828551804566, 76, "windy" },
                    { 77, 3243.6959838361977, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4453.2839834175084, 77, "rainy" },
                    { 78, 50.550746146573729, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 870.65947139669811, 78, "cloudy" },
                    { 79, 3208.9059641123831, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1740.5699443852791, 79, "rainy" },
                    { 80, 2644.339197522771, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2393.1784177079358, 80, "sunny" },
                    { 81, 591.3213527021727, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 428.9151890687798, 81, "windy" },
                    { 82, 3537.8118785157149, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2513.7761838195543, 82, "cloudy" },
                    { 83, 3520.520741374442, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1807.4733113177504, 83, "windy" },
                    { 84, 1123.7602643887208, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4540.1427977605481, 84, "sunny" },
                    { 85, 4048.0318942727099, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2381.4533431945702, 85, "windy" },
                    { 86, 140.59881535213759, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3835.6771309880151, 86, "windy" },
                    { 87, 3728.1299797938873, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2573.0948198569185, 87, "rainy" },
                    { 88, 4915.1489417022676, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 51.084283547715991, 88, "sunny" },
                    { 89, 4716.5618265406874, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 598.37363956184936, 89, "rainy" },
                    { 90, 3939.276889828976, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 269.82933102705056, 90, "sunny" },
                    { 91, 4884.1115513350396, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3443.6252534288542, 91, "windy" },
                    { 92, 2495.1746264614117, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 597.21771731598869, 92, "rainy" },
                    { 93, 762.13604521709226, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2785.2319958736894, 93, "cloudy" },
                    { 94, 375.15099822522268, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3084.2822357844861, 94, "rainy" },
                    { 95, 1778.6212367491821, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4246.2730685381075, 95, "windy" },
                    { 96, 4129.2121444653931, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 2413.1343076511621, 96, "sunny" },
                    { 97, 1230.9432253616626, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 4629.4318336587585, 97, "rainy" },
                    { 98, 3180.916880006765, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 870.92847268738615, 98, "rainy" },
                    { 99, 1820.5554839543393, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 3332.3609585255776, 99, "windy" },
                    { 100, 2170.9880954881887, new DateTime(2024, 5, 17, 12, 23, 22, 256, DateTimeKind.Local).AddTicks(169), 1178.4225195658344, 100, "windy" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionDatas_SolarId",
                table: "ProductionDatas",
                column: "SolarId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProductionDatas");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "SolarPowerPlants");
        }
    }
}
