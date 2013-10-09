using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RotatetoSort1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 2;
        }
        public int n = 9;
        public int[] usernum;
        public bool[] check;
        public bool setok = false;

        private void buttonX1_Click(object sender, EventArgs e)
        {
            usernum = new int[n];
            check = new bool[9];
            for (int i = 0; i < n; i++)
                check[i] = false;
            if (textBox1.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("没有输入完数字！");
                return;
            }
            usernum[0] = Convert.ToInt16(textBox1.Text);
            usernum[1] = Convert.ToInt16(textBox2.Text);
            usernum[2] = Convert.ToInt16(textBox3.Text);
            usernum[3] = Convert.ToInt16(textBox4.Text);
            usernum[4] = Convert.ToInt16(textBox5.Text);
            usernum[5] = Convert.ToInt16(textBox6.Text);
            if (n > 6)
            {
                if (textBox7.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("没有输入完数字！");
                    return;
                }
                usernum[6] = Convert.ToInt16(textBox7.Text);
                usernum[7] = Convert.ToInt16(textBox8.Text);
                if (n == 9)
                {
                    if (textBox9.Text == "")
                    {
                        MessageBox.Show("没有输入完数字！");
                        return;
                    }
                    usernum[8] = Convert.ToInt16(textBox9.Text);
                }
            }
            for (int i = 0; i < n; i++)
            {
                if (usernum[i] == 0)
                {
                    MessageBox.Show("只能输入数字1到" + n + "!");
                    return;
                }
                if (!check[usernum[i] - 1])
                    check[usernum[i] - 1] = true;
            }
            for (int i = 0; i < n; i++)
            {
                if (!check[i])
                {
                    MessageBox.Show("输入的数字有重复或者越界，请检查！");
                    return;
                }
            }
            setok = true;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    n = 6;
                    textBox7.Visible = false;
                    textBox8.Visible = false;
                    textBox9.Visible = false;
                    break;
                case 1:
                    n = 8;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    textBox9.Visible = false;
                    break;
                case 2:
                    n = 9;
                    textBox7.Visible = true;
                    textBox8.Visible = true;
                    textBox9.Visible = true;
                    break;
            }
        }
    }
}
