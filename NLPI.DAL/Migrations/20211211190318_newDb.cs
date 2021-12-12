using Microsoft.EntityFrameworkCore.Migrations;

namespace NLPI.DAL.Migrations
{
    public partial class newDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TaskTypes",
                columns: table => new
                {
                    Id_TaskType = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<string>(type: "TEXT", unicode: false, maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTaskType", x => x.Id_TaskType);
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
                name: "UserTaskResults",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Score = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id_Task = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    TaskTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("XPKTask", x => x.Id_Task);
                    table.ForeignKey(
                        name: "FK_Tasks_TaskTypes_TaskTypeId",
                        column: x => x.TaskTypeId,
                        principalTable: "TaskTypes",
                        principalColumn: "Id_TaskType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id_Answer = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TaskId = table.Column<int>(type: "INTEGER", nullable: false),
                    TextAnswer = table.Column<string>(type: "TEXT", unicode: false, nullable: true),
                    IsCorrect = table.Column<bool>(type: "INTEGER", nullable: false),
                    CorrectPosition = table.Column<int>(type: "INTEGER", nullable: true),
                    TestTaskId = table.Column<int>(type: "INTEGER", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_Answers_Tasks_TestTaskId",
                        column: x => x.TestTaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id_Task",
                        onDelete: ReferentialAction.Restrict);
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
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Position = table.Column<int>(type: "INTEGER", nullable: false),
                    IsCorrectAndInRightPosition = table.Column<bool>(type: "INTEGER", nullable: false),
                    AnswerId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserResultId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id_Answer",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAnswers_UserTaskResults_UserResultId",
                        column: x => x.UserResultId,
                        principalTable: "UserTaskResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hints",
                columns: new[] { "Id_Hint", "HintText", "HintType", "IdTask", "IdTaskNavigationId" },
                values: new object[] { 1, "CSS", "CSS", 1, null });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id_TaskType", "Type" },
                values: new object[] { 1, "Testing type clasification" });

            migrationBuilder.InsertData(
                table: "TaskTypes",
                columns: new[] { "Id_TaskType", "Type" },
                values: new object[] { 2, "Test case creation" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 1, "admin@gmail.com", "Admin", "Admin", "12345", "0123456789", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 2, "student@gmail.com", "Student", "Student", "12345", "1234567890", "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id_User", "Email", "FirstName", "LastName", "Password", "Phone", "Role" },
                values: new object[] { 3, "nripey@gmail.com", "Nazar", "Ripey", "12345", "2345678901", "User" });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id_Task", "Description", "Name", "TaskTypeId" },
                values: new object[] { 1, "Owner wants to make his web-app compatible with other actual browsers and OS.", "Crossplatform test classification", 1 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id_Task", "Description", "Name", "TaskTypeId" },
                values: new object[] { 2, "Check if link with password recovery in auto email is working correctly.", "Password recovery test case", 2 });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 1, 4, true, 1, null, "Compatibility Testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 16, 2, true, 2, null, "Click on link «Forgot your password ?»" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 15, null, false, 2, null, "Return on main page" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 14, 4, true, 2, null, "Check that email for a new letter with link" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 13, 3, true, 2, null, "Type in field valid account’s email" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 12, 5, true, 2, null, "Validate that link is working correctly" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 11, null, false, 2, null, "Type in field incorrect email" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 10, null, false, 1, null, "Safety testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 9, 3, true, 1, null, "Regression Testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 8, null, false, 1, null, "New feature testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 7, null, false, 1, null, "Accessibility testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 6, 1, true, 1, null, "Smoke testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 5, null, false, 1, null, "GUI testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 4, null, false, 1, null, "Installability testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 3, 2, true, 1, null, "Defect Validation" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 2, null, false, 1, null, "Volume testing" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 17, 1, true, 2, null, "Open Log In page(Log out if necessary)" });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "Id_Answer", "CorrectPosition", "IsCorrect", "TaskId", "TestTaskId", "TextAnswer" },
                values: new object[] { 18, null, false, 2, null, "Log In system / or check that you are in" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TaskId",
                table: "Answers",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_TestTaskId",
                table: "Answers",
                column: "TestTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Hints_IdTaskNavigationId",
                table: "Hints",
                column: "IdTaskNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_TaskTypeId",
                table: "Tasks",
                column: "TaskTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_UserResultId",
                table: "UserAnswers",
                column: "UserResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hints");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "UserTaskResults");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "TaskTypes");
        }
    }
}
