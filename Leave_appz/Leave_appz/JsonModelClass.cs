using System;
namespace Leave_appz
{
    public class JsonModelClass
    {
        
        public class UserDataModel
        {
            public string email_id { get; set; }
            public string user_password { get; set; }
            public string push_notification_id { get; set; }
            public string user_status { get; set; }
            public string user_type { get; set; }
        }

        public class UserLeaveCountModel
        {
            public string leave_count { get; set; }
        }

    }
}
