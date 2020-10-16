﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gas_Station
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox1.Items.Add("92");
            comboBox1.Items.Add("95");
            comboBox1.Items.Add("98");
            comboBox1.Items.Add("ДТ");

            button1.Enabled = false;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                if (!((e.KeyChar.ToString() == ",") && (textBox1.Text.IndexOf(",") == -1)))
                    e.Handled = true;

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "," && textBox1.TextLength > 0 && comboBox1.SelectedIndex != -1)
                button1.Enabled = true;
            else
                if (!button1.Enabled)
                button1.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "," && textBox1.TextLength > 0 && comboBox1.SelectedIndex != -1)
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double cl = 17.12F;//цена за литр
            double lt;//количество литров
            double cash;//нличные
            double ch;//сдача

            switch(comboBox1.SelectedIndex)
            {
                case 0: cl = 17.12F; break;
                case 1: cl = 19.45F; break;
                case 2: cl = 20.25F; break;
                case 3: cl = 17.00F; break;
            }

            cash = Convert.ToSingle(textBox1.Text);
            lt = (double)Decimal.Truncate((Decimal)(cash * 10 / cl)) / 10;
            ch = cash - lt * cl;

            label3.Text = "Литров:" + lt.ToString("N") +
                "\nСумма:" + cash.ToString("C") +
                "\nСдача:" + ch.ToString("C") +
                "|nЦена за литр:" + cl.ToString("C");

        }
    }
}
