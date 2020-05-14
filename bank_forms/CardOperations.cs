using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bank_forms
{
    public partial class CardOperations : Form
    {
        string cardId;

        public CardOperations(string cardId)
        {
            InitializeComponent();

            this.cardId = cardId;
        }
    }
}
