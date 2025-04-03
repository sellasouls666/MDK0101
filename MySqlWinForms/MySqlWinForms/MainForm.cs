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
                        MessageBox.Show($"Пользователь с логином '{loginToDelete}' успешно удален.");
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
    }
}
