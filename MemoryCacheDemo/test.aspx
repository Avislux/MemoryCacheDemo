<%@ Page Language="C#"%>
<%
    string response = MemoryCacheDemo.RequestHandler.Handle(Request);
    Response.ContentType = "application/json";
    Response.Write(response);
    //Response.End();
    this.ApplicationInstance.CompleteRequest();
    %>


