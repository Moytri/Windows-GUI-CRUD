using BusinessLib.Business;
using BusinessLib.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        public bool IsEditable { get; set; }
        public Mode Mode;
        public int NumberOfAffectedRows;

        public EditDialog()
        {
            InitializeComponent();
        }

        private void EditDialog_Load(object sender, EventArgs e)
        {
            if(Mode.Equals(Mode.Edit))
            {
                maskedTextBoxClientCode.ReadOnly = true;
                SetBindings();
            }
            else
            {
                maskedTextBoxClientCode.ReadOnly = false;
                SetBindings();
            }
        }

        private void SetBindings()
        {
            maskedTextBoxClientCode.DataBindings.Add("Text", ClientVM, "Client.ClientCode", false, DataSourceUpdateMode.OnValidation);
            textBoxCompanyName.DataBindings.Add("Text", ClientVM, "Client.CompanyName", false, DataSourceUpdateMode.OnValidation);
            textBoxAddress1.DataBindings.Add("Text", ClientVM, "Client.Address1", false, DataSourceUpdateMode.OnValidation);
            textBoxAddress2.DataBindings.Add("Text", ClientVM, "Client.Address2", false, DataSourceUpdateMode.OnValidation, "");
            textBoxCity.DataBindings.Add("Text", ClientVM, "Client.City", false, DataSourceUpdateMode.OnValidation, "");
            textBoxProvince.DataBindings.Add("Text", ClientVM, "Client.Province", false, DataSourceUpdateMode.OnValidation);
            maskedTextBoxPostalCode.DataBindings.Add("Text", ClientVM, "Client.PostalCode", false, DataSourceUpdateMode.OnValidation, "");
            textBoxYTDSales.DataBindings.Add("Text", ClientVM, "Client.YTDSales", true, DataSourceUpdateMode.OnValidation, "0.00", "#,##0.00;(#,##0.00);0.00");
            textBoxNotes.DataBindings.Add("Text", ClientVM, "Client.Notes", false, DataSourceUpdateMode.OnValidation, "");
            checkBoxCreditHold.DataBindings.Add("Checked", ClientVM, "Client.IsCreditHold", false, DataSourceUpdateMode.OnValidation);
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(buttonOk, "");
            Client client = new Client();
            try
            {

                client = ClientVM.GetDisplayClient();
                int rowsAffected = 0;

                if (Mode.Equals(Mode.Edit))
                {
                    rowsAffected = ClientValidation.UpdateClient(client);
                }
                else
                {
                    rowsAffected = ClientValidation.AddClient(client);
                }
                     
                if (rowsAffected > 0)
                {
                        DialogResult = DialogResult.OK;
                }
                else
                {
                    if (rowsAffected == -1)
                    {
                        errorProvider.SetError(buttonOk, ClientValidation.ErrorMessage);
                    }
                    else
                    {
                        errorProvider.SetError(buttonOk, "No DB changes were made");
                    }
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
