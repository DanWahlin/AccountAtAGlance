using AccountAtAGlance.Model;
using AccountAtAGlance.Repository.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountAtAGlance.Repository
{
    internal static class DataInitializer
    {
        internal static void Initialize(AccountAtAGlanceContext context)
        {
            //var customer = new Customer()
            //{
            //    FirstName = "Marcus",
            //    LastName = "Hightower",
            //    Address = "1234 Anywhere St.",
            //    City = "Phoenix",
            //    State = "AZ",
            //    Zip = 85229,
            //    CustomerCode = "C15643"
            //};
            //var ba = new BrokerageAccount()
            //{
            //    AccountNumber = "Z485739881",
            //    AccountTitle = "Joint Brokerage",
            //    Total = 1369265.00M,
            //    MarginBalance = 414888.67M,
            //    IsRetirement = false,
            //    CashTotal = 10000.00M,
            //    PositionsTotal = 1359265.00M,
            //    WatchList = new WatchList { Title = "My Watch Securities" }
            //};
            //customer.BrokerageAccounts.Add(ba);
            //context.Customers.Add(customer);

            //var exchange = new Exchange
            //{
            //    Title = "NYSE"
            //};

            //var stock = new Stock
            //{
            //    Change = 2.5M,
            //    PercentChange = 5.00M,
            //    Last = 32.10M,
            //    Shares = 100000,
            //    Symbol = "MSFT",
            //    RetrievalDateTime = DateTime.Now,
            //    Company = "Microsoft Corporation",
            //    Exchange = exchange,
            //    DayHigh = 33.00M,
            //    DayLow = 32.00M,
            //    Dividend = 0M,
            //    Open = 32.00M,
            //    Volume = 1000000M,
            //    YearHigh = 34.00M,
            //    YearLow = 28.00M,
            //    AverageVolume = 100000M,
            //    MarketCap = 10000000M
            //};

            //context.Stocks.Add(stock);

            context.Database.ExecuteSqlCommand(@"
                    CREATE PROCEDURE dbo.DeleteSecuritiesAndExchanges

                    AS
	                    BEGIN
	 
	 		                    BEGIN TRANSACTION
		                    BEGIN TRY
			                    DELETE FROM WatchListSecurity;
			                    DELETE FROM Positions;   
			                    DELETE FROM Securities_Stock;
			                    DELETE FROM Securities_MutualFund;
			                    DELETE FROM Securities;
			                    DELETE FROM Exchanges; 
			                    DELETE FROM MarketIndexes	
			                    COMMIT TRANSACTION
			                    SELECT 0				
		                    END TRY
		                    BEGIN CATCH
			                    ROLLBACK TRANSACTION
			                    SELECT -1		
		                    END CATCH
	
	                    END
            ");

            context.Database.ExecuteSqlCommand(@"
                CREATE PROCEDURE dbo.DeleteAccounts

                AS
	                BEGIN

		                BEGIN TRANSACTION
			                BEGIN TRY
				                DELETE FROM Orders;                                              
				                DELETE FROM BrokerageAccounts; 
				                DELETE FROM WatchLists;  
				                DELETE FROM Customers						
				                COMMIT TRANSACTION
				                SELECT 0				
			                END TRY
			                BEGIN CATCH
				                ROLLBACK TRANSACTION
				                SELECT -1		
			                END CATCH
	                END	
	        ");


            IStockEngine engine = new StockEngine();
            var sr = new SecurityRepository(engine);
            var opStatus = sr.InsertSecurityData();

            if (opStatus.Status)
            {
                var mr = new MarketsAndNewsRepository(engine);
                opStatus = mr.InsertMarketData();

                if (opStatus.Status)
                {
                    var ar = new AccountRepository(engine);
                    opStatus = ar.RefreshAccountsData();
                }
            }
        }
    }
}
