using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class StatementGenerator
    {
        public static string SaveStatement(int housekeeperOid, string housekeeperName, DateTime)
        {
            var report = new HousekeeperStatementReport(housekeeperOid, statementDate);

            if (!report.HasData)
                return string.Empty;

            report.CreateDocument();

            var filename = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),

                string.Format("Sandpiper Statement {0:yyyy-MM} {1}.pdf", StatementDate, housekeeperName)

            report.ExportToPdf(filename);
            return filename;
        }
    }
}
