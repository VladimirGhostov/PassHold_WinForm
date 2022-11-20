using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using PassHold_WF.Class;

namespace PassHold_WF
{
    public partial class Form_menu : Form
    { 
        public Form_menu()
        {
            InitializeComponent();
        }

        private void Form_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Database.Close_Connect(); // Перед завершением программы прекращаем работать с базой данных
            Application.Exit(); // Завершение программы
        }

        private void Form_menu_Load(object sender, EventArgs e)
        {
            Database.Create_Connect(); // Начинаем работу с базой данных
            Database.CreateTable(); // Создаём таблицу
        }

        private void Button_enterData_Click(object sender, EventArgs e)
        {
            // Считываем значение текстбоксов
            string id = textBox_ent_id.Text; 
            string login = textBox_ent_login.Text;
            string password = textBox_ent_password.Text;

            Database.InsertData(id, login, password);

            notifyIcon1.ShowBalloonTip(1000, "PassHold", "Запись занесена в базу данных", ToolTipIcon.Info);

            textBox_ent_id.Clear();
            textBox_ent_login.Clear();
            textBox_ent_password.Clear();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Database.ReadData();

            dataGridView1.DataSource = Database.ReadData().Tables[0];
        }

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string? s = dataGridView1.SelectedCells[0].Value.ToString();
            //MessageBox.Show(s);
            Clipboard.SetText(s);
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            string delete = Clipboard.GetText();

            Database.DeleteData(delete);
        }
    }
}
