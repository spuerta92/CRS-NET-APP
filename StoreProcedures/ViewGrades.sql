USE [CRS]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER OFF
GO

CREATE PROCEDURE [dbo].[crs_student_view_grades](
	@StudentId INT
)
AS
BEGIN
	SET NOCOUNT ON
	SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED

	BEGIN TRY
		SELECT rc.CourseId, c.CourseName, rc.Grade
		FROM [dbo].[RegisteredCourses] rc
		JOIN [dbo].[Courses] c
		ON rc.CourseId = c.CourseId
		WHERE rc.StudentId = @StudentId
	END TRY

	BEGIN CATCH
		DECLARE @ErrorMessage NVARCHAR(4000);
		DECLARE @ErrorSeverity INT;
		DECLARE @ErrorState INT;

		SELECT
		@ErrorMessage = ERROR_MESSAGE(),
		@ErrorSeverity = ERROR_SEVERITY(),
		@ErrorState = ERROR_STATE();

		print ERROR_LINE()

		IF @ErrorState < 1
		SET @ErrorState = 1

		RAISERROR(@ErrorMessage,@ErrorSeverity,@ErrorState)
	END CATCH
END