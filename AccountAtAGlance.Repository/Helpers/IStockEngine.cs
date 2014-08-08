using AccountAtAGlance.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAtAGlance.Repository.Helpers
{
    public interface IStockEngine
    {
        List<MarketIndex> GetMarketQuotes(params string[] symbols);
        List<Security> GetSecurityQuotes(params string[] symbols);
    }
}
