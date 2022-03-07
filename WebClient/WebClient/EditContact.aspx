﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditContact.aspx.cs" Inherits="WebClient.EditContact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin-top: 5%">
        <div class="row">
            <div class="col-sm-3"></div>
            <div class="col-sm-6">
                <div class="card">
                    <div class="card-header text-center text-light font-weight-bold mb-4 bg-dark">
                        Edit Contact
                    </div>
                    <div class="card-body">
                        <div class="auto-form-wrapper">
                            <form runat="server">
                                <div class="mb-3 row">
                                    <div class="text-danger text-center font-weight-bold col-sm-12">

                                        <asp:Label ID="ErrorMessage" runat="server" Text=""></asp:Label>

                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="label">Name</label>
                                    <div class="input-group">
                                        <asp:TextBox runat="server"
                                            placeholder="Enter Group Name" CssClass="form-control" ID="Name">
                                        </asp:TextBox>

                                    </div>
                                </div>
                                <div class="form-group row">
                                    <div class="col-md-6">
                                        <label class="label">Contact Number</label>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" TextMode="Phone"
                                                placeholder="Enter contact Number" CssClass="form-control" ID="PhoneNumber">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <label class="label">Email</label>
                                        <div class="input-group">
                                            <asp:TextBox runat="server" TextMode="Email"
                                                placeholder="Enter Email" CssClass="form-control" ID="Email">
                                            </asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="label">Description</label>
                                    <div class="input-group">
                                        <asp:TextBox runat="server" TextMode="MultiLine"
                                            placeholder="Enter Description" Rows="3" CssClass="form-control" ID="Description">
                                        </asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Button ID="SubmitButton" CssClass="btn btn-dark submit-btn btn-block" Text="Update" runat="server" OnClick="SubmitButton_Click"></asp:Button>
                                </div>
                            </form>
                        </div>

                    </div>
                </div>
            </div>
            <div class="col-sm-3"></div>
        </div>
    </div>
    <br />
    <br />
</asp:Content>
