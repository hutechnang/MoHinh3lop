using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class MajorService
    {
        public List<Major> GetAllByFaculty(int facultyID)
        {
            using (StudentModel context = new StudentModel())
            {
                // Trả về danh sách các chuyên ngành thuộc khoa có FacultyID tương ứng
                return context.Majors.Where(p => p.FacultyID == facultyID).ToList();
            }
        }
    }
}
