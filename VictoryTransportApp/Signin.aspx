<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Signin.aspx.cs"
    ClientIDMode="Static" Inherits="VictoryTransportApp.Signin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Content/css/app.css" rel="stylesheet" type="text/css" runat="server" />
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">
    <title>Login Page</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="BodyContent" runat="server">
    <div class="d-flex justify-content-start h-100">
        <div class="card">
            <div class="card-header">
                <h3>Sign In</h3>
            </div>
            <div class="card-body">
                <%--<form>--%>
                <div class="input-group form-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-user"></i></span>
                    </div>
                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="username"></asp:TextBox>

                </div>
                <div class="input-group form-group">
                    <div class="input-group-prepend">
                        <span class="input-group-text"><i class="fas fa-key"></i></span>
                    </div>
                    <asp:TextBox ID="Password" runat="server" CssClass="form-control" TextMode="Password" placeholder="password"></asp:TextBox>
                </div>
                <div class="row align-items-center remember">
                    <asp:CheckBox ID="CheckBox1" runat="server" />
                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Remember Me"></asp:Label>
                </div>
                <%--<div class="form-group">
						<asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn float-right login_btn" OnClick="Button1_Click" />
						<asp:Label ID="Label4" runat="server"></asp:Label>
					</div>--%>
                <div class="form-group">
                    <asp:LinkButton runat="server" ID="Button" Text="<i class='fas fa-sign-in-alt'></i> Login"
                        OnClick="Button1_Click" CssClass="btn float-right login_btn" />
                    <asp:Label ID="Label4" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
