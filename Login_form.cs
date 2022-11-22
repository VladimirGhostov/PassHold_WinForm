using PassHold_WF.Class;

namespace PassHold_WF
{
    public partial class Login_form : Form
    {
        public Login_form()
        {
            InitializeComponent();
        }

        private void Button_enter_Click(object sender, EventArgs e) // Событие нажатия кнопки "Войти"
        {
            // Считываем значения текстбоксов
            string? log = Convert.ToString(textBox_login.Text);
            string? pas = Convert.ToString(textBox_password.Text);

            Login.FileCreate(log, pas);
            bool result = Login.Enter(log, pas);

            // Проверка, сходятся ли пароли

            if (result == true)
            {
                Form_menu newForm = new();
                newForm.Show();
                this.Hide();
            }
        }
    }
}