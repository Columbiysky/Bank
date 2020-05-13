using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank_forms.src.FormsDialog
{
    public static class FormDialog
    {
        public static bool DataIsRecieved { get; set; }     // используется для сообщения форме 1, 
                                                            //что на форме 2 данные были успешно обновлены/добавлены
    }
}
