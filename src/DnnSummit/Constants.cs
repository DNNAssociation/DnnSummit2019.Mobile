#if (RELEASE || AD_HOC)
#define APPCENTER
#endif

namespace DnnSummit
{
    public static class Constants
    {
        public static class Navigation
        {
            public const string LoadingPage = "LoadingPage";
            public const string LoaddingOfflineModePage = "LoadingOfflineModePage";
            public const string NavigationPage = "NavigationPage";
            public const string TabbedPage = "TabbedPage";
            public const string VenuePage = "VenuePage";
            public const string SchedulePage = "SchedulePage";
            public const string ScheduleDetailsPage = "ScheduleDetailsPage";
            public const string SessionDetailsPage = "SessionDetailsPage";
            public const string SponsorsPage = "SponsorsPage";
            public const string CreditsPage = "CreditsPage";
            public const string FeedbackPage = "FeedbackPage";
            public const string CompletePage = "CompletePage";
            public const string PermissionPage = "PermissionPage";

            public static class Parameters
            {
                public const string LastUpdated = "LastUpdated";
                public const string GoBackToRoot = "GoBackToRoot";
                public const string Title = "Title";
                public const string Complete = "Complete"; 
            }
        }

        public static class Settings
        {
            public const string DownloadPermission = "DownloadPermission";
        }

        public static class ErrorHandling
        {
            public const int RetryAttempts = 5;
            public const int RetryWait = 500;
        }

#if APPCENTER
        public static class AppCenter
        {
            public static class Events
            {
                public const string Schedule = "Schedule";
                public const string Feedback = "Feedback";
                public const string Venue = "Venue";
                public const string Credits = "Credits";
                public const string DayByDay = "Day By Day";
                public const string SessionDetails = "Session Details";
            }
        }
#endif

        public static class Messages
        {
            public const string LastRetrieved = "Last Retrieved: {0}";
        }
    }
}
