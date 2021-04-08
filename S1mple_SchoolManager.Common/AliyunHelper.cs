//using System;
//using System.Linq;
//using System.Text;
//using Aliyun.OpenServices.OpenStorageService;
//using System.Configuration;
//using System.IO;
//using System.Web;

//namespace S1mple_SchoolManager.Common
//{
//    /// <summary>
//    /// 阿里云
//    /// </summary>
//    public class AliyunHelper
//    {
//        private static string accessid = ConfigurationManager.AppSettings["accessid"];

//        private static string accesskey = ConfigurationManager.AppSettings["accesskey"];

//        private static string endPoint = ConfigurationManager.AppSettings["endPoint"];

//        private static string bucket = ConfigurationManager.AppSettings["bucket"];

//        private static string fileUrl = ConfigurationManager.AppSettings["fileUrl"];

//        #region 上传文件
//        /// <summary>
//        /// 上传文件
//        /// </summary>
//        /// <param name="files"></param>
//        /// <returns></returns>
//        public static string UploadFile(HttpFileCollectionBase files)
//        {
//            try
//            {
//                if (files.Count > 0)
//                {
//                    StringBuilder sb = new StringBuilder();

//                    OssClient client = new OssClient(endPoint, accessid, accesskey);

//                    var objMetadata = new ObjectMetadata();

//                    for (int i = 0; i < files.Count; i++)
//                    {
//                        var c = files[i];
//                        if (c != null && c.ContentLength > 0)
//                        {
//                            int lastSlashIndex = c.FileName.LastIndexOf("\\");

//                            string fileName = c.FileName.Substring(lastSlashIndex + 1, c.FileName.Length - lastSlashIndex - 1);

//                            string fix = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();//获取文件后缀
//                            string filename = "GiveMedicine_Project/" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".png";

//                            var putResult = client.PutObject(bucket, filename, c.InputStream, objMetadata);

//                            sb.Append("," + fileUrl + filename);
//                        }
//                    }

//                    if (sb.Length > 0)
//                    {
//                        return sb.ToString().Substring(1);
//                    }
//                }
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                return string.Empty;
//            }
//        }
//        #endregion

//        #region 上传文件（IO）
//        /// <summary>
//        /// 上传文件
//        /// </summary>
//        /// <param name="files"></param>
//        /// <returns></returns>
//        public static string UploadFile(Stream io, string fix, string type)
//        {
//            try
//            {

//                OssClient client = new OssClient(endPoint, accessid, accesskey);

//                var objMetadata = new ObjectMetadata();

//                //string fix = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();//获取文件后缀

//                string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + type + "." + fix;

//                var putResult = client.PutObject(bucket, filename, io, objMetadata);


//                return fileUrl + filename;

//            }
//            catch (Exception ex)
//            {
//                return string.Empty;
//            }
//        }
//        #endregion

//        #region 上传大文件
//        public static string UploadBigFile(HttpFileCollectionBase files)
//        {
//            //string start = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
//            try
//            {
//                if (files.Count > 0)
//                {
//                    StringBuilder sb = new StringBuilder();

//                    OssClient client = new OssClient(endPoint, accessid, accesskey);

//                    var objMetadata = new ObjectMetadata();

//                    for (int i = 0; i < files.Count; i++)
//                    {
//                        var c = files[i];
//                        long fileSize = c.InputStream.Length;
//                        if (c != null && c.ContentLength > 0)
//                        {
//                            int lastSlashIndex = c.FileName.LastIndexOf("\\");

//                            string fileName = c.FileName.Substring(lastSlashIndex + 1, c.FileName.Length - lastSlashIndex - 1);

//                            string fix = fileName.Substring(fileName.LastIndexOf(".") + 1).ToLower();//获取文件后缀

//                            string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + fix;

//                            //实例化MultipartUpload
//                            var multipart = client.InitiateMultipartUpload(new InitiateMultipartUploadRequest(bucket, filename));

//                            byte[] fileData = new byte[c.InputStream.Length];

//                            c.InputStream.Read(fileData, 0, fileData.Length);

//                            long partSize = 10 * 1024 * 1024; //每次上传大小 10mb

//                            int partcount = (int)Math.Ceiling(Math.Round((c.InputStream.Length / (double)partSize))); //上传次数

//                            long uploadCount = 0;

//                            for (int j = 0; j < partcount; j++)
//                            {
//                                //截取文件
//                                if (fileSize - uploadCount < partSize)
//                                {
//                                    partSize = fileSize - uploadCount;
//                                }

//                                byte[] temp = new byte[partSize];

//                                Array.Copy(fileData, temp, temp.Length);

//                                Stream partstream = new MemoryStream(temp);
//                                //将文件内容分为多个part上传
//                                UploadPartRequest upr = new UploadPartRequest(bucket, filename, multipart.UploadId)
//                                {
//                                    InputStream = partstream,
//                                    PartNumber = j + 1,
//                                    PartSize = partSize
//                                };
//                                //返回的part上传结果
//                                var partResult = client.UploadPart(upr);

//                                uploadCount += partSize;
//                            }
//                            //完成MultipartUpload
//                            CompleteMultipartUploadRequest cmur = new CompleteMultipartUploadRequest(bucket, filename, multipart.UploadId);

//                            var cplResult = client.CompleteMultipartUpload(cmur);

//                            sb.Append("," + cplResult.Location);
//                        }
//                    }

//                    if (sb.Length > 0)
//                    {
//                        return sb.ToString().Substring(1);
//                    }
//                }
//                return string.Empty;
//            }
//            catch (Exception ex)
//            {
//                return string.Empty;
//            }
//        }
//        #endregion

//        #region 上传文件 流
//        /// <summary>
//        /// 上传文件
//        /// </summary>
//        /// <param name="stream">流</param>
//        /// <param name="ext">文件后缀</param>
//        /// <returns></returns>
//        public static string UploadFile(Stream stream, string ext)
//        {
//            try
//            {
//                if (stream != null && stream.Length > 0)
//                {
//                    StringBuilder sb = new StringBuilder();

//                    OssClient client = new OssClient(endPoint, accessid, accesskey);

//                    var objMetadata = new ObjectMetadata();

//                    string filename = DateTime.Now.ToString("yyyyMMddHHmmssfff") + "." + ext;

//                    var putResult = client.PutObject(bucket, filename, stream, objMetadata);

//                    return sb.Append(fileUrl + filename).ToString();
//                }
//            }
//            catch (Exception)
//            {

//            }
//            return string.Empty;
//        }
//        #endregion
//    }
//}
