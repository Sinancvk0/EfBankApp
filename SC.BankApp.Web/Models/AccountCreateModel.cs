namespace SC.BankApp.Web.Models
{
    public class AccountCreateModel
    {
        public decimal Balance { get; set; }
        public int AccountNumber { get; set; }
        public int ApplicationUserId { get; set; }
    }
}
