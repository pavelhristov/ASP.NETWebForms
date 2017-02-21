using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using SuperheroesUniverse.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SuperheroesUniverse.UniverseManagement
{
    public partial class EditUsers : Page
    {
        string[] rolesArray;
        MembershipUserCollection users;

        public void Page_Load()
        {
            Msg.Text = "";
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            ApplicationDbContext context = new ApplicationDbContext();
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            //var roleManager = new RoleManager<ApplicationRole>(new UserStore<ApplicationRole>(context));

            if (!IsPostBack)
            {
                // Bind roles to ListBox.

                rolesArray = Roles.GetAllRoles();
                RolesListBox.DataSource = rolesArray;
                RolesListBox.DataBind();


                //var user = userManager.FindByName("no@email.com");
                //userManager.AddToRole(user.Id, rolesArray[0]);
                //context.SaveChanges();
                // Bind users to ListBox.

                users = Membership.GetAllUsers();
                UsersListBox.DataSource = users;
                UsersListBox.DataBind();
            }
        }


        public void AddUser_OnClick(object sender, EventArgs args)
        {
            // Verify that a user and a role are selected.

            if (UsersListBox.SelectedItem == null)
            {
                Msg.Text = "Please select a user.";
                return;
            }

            if (RolesListBox.SelectedItem == null)
            {
                Msg.Text = "Please select a role.";
                return;
            }

            // Add the user to the selected role.

            try
            {
                Roles.AddUserToRole(UsersListBox.SelectedItem.Value, RolesListBox.SelectedItem.Value);
                Msg.Text = "User added to Role.";
            }
            catch (HttpException e)
            {
                Msg.Text = e.Message;
            }
        }

        protected void CreateRoleButton_Click(object sender, EventArgs e)
        {
            string newRoleName = this.RoleName.Text.Trim();

            if (!Roles.RoleExists(newRoleName))
                // Create the role
                Roles.CreateRole(newRoleName);

            this.RoleName.Text = string.Empty;
        }
    }
}