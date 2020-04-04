using MongoDB.Bson;

namespace bank_forms.src.BankCards
{
    interface ICard
    {
        ObjectId CardID { get; set; }                                                   // поле для хранения первичного ключа

        string Validity { get; set; }                                                   // до какого числа действительная карта

        int Percent { get; set; }                                                       // процент по карте (если кредитная)


        int MaximumLimit { get; set; }                                                  // максимальный лимит карты

        string CardType { get; set; }                                                   // тип карточки (дебетовая/кредитная)

        ICard CreateCard();
    }
}
