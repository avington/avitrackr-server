using System;
using System.Collections.Generic;
using MediatR;

namespace AviTrackr.Domain.Features.MyTasks.Commands
{
    public class AddUpdateMyTask
    {
        /*
         * {
  "identifier": "",
  "taskName": "",
  "taskDescription": "",
  "status": {
    "id": 1
  },
  "notifications": [
    {
      "notificationTiming": {
        "timingAmount": 15,
        "timingAmountType": "Minutes"
      },
      "notificationType": {
        "id": 1,
        "notificationTypeName": "Email"
      }
    }
  ],
  "expiresAt": null,
  "expiresAtTime": null
}
         */

        public class Command: IRequest
        {
            public Guid Identifier { get; set; }
            public string TaskName { get; set; }
            public string TaskDescription { get; set; }
            public StatusModel Status { get; set; }

            public List<NotificationModel> Notifications { get; set; }
            public DateTime? ExpiresAt { get; set; }

        }

        public class StatusModel
        {
            public long Id { get; set; }
        }

        public class NotificationModel
        {
            public Guid Identifier { get; set; }
            public NotificationTimingModel NotificationTiming { get; set; }
            public NotificationTypeModel NotificationType { get; set; }
        }

        public class NotificationTimingModel
        {
            public Guid Identifier { get; set; }
            public int TimingAmount { get; set; }
            public string TimingAmountType { get; set; } // minutes, hours, days, weeks, months

        }

        public class NotificationTypeModel
        {
            public long Id { get; set; }
            public string NotificationTypeName { get; set; }
        }

    }
}