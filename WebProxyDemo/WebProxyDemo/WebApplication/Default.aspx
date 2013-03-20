<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web Proxy Demo</title>

    <script type="text/javascript" src="Scripts/jquery-1.9.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div id="buttons">
            <input type="button" id="jQueryButton" name="jQueryButton" value="Direct" />
            <input type="button" id="WebProxyButton" name="WebProxyButton" value="Web Proxy" />
        </div>
        <div id="console">
            <label id="displayText"></label>
        </div>
    </div>
    </form>
    <script type="text/javascript">
       $(document).ready(function () {
           $('#jQueryButton').click(function () {
               // This call should fail due to cross domain javascript
                $.ajax({
                    type: "GET",
                    url: "http://localhost:1059/api/Authorization?username=bwakefield",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (msg) {
                        alert(msg.d);
                    },
                    error: function () {
                        alert("Failed cross domain javascript call!");
                    }
                });
            });

           $("#WebProxyButton").click(function () {
               // this call should be successful, javascript calls local "proxy" service which
               // then calls the service hosted on the external domain
                $.ajax({
                    type: "GET",
                    url: "Services/TestService.svc/CallServer",
                    contentType: "application/json",
                    dataType: "json",
                    success: function (msg) {
                        alert(msg.d);
                    },
                    error: function () {
                        alert("Failed web proxy call!");
                    }
                });
            });


       });

    </script>
</body>
</html>
