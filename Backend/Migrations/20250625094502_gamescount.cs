using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class gamescount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE [dbo].[GetRank]
                        (
                            @Id uniqueidentifier = null
                        )
                        AS
                        BEGIN
                            SET NOCOUNT ON
                            ;WITH NumberedRows
                            AS(SELECT ROW_NUMBER() OVER(ORDER BY Elo desc) AS Rank, id, elo
                            FROM Users)
                            select Rank from NumberedRows where id = @Id
                        END";

            migrationBuilder.Sql(sp);


            var insertGuest = $"INSERT INTO [dbo].[Users] ([Id],[EmailUnsubscribeId],[Name],[ShowPhoto],[Email],[PhotoUrl],[ProviderId],[SocialProvider],[Elo],[GameCount],[PassHash],[Gold],[LastFreeGold],[Admin],[MuteIntro],[EmailNotifications]) VALUES('{Guid.Empty}', '{Guid.Empty}', 'Guest', 'FALSE', '', '', '', '', 1200, 0, 0, 0, GETDATE(), 'FALSE', 'FALSE', 'FALSE')";
            migrationBuilder.Sql(insertGuest);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
