using System;
using FinalProject;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIS247Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BuildStudentData();
        }

        private void BuildStudentData()
        {
            gvStudents.DataSource = null;
            gvStudents.DataSource = StudentBuilder.StudentBody;
        }

        private void btnAddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                //  Get all student values from text box
                var id = txtStudentID.Text;
                var firstName = txtFirstName.Text;
                var lastName = txtLastName.Text;
                var gradeLevel = txtGradeLevel.Text;
                var gpa = Convert.ToDouble(txtGPA.Text);
                var major = txtMajor.Text;

                //  Add values to student here
                Student s = new Student();
                s.FirstName = firstName;
                s.LastName = lastName;
                s.ID = id;
                s.GradeLevel = gradeLevel;
                s.Gpa = gpa;
                s.Major = major;

                //  Add student to list of students
                StudentBuilder.StudentBody.Add(s);
                ClearStudent();// method that clears out the text boxes 
                MessageBox.Show("Student added successfully.");
                BuildStudentData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops! Something went wrong!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            try
            {
                //  gather values for grade from form
                var id = txtGradeStudentID.Text;
                var course = txtCourse.Text;
                var percentage = Convert.ToDouble(txtPercentage.Text);
                var grade = txtGrade.Text;
                var session = txtSession.Text;
                var gradeYear = txtGradeYear.Text;

                //  Add values to grade object

                //  Add gradecard to student
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Oops!  Error while adding grade!", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Student foundStudent = null;
            if (!string.IsNullOrWhiteSpace(txtSearchName.Text))
            {
            foundStudent =  SearchByName(txtSearchName.Text);
            }
            else if (!string.IsNullOrWhiteSpace(txtSearchID.Text))
            {
            foundStudent =  SearchByID(txtSearchID.Text);
            }
            else
            {
                MessageBox.Show("You must have a search value for name or ID!", "Nice try!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            if (foundStudent == null)
            {
                MessageBox.Show("Student not found.");
            }
            else
            {
                txtStudentID.Text = foundStudent.ID;
                txtFirstName.Text = foundStudent.FirstName;
                txtLastName.Text = foundStudent.LastName;
                txtMajor.Text = foundStudent.Major;
                txtGradeLevel.Text = foundStudent.GradeLevel;
                txtGPA.Text = foundStudent.Gpa.ToString();

                StudentBuilder.StudentBody.Remove(foundStudent);
                BuildStudentData();
            }
        }

        private Student SearchByID(string text)
        {
            //throw new NotImplementedException();
            foreach (var student in StudentBuilder.StudentBody)
            {
                if (student.ID == txtSearchID.Text)
                {
                    return student;
                }
            }

            return null;
        }

        private Student SearchByName(string text)
        {
           // throw new NotImplementedException();
            foreach (var student in StudentBuilder.StudentBody)
            {
                if (student.LastName == txtSearchName.Text)
                {
                    return student;
                }
                
            }

            return null;
        }

        private void ClearStudent()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtStudentID.Text = string.Empty;
            txtMajor.Text = string.Empty;
            txtGradeLevel.Text = string.Empty;
            txtGPA.Text = string.Empty;
        }
    }
}
