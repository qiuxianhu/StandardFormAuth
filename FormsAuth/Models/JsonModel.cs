using System;

namespace FormsAuth.Models
{
    /// <summary>
    /// json通信实体
    /// </summary>
    [Serializable]
    public class JsonModel
    {
        /// <summary>
        /// 错误码(0表示无错误)
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Success { get; set; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string Error { get; set; }
        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Json数据
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// 服务器响应时间 
        /// </summary>
        public long ResponseTicks
        {
            get
            {
                return DateTime.Now.Ticks;
            }
        }
    }
}