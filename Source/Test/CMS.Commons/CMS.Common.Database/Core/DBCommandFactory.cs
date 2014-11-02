namespace CMS.Common.Database.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CMS.Common.Model;

    public class DBCommandFactory
    {
        private static DBCommandFactory factory = null;

        private const string UPDATECOMMAND = "update ";
        private const string DELETECOMMAND = "delete ";
        private const string INSERTCOMMAND = "insert into ";
        private const string SELECTCOMMAND = "select ";

        private const string WHERECOMMAND = "where ";

        private const string ORCONDITION = "or ";
        private const string ANDCONDITION = "and ";

        protected const string INSERTSENTENCE = INSERTCOMMAND + "{0} {1} values {2}";

        protected const string UPDATESENTENCE = UPDATECOMMAND + "{0} set {1}";

        protected const string SELECTSENTENCE = SELECTCOMMAND + "{0} from {1}";

        protected const string DELETESENTENCE = DELETECOMMAND + "from {0}";

        private DBCommandFactory() { }

        public static Base.BaseCommand CreateCommand(Type CommandType)
        {
            factory = new DBCommandFactory();

            Base.BaseCommand command = null;

            if (CommandType.FullName == "CMS.Common.Database.Core.InsertCommand")
            {
                command = factory.CreateInsertCommand();
            }
            else if (CommandType.FullName == "CMS.Common.Database.Core.UpdateCommand")
            {
                command = factory.CreateUpdateCommand();
            }
            else if (CommandType.FullName == "CMS.Common.Database.Core.SelectCommand")
            {
                command = factory.CreateSeleteCommand();
            }
            else if (CommandType.FullName == "CMS.Common.Database.Core.DeleteCommand")
            {
                command = factory.CreateDeleteCommand();
            }

            return command;
        }

        public static Base.BaseCommand ConvertToRollbackCommand(Base.BaseCommand[] commands)
        {
            return null;
        }

        private Base.BaseCommand CreateInsertCommand()
        {
            InsertCommand insert = new InsertCommand(INSERTSENTENCE);

            return insert;
        }

        private Base.BaseCommand CreateSeleteCommand()
        {
            SelectCommand insert = new SelectCommand(SELECTSENTENCE);

            return insert;
        }

        private Base.BaseCommand CreateUpdateCommand()
        {
            UpdateCommand insert = new UpdateCommand(UPDATESENTENCE);

            return insert;
        }

        private Base.BaseCommand CreateDeleteCommand()
        {
            DeleteCommand insert = new DeleteCommand(DELETESENTENCE);

            return insert;
        }
    }
}
