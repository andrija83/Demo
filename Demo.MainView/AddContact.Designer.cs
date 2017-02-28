namespace Demo.MainView
{
    partial class AddContact
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxContactId = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxAdresa = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPrezime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxIme = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.insertDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.bindingSourceContact = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceContact)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 176);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 20);
            this.label5.TabIndex = 18;
            this.label5.Text = "Datum";
            // 
            // comboBoxContactId
            // 
            this.comboBoxContactId.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSourceContact, "ContactTypeID", true));
            this.comboBoxContactId.FormattingEnabled = true;
            this.comboBoxContactId.Location = new System.Drawing.Point(108, 215);
            this.comboBoxContactId.Name = "comboBoxContactId";
            this.comboBoxContactId.Size = new System.Drawing.Size(152, 28);
            this.comboBoxContactId.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 218);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "Contact ID";
            // 
            // textBoxAdresa
            // 
            this.textBoxAdresa.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceContact, "Address", true));
            this.textBoxAdresa.Location = new System.Drawing.Point(84, 129);
            this.textBoxAdresa.Name = "textBoxAdresa";
            this.textBoxAdresa.Size = new System.Drawing.Size(265, 26);
            this.textBoxAdresa.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Adresa";
            // 
            // textBoxPrezime
            // 
            this.textBoxPrezime.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceContact, "LastName", true));
            this.textBoxPrezime.Location = new System.Drawing.Point(84, 91);
            this.textBoxPrezime.Name = "textBoxPrezime";
            this.textBoxPrezime.Size = new System.Drawing.Size(265, 26);
            this.textBoxPrezime.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Prezime";
            // 
            // textBoxIme
            // 
            this.textBoxIme.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceContact, "Ime", true));
            this.textBoxIme.Location = new System.Drawing.Point(84, 54);
            this.textBoxIme.Name = "textBoxIme";
            this.textBoxIme.Size = new System.Drawing.Size(265, 26);
            this.textBoxIme.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 20);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ime";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(274, 263);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 47);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "&Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // insertDateDateTimePicker
            // 
            this.insertDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSourceContact, "InsertDate", true));
            this.insertDateDateTimePicker.Location = new System.Drawing.Point(75, 170);
            this.insertDateDateTimePicker.Name = "insertDateDateTimePicker";
            this.insertDateDateTimePicker.Size = new System.Drawing.Size(274, 26);
            this.insertDateDateTimePicker.TabIndex = 21;
            // 
            // bindingSourceContact
            // 
            this.bindingSourceContact.DataSource = typeof(ClassLibrary1.Contact);
            // 
            // AddContact
            // 
            this.AcceptButton = this.buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(378, 333);
            this.Controls.Add(this.insertDateDateTimePicker);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxContactId);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAdresa);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxPrezime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxIme);
            this.Controls.Add(this.label1);
            this.Name = "AddContact";
            this.Text = "AddContact";
            this.Load += new System.EventHandler(this.AddContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceContact)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxContactId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxAdresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPrezime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxIme;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.BindingSource bindingSourceContact;
        private System.Windows.Forms.DateTimePicker insertDateDateTimePicker;
    }
}