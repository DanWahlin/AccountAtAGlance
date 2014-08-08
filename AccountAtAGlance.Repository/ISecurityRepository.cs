using System.Collections.Generic;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public interface ISecurityRepository
    {
        Security GetSecurity(string symbol);
        List<TickerQuote> GetSecurityTickerQuotes();
        OperationStatus UpdateSecurities();
        OperationStatus InsertSecurityData();
    }
}