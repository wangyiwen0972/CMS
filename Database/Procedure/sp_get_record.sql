USE [CMS]
GO

/****** Object:  StoredProcedure [dbo].[sp_get_record]    Script Date: 2014/2/7 16:38:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[sp_get_record]
@TableName varchar(50), --表名 
@Fields varchar(5000) = '*', --字段名(全部字段为*) 
@OrderField varchar(5000), --排序字段(必须!支持多字段) 
@sqlWhere varchar(5000) = Null,--条件语句(不用加where) 
@pageSize int, --每页多少条记录 
@pageIndex int = 1 , --指定当前为第几页 
@TotalPage int output, --返回条数 
@OrderType bit -- 设置排序类型,1 升序 0 值则降序 
as 
begin 
declare @strOrder varchar(400) -- 排序类型 

Begin Tran --开始事务 
Declare @sql nvarchar(4000); 
Declare @totalRecord int; 
--计算总记录数 
if (@SqlWhere ='''' or @SqlWhere='' or @sqlWhere is NULL) 
set @sql = 'select @totalRecord = count(*) from ' + @TableName 
else 
set @sql = 'select @totalRecord = count(*) from ' + @TableName + ' where ' + @sqlWhere 
EXEC sp_executesql @sql,N'@totalRecord int OUTPUT',@totalRecord OUTPUT--计算总记录数 

--计算总页数 

select @TotalPage=@totalRecord --CEILING((@totalRecord+0.0)/@PageSize) 

if @OrderType = 0 
begin 
set @strOrder = ' order by [' + @OrderField +'] desc' 
--如果@OrderType是0，就执行降序，这句很重要！ 
end 
else 
begin 
set @strOrder = ' order by [' + @OrderField +'] asc' 
end 

if (@SqlWhere ='''' or @SqlWhere='' or @sqlWhere is NULL) 
set @sql = 'Select * FROM (select ROW_NUMBER() Over( '+@strOrder+' ) as rowId,' + @Fields + ' from ' + @TableName 
else 
set @sql = 'Select * FROM (select ROW_NUMBER() Over( '+@strOrder+' ) as rowId,' + @Fields + ' from ' + @TableName + ' where ' + @SqlWhere 
--处理页数超出范围情况 
if @PageIndex<=0 
Set @pageIndex = 1 

if @pageIndex>@TotalPage 
Set @pageIndex = @TotalPage 

--处理开始点和结束点 
Declare @StartRecord int 
Declare @EndRecord int 

set @StartRecord = (@pageIndex-1)*@PageSize + 1 
set @EndRecord = @StartRecord + @pageSize - 1 

if @OrderType = 0 
begin 
set @strOrder = ' order by rowid desc' 
--如果@OrderType是0，就执行降序，这句很重要！ 
end 
else 
begin 
set @strOrder = ' order by rowid asc' 
end 
--继续合成sql语句 
set @Sql = @Sql + ') as ' + @TableName + ' where rowId between ' + Convert(varchar(50),@StartRecord) + ' and ' + Convert(varchar(50),@EndRecord) + ' '+@strOrder 
-- print @sql 
Exec(@Sql) 
--------------------------------------------------- 
If @@Error <> 0 
Begin 
RollBack Tran 
Return -1 
End 
Else 
Begin 
Commit Tran 
Return @totalRecord ---返回记录总数 
End 
end 

GO

