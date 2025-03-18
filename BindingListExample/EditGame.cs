using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BindingListExample
{
    public partial class EditGame: Form
    {
        private MainForm _mainForm;
        private Game _editedGame;

        public EditGame(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void EditGame_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }


        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(changedName.Text) ||
               string.IsNullOrWhiteSpace(changedGenre.Text))
            {
                MessageBox.Show("Поля не должны быть пустыми", "Добавление игры", 
            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _editedGame = new Game
            {
                Name = changedName.Text,
                Genre = changedGenre.Text,
                Price = Convert.ToDouble(boxPrice.Value),
                Release = boxRelease.Value.Date
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public Game GetEditedGame()
        {
            return _editedGame;
        }

        public void SetEditedGame(Game game)
        {
            if (_editedGame == null)
            {
                _editedGame = game;
            }
            else
            {
                Console.WriteLine("Предупреждение: Попытка повторной установки EditedGame.");
            }
        }

    }
}
