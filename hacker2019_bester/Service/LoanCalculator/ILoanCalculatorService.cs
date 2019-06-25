using hacker2019_bester.Models;

namespace hacker2019_bester.Service
{
    public interface ILoanCalculatorService
    {
        LoanSimulatorResponse LoanSimulator(string customerId, LoanSimulatorRequest request, Header header);
    }
}
