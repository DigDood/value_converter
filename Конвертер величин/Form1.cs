using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Конвертер_величин
{
    public partial class Form1 : Form
    {
        bool actionL1, actionL2, actionW1, actionW2, actionT1, actionT2, isLightTheme = true, aboutOur = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void length_list_1_Click(object sender, EventArgs e)
        {
            AcceptTheValue(length_list_1, value_length_1, length_btn_1, ref actionL1);
        }

        private void length_list_2_Click(object sender, EventArgs e)
        {
            AcceptTheValue(length_list_2, value_length_2, length_btn_2, ref actionL2);
        }

        private void weight_list_1_Click(object sender, EventArgs e)
        {
            AcceptTheValue(weight_list_1, value_weight_1, weight_btn_1, ref actionW1);
        }

        private void weight_list_2_Click(object sender, EventArgs e)
        {
            AcceptTheValue(weight_list_2, value_weight_2, weight_btn_2, ref actionW2);
        }

        private void temperature_list_1_Click(object sender, EventArgs e)
        {
            AcceptTheValue(temperature_list_1, value_temperature_1, temperature_btn_1, ref actionT1);
        }

        private void temperature_list_2_Click(object sender, EventArgs e)
        {
            AcceptTheValue(temperature_list_2, value_temperature_2, temperature_btn_2, ref actionT2);
        }

        private void length_btn_1_Click(object sender, EventArgs e)
        {
            actionL1 = Activity(length_btn_1, length_list_1, actionL1);
        }

        private void length_btn_2_Click(object sender, EventArgs e)
        {
            actionL2 = Activity(length_btn_2, length_list_2, actionL2);
        }

        private void value_length_1_TextChanged(object sender, EventArgs e)
        {
           length_result.Text = LengthFormulas().ToString();
        }
        private void value_length_2_TextChanged(object sender, EventArgs e)
        {
            length_result.Text = LengthFormulas().ToString();
        }

        private void weight_btn_1_Click(object sender, EventArgs e)
        {
            actionW1 = Activity(weight_btn_1, weight_list_1, actionW1);
        }

        private void weight_btn_2_Click(object sender, EventArgs e)
        {
            actionW2 = Activity(weight_btn_2, weight_list_2, actionW2);
        }

        private void length_value_TextChanged(object sender, EventArgs e)
        {
            if (value_length_2.Text == "<Не выбрано>")
                value_length_2.Text = "Километр";
            if (value_length_1.Text == "<Не выбрано>")
                value_length_1.Text = "Метр";
            length_result.Text = LengthFormulas().ToString();
        }

        private void temperature_btn_1_Click(object sender, EventArgs e)
        {
            actionT1 = Activity(temperature_btn_1, temperature_list_1, actionT1);
        }

        private void value_weight_1_TextChanged(object sender, EventArgs e)
        {
            if (value_weight_1.Text == "<Не выбрано>")
                value_weight_1.Text = "Килограмм";
            if (value_weight_2.Text == "<Не выбрано>")
                value_weight_2.Text = "Тонна";
            weight_result.Text = FormulaWeight().ToString();
        }

        private void temperature_btn_2_Click(object sender, EventArgs e)
        {
            actionT2 = Activity(temperature_btn_2, temperature_list_2, actionT2);
        }

        private void temperature_value_TextChanged(object sender, EventArgs e)
        {
            if (value_temperature_1.Text == "<Не выбрано>")
                value_temperature_1.Text = "Кельвин";
            if (value_temperature_2.Text == "<Не выбрано>")
                value_temperature_2.Text = "Кельвин";
            temperature_result.Text = FormulaTemperature().ToString();
        }

        string a = "";
        private void permutation_btn_1_Click(object sender, EventArgs e)
        {
            length_value.Text = length_result.Text;
            a = value_length_1.Text;
            value_length_1.Text = value_length_2.Text;
            value_length_2.Text = a;
        }

        private void permutation_btn_2_Click(object sender, EventArgs e)
        {
            weight_value.Text = weight_result.Text;
            a = value_weight_1.Text;
            value_weight_1.Text = value_weight_2.Text;
            value_weight_2.Text = a;
        }

        private void permutation_btn_3_Click(object sender, EventArgs e)
        {
            temperature_value.Text = temperature_result.Text;
            a = value_temperature_1.Text;
            value_temperature_1.Text = value_temperature_2.Text;
            value_temperature_2.Text = a;
        }

        private void about_the_program_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (aboutOur)
            {
                aboutOur = false;
                aboutProgramm.Visible = false;
                about_the_program.SendToBack();
                if (isLightTheme)
                    about_the_program.BackColor = Color.FromArgb(167, 196, 212);
                else
                    about_the_program.BackColor = Color.FromArgb(53, 71, 83);
            }
            else
            {
                aboutOur = true;
                aboutProgramm.Visible = true;
                about_the_program.BringToFront();
                if (isLightTheme)
                {
                    aboutProgramm.BackColor = Color.White;
                    about_the_program.BackColor = Color.White;
                    label11.BackColor = Color.White;
                    label11.ForeColor = Color.Black;
                }
                else
                {
                    aboutProgramm.BackColor = Color.Black;
                    about_the_program.BackColor = Color.Black;
                    label11.BackColor = Color.Black;
                    label11.ForeColor = Color.White;
                }
            }
        }

        private void day_or_night_Click(object sender, EventArgs e)
        {
            if (isLightTheme)
            {
                BackColor = Color.FromArgb(53, 71, 83);
                about_the_program.BackColor = Color.FromArgb(53, 71, 83);
                pictureBox1.BackColor = Color.FromArgb(41, 47, 43);
                label4.BackColor = Color.FromArgb(41, 47, 43);
                isLightTheme = false;
                day_or_night.Text = "✹";
            }
            else
            {
                BackColor = Color.FromArgb(167, 196, 212);
                about_the_program.BackColor = Color.FromArgb(167, 196, 212);
                pictureBox1.BackColor = Color.FromArgb(243, 191, 195);
                label4.BackColor = Color.FromArgb(243, 191, 195);
                isLightTheme = true;
                day_or_night.Text = "☾";
            }
        }

        private void AcceptTheValue(ListBox lb, Label l, Button btn, ref bool b)
        {
            string value = lb.SelectedItem.ToString();
            if (value != "")
            {
                l.Text = value;
                b = Activity(btn, lb, true);
            }
        }

        private bool Activity(Button b, ListBox lb, bool a)
        {
            if (!a)
            {
                b.Text = "▲";
                lb.Visible = true;
                return true;
            }
            else
            {
                b.Text = "▼";
                lb.Visible = false;
                return false;
            }
        }

        private double LengthFormulas()
        {
            double a;

            if (!double.TryParse(length_value.Text, out a))
            {
                return double.NaN;
            }
            if (value_length_1 == value_length_2)
            {
                return a;
            }
            else if (value_length_1.Text == "Миллиметр")
            {
                a = a / 1000;
            }
            else if (value_length_1.Text == "Сантиметр")
            {
                a = a / 100;
            }
            else if (value_length_1.Text == "Дециметр")
            {
                a = a / 10;
            }
            else if (value_length_1.Text == "Километр")
            {
                a = a * 1000;
            }

            if (value_length_2.Text == "Миллиметр")
            {
                return a * 1000;
            }
            if (value_length_2.Text == "Сантиметр")
            {
                return a * 100;
            }
            if (value_length_2.Text == "Дециметр")
            {
                return a * 10;
            }
            if (value_length_2.Text == "Метр")
            {
                return a;
            }

            return a / 1000;
        }

        private double FormulaWeight()
        {
            double a;

            if (!double.TryParse(weight_value.Text, out a))
            {
                return double.NaN;
            }
            if (value_weight_1 == value_weight_2)
            {
                return a;
            }
            else if (value_weight_1.Text == "Грамм")
            {
                a = a / 1000;
            }
            else if (value_weight_1.Text == "Тонна")
            {
                a = a * 1000;
            }

            if (value_weight_2.Text == "Грамм")
            {
                return a * 1000;
            }
            if (value_weight_2.Text == "Килограмм")
            {
                return a;
            }

            return a / 1000;
        }

        private double FormulaTemperature()
        {
            double a;

            if (!double.TryParse(temperature_value.Text, out a))
            {
                return double.NaN;
            }
            if (value_temperature_1 == value_temperature_2)
            {
                return a;
            }
            else if (value_temperature_1.Text == "Цельсия")
            {
                a = a + 273.15;
            }
            else if (value_temperature_1.Text == "Фаренгейт")
            {
                a = (a - 32) * (5.0/9) + 273.15;
            }

            if (value_temperature_2.Text == "Цельсия")
            {
                return a - 273.15;
            }
            if (value_temperature_2.Text == "Фаренгейт")
            {
                return (a - 273.15) * (9.0 / 5) + 32;
            }

            return a;
        }

    }
}
