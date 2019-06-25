namespace hacker2019_bester.Models
{
    public class Loan
    {
        public string productIntent { get; set; }
        public decimal totalRequestAmount { get; set; }
        public string paymentFrequency { get; set; }
        public int loanTenor { get; set; }
        public decimal installmentAmount { get; set; }
        public int gracePeriod { get; set; }
        public int dueDay { get; set; }
    }

    public class LoanSimulatorRequest
    {
        public Loan loan { get; set; }
    }
}
