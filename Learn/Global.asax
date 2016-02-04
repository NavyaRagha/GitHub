<%@ Application Language="C#" %>
<%@ Import Namespace="System.Net" %>
<%@ Import Namespace="System.Web.Configuration" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="Microsoft.AspNet.FriendlyUrls" %>

<script runat="server">

    void RegisterRoutes(RouteCollection routes)
    {
        routes.EnableFriendlyUrls();
        routes.MapPageRoute("home", "home", "~/Default.aspx");
        routes.MapPageRoute("Signin", "Signin", "~/SignIn.aspx");
        routes.MapPageRoute("Login", "login", "~/SignIn.aspx");
        routes.MapPageRoute("register", "register", "~/SignUp.aspx");
        routes.MapPageRoute("join", "join", "~/SignUp.aspx");
    }

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup
        RegisterRoutes(RouteTable.Routes);

        //ScriptManager.ScriptResourceMapping.AddDefinition("jquery",new ScriptResourceDefinition
        //{
        //    Path="~/scrips/jquery-1.4.1.min.js",
        //    DebugPath="~/scripts/jquery-1.4.1.js",
        //    CdnPath="http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.min.js",
        //    CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.js"
        //});



        ScriptResourceDefinition myScriptResDef = new ScriptResourceDefinition();
        myScriptResDef.Path = "~/scrips/jquery-1.4.1.min.js";
        myScriptResDef.DebugPath = "~/scripts/jquery-1.4.1.js";
        myScriptResDef.CdnPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.min.js";
        myScriptResDef.CdnDebugPath = "http://ajax.microsoft.com/ajax/jQuery/jquery-1.4.1.js";
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", null, myScriptResDef);

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

</script>
