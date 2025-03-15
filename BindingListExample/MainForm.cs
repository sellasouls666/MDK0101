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
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var EditForm = new EditGame();
            EditForm.Show();
        }
    }
}
