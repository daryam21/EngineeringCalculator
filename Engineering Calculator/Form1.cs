using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engineering_Calculator
{
    public partial class Form1 : Form
    {
        public double d1, d2, A1, A2, K, n, r, P;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Aluminium Alloy 6061-T6");
            comboBox1.Items.Add("Brass Annealed");
            comboBox1.Items.Add("Low Carbon Steel");
            comboBox1.Items.Add("Other");

            K_txt.ReadOnly = true;
            n_txt.ReadOnly = true;
            r_txt.ReadOnly = true;
            P_txt.ReadOnly = true;

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }

        private void d1_txt_TextChanged(object sender, EventArgs e)
        {
            if (d1_txt.Text == ".")
            {
                d1_txt.Text = "";
            }

            if (d1_txt.Text != "")
            {
                d1 = double.Parse(d1_txt.Text);
                A1 = Math.Pow(d1, 2) * ((Math.PI) / 4);
            }

            if ((d1_txt.Text != "") && (d2_txt.Text != ""))
            {
                r = ((A1 - A2) / A1);
                r_txt.Text = r.ToString();
            }
            else
                r_txt.Text = "";

            if ((r > 0.63) || (0 >= r))
            {
                r_txt.BackColor = Color.Red;
            }
            else
                r_txt.BackColor = DefaultBackColor;

            if (r_txt.Text == "")
            {
                r_txt.BackColor = DefaultBackColor;
            }
        }

        private void d1_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void d2_txt_TextChanged(object sender, EventArgs e)
        {
            if (d2_txt.Text == ".")
            {
                d2_txt.Text = "";
            }

            if (d2_txt.Text != "")
            {
                d2 = double.Parse(d2_txt.Text);
                A2 = Math.Pow(d2, 2) * ((Math.PI) / 4);
            }

            if ((d1_txt.Text != "") && (d2_txt.Text != ""))
            {
                r = ((A1 - A2) / A1);
                r_txt.Text = r.ToString();
            }
            else
                r_txt.Text = "";

            if ((r > 0.63) || (0 >= r))
            {
                r_txt.BackColor = Color.Red;
            }
            else
                r_txt.BackColor = DefaultBackColor;
    
            if (r_txt.Text == "")
            {
               r_txt.BackColor = DefaultBackColor;
            }
        }

        private void d2_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            K_txt.BackColor = DefaultBackColor;
            n_txt.BackColor = DefaultBackColor;

            if (comboBox1.SelectedItem.ToString() == "Aluminium Alloy 6061-T6")
            {
                K = 410000000;
                n = 0.05;

                K_txt.Text = K.ToString();
                n_txt.Text = n.ToString();

                K_txt.ReadOnly = true;
                n_txt.ReadOnly = true;
            }

            if (comboBox1.SelectedItem.ToString() == "Brass Annealed")
            {
                K = 900000000;
                n = 0.49;

                K_txt.Text = K.ToString();
                n_txt.Text = n.ToString();

                K_txt.ReadOnly = true;
                n_txt.ReadOnly = true;
            }

            if (comboBox1.SelectedItem.ToString() == "Low Carbon Steel")
            {
                K = 530000000;
                n = 0.26;

                K_txt.Text = K.ToString();
                n_txt.Text = n.ToString();

                K_txt.ReadOnly = true;
                n_txt.ReadOnly = true;
            }

            if (comboBox1.SelectedItem.ToString() == "Other")
            {
                K_txt.Text = "";
                n_txt.Text = "";

                K_txt.ReadOnly = false;
                n_txt.ReadOnly = false;

                K_txt.BackColor = Color.LightGreen;
                n_txt.BackColor = Color.LightGreen;

                MessageBox.Show("Please enter your desired values in the highlighted boxes.");                    
            }
        }

        private void K_txt_TextChanged(object sender, EventArgs e)
        {
            if (K_txt.Text == ".")
            {
                K_txt.Text = "";
            }

            if (K_txt.Text != "")
            {
                K = double.Parse(K_txt.Text);
            }
        }

        private void K_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void n_txt_TextChanged(object sender, EventArgs e)
        {
            if (n_txt.Text == ".")
            {
                n_txt.Text = "";
            }

            if (n_txt.Text != "")
            {
                n = double.Parse(n_txt.Text);
            }
        }

        private void n_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            P = (A2 * ((K) / (n + 1)) * (Math.Pow((Math.Log(A1 / A2)), (n + 1))));
            P_txt.Text = P.ToString();

            if (r > 0.63)
            {
                MessageBox.Show("r value is greater than 0.63, please adjust area values.");
            }

            if (0 > r)
            {
                MessageBox.Show("r value is less than 0, please adjust area values.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            d1_txt.Text = "";
            d2_txt.Text = "";
            r_txt.Text = "";
            K_txt.Text = "";
            n_txt.Text = "";
            P_txt.Text = "";
            comboBox1.Text = "Select Material";
        }
    }
}
