using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Oqtane.Databases.Interfaces;
using Oqtane.Migrations;
using Oqtane.Migrations.EntityBuilders;

namespace Lemcube.Module.LemModule.Migrations.EntityBuilders
{
    public class LemModuleEntityBuilder : AuditableBaseEntityBuilder<LemModuleEntityBuilder>
    {
        private const string _entityTableName = "LemcubeLemModule";
        private readonly PrimaryKey<LemModuleEntityBuilder> _primaryKey = new("PK_LemcubeLemModule", x => x.LemModuleId);
        private readonly ForeignKey<LemModuleEntityBuilder> _moduleForeignKey = new("FK_LemcubeLemModule_Module", x => x.ModuleId, "Module", "ModuleId", ReferentialAction.Cascade);

        public LemModuleEntityBuilder(MigrationBuilder migrationBuilder, IDatabase database) : base(migrationBuilder, database)
        {
            EntityTableName = _entityTableName;
            PrimaryKey = _primaryKey;
            ForeignKeys.Add(_moduleForeignKey);
        }

        protected override LemModuleEntityBuilder BuildTable(ColumnsBuilder table)
        {
            LemModuleId = AddAutoIncrementColumn(table,"LemModuleId");
            ModuleId = AddIntegerColumn(table,"ModuleId");
            Name = AddMaxStringColumn(table,"Name");
            AddAuditableColumns(table);
            return this;
        }

        public OperationBuilder<AddColumnOperation> LemModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> ModuleId { get; set; }
        public OperationBuilder<AddColumnOperation> Name { get; set; }
    }
}
