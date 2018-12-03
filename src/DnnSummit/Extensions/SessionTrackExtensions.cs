using DnnSummit.Attributes;
using DnnSummit.Models;
using System;
using System.Linq;

namespace DnnSummit.Extensions
{
    public static class SessionTrackExtensions
    {
        public static SessionTrack ToSessionTrack(this string input)
        {
            var type = typeof(SessionTrack);
            var members = type.GetMembers();
            foreach (var memberInfo in members)
            {
                var attributes = memberInfo.GetCustomAttributes(typeof(TrackNameAttribute), false);
                if (attributes != null && attributes.Length > 0)
                {
                    var trackName = (TrackNameAttribute)attributes[0];

                    if (trackName != null && trackName.Name == input)
                    {
                        var values = (SessionTrack[])Enum.GetValues(type);
                        return values.FirstOrDefault(x => x.ToString() == memberInfo.Name);
                    }
                }
            }

            return SessionTrack.Other;
        }
    }
}
