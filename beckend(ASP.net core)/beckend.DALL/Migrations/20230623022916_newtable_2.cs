using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace beckend.DALL.Migrations
{
    /// <inheritdoc />
    public partial class newtable_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExercisesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shortName = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    groupMuscle = table.Column<int>(type: "integer", nullable: false),
                    groupExercises = table.Column<int>(type: "integer", nullable: false),
                    additionalGroupMuscle = table.Column<int[]>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExercisesDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "setWorckoutsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    WorkoutId = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setWorckoutsDb", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "workoutsDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TimeWorkout = table.Column<DateOnly>(type: "date", nullable: false),
                    ModifiedTimeWorkout = table.Column<DateOnly>(type: "date", nullable: false),
                    MainWork = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ExerciseId = table.Column<List<int>>(type: "integer[]", nullable: false),
                    SetWorckoutId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workoutsDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_workoutsDb_setWorckoutsDb_SetWorckoutId",
                        column: x => x.SetWorckoutId,
                        principalTable: "setWorckoutsDb",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PersonalExercisesDb",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    shortName = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    ExerciseId = table.Column<int>(type: "integer", nullable: false),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    Repetitions = table.Column<short>(type: "smallint", nullable: false),
                    Approaches = table.Column<short>(type: "smallint", nullable: false),
                    WorkoutId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalExercisesDb", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalExercisesDb_ExercisesDb_ExerciseId",
                        column: x => x.ExerciseId,
                        principalTable: "ExercisesDb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonalExercisesDb_workoutsDb_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "workoutsDb",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonalExercisesDb_ExerciseId",
                table: "PersonalExercisesDb",
                column: "ExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalExercisesDb_WorkoutId",
                table: "PersonalExercisesDb",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_workoutsDb_SetWorckoutId",
                table: "workoutsDb",
                column: "SetWorckoutId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonalExercisesDb");

            migrationBuilder.DropTable(
                name: "ExercisesDb");

            migrationBuilder.DropTable(
                name: "workoutsDb");

            migrationBuilder.DropTable(
                name: "setWorckoutsDb");
        }
    }
}
