using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Migrations
{
    public partial class addProcedure1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"
					USE [ContactManager]
					GO
					/****** Object:  StoredProcedure [dbo].[Glb_Sp_GetContactInfo]    Script Date: 10/19/2021 6:47:52 PM ******/
					SET ANSI_NULLS ON
					GO
					SET QUOTED_IDENTIFIER ON
					GO
					-- =============================================
					-- Author:		<MILAD AFSARI>
					-- Create date: <2021/18/10>
					-- Description:	<Show Contact Information>
					-- =============================================

					CREATE PROCEDURE [dbo].[Glb_Sp_GetContactInfo] 
						@Id INT
						,@ErrorCode INT OUT
						,@ErrorMessage NVARCHAR(250) OUT
					AS
					BEGIN
						-------------------------------
						SET @ErrorCode = 0
						SET @ErrorMessage = NULL
						-------------------------------
						SET NOCOUNT ON;

						SELECT
							C.Name
							,C.Family
							,C.Phone
							,C.Email
							,C.Address
						FROM
							dbo.Contacts C
						WHERE
							@Id IS NULL OR C.Id = @Id
					END";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			var dropProcSql = "DROP PROC Glb_Sp_GetContactInfo";
			migrationBuilder.Sql(dropProcSql);
		}
    }
}
