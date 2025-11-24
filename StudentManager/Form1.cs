using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManager
{
    public partial class Form1 : Form
    {
        // -----------------------
        // KHAI BÁO DANH SÁCH SINH VIÊN
        // -----------------------
        List<Student> students = new List<Student>();

        public Form1()
        {
            InitializeComponent();
            cboGender.Items.Add("Khác");
        }
    }

        // -----------------------
        // KHAI BÁO LỚP SINH VIÊN
        // -----------------------
        public class Student
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public string Class { get; set; }
        public int Age { get; set; }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboGender.Items.Add("Nam");
            cboGender.Items.Add("Nữ");
            cboGender.Items.Add("Khác");

            cboGender.SelectedIndex = 0; // chọn "Nam" làm mặc định
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.Text = textBox1.Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student()
            {
                Name = txtName.Text,
                Gender = cboGender.Text,
                Class = txtClass.Text
                students.Add(s);
            };

            students.Add(s);

            dgvStudents.DataSource = null;
            dgvStudents.DataSource = students;
            MessageBox.Show("Thêm sinh viên thành công!");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                int index = dgvStudents.CurrentRow.Index;
                students[index].Name = txtName.Text;
                students[index].Gender = cboGender.Text;
                students[index].Class = txtClass.Text;
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;
            }
            MessageBox.Show("Cập nhật sinh viên thành công!");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow != null)
            {
                int index = dgvStudents.CurrentRow.Index;
                students.RemoveAt(index);
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;
            }
            MessageBox.Show("Xóa sinh viên thành công!");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtName.Text.ToLower();
            var result = students.FindAll(s => s.Name.ToLower().Contains(keyword));
            dgvStudents.DataSource = null;
            dgvStudents.DataSource = result;

        }

        private void dgvStudents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvStudents.Rows[e.RowIndex].Cells[1].Value.ToString();
                cboGender.Text = dgvStudents.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtClass.Text = dgvStudents.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }
    }
}
MessageBox.Show("Hello");
