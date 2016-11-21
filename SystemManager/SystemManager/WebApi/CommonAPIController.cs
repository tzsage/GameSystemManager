using Code;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;

namespace SystemManager.WebApi
{
    public class CommonAPIController : ApiController
    {

        //api/CommonAPI/UploadImage
        public async Task<string> UploadImage()
        {

            try
            {
                // 是否请求包含multipart/form-data。
                if (!Request.Content.IsMimeMultipartContent())
                {
                    throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
                }

                string root = HttpContext.Current.Server.MapPath("/UploadFiles/");
                if (!Directory.Exists(HttpContext.Current.Server.MapPath("~/UploadFiles/")))
                {
                    Directory.CreateDirectory(HttpContext.Current.Server.MapPath("~/UploadFiles/"));
                }

                var provider = new MultipartFormDataStreamProvider(root);

                StringBuilder sb = new StringBuilder(); // Holds the response body

                // 阅读表格数据并返回一个异步任务.
                await Request.Content.ReadAsMultipartAsync(provider);
                // 如何上传文件到文件名.
                foreach (var file in provider.FileData)
                {
                    string orfilename = file.Headers.ContentDisposition.FileName.TrimStart('"').TrimEnd('"');
                    FileInfo fileinfo = new FileInfo(file.LocalFileName);
                    if (fileinfo.Length <= 0)
                    {
                        throw new Exception();
                    }
                    //else if (fileinfo.Length > ConfigHelper.MaxFileSize)
                    //{
                    //    json.Msg = "上传文件大小超过限制";
                    //    json.Code = 302;
                    //}
                    else
                    {
                        string fileExt = orfilename.Substring(orfilename.LastIndexOf('.'));
                        //定义允许上传的文件扩展名
                        //String fileTypes = SettingConfig.FileTypes;
                        //if (String.IsNullOrEmpty(fileExt) || Array.IndexOf(fileTypes.Split(','), fileExt.Substring(1).ToLower()) == -1)
                        //{
                        //    json.Msg = "图片类型不正确";
                        //    json.Code = 303;
                        //}
                        //else
                        //{
                        //String ymd = DateTime.Now.ToString("yyyyMMdd", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                        //String newFileName = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);

                        fileinfo.CopyTo(Path.Combine(root, fileinfo.Name + fileExt), true);
                        fileinfo.Delete();//删除原文件
                        return  Path.Combine(root, fileinfo.Name + fileExt) ;
                        //json.Success = true;
                        //json.Msg = "操作成功";
                        //json.Code = 200;
                        //sb.Append("/UploadFiles/" + fileinfo.Name + fileExt);
                        //json.Data = sb.ToString();
                        //}
                    }
                  
                }
            }
            catch (System.Exception e)
            {
               
            }
            return "";
        }
    }
}
