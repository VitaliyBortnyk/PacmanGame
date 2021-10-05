using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Pacman
{
    public partial class Results : Form
    {
        private GameResults gameResults;

        public Results()
        {
            InitializeComponent();

            gameResults = new GameResults();

            lbMenu.MouseEnter += new EventHandler(GlobalLabelEffects.ItemHover);
            lbMenu.MouseLeave += new EventHandler(GlobalLabelEffects.ItemLeave);

            ShowList(dataGridView1);
            DeleteAccess(btnDelSelected, btnDelAll, btnSearch, dataGridView1, lbNickname, tbNickname, lbNotFound);
        }
        ~Results() { }

        private void ShowList(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            dataGridView.ClearSelection();

            gameResults.resultsList = SortResults.SortDescending(gameResults.resultsList);

            foreach (Result item in gameResults.resultsList)
            {
                dataGridView.Rows.Add(item.nickname, item.score, item.attempt);
            }

            Leaderboard(dataGridView);
            dataGridView.ClearSelection();
        }

        private void Leaderboard(DataGridView dataGridView)
        {
            int rowNumber = 1;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow)
                    continue;

                row.HeaderCell.Value = rowNumber.ToString();
                rowNumber++;
            }
            dataGridView.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }

        private void DeleteAccess(Button delSelectedBTN, Button delAllBTN, Button searchBTN,
            DataGridView dataGridView, Label nicknameLB, TextBox nicknameTB, Label notFoundLB)
        {
            if (string.IsNullOrEmpty(Methods.GetCurrentUser().login))
            {
                delSelectedBTN.Visible = false;
                delAllBTN.Visible = false;

                dataGridView.Height += 100;
                nicknameLB.Top += 100;
                nicknameTB.Top += 100;
                notFoundLB.Top += 100;
                searchBTN.Top += 100;
            }
        }

        private void tbNickname_TextChanged(object sender, EventArgs e)
        {
            gameResults.enteredNickname = tbNickname.Text;
        }

        private void SelectResults(DataGridView dataGridView, TextBox nicknameTB, Label notFoundLB)
        {
            dataGridView.ClearSelection();
            gameResults.incorectNickname = string.Empty;
            notFoundLB.Text = gameResults.incorectNickname;

            if (!gameResults.SearchResults().Count.Equals(0))
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                    foreach (Result item in gameResults.SearchResults())
                        if (row.Cells[0].Value.Equals(item.nickname))
                            row.Selected = true;
            }
            else
                Errors(nicknameTB, notFoundLB);
        }

        private void Errors(TextBox nicknameTB, Label notFoundLB)
        {
            if (string.IsNullOrEmpty(gameResults.enteredNickname))
            {
                InfoForm infoForm = new InfoForm();
                infoForm.EmptyTextBox();
                infoForm.ShowDialog();
            }
            else
            {
                if (nicknameTB.Text.Length >= 17)
                    notFoundLB.Font = new Font("Microsoft Sans Serif",
                        8F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
                else
                    notFoundLB.Font = new Font("Microsoft Sans Serif",
                        10.2F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(204)));
            }
            notFoundLB.Text = gameResults.incorectNickname;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            SelectResults(dataGridView1, tbNickname, lbNotFound);
        }

        private List<Result> GetDeleteList(DataGridViewSelectedRowCollection rowsList)
        {
            List<Result> list = new List<Result>();

            foreach (DataGridViewRow row in rowsList)
                list.Add(new Result(Convert.ToString(row.Cells[0].Value),
                                 Convert.ToInt32(row.Cells[1].Value),
                                 Convert.ToInt32(row.Cells[2].Value)));

            return list;
        }

        private void DeleteFromTable(DataGridView dataGridView, string mode)
        {
            switch(mode)
            {
                case "selected": break;
                case "all": dataGridView.SelectAll(); break;
                default: return;
            }

            gameResults.resultsList = gameResults.DeleteResults(GetDeleteList(dataGridView1.SelectedRows));
            ShowList(dataGridView);
        }

        private void BtnDelSelected_Click(object sender, EventArgs e)
        {
            DeleteFromTable(dataGridView1, "selected");
        }

        private void BtnDelAll_Click(object sender, EventArgs e)
        {
            DeleteFromTable(dataGridView1, "all");
        }

        private void LbMenu_Click(object sender, EventArgs e)
        {
            Close();

            Menu menu = new Menu();
            menu.Visible = true;
        }

        private void TextBox_Validator(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58 && e.KeyChar <= 64 || e.KeyChar >= 91 &&
                e.KeyChar <= 96 || e.KeyChar >= 123) && number != 8 && number != 95)
                e.Handled = true;
        }
    }
}
