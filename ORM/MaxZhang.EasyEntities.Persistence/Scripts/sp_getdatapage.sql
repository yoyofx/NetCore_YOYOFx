CREATE procedure [dbo].[sp_getdatapage] 
@PageIndex         int, 
@PageSize      int, 
@TableName    nvarchar(4000), 
@Where     nvarchar(max)='', 
@id        nvarchar(10)
as 
Declare @rowcount    int 
Declare @intStart    int 
Declare @intEnd         int 
Declare @SQl nvarchar(max), @WhereR nvarchar(max), @OrderBy nvarchar(max) 
set @rowcount=0 
set nocount on 
if @Where<>'' 
begin 
set @Where=' and '+@Where 
end 
if CHARINDEX('order by', @Where)>0 
begin 
set @WhereR=substring(@Where, 1, CHARINDEX('order by',@Where)-1) --ȡ������ 
set @OrderBy=substring(@Where, CHARINDEX('order by',@Where), Len(@Where)) --ȡ������ʽ(order by �ֶ� ��ʽ) 
end 
else 
begin 
set @WhereR=@Where 
set @OrderBy=' order by ' + @id + ' asc' 
end 
set @SQl='SELECT @rowcount=count(*) from '+cast(@TableName as varchar(4000))+' where 1=1 '+@WhereR 
exec sp_executeSql @SQl,N'@rowcount int output',@rowcount output 
if @PageIndex=0 and @PageSize=0 --�����з�ҳ,��ѯ���������б� 
begin 
set @SQl='SELECT * from '+cast(@TableName as varchar(4000))+' where 1=1 '+@Where 
end 
else --���з�ҳ��ѯ�����б� 
begin 
set @intStart=(@PageIndex-1)*@PageSize+1; 
set @intEnd=@intStart+@PageSize-1 
set @SQl='select * from(select *,ROW_NUMBER() OVER('+cast(@OrderBy as nvarchar(400))+') as row from ' 
set @SQl=@SQL+@TableName+' where 1=1 '+@WhereR+') as a where row between '+cast(@intStart as varchar)+' and '+cast(@intEnd as varchar) 
end 
exec sp_executeSql @SQl 
return @rowcount 
set nocount off
GO

