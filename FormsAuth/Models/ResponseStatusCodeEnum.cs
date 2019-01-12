using System.ComponentModel;

namespace FormsAuth.Models
{
    public enum ResponseStatusCodeEnum
    {
        [Description("OK")]
        OK = 200,
        [Description("临时重定向")]
        Found = 302,
        [Description("报文语法错误")]
        BadRequest=400,
        [Description("Forbidden")]
        Forbidden =403,
        [Description("NotFound")]
        NotFound = 404,
        [Description("InternalServerError")]
        InternalServerError =500

    }
}