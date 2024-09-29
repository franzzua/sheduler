﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#pragma warning disable 219, 612, 618
#nullable disable

namespace Sheduler.Storage.Db.Gen
{
    public partial class ScheduleContextModel
    {
        partial void Initialize()
        {
            var invokeEntity = InvokeEntityEntityType.Create(this);
            var scheduleEntity = ScheduleEntityEntityType.Create(this);
            var taskEntity = TaskEntityEntityType.Create(this);

            InvokeEntityEntityType.CreateForeignKey1(invokeEntity, scheduleEntity);
            TaskEntityEntityType.CreateForeignKey1(taskEntity, scheduleEntity);

            InvokeEntityEntityType.CreateAnnotations(invokeEntity);
            ScheduleEntityEntityType.CreateAnnotations(scheduleEntity);
            TaskEntityEntityType.CreateAnnotations(taskEntity);

            AddAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
            AddAnnotation("ProductVersion", "8.0.8");
            AddAnnotation("Relational:MaxIdentifierLength", 63);
            AddRuntimeAnnotation("Relational:RelationalModel", CreateRelationalModel());
        }

        private IRelationalModel CreateRelationalModel()
        {
            var relationalModel = new RelationalModel(this);

            var invokeEntity = FindEntityType("Sheduler.Storage.Db.InvokeEntity")!;

            var defaultTableMappings = new List<TableMappingBase<ColumnMappingBase>>();
            invokeEntity.SetRuntimeAnnotation("Relational:DefaultMappings", defaultTableMappings);
            var shedulerStorageDbInvokeEntityTableBase = new TableBase("Sheduler.Storage.Db.InvokeEntity", null, relationalModel);
            var dateTimeColumnBase = new ColumnBase<ColumnMappingBase>("DateTime", "timestamp with time zone", shedulerStorageDbInvokeEntityTableBase);
            shedulerStorageDbInvokeEntityTableBase.Columns.Add("DateTime", dateTimeColumnBase);
            var idColumnBase = new ColumnBase<ColumnMappingBase>("Id", "text", shedulerStorageDbInvokeEntityTableBase);
            shedulerStorageDbInvokeEntityTableBase.Columns.Add("Id", idColumnBase);
            var scheduleIdColumnBase = new ColumnBase<ColumnMappingBase>("ScheduleId", "text", shedulerStorageDbInvokeEntityTableBase);
            shedulerStorageDbInvokeEntityTableBase.Columns.Add("ScheduleId", scheduleIdColumnBase);
            relationalModel.DefaultTables.Add("Sheduler.Storage.Db.InvokeEntity", shedulerStorageDbInvokeEntityTableBase);
            var shedulerStorageDbInvokeEntityMappingBase = new TableMappingBase<ColumnMappingBase>(invokeEntity, shedulerStorageDbInvokeEntityTableBase, true);
            shedulerStorageDbInvokeEntityTableBase.AddTypeMapping(shedulerStorageDbInvokeEntityMappingBase, false);
            defaultTableMappings.Add(shedulerStorageDbInvokeEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)idColumnBase, invokeEntity.FindProperty("Id")!, shedulerStorageDbInvokeEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)dateTimeColumnBase, invokeEntity.FindProperty("DateTime")!, shedulerStorageDbInvokeEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)scheduleIdColumnBase, invokeEntity.FindProperty("ScheduleId")!, shedulerStorageDbInvokeEntityMappingBase);

            var tableMappings = new List<TableMapping>();
            invokeEntity.SetRuntimeAnnotation("Relational:TableMappings", tableMappings);
            var invokesTable = new Table("Invokes", null, relationalModel);
            var idColumn = new Column("Id", "text", invokesTable);
            invokesTable.Columns.Add("Id", idColumn);
            var dateTimeColumn = new Column("DateTime", "timestamp with time zone", invokesTable);
            invokesTable.Columns.Add("DateTime", dateTimeColumn);
            var scheduleIdColumn = new Column("ScheduleId", "text", invokesTable);
            invokesTable.Columns.Add("ScheduleId", scheduleIdColumn);
            var pK_Invokes = new UniqueConstraint("PK_Invokes", invokesTable, new[] { idColumn });
            invokesTable.PrimaryKey = pK_Invokes;
            var pK_InvokesUc = RelationalModel.GetKey(this,
                "Sheduler.Storage.Db.InvokeEntity",
                new[] { "Id" });
            pK_Invokes.MappedKeys.Add(pK_InvokesUc);
            RelationalModel.GetOrCreateUniqueConstraints(pK_InvokesUc).Add(pK_Invokes);
            invokesTable.UniqueConstraints.Add("PK_Invokes", pK_Invokes);
            var iX_Invokes_ScheduleId = new TableIndex(
            "IX_Invokes_ScheduleId", invokesTable, new[] { scheduleIdColumn }, true);
            var iX_Invokes_ScheduleIdIx = RelationalModel.GetIndex(this,
                "Sheduler.Storage.Db.InvokeEntity",
                new[] { "ScheduleId" });
            iX_Invokes_ScheduleId.MappedIndexes.Add(iX_Invokes_ScheduleIdIx);
            RelationalModel.GetOrCreateTableIndexes(iX_Invokes_ScheduleIdIx).Add(iX_Invokes_ScheduleId);
            invokesTable.Indexes.Add("IX_Invokes_ScheduleId", iX_Invokes_ScheduleId);
            relationalModel.Tables.Add(("Invokes", null), invokesTable);
            var invokesTableMapping = new TableMapping(invokeEntity, invokesTable, true);
            invokesTable.AddTypeMapping(invokesTableMapping, false);
            tableMappings.Add(invokesTableMapping);
            RelationalModel.CreateColumnMapping(idColumn, invokeEntity.FindProperty("Id")!, invokesTableMapping);
            RelationalModel.CreateColumnMapping(dateTimeColumn, invokeEntity.FindProperty("DateTime")!, invokesTableMapping);
            RelationalModel.CreateColumnMapping(scheduleIdColumn, invokeEntity.FindProperty("ScheduleId")!, invokesTableMapping);

            var scheduleEntity = FindEntityType("Sheduler.Storage.Db.ScheduleEntity")!;

            var defaultTableMappings0 = new List<TableMappingBase<ColumnMappingBase>>();
            scheduleEntity.SetRuntimeAnnotation("Relational:DefaultMappings", defaultTableMappings0);
            var shedulerStorageDbScheduleEntityTableBase = new TableBase("Sheduler.Storage.Db.ScheduleEntity", null, relationalModel);
            var descriptionColumnBase = new ColumnBase<ColumnMappingBase>("Description", "text", shedulerStorageDbScheduleEntityTableBase)
            {
                IsNullable = true
            };
            shedulerStorageDbScheduleEntityTableBase.Columns.Add("Description", descriptionColumnBase);
            var idColumnBase0 = new ColumnBase<ColumnMappingBase>("Id", "text", shedulerStorageDbScheduleEntityTableBase);
            shedulerStorageDbScheduleEntityTableBase.Columns.Add("Id", idColumnBase0);
            var nameColumnBase = new ColumnBase<ColumnMappingBase>("Name", "text", shedulerStorageDbScheduleEntityTableBase);
            shedulerStorageDbScheduleEntityTableBase.Columns.Add("Name", nameColumnBase);
            relationalModel.DefaultTables.Add("Sheduler.Storage.Db.ScheduleEntity", shedulerStorageDbScheduleEntityTableBase);
            var shedulerStorageDbScheduleEntityMappingBase = new TableMappingBase<ColumnMappingBase>(scheduleEntity, shedulerStorageDbScheduleEntityTableBase, true);
            shedulerStorageDbScheduleEntityTableBase.AddTypeMapping(shedulerStorageDbScheduleEntityMappingBase, false);
            defaultTableMappings0.Add(shedulerStorageDbScheduleEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)idColumnBase0, scheduleEntity.FindProperty("Id")!, shedulerStorageDbScheduleEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)descriptionColumnBase, scheduleEntity.FindProperty("Description")!, shedulerStorageDbScheduleEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)nameColumnBase, scheduleEntity.FindProperty("Name")!, shedulerStorageDbScheduleEntityMappingBase);

            var tableMappings0 = new List<TableMapping>();
            scheduleEntity.SetRuntimeAnnotation("Relational:TableMappings", tableMappings0);
            var schedulesTable = new Table("Schedules", null, relationalModel);
            var idColumn0 = new Column("Id", "text", schedulesTable);
            schedulesTable.Columns.Add("Id", idColumn0);
            var descriptionColumn = new Column("Description", "text", schedulesTable)
            {
                IsNullable = true
            };
            schedulesTable.Columns.Add("Description", descriptionColumn);
            var nameColumn = new Column("Name", "text", schedulesTable);
            schedulesTable.Columns.Add("Name", nameColumn);
            var pK_Schedules = new UniqueConstraint("PK_Schedules", schedulesTable, new[] { idColumn0 });
            schedulesTable.PrimaryKey = pK_Schedules;
            var pK_SchedulesUc = RelationalModel.GetKey(this,
                "Sheduler.Storage.Db.ScheduleEntity",
                new[] { "Id" });
            pK_Schedules.MappedKeys.Add(pK_SchedulesUc);
            RelationalModel.GetOrCreateUniqueConstraints(pK_SchedulesUc).Add(pK_Schedules);
            schedulesTable.UniqueConstraints.Add("PK_Schedules", pK_Schedules);
            relationalModel.Tables.Add(("Schedules", null), schedulesTable);
            var schedulesTableMapping = new TableMapping(scheduleEntity, schedulesTable, true);
            schedulesTable.AddTypeMapping(schedulesTableMapping, false);
            tableMappings0.Add(schedulesTableMapping);
            RelationalModel.CreateColumnMapping(idColumn0, scheduleEntity.FindProperty("Id")!, schedulesTableMapping);
            RelationalModel.CreateColumnMapping(descriptionColumn, scheduleEntity.FindProperty("Description")!, schedulesTableMapping);
            RelationalModel.CreateColumnMapping(nameColumn, scheduleEntity.FindProperty("Name")!, schedulesTableMapping);

            var taskEntity = FindEntityType("Sheduler.Storage.Db.TaskEntity")!;

            var defaultTableMappings1 = new List<TableMappingBase<ColumnMappingBase>>();
            taskEntity.SetRuntimeAnnotation("Relational:DefaultMappings", defaultTableMappings1);
            var shedulerStorageDbTaskEntityTableBase = new TableBase("Sheduler.Storage.Db.TaskEntity", null, relationalModel);
            var cronExpressionColumnBase = new ColumnBase<ColumnMappingBase>("CronExpression", "text", shedulerStorageDbTaskEntityTableBase);
            shedulerStorageDbTaskEntityTableBase.Columns.Add("CronExpression", cronExpressionColumnBase);
            var idColumnBase1 = new ColumnBase<ColumnMappingBase>("Id", "text", shedulerStorageDbTaskEntityTableBase);
            shedulerStorageDbTaskEntityTableBase.Columns.Add("Id", idColumnBase1);
            var lastInvocationColumnBase = new ColumnBase<ColumnMappingBase>("LastInvocation", "timestamp with time zone", shedulerStorageDbTaskEntityTableBase);
            shedulerStorageDbTaskEntityTableBase.Columns.Add("LastInvocation", lastInvocationColumnBase);
            var scheduleIdColumnBase0 = new ColumnBase<ColumnMappingBase>("ScheduleId", "text", shedulerStorageDbTaskEntityTableBase);
            shedulerStorageDbTaskEntityTableBase.Columns.Add("ScheduleId", scheduleIdColumnBase0);
            var urlColumnBase = new ColumnBase<ColumnMappingBase>("Url", "text", shedulerStorageDbTaskEntityTableBase);
            shedulerStorageDbTaskEntityTableBase.Columns.Add("Url", urlColumnBase);
            relationalModel.DefaultTables.Add("Sheduler.Storage.Db.TaskEntity", shedulerStorageDbTaskEntityTableBase);
            var shedulerStorageDbTaskEntityMappingBase = new TableMappingBase<ColumnMappingBase>(taskEntity, shedulerStorageDbTaskEntityTableBase, true);
            shedulerStorageDbTaskEntityTableBase.AddTypeMapping(shedulerStorageDbTaskEntityMappingBase, false);
            defaultTableMappings1.Add(shedulerStorageDbTaskEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)idColumnBase1, taskEntity.FindProperty("Id")!, shedulerStorageDbTaskEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)cronExpressionColumnBase, taskEntity.FindProperty("CronExpression")!, shedulerStorageDbTaskEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)lastInvocationColumnBase, taskEntity.FindProperty("LastInvocation")!, shedulerStorageDbTaskEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)scheduleIdColumnBase0, taskEntity.FindProperty("ScheduleId")!, shedulerStorageDbTaskEntityMappingBase);
            RelationalModel.CreateColumnMapping((ColumnBase<ColumnMappingBase>)urlColumnBase, taskEntity.FindProperty("Url")!, shedulerStorageDbTaskEntityMappingBase);

            var tableMappings1 = new List<TableMapping>();
            taskEntity.SetRuntimeAnnotation("Relational:TableMappings", tableMappings1);
            var tasksTable = new Table("Tasks", null, relationalModel);
            var idColumn1 = new Column("Id", "text", tasksTable);
            tasksTable.Columns.Add("Id", idColumn1);
            var cronExpressionColumn = new Column("CronExpression", "text", tasksTable);
            tasksTable.Columns.Add("CronExpression", cronExpressionColumn);
            var lastInvocationColumn = new Column("LastInvocation", "timestamp with time zone", tasksTable);
            tasksTable.Columns.Add("LastInvocation", lastInvocationColumn);
            var scheduleIdColumn0 = new Column("ScheduleId", "text", tasksTable);
            tasksTable.Columns.Add("ScheduleId", scheduleIdColumn0);
            var urlColumn = new Column("Url", "text", tasksTable);
            tasksTable.Columns.Add("Url", urlColumn);
            var pK_Tasks = new UniqueConstraint("PK_Tasks", tasksTable, new[] { idColumn1 });
            tasksTable.PrimaryKey = pK_Tasks;
            var pK_TasksUc = RelationalModel.GetKey(this,
                "Sheduler.Storage.Db.TaskEntity",
                new[] { "Id" });
            pK_Tasks.MappedKeys.Add(pK_TasksUc);
            RelationalModel.GetOrCreateUniqueConstraints(pK_TasksUc).Add(pK_Tasks);
            tasksTable.UniqueConstraints.Add("PK_Tasks", pK_Tasks);
            var iX_Tasks_ScheduleId = new TableIndex(
            "IX_Tasks_ScheduleId", tasksTable, new[] { scheduleIdColumn0 }, false);
            var iX_Tasks_ScheduleIdIx = RelationalModel.GetIndex(this,
                "Sheduler.Storage.Db.TaskEntity",
                new[] { "ScheduleId" });
            iX_Tasks_ScheduleId.MappedIndexes.Add(iX_Tasks_ScheduleIdIx);
            RelationalModel.GetOrCreateTableIndexes(iX_Tasks_ScheduleIdIx).Add(iX_Tasks_ScheduleId);
            tasksTable.Indexes.Add("IX_Tasks_ScheduleId", iX_Tasks_ScheduleId);
            relationalModel.Tables.Add(("Tasks", null), tasksTable);
            var tasksTableMapping = new TableMapping(taskEntity, tasksTable, true);
            tasksTable.AddTypeMapping(tasksTableMapping, false);
            tableMappings1.Add(tasksTableMapping);
            RelationalModel.CreateColumnMapping(idColumn1, taskEntity.FindProperty("Id")!, tasksTableMapping);
            RelationalModel.CreateColumnMapping(cronExpressionColumn, taskEntity.FindProperty("CronExpression")!, tasksTableMapping);
            RelationalModel.CreateColumnMapping(lastInvocationColumn, taskEntity.FindProperty("LastInvocation")!, tasksTableMapping);
            RelationalModel.CreateColumnMapping(scheduleIdColumn0, taskEntity.FindProperty("ScheduleId")!, tasksTableMapping);
            RelationalModel.CreateColumnMapping(urlColumn, taskEntity.FindProperty("Url")!, tasksTableMapping);
            var fK_Invokes_Schedules_ScheduleId = new ForeignKeyConstraint(
                "FK_Invokes_Schedules_ScheduleId", invokesTable, schedulesTable,
                new[] { scheduleIdColumn },
                schedulesTable.FindUniqueConstraint("PK_Schedules")!, ReferentialAction.Cascade);
            var fK_Invokes_Schedules_ScheduleIdFk = RelationalModel.GetForeignKey(this,
                "Sheduler.Storage.Db.InvokeEntity",
                new[] { "ScheduleId" },
                "Sheduler.Storage.Db.ScheduleEntity",
                new[] { "Id" });
            fK_Invokes_Schedules_ScheduleId.MappedForeignKeys.Add(fK_Invokes_Schedules_ScheduleIdFk);
            RelationalModel.GetOrCreateForeignKeyConstraints(fK_Invokes_Schedules_ScheduleIdFk).Add(fK_Invokes_Schedules_ScheduleId);
            invokesTable.ForeignKeyConstraints.Add(fK_Invokes_Schedules_ScheduleId);
            schedulesTable.ReferencingForeignKeyConstraints.Add(fK_Invokes_Schedules_ScheduleId);
            var fK_Tasks_Schedules_ScheduleId = new ForeignKeyConstraint(
                "FK_Tasks_Schedules_ScheduleId", tasksTable, schedulesTable,
                new[] { scheduleIdColumn0 },
                schedulesTable.FindUniqueConstraint("PK_Schedules")!, ReferentialAction.Cascade);
            var fK_Tasks_Schedules_ScheduleIdFk = RelationalModel.GetForeignKey(this,
                "Sheduler.Storage.Db.TaskEntity",
                new[] { "ScheduleId" },
                "Sheduler.Storage.Db.ScheduleEntity",
                new[] { "Id" });
            fK_Tasks_Schedules_ScheduleId.MappedForeignKeys.Add(fK_Tasks_Schedules_ScheduleIdFk);
            RelationalModel.GetOrCreateForeignKeyConstraints(fK_Tasks_Schedules_ScheduleIdFk).Add(fK_Tasks_Schedules_ScheduleId);
            tasksTable.ForeignKeyConstraints.Add(fK_Tasks_Schedules_ScheduleId);
            schedulesTable.ReferencingForeignKeyConstraints.Add(fK_Tasks_Schedules_ScheduleId);
            return relationalModel.MakeReadOnly();
        }
    }
}
