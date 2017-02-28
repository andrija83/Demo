using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;
using Demo.Model;
using Newtonsoft.Json;

namespace Demo.MainView
{
    public partial class Import : Form
    {
        private ContactManagerDBEntities db = new ContactManagerDBEntities();
        public Import()
        {
            InitializeComponent();
            //_data = new BindingList<Contact>();
            //this.dataGridView1.DataSource = _data;
        }

        private async void buttonImport_Click(object sender, EventArgs e)
        {
            


            try
            {
                using (
                    var ofd = new OpenFileDialog
                    {
                        Filter = "Text Documents|*.txt",
                        ValidateNames = true,
                        Multiselect = false
                    })
                {
                    if (ofd.ShowDialog() == DialogResult.OK)
                        using (var sr = new StreamReader(ofd.FileName))
                        {
                            textBox1.Text = await sr.ReadToEndAsync();
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonJson_Click(object sender, EventArgs e)
        {
            //ContactManagerDBEntities db;
            //Contact asd = new Contact();
            //string json = JsonConvert.SerializeObject(asd, Formatting.Indented);
            //textBox2.Text = json;
            //File.WriteAllText(@"C:\Contact.json", JsonConvert.SerializeObject(asd));
            //using (StreamWriter file = File.CreateText(@"C:\Contact.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Serialize(file,asd);

            //}
            //JsonSerializer js = new JsonSerializer();
            //ContactManagerDBEntities db = new ContactManagerDBEntities();

            //var myvalues = (from x in db.Contacts where (x.ContactID == 1) select x).ToList();
            ////return js.Serialize(myvalues);
            //string output = JsonConvert.SerializeObject(_data);
            //System.IO.File.WriteAllText(@"c:\Contacts.json", output);

            var db = new ContactManagerDBEntities();

            var result = (from c in db.Contacts
                join x in db.ContactTypes on c.ContactTypeID equals x.ContactTypeID
                select new ContactInfo
                {
                    Ime = c.Ime,
                    LastName = c.LastName,
                    Address = c.Address,
                    InsertDate = c.InsertDate,
                    Captions =  x.Caption

                }).ToArray();
            dataGridView1.DataSource = result;
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);
            File.WriteAllText(@"C:\Users\thcja\Documents\Demojson.json", JsonConvert.SerializeObject(result));
            using (var file = File.CreateText(@"C:\Users\thcja\Documents\Demojson.json"))
            {
                var serializer = new JsonSerializer();
                serializer.Serialize(file,result);
            }






        }

        private void buttonImportJson_Click(object sender, EventArgs e)
        {
            using (var sr = new StreamReader(@"C:\Users\thcja\Documents\Demojson.json"))
            {
                var json = sr.ReadToEnd();
                var items = JsonConvert.DeserializeObject<List<ContactInfo>>(json);
                dataGridView1.DataSource = items;
            }
        }
        //private readonly BindingList<Contact> _data;
    }
  }

