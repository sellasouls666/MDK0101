using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySqlWinForms
{
    public partial class AddForm: Form
    {
        public UserInfo NewUser { get; set; }
        private bool isEditMode = false;

        public AddForm()
        {
            InitializeComponent();
            isEditMode = false;
        }


        public AddForm(UserInfo user)
        {
            InitializeComponent();
            isEditMode = true;

            loginTextBox.Text = user.Login;
            nameTextBox.Text = user.Name;
            surnameTextBox.Text = user.Surname;
            datePicker.Value = user.Birhday;
            passwordTextBox.Text = user.Password;
            emailTextBox.Text = user.Email;
        }

        private void OKbutton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
            {
                MessageBox.Show("Поле 'Login' обязательно для заполнения.");
                return; // Прерываем выполнение, если поле пустое
            }
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("Поле 'Имя' обязательно для заполнения.");
                return; // Прерываем выполнение, если поле пустое
            }
            if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
            {
                MessageBox.Show("Поле 'Фамилия' обязательно для заполнения.");
                return; // Прерываем выполнение, если поле пустое
            }
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                MessageBox.Show("Поле 'Пароль' обязательно для заполнения.");
                return; // Прерываем выполнение, если поле пустое
            }
            if (string.IsNullOrWhiteSpace(emailTextBox.Text))
            {
                MessageBox.Show("Поле 'Email' обязательно для заполнения.");
                return; // Прерываем выполнение, если поле пустое
            }

            NewUser = new UserInfo(loginTextBox.Text); 
            NewUser.Name = nameTextBox.Text;
            NewUser.Surname = surnameTextBox.Text;
            NewUser.Birhday = datePicker.Value;  
            NewUser.Password = passwordTextBox.Text; 
            NewUser.Email = emailTextBox.Text;

            this.DialogResult = DialogResult.OK;  
            this.Close();  
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel; 
            this.Close();
        }
    }
}
