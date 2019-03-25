using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assign06
{
    public partial class EditDialog : Form
    {
        public CientViewModel ClientVM { get; set; }
        public EditDialog()
        {
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            SetBindings();
        }

        private void SetBindings()
        {
            textBoxCompanyName.DataBindings.Add("Text", ClientVM, "Client.CompanyName", false, DataSourceUpdateMode.OnValidation);
            textBoxAddress1.DataBindings.Add("Text", ClientVM, "Client.Address1", false, DataSourceUpdateMode.OnValidation);
            textBoxAddress2.DataBindings.Add("Text", ClientVM, "Client.Address2", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCity.DataBindings.Add("Text", ClientVM, "Client.City", false, DataSourceUpdateMode.OnValidation, "");
            textBoxProvince.DataBindings.Add("Text", ClientVM, "Client.Province", false, DataSourceUpdateMode.OnValidation);
            textBoxPostalCode.DataBindings.Add("Text", ClientVM, "Client.PostalCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxYTDSales.DataBindings.Add("Text", ClientVM, "Client.YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            textBoxNotes.DataBindings.Add("Text", ClientVM, "Client.Notes", false, DataSourceUpdateMode.OnValidation, "");
            checkBoxCreditHold.DataBindings.Add("Checked", ClientVM, "Client.IsCreditHold", false, DataSourceUpdateMode.OnValidation);
        }
    }
}
