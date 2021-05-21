namespace Kadry.Web.Business.Commands
{
    public class Command
    {
        public bool IsError { get; set; }
        public string CommandError { get; set; }
        public long OperationId { get; set; }
        public string Host { get; set; }
        public int RowsAffected { get; set; }
    }
}
