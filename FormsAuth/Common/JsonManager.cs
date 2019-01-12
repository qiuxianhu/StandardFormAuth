using FormsAuth.Models;
using System;
using System.Web.Mvc;

namespace FormsAuth.Common
{
    public static class JsonManager
    {
        public static JsonResult GetSuccess(string successMessage)
        {
            return Get(new JsonModel()
            {
                Code = (int)ResponseStatusCodeEnum.OK,
                Data = null,
                Error = successMessage,
                Success = true,
                Message = successMessage
            });
        }

        public static JsonResult GetError(string errorMessage)
        {
            return Get(new JsonModel()
            {
                Code = (int)ResponseStatusCodeEnum.BadRequest,
                Data = null,
                Error = errorMessage,
                Success = false,
                Message = errorMessage
            });
        }
        public static JsonResult Get(JsonModel jsonModel)
        {
            if (jsonModel == null)
            {
                throw new ArgumentNullException("jsonModel");
            }
            return new JsonResult()
            {
                Data = jsonModel,
                MaxJsonLength = int.MaxValue,
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}