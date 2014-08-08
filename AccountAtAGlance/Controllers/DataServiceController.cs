using AccountAtAGlance.Model;
using AccountAtAGlance.Repository;
using AccountAtAGlance.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AccountAtAGlance.Controllers
{
    public class DataServiceController : ApiController
    {
        IAccountRepository _AccountRepository;
        ISecurityRepository _SecurityRepository;
        IMarketsAndNewsRepository _MarketRepository;

        public DataServiceController(IAccountRepository acctRepo,
          ISecurityRepository secRepo, IMarketsAndNewsRepository marketRepo)
        {
            _AccountRepository = acctRepo;
            _SecurityRepository = secRepo;
            _MarketRepository = marketRepo;
        }


        [HttpGet]
        public BrokerageAccount Account(string acctNumber)
        {
            var acct = _AccountRepository.GetAccount(acctNumber);
            if (acct == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return acct;
        }

        [HttpGet]
        public Security Quote(string symbol)
        {
            var security = _SecurityRepository.GetSecurity(symbol);
            if (security == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return security;
        }

        [HttpGet]
        public MarketQuotes MarketIndices()
        {
            var marketQuotes = _MarketRepository.GetMarkets();
            if (marketQuotes == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }
            return marketQuotes;
        }

        [HttpGet]
        public MarketsAndNews TickerQuotes()
        {
            var marketQuotes = _MarketRepository.GetMarketTickerQuotes();
            var securityQuotes = _SecurityRepository.GetSecurityTickerQuotes();
            marketQuotes.AddRange(securityQuotes);
            var news = _MarketRepository.GetMarketNews();

            if (marketQuotes == null && news == null)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            return new MarketsAndNews { Markets = marketQuotes, News = news };
        }

        public IHttpActionResult PostAccount(BrokerageAccount acct)
        {
            var opStatus = _AccountRepository.InsertAccount(acct);

            if (!opStatus.Status)
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
            }

            //Generate success response
            return CreatedAtRoute("DefaultApi", new { id = acct.AccountNumber }, acct);
        }

    }
}
