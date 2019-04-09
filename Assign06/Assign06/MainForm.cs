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
using BusinessLib.Business;
using BusinessLib.Common;
using BusinessLib.Data;

namespace Assign06
{
    public partial class MainForm : Form
    {
        private CientViewModel clientVM;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //initially set empty for all the display label 
            labelShowTotalYTD.Text = string.Empty;
            labelCreditHolderCount.Text = string.Empty;
            labelClientCount.Text = string.Empty;

            clientVM = new CientViewModel();
            setBindings();
            setupDataGridView();
        }

        private void setBindings()
        { 
            dataGridViewClients.AutoGenerateColumns = false;
            dataGridViewClients.DataSource = clientVM.Clients;  
            showCalculatedData(clientVM.Clients);
        }

        /// <summary>
        /// Formats and organizes the data grid view
        /// </summary>
        private void setupDataGridView()
        {
            // configure for readonly 
            dataGridViewClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewClients.MultiSelect = false;
            dataGridViewClients.AllowUserToAddRows = false;
            dataGridViewClients.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewClients.AllowUserToOrderColumns = false;
            dataGridViewClients.AllowUserToResizeColumns = false;
            dataGridViewClients.AllowUserToResizeRows = false;
            dataGridViewClients.ColumnHeadersDefaultCellStyle.Font = new Font(DataGridView.DefaultFont, FontStyle.Bold);

            //add columns
            DataGridViewTextBoxColumn clientCode = new DataGridViewTextBoxColumn();
            clientCode.Name = "clientCode";
            clientCode.DataPropertyName = "ClientCode";
            clientCode.HeaderText = "Client Code";
            clientCode.Width = 50;
            clientCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(clientCode);

            DataGridViewTextBoxColumn companyName = new DataGridViewTextBoxColumn();
            companyName.Name = "companyName";
            companyName.DataPropertyName = "CompanyName";
            companyName.HeaderText = "Company Name";
            companyName.Width = 120;
            companyName.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(companyName);

            DataGridViewTextBoxColumn address1 = new DataGridViewTextBoxColumn();
            address1.Name = "address1";
            address1.DataPropertyName = "Address1";
            address1.HeaderText = "Address1";
            address1.Width = 120;
            address1.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(address1);

            DataGridViewTextBoxColumn address2 = new DataGridViewTextBoxColumn();
            address2.Name = "address2";
            address2.DataPropertyName = "Address2";
            address2.HeaderText = "Address2";
            address2.Width = 70;
            address2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(address2);

            DataGridViewTextBoxColumn city = new DataGridViewTextBoxColumn();
            city.Name = "city";
            city.DataPropertyName = "City";
            city.HeaderText = "City";
            city.Width = 60;
            city.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(city);

            DataGridViewTextBoxColumn province = new DataGridViewTextBoxColumn();
            province.Name = "province";
            province.DataPropertyName = "Province";
            province.HeaderText = "Province";
            province.Width = 55;
            province.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            province.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            province.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(province);

            DataGridViewTextBoxColumn postalCode = new DataGridViewTextBoxColumn();
            postalCode.Name = "postalCode";
            postalCode.DataPropertyName = "PostalCode";
            postalCode.HeaderText = "Postal Code";
            postalCode.Width = 55;
            postalCode.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            postalCode.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            postalCode.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(postalCode);

            DataGridViewTextBoxColumn ytdSales = new DataGridViewTextBoxColumn();
            ytdSales.Name = "ytdSales";
            ytdSales.DataPropertyName = "YTDSales";
            ytdSales.HeaderText = "YTDSales";
            ytdSales.Width = 80;
            ytdSales.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdSales.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            ytdSales.DefaultCellStyle.Format = "N2";
            ytdSales.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(ytdSales);

            DataGridViewCheckBoxColumn creditHold = new DataGridViewCheckBoxColumn();
            creditHold.Name = "creditHold";
            creditHold.DataPropertyName = "IsCreditHold";
            creditHold.HeaderText = "Credit Hold";
            creditHold.Width = 45;
            creditHold.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(creditHold);

            DataGridViewTextBoxColumn notes = new DataGridViewTextBoxColumn();
            notes.Name = "notes";
            notes.DataPropertyName = "Notes";
            notes.HeaderText = "Notes";
            notes.Width = 120;
            notes.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewClients.Columns.Add(notes);
        }

        private void buttonShowEditDialog_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridViewClients.CurrentRow.Index;

                Client client = clientVM.Clients[index];
                clientVM.SetDisplayClient(client);

                EditDialog dialog = new EditDialog();        
                dialog.ClientVM = clientVM;
                dialog.IsEditable = false;
                dialog.Mode = Mode.Edit;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //After a successful update, show all the clients in the dataGrid, and the updated row will keep selected 
                    client = clientVM.GetDisplayClient();
                    clientVM.Clients = ClientValidation.GetClients();
                    clientVM.Clients.ResetItem(index);
                    dataGridViewClients.DataSource = clientVM.Clients;
                    dataGridViewClients.Rows[index].Selected = true;

                    showCalculatedData(clientVM.Clients);
                }
                dialog.Dispose();
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

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Client client = new Client();
                clientVM.SetDisplayClient(client);

                EditDialog dialog = new EditDialog();
                dialog.ClientVM = clientVM;
                dialog.Mode = Mode.Add;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    client = clientVM.GetDisplayClient();
                    clientVM.Clients = ClientValidation.GetClients();
                    dataGridViewClients.DataSource = clientVM.Clients;

                    showCalculatedData(clientVM.Clients);
                }
                dialog.Dispose();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int index = dataGridViewClients.CurrentRow.Index;
                Client client = clientVM.Clients[index];
                deleteCurrentRecord(client, checkBoxDeleteConfirmation.Checked);

                clientVM.Clients = ClientValidation.GetClients();
                dataGridViewClients.DataSource = clientVM.Clients;

                showCalculatedData(clientVM.Clients);
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

        //Delete record and deletion process depends on checkbox status
        private void deleteCurrentRecord(Client client, bool deleteConfirmation)
        {
            DialogResult response = DialogResult.None;
            if(deleteConfirmation)
            {
                response = MessageBox.Show("You are about to Delete record with ID: " + client.ClientCode + " ?\nAre you sure?", "Warning!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            }
            else
            {
                ClientValidation.DeleteClient(client);
            }

            if(response == DialogResult.Yes)
            {
                ClientValidation.DeleteClient(client);
            }
        }

        //show all the calculated methods of the ClientCollection in corresponding labels
        private void showCalculatedData(ClientCollection clients)
        {
            labelShowTotalYTD.Text = clients.TotalYTDSales.ToString("#,##0.00");
            labelCreditHolderCount.Text = clients.CreditHoldCount.ToString();
            labelClientCount.Text = clients.Count.ToString();
        }
    }
}
