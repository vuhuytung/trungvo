﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataContext
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class ProjectDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public ProjectDataContext() : 
				base(global::DataContext.Properties.Settings.Default.Database1ConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ProjectDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspProjectGetTop3")]
		public ISingleResult<uspProjectGetTop3Result> uspProjectGetTop3([global::System.Data.Linq.Mapping.ParameterAttribute(Name="CategoryID", DbType="Int")] System.Nullable<int> categoryID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoryID);
			return ((ISingleResult<uspProjectGetTop3Result>)(result.ReturnValue));
		}
	}
	
	public partial class uspProjectGetTop3Result
	{
		
		private int _NewsID;
		
		private string _Title;
		
		private string _Description;
		
		private string _Content;
		
		private string _Img;
		
		private System.DateTime _CreateDate;
		
		private System.Nullable<System.DateTime> _PublishDate;
		
		private System.Nullable<int> _UserID;
		
		private System.Nullable<System.DateTime> _LastModify;
		
		private int _CategoryID;
		
		private string _Resource;
		
		private bool _Status;
		
		public uspProjectGetTop3Result()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_NewsID", DbType="Int NOT NULL")]
		public int NewsID
		{
			get
			{
				return this._NewsID;
			}
			set
			{
				if ((this._NewsID != value))
				{
					this._NewsID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Title", DbType="NVarChar(400) NOT NULL", CanBeNull=false)]
		public string Title
		{
			get
			{
				return this._Title;
			}
			set
			{
				if ((this._Title != value))
				{
					this._Title = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NText", UpdateCheck=UpdateCheck.Never)]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this._Description = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Content", DbType="NVarChar(MAX) NOT NULL", CanBeNull=false)]
		public string Content
		{
			get
			{
				return this._Content;
			}
			set
			{
				if ((this._Content != value))
				{
					this._Content = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Img", DbType="VarChar(200)")]
		public string Img
		{
			get
			{
				return this._Img;
			}
			set
			{
				if ((this._Img != value))
				{
					this._Img = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreateDate", DbType="DateTime NOT NULL")]
		public System.DateTime CreateDate
		{
			get
			{
				return this._CreateDate;
			}
			set
			{
				if ((this._CreateDate != value))
				{
					this._CreateDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PublishDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> PublishDate
		{
			get
			{
				return this._PublishDate;
			}
			set
			{
				if ((this._PublishDate != value))
				{
					this._PublishDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int")]
		public System.Nullable<int> UserID
		{
			get
			{
				return this._UserID;
			}
			set
			{
				if ((this._UserID != value))
				{
					this._UserID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastModify", DbType="DateTime")]
		public System.Nullable<System.DateTime> LastModify
		{
			get
			{
				return this._LastModify;
			}
			set
			{
				if ((this._LastModify != value))
				{
					this._LastModify = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryID", DbType="Int NOT NULL")]
		public int CategoryID
		{
			get
			{
				return this._CategoryID;
			}
			set
			{
				if ((this._CategoryID != value))
				{
					this._CategoryID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Resource", DbType="NVarChar(250)")]
		public string Resource
		{
			get
			{
				return this._Resource;
			}
			set
			{
				if ((this._Resource != value))
				{
					this._Resource = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit NOT NULL")]
		public bool Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				if ((this._Status != value))
				{
					this._Status = value;
				}
			}
		}
	}
}
#pragma warning restore 1591