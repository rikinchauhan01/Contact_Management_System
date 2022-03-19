﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.GroupServiceReference;

namespace WebClient
{
    public partial class NewGroup : System.Web.UI.Page
    {
        GroupServiceClient proxy;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                this.Context.Items.Add("ErrorMessage", "Access Denied! Please Login");
                Server.Transfer("~/Login.aspx");
            }
        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                proxy = new GroupServiceReference.GroupServiceClient();
                Group1 group = new Group1();
                group.Name = Name.Text;
                group.Description = Description.Text;
                group.UserId = Int32.Parse(Session["UserId"].ToString());
                var fetchedGroup = ((IGroupService)proxy).AddGroup(group);
                if (fetchedGroup.GroupId == -1)
                {
                    ErrorMessage.Text = "Group Name is already Used";
                    return;
                }
                Response.Redirect("GroupList.aspx");
            }
            catch (System.ServiceModel.CommunicationException)
            {
                proxy = new GroupServiceClient();
                Server.Transfer("~/Dashboard.aspx");
            }
        }
    }
}