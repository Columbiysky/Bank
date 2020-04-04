namespace bank_forms.src.BankCards
{
    interface ICardOperations
    {
        void TransferMoneyToUser(IClient sender, IClient reciever);

        void TransferMoney();

    }
}
