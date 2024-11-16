using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Common.Interfaces;

namespace Common.Utils
{
    public static class EventSerializer
    {
        public static string Serialize<T>(T eventMessage)where T :IEvent
        {
            return JsonSerializer.Serialize(eventMessage);
        }
        public static T Deserialize<T>(string eventData)where T:IEvent
        {
            return JsonSerializer.Deserialize<T>(eventData);
        }
    }
}