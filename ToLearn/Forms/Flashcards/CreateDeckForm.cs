using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToLearn.Utils;

namespace ToLearn.Forms.Flashcards;

public partial class CreateDeckForm : CustomForm
{
    private readonly AccountManager _accountManager;

    public CreateDeckForm()
    {
        InitializeComponent();
        _accountManager = new AccountManager(this);
    }
}
