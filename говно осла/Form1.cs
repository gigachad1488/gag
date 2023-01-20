using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace говно_осла
{
    public partial class Form1 : Form
    {
        public int c;
        public bool stoped;
        public List<Client> clients = new List<Client>();
        public int curitem = -1;
        public List<Song> sounds = new List<Song>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            sounds.Add(new Song(new SoundPlayer(Properties.Resources.ham), "Отпути непутю"));
            sounds.Add(new Song(new SoundPlayer(Properties.Resources.bumer), "Черный бумер"));
            sounds.Add(new Song(new SoundPlayer(Properties.Resources.malii), "Малый повзрослел"));
            sounds.Add(new Song(new SoundPlayer(Properties.Resources.sueta), "Суета"));
            sounds.Add(new Song(new SoundPlayer(Properties.Resources.hohudet), "Время похудеть"));
            sounds.Add(new Song(new SoundPlayer(Properties.Resources.hlopai), "Хлопай"));
            Random r = new Random();
            c = r.Next(0, sounds.Count - 1);
            stoped = false;
            ChangeSong(true);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client chel = new Client();
            chel.Fio = textBox1.Text;
            chel.Email = textBox3.Text;
            chel.Phonenumber = Convert.ToInt32(textBox2.Text);
            clients.Add(chel);
            Refresh();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int itm = listBox1.SelectedIndex;
            Refresh();
        }
        new public void Refresh()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < clients.Count; i++)
            {
                listBox1.Items.Add($"Имя: {clients[i].Fio}, Номер: {clients[i].Phonenumber}, Емаил: {clients[i].Email}");
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            curitem = listBox1.SelectedIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            clients.Remove(clients[curitem]);
            curitem = -1;
            Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            stoped = true;
            StopSong();
            ChangeSong(true);
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        public void ChangeSong(bool up)
        {
            if (up)
            {
                if (c == sounds.Count - 1)
                {
                    stoped = false;
                    c = 0;
                    sounds[c].PlaySong();
                    label4.Text = sounds[c].Name;
                }
                else
                {
                    stoped = false;
                    c++;
                    sounds[c].PlaySong();
                    label4.Text = sounds[c].Name;
                }

            }
            else
            {

                if (c == 0)
                {
                    c = sounds.Count - 1;
                    sounds[c].PlaySong();
                    label4.Text = sounds[c].Name;
                }
                else
                {
                    c--;
                    sounds[c].PlaySong();
                    label4.Text = sounds[c].Name;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            stoped = true;
            StopSong();
            ChangeSong(false);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StopSong();
            
        }
        
        public void StopSong()
        {
            if (!stoped)
            {

                sounds[c].StopSong();
                button6.Text = "▷";
                stoped = true;
            }
            else
            {
                sounds[c].ResumeSong();
                stoped = false;
                button6.Text = "=";
            }
        }
    }
}
