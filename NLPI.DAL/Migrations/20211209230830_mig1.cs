using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NLPI.DAL.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id_Level = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Difficulty = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKLevel", x => x.Id_Level);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id_Question = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuestionText = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: true),
                    HtmlText = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKQuestion", x => x.Id_Question);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id_Tag = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTag", x => x.Id_Tag);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id_Unit = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUnit", x => x.Id_Unit);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", unicode: false, maxLength: 15, nullable: true),
                    Password = table.Column<string>(type: "TEXT", unicode: false, maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUser", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Metadatas",
                columns: table => new
                {
                    Id_Metadata = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdUnit = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUnitNavigationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKMetadata", x => x.Id_Metadata);
                    table.ForeignKey(
                        name: "FK_Metadatas_Units_IdUnitNavigationId",
                        column: x => x.IdUnitNavigationId,
                        principalTable: "Units",
                        principalColumn: "Id_Unit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskResults",
                columns: table => new
                {
                    Id_TaskResult = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false),
                    LevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTaskResult", x => x.Id_TaskResult);
                    table.ForeignKey(
                        name: "FK_TaskResults_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id_Level",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskResults_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAchievements",
                columns: table => new
                {
                    Id_UserAchievement = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", unicode: false, maxLength: 50, nullable: true),
                    Notes = table.Column<string>(type: "TEXT", unicode: false, maxLength: 500, nullable: true),
                    IdLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUser = table.Column<int>(type: "INTEGER", nullable: false),
                    SaveDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdLevelNavigationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKUserAchievement", x => x.Id_UserAchievement);
                    table.ForeignKey(
                        name: "FK_UserAchievements_Levels_IdLevelNavigationId",
                        column: x => x.IdLevelNavigationId,
                        principalTable: "Levels",
                        principalColumn: "Id_Level",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "R_1",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagDistributions",
                columns: table => new
                {
                    Id_TagDistribution = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdTag = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMetadata = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTagDistribution", x => x.Id_TagDistribution);
                    table.ForeignKey(
                        name: "R_4",
                        column: x => x.IdTag,
                        principalTable: "Tags",
                        principalColumn: "Id_Tag",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "R_5",
                        column: x => x.IdMetadata,
                        principalTable: "Metadatas",
                        principalColumn: "Id_Metadata",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id_Task = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    LevelId = table.Column<int>(type: "INTEGER", nullable: false),
                    MetadataId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuestionId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTask", x => x.Id_Task);
                    table.ForeignKey(
                        name: "FK_Tasks_Levels_LevelId",
                        column: x => x.LevelId,
                        principalTable: "Levels",
                        principalColumn: "Id_Level",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Metadatas_MetadataId",
                        column: x => x.MetadataId,
                        principalTable: "Metadatas",
                        principalColumn: "Id_Metadata",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tasks_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id_Question",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AchievementDatas",
                columns: table => new
                {
                    Id_AchievementData = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompletedCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CorrectCount = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentMark = table.Column<int>(type: "INTEGER", nullable: false),
                    TryCount = table.Column<int>(type: "INTEGER", nullable: false),
                    IdUserAchievement = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKAchievementData", x => x.Id_AchievementData);
                    table.ForeignKey(
                        name: "R_2",
                        column: x => x.IdUserAchievement,
                        principalTable: "UserAchievements",
                        principalColumn: "Id_UserAchievement",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id_Answer = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false),
                    EtalonAnswer = table.Column<string>(type: "TEXT", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKAnswer", x => x.Id_Answer);
                    table.ForeignKey(
                        name: "FK_Answers_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hints",
                columns: table => new
                {
                    Id_Hint = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    HintType = table.Column<string>(type: "TEXT", unicode: false, maxLength: 20, nullable: true),
                    HintText = table.Column<string>(type: "TEXT", unicode: false, maxLength: 200, nullable: true),
                    IdTask = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTaskNavigationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKHint", x => x.Id_Hint);
                    table.ForeignKey(
                        name: "FK_Hints_Tasks_IdTaskNavigationId",
                        column: x => x.IdTaskNavigationId,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskDistributions",
                columns: table => new
                {
                    Id_TaskDistribution = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskOrder = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTask = table.Column<int>(type: "INTEGER", nullable: false),
                    IdLevel = table.Column<int>(type: "INTEGER", nullable: false),
                    IdTaskNavigationId = table.Column<int>(type: "INTEGER", nullable: true),
                    IdLevelNavigationId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTaskDistribution", x => x.Id_TaskDistribution);
                    table.ForeignKey(
                        name: "FK_TaskDistributions_Levels_IdLevelNavigationId",
                        column: x => x.IdLevelNavigationId,
                        principalTable: "Levels",
                        principalColumn: "Id_Level",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TaskDistributions_Tasks_IdTaskNavigationId",
                        column: x => x.IdTaskNavigationId,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Hints",
                columns: new[] { "Id_Hint", "HintText", "HintType", "IdTask", "IdTaskNavigationId" },
                values: new object[] { 1, "CSS", "CSS", 1, null });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "Difficulty", "Name" },
                values: new object[] { 1, "Easy", "1" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "Difficulty", "Name" },
                values: new object[] { 2, "Easy", "2" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "Difficulty", "Name" },
                values: new object[] { 3, "Easy", "3" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "Difficulty", "Name" },
                values: new object[] { 4, "Easy", "4" });

            migrationBuilder.InsertData(
                table: "Levels",
                columns: new[] { "Id_Level", "Difficulty", "Name" },
                values: new object[] { 5, "Easy", "5" });

            migrationBuilder.InsertData(
                table: "Metadatas",
                columns: new[] { "Id_Metadata", "IdUnit", "IdUnitNavigationId" },
                values: new object[] { 1, 0, null });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "Id_Question", "HtmlText", "QuestionText" },
                values: new object[] { 1, null, "CSS" });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id_Tag", "Name" },
                values: new object[] { 1, "CSS" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id_Unit", "Name" },
                values: new object[] { 1, "CSS" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 1, "ilivocs@gmail.com", "Oksana", "Iliv", "_Aa123456", "0123456789", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 2, "turyanmykh@gmail.com", "Mykhailo", "Turianskyi", "_Aa123456", "1234567890", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 3, "stasenoleks@gmail.com", "Oleksandr", "Stasenko", "_Aa123456", "2345678901", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 4, "pynzynyura@gmail.com", "Yurii", "Pynzyn", "_Aa123456", "3456789012", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 5, "hladyoandr@gmail.com", "Andrii", "Hlado", "_Aa123456", "4567890123", "User" });

            migrationBuilder.InsertData(
                table: "TagDistributions",
                columns: new[] { "Id_TagDistribution", "IdMetadata", "IdTag" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "TaskResults",
                columns: new[] { "Id_TaskResult", "LevelId", "Score", "TaskCount", "UserId" },
                values: new object[] { 3, 2, 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "TaskResults",
                columns: new[] { "Id_TaskResult", "LevelId", "Score", "TaskCount", "UserId" },
                values: new object[] { 1, 1, 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "TaskResults",
                columns: new[] { "Id_TaskResult", "LevelId", "Score", "TaskCount", "UserId" },
                values: new object[] { 2, 2, 1, 2, 3 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id_Task", "Description", "LevelId", "MetadataId", "QuestionId" },
                values: new object[] { 1, "Level 1 Task 1", 1, null, null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id_Task", "Description", "LevelId", "MetadataId", "QuestionId" },
                values: new object[] { 3, "Level 1 Task 1", 2, null, null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id_Task", "Description", "LevelId", "MetadataId", "QuestionId" },
                values: new object[] { 2, "Level 1 Task 2", 1, null, null });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id_Task", "Description", "LevelId", "MetadataId", "QuestionId" },
                values: new object[] { 4, "Level 1 Task 2", 2, null, null });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 1, 1, null, 1, "Need to learn margin", new DateTime(2020, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task1 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 2, 2, null, 1, "Need to learn padding", new DateTime(2020, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task2 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 3, 3, null, 1, "Need to learn border", new DateTime(2020, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task3 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 5, 5, null, 1, "Need to learn tables", new DateTime(2020, 12, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task5 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 6, 1, null, 2, "Need to learn position", new DateTime(2020, 12, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task1 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 7, 2, null, 2, "Need to learn float", new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task2 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 8, 3, null, 2, "Need to learn align", new DateTime(2020, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task3 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 9, 4, null, 2, "Need to learn opacity", new DateTime(2020, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task4 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 10, 5, null, 2, "Need to learn forms", new DateTime(2020, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task5 Achivement" });

            migrationBuilder.InsertData(
                table: "UserAchievements",
                columns: new[] { "Id_UserAchievement", "IdLevel", "IdLevelNavigationId", "IdUser", "Notes", "SaveDate", "Title" },
                values: new object[] { 4, 4, null, 1, "Need to learn links", new DateTime(2020, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Task4 Achivement" });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 12, 27, 24, 48, 4, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 14, 26, 23, 46, 5, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 15, 29, 26, 52, 5, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 16, 16, 11, 22, 6, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 17, 19, 14, 28, 6, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 18, 22, 17, 34, 6, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 19, 18, 13, 26, 7, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 20, 21, 16, 32, 7, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 21, 24, 19, 38, 7, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 22, 20, 15, 30, 8, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 23, 23, 18, 36, 8, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 24, 26, 21, 42, 8, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 25, 22, 17, 34, 9, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 26, 25, 20, 40, 9, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 27, 28, 23, 46, 9, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 28, 24, 19, 38, 10, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 13, 23, 20, 40, 5, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 29, 27, 22, 44, 10, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 30, 30, 25, 50, 10, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 10, 21, 18, 36, 4, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 1, 15, 12, 24, 1, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 11, 24, 21, 42, 4, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 3, 21, 18, 36, 1, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 4, 17, 14, 28, 2, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 2, 18, 15, 30, 1, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 6, 23, 20, 40, 2, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 7, 19, 16, 32, 3, 1 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 8, 22, 19, 38, 3, 2 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 9, 25, 22, 44, 3, 3 });

            migrationBuilder.InsertData(
                table: "AchievementDatas",
                columns: new[] { "Id_AchievementData", "CompletedCount", "CorrectCount", "CurrentMark", "IdUserAchievement", "TryCount" },
                values: new object[] { 5, 20, 17, 34, 2, 2 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "EtalonAnswer", "TaskId" },
                values: new object[] { 4, "Answer 4", 4 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "EtalonAnswer", "TaskId" },
                values: new object[] { 7, "Answer 7", 3 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "EtalonAnswer", "TaskId" },
                values: new object[] { 3, "Answer 3", 3 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "EtalonAnswer", "TaskId" },
                values: new object[] { 6, "Answer 6", 2 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "EtalonAnswer", "TaskId" },
                values: new object[] { 2, "Answer 2", 2 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "EtalonAnswer", "TaskId" },
                values: new object[] { 5, "Answer 5", 1 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "EtalonAnswer", "TaskId" },
                values: new object[] { 1, "Answer 1", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_AchievementDatas_IdUserAchievement",
                table: "AchievementDatas",
                column: "IdUserAchievement");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TaskId",
                table: "Answers",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Hints_IdTaskNavigationId",
                table: "Hints",
                column: "IdTaskNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Metadatas_IdUnitNavigationId",
                table: "Metadatas",
                column: "IdUnitNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_TagDistributions_IdMetadata",
                table: "TagDistributions",
                column: "IdMetadata");

            migrationBuilder.CreateIndex(
                name: "IX_TagDistributions_IdTag",
                table: "TagDistributions",
                column: "IdTag");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDistributions_IdLevelNavigationId",
                table: "TaskDistributions",
                column: "IdLevelNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskDistributions_IdTaskNavigationId",
                table: "TaskDistributions",
                column: "IdTaskNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResults_LevelId",
                table: "TaskResults",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskResults_UserId",
                table: "TaskResults",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_LevelId",
                table: "Tasks",
                column: "LevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MetadataId",
                table: "Tasks",
                column: "MetadataId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_QuestionId",
                table: "Tasks",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_IdLevelNavigationId",
                table: "UserAchievements",
                column: "IdLevelNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAchievements_IdUser",
                table: "UserAchievements",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AchievementDatas");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Hints");

            migrationBuilder.DropTable(
                name: "TagDistributions");

            migrationBuilder.DropTable(
                name: "TaskDistributions");

            migrationBuilder.DropTable(
                name: "TaskResults");

            migrationBuilder.DropTable(
                name: "UserAchievements");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Levels");

            migrationBuilder.DropTable(
                name: "Metadatas");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Units");
        }
    }
}
