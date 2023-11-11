using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashScreen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            try
            {
                mySqlConnection.Open();
                if (mySqlConnection.State == ConnectionState.Open)
                {
                    var stm = "SELECT * FROM wp_users";
                    var cmd = new MySqlCommand(stm, mySqlConnection);

                    var resultado = cmd.ExecuteScalar().ToString();
                    Console.WriteLine($"{resultado}");
                }
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panelProgress.Width += 11;
            if (panelProgress.Width > 522)
            {
                timer1.Stop();
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
        }

       
    }
}
