using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using Demo.Model;
using Newtonsoft.Json;

namespace Demo.MainView
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var db = new ContactManagerDBEntities();
            contactBindingSource.DataSource = db.Contacts.ToList();
           
            
        }

        private async void buttonAdd_Click(object sender, EventArgs e)
        {
            using (var frm = new AddContact(new Contact()))
            {
                if (frm.ShowDialog() == DialogResult.OK)
                    try
                    {
                        contactBindingSource.Add(frm.ContactInfo);
                        db.Contacts.Add(frm.ContactInfo);
                        await db.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void buttonrefresh_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            contactBindingSource.DataSource = db.Contacts.ToList();
            contactTypeBindingSource.DataSource = db.ContactTypes.ToList();
            Cursor.Current = Cursors.Default;
        }





        private ContactManagerDBEntities db;
        private void Form1_Load(object sender, EventArgs e)
        {
            db = new ContactManagerDBEntities();
            contactBindingSource.DataSource = db.Contacts.ToList();
            contactTypeBindingSource.DataSource = db.ContactTypes.ToList();

           


        }








        private async void buttonEdit_Click(object sender, EventArgs e)
        {
            var obj = contactBindingSource.Current as Contact;
            if (obj != null)
                using (var frm = new AddContact(obj))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                        try
                        {
                            contactBindingSource.EndEdit();
                            await db.SaveChangesAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show("Do you want to save the changes?", "Message", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var rows = dataGridView1.RowCount;
                for (var i = rows - 1; i >= 0; i--)
                    if (dataGridView1.Rows[i].Selected)
                    {
                        db.Contacts.Remove(dataGridView1.Rows[i].DataBoundItem as Contact);
                        contactBindingSource.RemoveAt(dataGridView1.Rows[i].Index);
                    }
            }
        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if ( MessageBox.Show("Do you want to save the changes?", "Message", MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    contactBindingSource.EndEdit();
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonSaveToTxT_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
                return;
            using (var sfd = new SaveFileDialog { Filter = "Text Documents|*.txt", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    _inputParameter.ContactList = contactBindingSource.DataSource as List<Contact>;
                    _inputParameter.FileName = sfd.FileName;
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    backgroundWorker.RunWorkerAsync(_inputParameter);
                }
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var list = ((Dataparameter)e.Argument).ContactList;
            var fileName = ((Dataparameter)e.Argument).FileName;
            using (TextWriter tw = new StreamWriter(new FileStream(fileName, FileMode.Create), Encoding.UTF8))
            {
                var index = 1;
                var process = list.Count;
                var sb = new StringBuilder();
                foreach (var p in list)
                    if (!backgroundWorker.CancellationPending)
                    {
                        backgroundWorker.ReportProgress(index++ * 100 / process);
                        sb.AppendLine(string.Format("Ime - {0} {1} : Adresa - : {2} : Datum upisa - : {3}", p.Ime,
                            p.LastName, p.Address, p.InsertDate));
                    }
                tw.Write(sb.ToString());
            }
        }

        private struct Dataparameter
        {
            public List<Contact> ContactList;
            public string FileName { get; set; }
        }

        private Dataparameter _inputParameter;

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = string.Format("Processing....{0}", e.ProgressPercentage);
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(100);
            if (e.Error == null)
                label1.Text = "your data has been saved to text file ";
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            var frm = new Import();
          frm.ShowDialog();

           
        }

    }
}
