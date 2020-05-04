namespace bank_forms.src.BankAccount
{
    interface IAccountOperations
    {
        void TransferMoneyToUserByNumber(IClient sender, long phoneNumber, decimal moneyAmount);

        void TransferMoneyIDKWhere(IClient sender, decimal mountAmount);
    }
}
