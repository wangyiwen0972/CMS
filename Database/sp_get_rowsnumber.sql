set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


-- Add a row into the "MSagent_parameters" table
Create procedure [CMS].[sp_get_rowsnumber] (
    @table_name nvarchar(255),
	@column_name nvarchar(255)
)
as
	declare @row_number int
	if exists(SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[' +@table_name]+']')AND type in (N'U'))
	begin
		select @row_number =  max(ROW_NUMBER() OVER (order by @column_name)) from employee
	end

return @row_number