namespace Assign06
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridViewClients = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonEditRecord = new System.Windows.Forms.Button();
            this.clientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.labelTotalYTDSales = new System.Windows.Forms.Label();
            this.labelShowTotalYTD = new System.Windows.Forms.Label();
            this.labelCreditHold = new System.Windows.Forms.Label();
            this.labelCreditHolderCount = new System.Windows.Forms.Label();
            this.checkBoxDeleteConfirmation = new System.Windows.Forms.CheckBox();
            this.labelTotalClients = new System.Windows.Forms.Label();
            this.labelClientCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewClients
            // 
            this.dataGridViewClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClients.Location = new System.Drawing.Point(12, 38);
            this.dataGridViewClients.Name = "dataGridViewClients";
            this.dataGridViewClients.Size = new System.Drawing.Size(816, 338);
            this.dataGridViewClients.TabIndex = 1;
            this.dataGridViewClients.DoubleClick += new System.EventHandler(this.buttonShowEditDialog_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "&Grid";
            // 
            // buttonEditRecord
            // 
            this.buttonEditRecord.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonEditRecord.Location = new System.Drawing.Point(710, 420);
            this.buttonEditRecord.Name = "buttonEditRecord";
            this.buttonEditRecord.Size = new System.Drawing.Size(118, 23);
            this.buttonEditRecord.TabIndex = 2;
            this.buttonEditRecord.Text = "&Edit Record";
            this.buttonEditRecord.UseVisualStyleBackColor = true;
            this.buttonEditRecord.Click += new System.EventHandler(this.buttonShowEditDialog_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAdd.Location = new System.Drawing.Point(576, 420);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(118, 23);
            this.buttonAdd.TabIndex = 3;
            this.buttonAdd.Text = "&Add Record";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDelete.Location = new System.Drawing.Point(442, 420);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(118, 23);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "&Delete Record";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // labelTotalYTDSales
            // 
            this.labelTotalYTDSales.AutoSize = true;
            this.labelTotalYTDSales.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalYTDSales.Location = new System.Drawing.Point(535, 379);
            this.labelTotalYTDSales.Name = "labelTotalYTDSales";
            this.labelTotalYTDSales.Size = new System.Drawing.Size(75, 13);
            this.labelTotalYTDSales.TabIndex = 5;
            this.labelTotalYTDSales.Text = "Total Sales:";
            // 
            // labelShowTotalYTD
            // 
            this.labelShowTotalYTD.AutoSize = true;
            this.labelShowTotalYTD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShowTotalYTD.Location = new System.Drawing.Point(606, 379);
            this.labelShowTotalYTD.Name = "labelShowTotalYTD";
            this.labelShowTotalYTD.Size = new System.Drawing.Size(0, 13);
            this.labelShowTotalYTD.TabIndex = 6;
            this.labelShowTotalYTD.Text = "<SumYTD>";
            // 
            // labelCreditHold
            // 
            this.labelCreditHold.AutoSize = true;
            this.labelCreditHold.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditHold.Location = new System.Drawing.Point(680, 379);
            this.labelCreditHold.Name = "labelCreditHold";
            this.labelCreditHold.Size = new System.Drawing.Size(85, 13);
            this.labelCreditHold.TabIndex = 7;
            this.labelCreditHold.Text = "Credit Holder:";
            // 
            // labelCreditHolderCount
            // 
            this.labelCreditHolderCount.AutoSize = true;
            this.labelCreditHolderCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCreditHolderCount.Location = new System.Drawing.Point(760, 379);
            this.labelCreditHolderCount.Name = "labelCreditHolderCount";
            this.labelCreditHolderCount.Size = new System.Drawing.Size(0, 13);
            this.labelCreditHolderCount.TabIndex = 8;
            this.labelCreditHolderCount.Text = "<Holder>";
            // 
            // checkBoxDeleteConfirmation
            // 
            this.checkBoxDeleteConfirmation.AutoSize = true;
            this.checkBoxDeleteConfirmation.Location = new System.Drawing.Point(420, 424);
            this.checkBoxDeleteConfirmation.Name = "checkBoxDeleteConfirmation";
            this.checkBoxDeleteConfirmation.Size = new System.Drawing.Size(15, 14);
            this.checkBoxDeleteConfirmation.TabIndex = 9;
            this.checkBoxDeleteConfirmation.UseVisualStyleBackColor = true;
            // 
            // labelTotalClients
            // 
            this.labelTotalClients.AutoSize = true;
            this.labelTotalClients.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotalClients.Location = new System.Drawing.Point(430, 379);
            this.labelTotalClients.Name = "labelTotalClients";
            this.labelTotalClients.Size = new System.Drawing.Size(82, 13);
            this.labelTotalClients.TabIndex = 10;
            this.labelTotalClients.Text = "Total Clients:";
            // 
            // labelClientCount
            // 
            this.labelClientCount.AutoSize = true;
            this.labelClientCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClientCount.Location = new System.Drawing.Point(508, 379);
            this.labelClientCount.Name = "labelClientCount";
            this.labelClientCount.Size = new System.Drawing.Size(0, 13);
            this.labelClientCount.TabIndex = 11;
            this.labelClientCount.Text = "<N>";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 469);
            this.Controls.Add(this.labelClientCount);
            this.Controls.Add(this.labelTotalClients);
            this.Controls.Add(this.checkBoxDeleteConfirmation);
            this.Controls.Add(this.labelCreditHolderCount);
            this.Controls.Add(this.labelCreditHold);
            this.Controls.Add(this.labelShowTotalYTD);
            this.Controls.Add(this.labelTotalYTDSales);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonEditRecord);
            this.Controls.Add(this.dataGridViewClients);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Data Binding - COMP2614 - Assignment 6 - A01062206";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource clientBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewClients;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonEditRecord;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label labelTotalYTDSales;
        private System.Windows.Forms.Label labelShowTotalYTD;
        private System.Windows.Forms.Label labelCreditHold;
        private System.Windows.Forms.Label labelCreditHolderCount;
        private System.Windows.Forms.CheckBox checkBoxDeleteConfirmation;
        private System.Windows.Forms.Label labelTotalClients;
        private System.Windows.Forms.Label labelClientCount;
    }
}

