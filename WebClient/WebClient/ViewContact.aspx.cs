﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.ContactServiceReference;

namespace WebClient
{
    public partial class ViewContact : System.Web.UI.Page
    {
        ContactServiceClient proxy;

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
                int ContactId = Int32.Parse(Request.QueryString["ContactId"]);
                var UserId = Int32.Parse(Session["UserId"].ToString());
                proxy = new ContactServiceClient();
                var contact = new Contact1();
                contact.UserId = UserId;
                contact.ContactId = ContactId;

                var fetchedContact = ((IContactService)proxy).GetContact(contact);
                if (fetchedContact.ContactId == 0)
                {
                    Response.Redirect("~/404.aspx");
                }
                if (fetchedContact.UserId != UserId)
                {
                    Response.Redirect("~/AccessDenied.aspx");
                }

                Name.Text = fetchedContact.Name;
                PhoneNumber.Text = fetchedContact.PhoneNumber;
                Description.Text = fetchedContact.Description;
                Email.Text = fetchedContact.Email;
                EditContactLink.NavigateUrl = "EditContact.aspx?ContactId=" + ContactId;
                DeleteContactLink.NavigateUrl = "DeleteContact.aspx?ContactId=" + ContactId;
            }
            catch (System.ServiceModel.CommunicationException)
            {
                proxy = new ContactServiceClient();
                Server.Transfer("~/Dashboard.aspx");
            }
        }
    }
}