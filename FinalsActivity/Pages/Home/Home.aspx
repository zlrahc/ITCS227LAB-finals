<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Home/HomeMaster.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalsActivity.Pages.Home.Home" %>

<asp:Content ID="Home" ContentPlaceHolderID="HomeMasterContent" runat="server">
    
<a href="~/Pages/Home/Login.aspx" class="welcome-container" id="welcomeLink" runat="server">
  <span id="welcomeText">WELCOME</span>
</a>

<script>
  const welcomeText = document.getElementById('welcomeText');
  const welcomeLink = document.getElementById('welcomeLink');

  let toggle = false;

  setInterval(() => {
    // Start fade out
    welcomeText.classList.add('fade-out');

    // After fade out ends, change text and fade back in
    setTimeout(() => {
      welcomeText.textContent = toggle ? 'WELCOME' : 'CLICK ANYWHERE';
      welcomeText.classList.remove('fade-out');
      welcomeText.classList.add('fade-in');

      // Remove fade-in after animation to reset
      setTimeout(() => {
        welcomeText.classList.remove('fade-in');
      }, 1000);

      toggle = !toggle;
    }, 1000);

  }, 4000); // 4 seconds cycle (1s fade out + 2s visible + 1s fade in)
</script>

</asp:Content>