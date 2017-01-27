using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace StudentsAndCourses
{
    public partial class RegisterStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSend_Click(object sender, EventArgs e)
        {
            this.RegistrationResult.InnerHtml = string.Empty;

            string firstName = this.TextBoxFirstName.Text;
            string lastName = this.TextBoxLastName.Text;
            string facultyNumber = this.TextBoxFacultyNumber.Text;
            string university = this.DropDownUniversity.SelectedValue;
            string specialty = this.DropDownSpeciality.SelectedValue;
            var courses = this.Courses.Items.Cast<ListItem>()
                   .Where(li => li.Selected)
                   .Select(li => li.Value)
                   .ToList();

            this.LabelResult.Text = "Registration Successful!";

            var nameInfo = new HtmlGenericControl("h1");
            nameInfo.InnerText = $"Name: {firstName} {lastName}";
            this.RegistrationResult.Controls.Add(nameInfo);

            var facultyNumberInfo = new HtmlGenericControl("p");
            facultyNumberInfo.InnerText = $"Faculty Number: {facultyNumber}";
            this.RegistrationResult.Controls.Add(facultyNumberInfo);

            var universityInfo = new HtmlGenericControl("p");
            universityInfo.InnerText = $"University: {university}";
            this.RegistrationResult.Controls.Add(universityInfo);

            var specialtyInfo = new HtmlGenericControl("p");
            specialtyInfo.InnerText = $"Specialty: {specialty}";
            this.RegistrationResult.Controls.Add(specialtyInfo);

            var coursesInfo = new HtmlGenericControl("ul");
            coursesInfo.InnerText = $"Courses:";
            foreach (var course in courses)
            {
                var li = new HtmlGenericControl("li");
                li.InnerText = course;
                coursesInfo.Controls.Add(li);
            }
            this.RegistrationResult.Controls.Add(coursesInfo);
        }
    }
}