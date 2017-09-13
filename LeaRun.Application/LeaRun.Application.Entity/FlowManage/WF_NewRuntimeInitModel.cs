using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeaRun.Application.Entity.FlowManage
{
    /// <summary>
    /// 版 本 6.1
    /// Copyright (c) 2013-2016 北京泉江科技有限公司
    /// 创建人：L&B
    /// 日 期：2016.03.04 16:58
    /// 描 述：工作流流程流转初始化模型类
    /// </summary>
    public class WNewRuntimeInitModel
    {
        /// <summary>
        /// GUID
        /// </summary>
        public string processId { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string processName { get; set; }

        /// <summary>
        /// 流程信息ID号
        /// </summary>
        public string schemeId { get; set; }
        /// <summary>
        /// 重要等级
        /// </summary>
        public int level { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 模板ID序号
        /// </summary>
        public string formId { get; set; }

        /// <summary>
        /// 提交的表单数据
        /// </summary>
        public string formData { get; set; }

    }
}
