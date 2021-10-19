using Microsoft.EntityFrameworkCore.Migrations;

namespace Contact.Migrations
{
    public partial class addProcedure3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var createProcSql = @"
                USE [ContactManager]
                GO
                /****** Object:  StoredProcedure [dbo].[Glb_Sp_AddContactInfo]    Script Date: 10/19/2021 6:46:28 PM ******/
                SET ANSI_NULLS ON
                GO
                SET QUOTED_IDENTIFIER ON
                GO
                -- =============================================
                -- Author:		<MILAD AFSARI>
                -- Create date: <2021/18/10>
                -- Description:	<Add Contact Information>
                -- =============================================

                CREATE PROCEDURE [dbo].[Glb_Sp_AddContactInfo] 
	                @Name NVARCHAR(50)
	                ,@Family NVARCHAR(100)
	                ,@Email NVARCHAR(MAX)
	                ,@Address NVARCHAR(MAX)
	                ,@Phone NVARCHAR(11)
	                ,@ErrorCode INT OUT
	                ,@ErrorMessage NVARCHAR(250) OUT

                AS
                BEGIN
	                SET NOCOUNT ON;
		                -------------------------------
		                SET @ErrorCode = 0
		                SET @ErrorMessage = NULL
		                -------------------------------

	
	                INSERT INTO [dbo].[Contacts]
                        ([Name]
                        ,[Family]
                        ,[Email]
                        ,[Address]
                        ,[Phone])
                     VALUES
                        (@Name
                        ,@Family
                        ,@Email
                        ,@Address
                        ,@Phone)
                END";
            migrationBuilder.Sql(createProcSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var dropProcSql = "DROP PROC Glb_Sp_AddContactInfo";
            migrationBuilder.Sql(dropProcSql);
        }
    }
}
