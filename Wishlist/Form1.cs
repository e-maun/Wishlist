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

namespace Wishlist
{
    public partial class Form1 : Form
    {
        private ContextMenuStrip rowMenu = new ContextMenuStrip();
        private int rightClickedRowIndex = -1;

        public Form1()
        {
            InitializeComponent();

            SetupWishlistTable();

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

            if (dgvWishlist.Columns.Count == 0)
            {
                dgvWishlist.Columns.Add("colName", "Name");
                dgvWishlist.Columns.Add("colItem1", "Item 1");
                dgvWishlist.Columns.Add("colItem2", "Item 2");
                dgvWishlist.Columns.Add("colAmount", "Amount");
            }
        }

        private void btnAddToWishlist_Click(
            object sender, EventArgs e)
        {
            string name = txtWishlistName.Text.Trim();
            string item1 = txtItem1.Text.Trim();
            string item2 = txtItem2.Text.Trim();
            string amountText = txtAmount.Text.Trim();

            if (name == "" || item1 == "" ||
                item2 == "" || amountText == "")
            {
                MessageBox.Show(
                    "Please fill in all fields.",
                    "Missing Information",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            decimal amount;

            if (!decimal.TryParse(amountText, out amount)
                || amount < 0)
            {
                MessageBox.Show(
                    "Please enter a valid, non-negative amount.",
                    "Invalid Amount",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            dgvWishlist.Rows.Add(
                name, item1, item2, amount.ToString("$#,##0.00"));

            txtWishlistName.Clear();
            txtItem1.Clear();
            txtItem2.Clear();
            txtAmount.Clear();

            txtWishlistName.Focus();
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

        private void deleteItem_Click(
            object sender, EventArgs e)
        {
            int rowIndex = rightClickedRowIndex;

            if (rowIndex < 0 ||
                rowIndex >= dgvWishlist.Rows.Count)
                return;

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this wishlist item?",
                "Confirm Deletion",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                dgvWishlist.Rows.RemoveAt(rowIndex);
                rightClickedRowIndex = -1;
            }
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
