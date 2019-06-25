using System;

namespace hacker2019_bester.Models
{
    public class Installment
    {
        public decimal minAmount { get; set; }
        public decimal maxAmount { get; set; }
    }

    public class Loanresponse
    {
        public decimal totalRequestAmount { get; set; }
        public int loanTenor { get; set; }
        public decimal installmentAmount { get; set; }
        public string paymentFrequency { get; set; }
        public Installment installment { get; set; }
        public decimal interestRate { get; set; }
        public DateTime firstDueDate { get; set; }
    }

    public class LoanData
    {
        public Loanresponse loan { get; set; }
    }

    public class LoanSimulatorResponse : BaseResponse
    {
        public LoanData data { get; set; }
    }
}
