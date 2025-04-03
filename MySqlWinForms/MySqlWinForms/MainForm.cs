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
    public partial class MainForm: Form
    {
        SQLUserReader sqlreader = new SQLUserReader();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            UsersTable.DataSource = null;  // Очистите DataSource перед обновлением
            UsersTable.DataSource = sqlreader.ReadUsers();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (UsersTable.SelectedRows.Count > 0)
            {
                string loginToDelete = UsersTable.SelectedRows[0].Cells["login"].Value.ToString(); // Получаем login выбранной строки

                if (MessageBox.Show($"Вы уверены, что хотите удалить пользователя с логином '{loginToDelete}'?", "Подтверждение удаления", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (sqlreader.DeleteUser(loginToDelete))
                    {
                        RefreshDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить пользователя.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для удаления.");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                UserInfo newUser = addForm.NewUser;

                if (sqlreader.AddUser(newUser))
                {
                    MessageBox.Show($"Пользователь с логином '{newUser.Login}' успешно добавлен.");
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Не удалось добавить пользователя.");
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (UsersTable.SelectedRows.Count > 0)
            {
                string oldLogin = UsersTable.SelectedRows[0].Cells["login"].Value.ToString(); // Сохраняем старый логин

                UserInfo userToEdit = null;
                foreach (UserInfo user in sqlreader.ReadUsers()) // Ищем в текущих данных
                {
                    if (user.Login == oldLogin)
                    {
                        userToEdit = user;
                        break;
                    }
                }

                if (userToEdit != null)
                {
                    AddForm editForm = new AddForm(userToEdit);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        UserInfo updatedUser = editForm.NewUser;

                        // Проверяем уникальность нового логина
                        if (updatedUser.Login != oldLogin && !sqlreader.IsLoginUnique(updatedUser.Login))
                        {
                            MessageBox.Show("Логин уже используется. Пожалуйста, выберите другой.");
                            return;
                        }

                        if (sqlreader.UpdateUser(updatedUser, oldLogin)) // Передаем старый логин
                        {
                            MessageBox.Show($"Пользователь с логином '{updatedUser.Login}' успешно обновлен.");
                            RefreshDataGridView();
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить пользователя.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Не удалось найти пользователя для редактирования.");
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
            }
        }
    }
}
