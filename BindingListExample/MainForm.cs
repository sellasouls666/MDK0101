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

namespace BindingListExample
{
    public partial class MainForm: Form
    {
        private BindingList<Game> Games = new BindingList<Game>();
        public MainForm()
        {
            InitializeComponent();

            Games.Add(new Game
            {
                Name = "Witcher 3",
                Genre = "RPG",
                Price = 1999,
                Release = new DateTime(2015, 10, 10)
            });
            Games.Add(new Game
            {
                Name = "Grand Theft Auto V",
                Genre = "Action",
                Price = 1999,
                Release = new DateTime(2013, 08, 14)
            });
            gameTable.DataSource = Games;
            gameTable.DataSource = Games;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            EditGame editGame = new EditGame(this);

            DialogResult result = editGame.ShowDialog();

            if (result == DialogResult.OK)
            {
                Game newGame = editGame.GetEditedGame();
                if (newGame != null)
                {
                    Games.Add(newGame);
                }

            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
          
                int selectedIndex = gameTable.SelectedRows[0].Index;

                if (selectedIndex < 0 || selectedIndex >= Games.Count)
                {
                    MessageBox.Show("Индекс выбранной строки находится вне допустимого диапазона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return; 
                }

                DialogResult result = MessageBox.Show("Вы уверены, что хотите удалить выбранную игру?", "Подтверждение удаления", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                if (result == DialogResult.Yes)
                {
                    Games.RemoveAt(selectedIndex); 
                    if (selectedIndex < Games.Count)
                    {
                        gameTable.Rows[selectedIndex].Selected = true;
                    }
                    else if (Games.Count > 0)
                    {
                        gameTable.Rows[Games.Count - 1].Selected = true;
                    }
                }
            
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (gameTable.SelectedRows.Count > 0)
            {
                int selectedIndex = gameTable.SelectedRows[0].Index;
                if (selectedIndex < 0 || selectedIndex >= Games.Count)
                {
                    MessageBox.Show("Индекс выбранной строки находится вне допустимого диапазона.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Game selectedGame = Games[selectedIndex];

                EditGame editGame = new EditGame(this);

                PrepareEditForm(editGame, selectedGame);

                DialogResult result = editGame.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Game updatedGame = editGame.GetEditedGame();

                    Games[selectedIndex].Name = updatedGame.Name;
                    Games[selectedIndex].Genre = updatedGame.Genre;
                    Games[selectedIndex].Price = updatedGame.Price;
                    Games[selectedIndex].Release = updatedGame.Release;

                    Games.ResetItem(selectedIndex);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите строку для редактирования.");
            }
        }

        private void PrepareEditForm(EditGame editForm, Game game)
        {
            editForm.SetEditedGame(game);
            editForm.changedName.Text = game.GetName();
            editForm.changedGenre.Text = game.GetGenre();
            editForm.boxPrice.Value = (decimal)game.GetPrice();
            editForm.boxRelease.Value = game.GetRelease();
        }
    }
}
