using FormsAuth.Common;
using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Security.Principal;
using System.Web.Security;

namespace FormsAuth.Models
{
    [Serializable]
    public class User:IIdentity, ISerializable
    {
        public User()
        {
            this.IsAuthenticated = false;
        }
        /// <summary>
        /// 通过客户端Ticket创建用户标识
        /// </summary>
        /// <param name="ticket"></param>
        public User(FormsAuthenticationTicket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException("ticket");
            }
            User user = this.Desrialize(ticket.UserData);
            if (user == null || FormsAuthenticationHelper.TicketVersion != ticket.Version)
            {
                this.IsAuthenticated = false;
                return;
            }
            this.ID = user.ID;
            this.Name = user.Name;           
            this.IsAuthenticated = true;
        }
        public int ID { get; set; }
       
        public string Name { get; set; }

        /// <summary>
        /// 授权类型
        /// </summary>
        public string AuthenticationType
        {
            get { return "qxh"; }
        }

        public bool IsAuthenticated { get; set; }
               

        [SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ID", this.ID);
            info.AddValue("Name", this.Name);           
        }

        /// <summary>
        /// 序列化登录人的信息
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            return SerializeHelper.Serialize(this);
        }
        /// <summary>
        /// 反序列化登录人的信息
        /// </summary>
        /// <param name="userContextData"></param>
        /// <returns></returns>
        public User Desrialize(string userContextData)
        {
            User user = null;
            try
            {
                user = SerializeHelper.Deserialize<User>(userContextData);
            }
            catch
            {
                user = null;
            }
            return user;
        }
        
    }
}