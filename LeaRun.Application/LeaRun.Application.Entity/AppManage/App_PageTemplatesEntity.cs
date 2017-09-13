using LeaRun.Application.Code;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LeaRun.Application.Entity.AppManage
{
	public class App_PageTemplatesEntity : BaseEntity
	{
		[Column("ID")]
		public string Id
		{
			get;
			set;
		}

		[Column("PROJECTID")]
		public string ProjectId
		{
			get;
			set;
		}

		[Column("NAME")]
		public string Name
		{
			get;
			set;
		}

		[Column("TYPE")]
		public int? Type
		{
			get;
			set;
		}

		[Column("CONTENT")]
		public string Content
		{
			get;
			set;
		}

		[Column("CREATEDATE")]
		public DateTime? CreateDate
		{
			get;
			set;
		}

		[Column("CREATEUSERID")]
		public string CreateUserId
		{
			get;
			set;
		}

		[Column("CREATEUSERNAME")]
		public string CreateUserName
		{
			get;
			set;
		}

		public override void Create()
		{
			this.Id = Guid.NewGuid().ToString();
			this.CreateDate = new DateTime?(DateTime.Now);
			this.CreateUserId = OperatorProvider.Provider.Current().UserId;
			this.CreateUserName = OperatorProvider.Provider.Current().UserName;
		}

		public override void Modify(string keyValue)
		{
			this.Id = keyValue;
		}
	}
}
