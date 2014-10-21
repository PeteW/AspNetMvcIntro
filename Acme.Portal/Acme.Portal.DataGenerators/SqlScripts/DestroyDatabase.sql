--this file deletes all objects inside the database

--disable foreign keys
exec sp_msforeachtable @command1='alter table ? nocheck constraint all'

--disable triggers
exec sp_msforeachtable @command1='alter table ? disable trigger all'

--delete the data
exec sp_MSForEachTable @command1='IF OBJECTPROPERTY(object_id(''?''), ''TableHasForeignRef'') = 1 DELETE FROM ? else TRUNCATE TABLE ?'

while(exists(select 1 from INFORMATION_SCHEMA.TABLE_CONSTRAINTS where CONSTRAINT_TYPE='FOREIGN KEY'))
begin
       declare @sql nvarchar(2000)
       SELECT TOP 1 @sql=('ALTER TABLE ' + TABLE_SCHEMA + '.[' + TABLE_NAME
       + '] DROP CONSTRAINT [' + CONSTRAINT_NAME + ']')
       FROM information_schema.table_constraints
       WHERE CONSTRAINT_TYPE = 'FOREIGN KEY'
       exec (@sql)
end

exec sp_msforeachtable @command1 = 'drop table ?'


-- Delete all the stored proc's within the database
declare @procName varchar(500)

declare cur cursor
    for select [name] from sys.objects where type ='p'
    open cur

       fetch next from cur into @procName
       while @@fetch_status = 0
       begin
              exec('drop procedure ' + @procName)
              fetch next from cur into @procName
       end

close cur
deallocate cur


-- Delete all the views within the database
declare @viewName varchar(500)

declare cur cursor
    for select [name] from sys.objects where type ='v'
    open cur

       fetch next from cur into @viewName
       while @@fetch_status = 0
       begin
              exec('drop view ' + @viewName)
              fetch next from cur into @viewName
       end

close cur
deallocate cur


-- Delete all the user-defined types within the database
declare @typeName varchar(500)

declare cur cursor
    for select [name] from sys.table_types
    open cur

       fetch next from cur into @typeName
       while @@fetch_status = 0
       begin
              exec('DROP TYPE ' + @typeName)
              fetch next from cur into @typeName
       end

close cur
deallocate cur
