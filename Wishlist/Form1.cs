using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace Wishlist
{
    public partial class Form1 : Form
    {
        private ContextMenuStrip rowMenu = new ContextMenuStrip();
        private int rightClickedRowIndex = -1;

        // Database connection string
        private string connectionString =
                       "Server=localhost;" +
                       "Port=3306;" +
                       "Database=wishlist;" +
                       "Uid=root;" +
                       "Pwd=;";

      
        // Load wishlist items from the database into the DataGridView
        private void LoadWishlist()
        {
            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT * FROM items";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Clear old rows before loading
                            dgvWishlist.Rows.Clear();

                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["id"]);
                                string name = reader["name"].ToString();
                                string item1 = reader["item1"].ToString();
                                string item2 = reader["item2"].ToString();

                                decimal amount =
                                    Convert.ToDecimal(reader["amount"]);

                                dgvWishlist.Rows.Add(
                                    id,
                                    name,
                                    item1,
                                    item2,
                                    amount.ToString("$#,##0.00")
                                );
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error loading wishlist: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        public Form1()
        {
            InitializeComponent();

            SetupWishlistTable();

            // Load wishlist items from the database into the DataGridView
            LoadWishlist();

            btnAddToWishlist.Click += btnAddToWishlist_Click;
            dgvWishlist.MouseDown += dgvWishlist_MouseDown;

            

            ToolStripMenuItem deleteItem =
                new ToolStripMenuItem("Delete");

            deleteItem.Click += deleteItem_Click;
            rowMenu.Items.Add(deleteItem);
        }


        private void SetupWishlistTable()
        {
            dgvWishlist.AllowUserToAddRows = false;
            dgvWishlist.AllowUserToDeleteRows = false;
            dgvWishlist.ReadOnly = true;
            dgvWishlist.MultiSelect = false;
            dgvWishlist.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            // Add hidden ID column at the beginning
            if (!dgvWishlist.Columns.Contains("colId"))
            {
                DataGridViewTextBoxColumn idColumn =
                    new DataGridViewTextBoxColumn();

                idColumn.Name = "colId";
                idColumn.HeaderText = "ID";
                idColumn.Visible = false;

                dgvWishlist.Columns.Insert(0, idColumn);
            }
        }



        private void btnAddToWishlist_Click(object sender, EventArgs e)
        {
            string name = txtWishlistName.Text.Trim();
            string item1 = txtItem1.Text.Trim();
            string item2 = txtItem2.Text.Trim();
            string amountText = txtAmount.Text.Trim();

            // Validate empty fields
            if (name == "" || item1 == "" ||
                item2 == "" || amountText == "")
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            // Validate amount
            decimal amount;

            if (!decimal.TryParse(amountText, out amount) || amount < 0)
            {
                MessageBox.Show("Please enter a valid amount.");
                return;
            }

            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO items
                             (name, item1, item2, amount)
                             VALUES
                             (@name, @item1, @item2, @amount)";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@item1", item1);
                        cmd.Parameters.AddWithValue("@item2", item2);
                        cmd.Parameters.AddWithValue("@amount", amount);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Add to DataGridView after successful database insertion
                LoadWishlist();

                MessageBox.Show("Wishlist saved successfully!");

                // Clear input fields
                txtWishlistName.Clear();
                txtItem1.Clear();
                txtItem2.Clear();
                txtAmount.Clear();

                txtWishlistName.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error saving wishlist: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void dgvWishlist_MouseDown(
            object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            DataGridView.HitTestInfo hit =
                dgvWishlist.HitTest(e.X, e.Y);

            if (hit.RowIndex >= 0 &&
                hit.RowIndex < dgvWishlist.Rows.Count)
            {
                rightClickedRowIndex = hit.RowIndex;

                dgvWishlist.ClearSelection();
                dgvWishlist.Rows[hit.RowIndex].Selected = true;

                rowMenu.Show(dgvWishlist, e.Location);
            }
            else
            {
                rightClickedRowIndex = -1;
            }
        }


        private void deleteItem_Click(object sender, EventArgs e)
        {
            int rowIndex = rightClickedRowIndex;

            if (rowIndex < 0 ||
                rowIndex >= dgvWishlist.Rows.Count)
                return;

            // Get the database ID of the selected row
            int id = Convert.ToInt32(
                dgvWishlist.Rows[rowIndex].Cells["colId"].Value
            );

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this wishlist item?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
            );

            if (result != DialogResult.Yes)
                return;

            try
            {
                using (MySqlConnection conn =
                    new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "DELETE FROM items WHERE id = @id";

                    using (MySqlCommand cmd =
                        new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Wishlist deleted successfully!");

                            // Refresh the DataGridView
                            LoadWishlist();
                        }
                        else
                        {
                            MessageBox.Show("Record not found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error deleting wishlist: " + ex.Message,
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            rightClickedRowIndex = -1;
        }


        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnAddToWishlist_Click_1(object sender, EventArgs e)
        {

        }

        private void dgvWishlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
