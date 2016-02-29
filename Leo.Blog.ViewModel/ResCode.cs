using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.Blog.ViewModel
{
   public class ResCode
    {
       private ResCode() { }
        /// <summary>
        /// 消息ID
        /// </summary>
        /// <author>马志远(Marc)</author>
        public string CodeId { get; private set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="productType"></param>
        /// <author>马志远(Marc)</author>
        public ResCode(string codeId, string descripion)
        {
            this.CodeId = codeId;
            this.Description = descripion;
        }
        public static readonly ResCode Success = new ResCode("100", "成功");
        #region 200错误系列是基础性的
        public static readonly ResCode Fail = new ResCode("200", "失败");
        public static readonly ResCode FailActionIsNull = new ResCode("201", "参数Action必须");
        public static readonly ResCode FailActionIsNotExists = new ResCode("202", "参数Action传值不正确");
        public static readonly ResCode FailHttpMethodError = new ResCode("203", "Http请求方式不正确");
        public static readonly ResCode FailParameterFormatIsNotValid = new ResCode("204", "参数格式不正确");
        public static readonly ResCode FailParameterIsNull = new ResCode("205", "参数未赋值");
        public static readonly ResCode FailDeserialize = new ResCode("206", "反序列化失败");
        public static readonly ResCode FailEntityIsNotGet = new ResCode("207", "对象未获取");
        public static readonly ResCode FailEntityIsExists = new ResCode("208", "数据已经存在");
        public static readonly ResCode FailMoreEntity = new ResCode("209", "存在多条记录");
        #endregion
        #region 300错误系列是关于用户的
        public static readonly ResCode FailMobileIsRegisted = new ResCode("300", "手机号已经注册");
        #endregion
        public static readonly ResCode FailServer = new ResCode("500", "服务器内部错误");
    }
}
