using BUS;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoHinh3Lop
{
    public partial class Form1 : Form
    {
        private readonly StudentService studentService = new StudentService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            List<Student> students = studentService.getAll();
            dataGridView1.DataSource = students;
            dataGridView1.Columns["Faculty"].Visible = false;
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy dữ liệu từ các textbox
                string studentID = Convert.ToString(txtMSSV.Text);
                string fullName = txtHoTen.Text;
                double averageScore = Convert.ToDouble(txtDiemTB.Text);
                int facultyID = Convert.ToInt32(txtKhoa.Text);


                // Tạo sinh viên mới từ dữ liệu nhập vào
                Student newStudent = new Student
                {
                    StudentID = studentID, // Thêm ID sinh viên nếu cần thiết
                    FullName = fullName,
                    AverageScore = averageScore,
                    FacultyID = facultyID
                };

                StudentService.AddStudent(newStudent);
                LoadData(); // Cập nhật lại DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm sinh viên: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    int studentId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StudentID"].Value);
                    StudentService.DeleteStudent(studentId);
                    LoadData(); // Cập nhật lại DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi xóa sinh viên: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                try
                {
                    // Lấy dữ liệu từ các textbox
                    int studentID = Convert.ToInt32(txtMSSV.Text);
                    string fullName = txtHoTen.Text;
                    double averageScore = Convert.ToDouble(txtDiemTB.Text);
                    int facultyID = Convert.ToInt32(txtKhoa.Text);
                    // Lấy sinh viên từ DataGridView
                    int selectedStudentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["StudentID"].Value);
                    Student student = StudentService.GetStudentById(selectedStudentID);

                    // Cập nhật thông tin sinh viên
                    student.FullName = fullName;
                    student.AverageScore = averageScore;
                    student.FacultyID = facultyID;

                    StudentService.UpdateStudent(student);
                    LoadData(); // Cập nhật lại DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi sửa sinh viên: " + ex.Message);
                }
            }
        }
        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}


