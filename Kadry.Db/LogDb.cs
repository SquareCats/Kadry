using System;

namespace Kadry.Db
{
    public class LogDb : MyEntity
    {
        public LogActivitiesDb Activity { get; set; }
        public DateTime ActivityTime { get; set; }
        public string Host { get; set; }
        public string Details { get; set; }
    }
}
