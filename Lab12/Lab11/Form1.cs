using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11
{
    string connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyBanHang;Integrated Security=True";
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Kết nối (Nhớ dùng Server Name bạn đã connect thành công ở SQL nhé)
                string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyBanHang;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    con.Open();
                    // 2. Gọi lệnh Thêm từ SQL
                    SqlCommand cmd = new SqlCommand("sp_InsertKhachHang", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // 3. Lấy dữ liệu từ mấy cái ô bạn đã đặt tên lúc nãy
                    cmd.Parameters.AddWithValue("@MaKH", txtMaKH.Text);
                    cmd.Parameters.AddWithValue("@TenKH", txtTen.Text);
                    cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);

                    // 4. Chạy
                    cmd.ExecuteNonQuery();
                    System.Windows.Forms.MessageBox.Show("Thêm thành công cho " + txtTen.Text + " rồi!");
                }
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Lỗi: " + ex.Message);
            }

        }
    }
}
