using System.Collections.Generic;
using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public interface IMarketsAndNewsRepository
    {
        MarketQuotes GetMarkets();
        List<TickerQuote> GetMarketTickerQuotes();
        List<string> GetMarketNews();
        OperationStatus InsertMarketData();
    }
}