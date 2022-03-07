﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ContactServiceReference;
using WebClient.GroupServiceReference;

namespace WebClient
{
    public partial class DeleteContact : System.Web.UI.Page
    {
        ContactServiceClient contactProxy;

        GroupServiceClient groupProxy;

        int UserId, ContactId;

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                var contact = new Contact1();
                groupProxy = new GroupServiceClient();
                GroupContact1 groupContact = new GroupContact1();
                groupContact.ContactId = ContactId;
                ((IGroupService)groupProxy).DeleteGroupContactByContactId(groupContact);
                contact.ContactId = ContactId;
                ((IContactService)contactProxy).DeleteContact(contact);
                Response.Redirect("~/ContactList.aspx");
            }
            catch (System.ServiceModel.CommunicationException)
            {
                groupProxy = new GroupServiceClient();
                contactProxy = new ContactServiceClient();
                Server.Transfer("~/Dashboard.aspx");
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ViewContact.aspx?ContactId=" + ContactId);
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
                if (Request.QueryString["ContactId"] == null)
                {
                    Response.Redirect("~/404.aspx");
                }
                contactProxy = new ContactServiceClient();
                ContactId = Int32.Parse(Request.QueryString["ContactId"]);
                UserId = Int32.Parse(Session["UserId"].ToString());
                var contact = new Contact1();
                contact.UserId = UserId;
                contact.ContactId = ContactId;
                var fetchedContact = ((IContactService)contactProxy).GetContact(contact);

                if (fetchedContact.ContactId == 0)
                {
                    Response.Redirect("~/404.aspx");
                }
                if (fetchedContact.UserId != UserId)
                {
                    Response.Redirect("~/AccessDenied.aspx");
                }
                ContactData.Text = "Name :- " + fetchedContact.Name +
                                "<br>Phone number :- " + fetchedContact.PhoneNumber +
                                "<br>Email :- " + fetchedContact.Email +
                                "<br>Description :- " + fetchedContact.Description;
            }
            catch (System.ServiceModel.CommunicationException)
            {
                groupProxy = new GroupServiceClient();
                contactProxy = new ContactServiceClient();
                Server.Transfer("~/Dashboard.aspx");
            }
        }
    }
}