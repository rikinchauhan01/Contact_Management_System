﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.GroupServiceReference;

namespace WebClient
{
    public partial class DeleteGroup : System.Web.UI.Page
    {
        GroupServiceClient proxy;

        int UserId, GroupId;

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                var grp = new Group1();
                grp.GroupId = GroupId;
                var grpContact = new GroupContact1();
                grpContact.GroupId = GroupId;
                ((IGroupService)proxy).DeleteGroupContactByGroupId(grpContact);
                ((IGroupService)proxy).DeleteGroup(grp);
                Response.Redirect("~/GroupList.aspx");
            }
            catch (System.ServiceModel.CommunicationException)
            {
                proxy = new GroupServiceClient();
                Server.Transfer("~/Dashboard.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewGroup.aspx?GroupId=" + GroupId);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    this.Context.Items.Add("ErrorMessage", "Access Denied! Please Login");
                    Server.Transfer("~/Login.aspx");
                }
                proxy = new GroupServiceClient();
                if (Request.QueryString["GroupId"] == null)
                {
                    Response.Redirect("~/404.aspx");
                }
                GroupId = Int32.Parse(Request.QueryString["GroupId"]);

                UserId = Int32.Parse(Session["UserId"].ToString());
                var group = new Group1();
                group.UserId = UserId;
                group.GroupId = GroupId;
                var fetchedGroup = ((IGroupService)proxy).GetGroup(group);

                if (fetchedGroup.GroupId == 0)
                {
                    Response.Redirect("~/404.aspx");
                }
                if (fetchedGroup.UserId != UserId)
                {
                    Response.Redirect("~/AccessDenied.aspx");
                }
                GrpData.Text = "Name :- " + fetchedGroup.Name +
                                "<br>Description :- " + fetchedGroup.Description +
                                "<br>Total Contacts :- " + ((IGroupService)proxy).GetGroupContacts(GroupId).Length;
            }
            catch (System.ServiceModel.CommunicationException)
            {
                proxy = new GroupServiceClient();
                Server.Transfer("~/Dashboard.aspx");
            }
        }
    }
}