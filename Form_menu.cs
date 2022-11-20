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

namespace PassHold_WF
{
    public partial class Form_menu : Form
    {
        public string select = ("");
        
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
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Database.ReadData();

            dataGridView1.DataSource = Database.ReadData().Tables[0];
        }

        private void ToolStripButton2_Click(object sender, EventArgs e)
        {
            //string select = dataGridView1.CurrentCell.Value.ToString();
            MessageBox.Show(select);


            Database.DeleteData(select);
        }

        public void DataGridView1_CellClick(object sender, string select, DataGridViewCellEventArgs e)
        {
            select = dataGridView1.CurrentCell.Value.ToString();
        }
    }
}
