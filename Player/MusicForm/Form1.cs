using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MusicForm
{
    public partial class Form1 : Form
    {
        //declare and  create object
        private SoundPlayer player;

        public Form1()
        {
            InitializeComponent();
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            //open file location box
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "WAV|*.wav", Multiselect = false, ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    //display file location
                    txtFileName.Text = ofd.FileName;
                }
            }
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtFileName.Text))
            {
                return;
            }
            try
            {
                if (playButton.Text == "PLAY")
                {
                    //play button
                    player.SoundLocation = txtFileName.Text;
                    player.PlayLooping();
                    playButton.Text = "STOP";
                }
                else if (playButton.Text == "STOP")
                {
                    //stop button
                    player.Stop();
                    playButton.Text = "PLAY";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {
            player = new SoundPlayer();
        }
    }
}
