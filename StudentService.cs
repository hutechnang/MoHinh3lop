using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{

    public class StudentService
    {
        private readonly StudentModel _context;
        public StudentService()
        {
            _context = new StudentModel(); // Khởi tạo context
        }
        public void UpdateMajor(int studentId, int majorId)
        {
            // Tìm sinh viên theo ID
            var student = _context.Students.Find(studentId); // dbContext là đối tượng của bạn để làm việc với cơ sở dữ liệu
            if (student != null)
            {
                student.MajorID = majorId; // Cập nhật MajorID
                _context.SaveChanges(); // Lưu thay đổi
            }
        }
        public string GetAvatarPath(int studentID)
        {
            // Giả sử bạn có một danh sách sinh viên được lưu trong cơ sở dữ liệu
            var student = GetStudentById(studentID);
            return student?.Avatar; // Trả về đường dẫn avatar nếu sinh viên tồn tại, ngược lại trả về null
        }
        public Student GetStudentById(int studentID)
        {
            // Sử dụng _context đã được khởi tạo để truy vấn
            return _context.Students.SingleOrDefault(s => s.StudentID == studentID.ToString());
        }
        public List<Student> getAll()
        {
            StudentModel context = new StudentModel();
            return context.Students.ToList();

        }
        public void AddStudent(Student student)
        {
            try
            {
                _context.Students.Add(student); // Thêm sinh viên vào DbSet
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi thêm sinh viên: " + ex.Message); // Bắt và ném lại lỗi
            }
        }
        public void DeleteStudent(int studentId)
        {

            {
                var student = _context.Students.Find(studentId);
                if (student != null)
                {
                    _context.Students.Remove(student);
                    _context.SaveChanges();
                }
                else
                {
                    throw new Exception("Sinh viên không tồn tại.");
                }
            }
        }
        public void UpdateStudent(Student student)
        {
            // Tìm sinh viên theo ID
            var existingStudent = _context.Students.Find(student.StudentID);
            if (existingStudent != null)
            {
                // Cập nhật các thuộc tính
                existingStudent.FullName = student.FullName;
                existingStudent.AverageScore = student.AverageScore;
                existingStudent.FacultyID = student.FacultyID;
                existingStudent.MajorID = student.MajorID;
                existingStudent.Avatar = student.Avatar;

                // Lưu thay đổi vào cơ sở dữ liệu
                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Sinh viên không tồn tại."); // Nếu không tìm thấy sinh viên
            }
        }

    }
 }
