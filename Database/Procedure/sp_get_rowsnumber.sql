USE [CMS]
GO
/****** 对象:  StoredProcedure [dbo].[sp_get_rownumbers]    脚本日期: 02/17/2014 23:12:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_get_rownumbers] 
	-- Add the parameters for the stored procedure here
	@table_name nvarchar(255),
	@column_name nvarchar(255),
    @attribute_guid nvarchar(255) = null
AS
BEGIN
	DECLARE @cmd nvarchar(512)
	DECLARE @row_number nvarchar(512)

	DECLARE @column nvarchar(255)
	DECLARE @table nvarchar(255)
	DECLARE @attribute nvarchar(255)

	set @column = @column_name
	set @table = @table_name

	if not exists (select * from sys.sysobjects where name = @table_name)
	begin
      raiserror(15010,-1,-1,@table_name)
      return (1)
	end
	
	if @attribute_guid = null
	begin
		set @cmd = 'select @row_number = ROW_NUMBER() OVER (order by ' + @column_name +') from ' +@table_name
		
		exec sp_executesql @cmd,N'@row_number nvarchar(512) output', @row_number output
	end
	else
	begin
		set @cmd = 'select @row_number = ROW_NUMBER() OVER (order by ' + @column_name +') from ' +@table_name + ' where AttributeGuid = @attribute'
		--SET @attribute_guid = 'f43dbe54-c5df-4f26-99ee-2b1579b5f731'
		
		SET @attribute = @attribute_guid
		exec sp_executesql @cmd,N'@row_number nvarchar(512) output, @attribute nvarchar(255)', @row_number output,@attribute_guid
	end
	
	

	select @row_number
END


