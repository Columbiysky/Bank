using MongoDB.Bson;
using System;

namespace bank_forms.src.BankCards
{
    class DebitCard : ICard
    {
        public ObjectId CardID 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        public string Validity 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        public int Percent 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        public int MaximumLimit 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
        public string CardType 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }

        public ICard CreateCard()
        {
            throw new NotImplementedException();
        }
    }
}
