using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace говно_осла
{
    public partial class Edit : Form
    {
        Client client;
        public Edit(Client cl)
        {
            InitializeComponent();
            client = cl;
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            textBox1.Text = client.Fio;
            textBox2.Text = client.Phonenumber.ToString();
            textBox3.Text = client.Email;
        }
    }
}
