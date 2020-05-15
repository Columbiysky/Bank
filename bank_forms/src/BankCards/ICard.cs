using MongoDB.Bson;
using MongoDB.Driver;

namespace bank_forms.src.BankCards
{
    public interface ICard
    {
        ObjectId CardID { get; set; }                                                   // поле для хранения первичного ключа

        decimal Balance { get; set; }

        string Validity { get; set; }                                                   // до какого числа действительная карта

        double Percent { get; set; }                                                       // процент по карте (если кредитная)

        int MaximumLimit { get; set; }                                                  // максимальный лимит карты

        string CardType { get; set; }                                                   // тип карточки (дебетовая/кредитная)

        long CardNumber { get; set; }

        string CVV { get; set; }

        bool IsMain { get; set; }
    }
}
