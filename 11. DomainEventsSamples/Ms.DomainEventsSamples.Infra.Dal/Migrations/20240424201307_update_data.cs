﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ms.DomainEventsSamples.Infra.Dal.Migrations
{
    /// <inheritdoc />
    public partial class update_data : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OutBoxEventItems",
                columns: table => new
                {
                    OutBoxEventItemId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccuredByUserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AccuredOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AggregateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AggregateTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AggregateId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EventPayload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsProcessed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutBoxEventItems", x => x.OutBoxEventItemId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OutBoxEventItems");
        }
    }
}
