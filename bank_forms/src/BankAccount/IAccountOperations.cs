namespace bank_forms.src.BankAccount
{
    interface IAccountOperations
    {
        void TransferMoneyToUserByNumber(IClient sender, string senderAccId, long phoneNumber, decimal moneyAmount);

        void TransferMoneyIDKWhere(IClient sender, string senderAccId, decimal mountAmount);
    }
}
