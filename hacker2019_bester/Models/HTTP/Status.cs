namespace hacker2019_bester.Models
{
    public class BaseResponse
    {
        public Status status { get; set; }
    }

    public class Status
    {
        public long code { get; set; }

        public string description { get; set; }
    }
}
