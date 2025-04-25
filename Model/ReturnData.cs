using System;

namespace CodeconChallenge.Models
{
    public class ReturnData<T>
    {
        public T? Data { get; set; }
        public long ProcessingTimeMs { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
