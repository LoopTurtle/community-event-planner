using System;

namespace CommunityEventPlanner.Services
{
    public class EventSignUpService
    {
        public int? EventId { get; set; }

        public void SetEventId(int eventId)
        {
            EventId = eventId;
        }

        public void ClearEventId()
        {
            EventId = null;
        }
    }
}