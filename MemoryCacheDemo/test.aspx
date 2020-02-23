<%@ Page Language="C#"%>
<%
    string response = MemoryCacheDemo.RequestHandler.Handle(Request);
    Response.Write(response);
    //Response.End();
    this.ApplicationInstance.CompleteRequest();
    %>


