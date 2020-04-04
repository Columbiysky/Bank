using MongoDB.Bson;

namespace bank_forms.src.BankCards
{
    class CreditCard : ICard
    {
        public ObjectId CardID 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }
        public string Validity 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }
        public int Percent 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }
        public int MaximumLimit 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }
        public string CardType 
        { 
            get => throw new System.NotImplementedException(); 
            set => throw new System.NotImplementedException(); 
        }

        public ICard CreateCard()
        {
            throw new System.NotImplementedException();
        }
    }
}
