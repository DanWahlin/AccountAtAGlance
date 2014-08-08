using AccountAtAGlance.Model;

namespace AccountAtAGlance.Repository
{
    public interface IAccountRepository
    {
        BrokerageAccount GetAccount(string acctNumber);
        //BrokerageAccount GetAccount(int id);
        Customer GetCustomer(string custId);
        OperationStatus RefreshAccountsData();
        OperationStatus InsertAccount(BrokerageAccount acct);
    }
}