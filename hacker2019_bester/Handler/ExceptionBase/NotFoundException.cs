namespace hacker2019_bester.Handler
{
    public class NotFoundException : BaseException
    {
        public NotFoundException() : base("000001", "ไม่พบข้อมูล")
        {
        }
    }
}
