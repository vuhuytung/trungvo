﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.235
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
	public partial class AdminDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public AdminDataContext() : 
				base(global::DataContext.Properties.Settings.Default.Database1ConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public AdminDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdminDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdminDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public AdminDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspFunctionByParentID")]
		public ISingleResult<uspFunctionByParentIDResult> uspFunctionByParentID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParentID", DbType="Int")] System.Nullable<int> parentID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), parentID, status);
			return ((ISingleResult<uspFunctionByParentIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspFunctionGetInfoByFunctionID")]
		public ISingleResult<uspFunctionGetInfoByFunctionIDResult> uspFunctionGetInfoByFunctionID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FunctionID", DbType="Int")] System.Nullable<int> functionID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), functionID);
			return ((ISingleResult<uspFunctionGetInfoByFunctionIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleGetAll")]
		public ISingleResult<uspRoleGetAllResult> uspRoleGetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<uspRoleGetAllResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspFunctionDeleteByFunctionID")]
		public int uspFunctionDeleteByFunctionID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FunctionID", DbType="Int")] System.Nullable<int> functionID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), functionID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspFunctionInsert")]
		public int uspFunctionInsert([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(100)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Url", DbType="NVarChar(255)")] string url, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Order", DbType="Int")] System.Nullable<int> order, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParrentID", DbType="Int")] System.Nullable<int> parrentID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, url, order, parrentID, status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspFunctionUpdateByFunctionID")]
		public int uspFunctionUpdateByFunctionID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="FunctionID", DbType="Int")] System.Nullable<int> functionID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(100)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Url", DbType="NVarChar(255)")] string url, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Order", DbType="Int")] System.Nullable<int> order, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="ParrentID", DbType="Int")] System.Nullable<int> parrentID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), functionID, name, url, order, parrentID, status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleGetInfoByRoleID")]
		public ISingleResult<uspRoleGetInfoByRoleIDResult> uspRoleGetInfoByRoleID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="RoleID", DbType="Int")] System.Nullable<int> roleID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), roleID);
			return ((ISingleResult<uspRoleGetInfoByRoleIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleUpdateByRoleID")]
		public int uspRoleUpdateByRoleID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="RoleID", DbType="Int")] System.Nullable<int> roleID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(50)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="NVarChar(500)")] string description, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), roleID, name, description, status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleInsert")]
		public int uspRoleInsert([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(50)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Description", DbType="NVarChar(500)")] string description, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, description, status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleDeleteByRoleID")]
		public int uspRoleDeleteByRoleID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="RoleID", DbType="Int")] System.Nullable<int> roleID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), roleID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleUpdateStatus")]
		public int uspRoleUpdateStatus([global::System.Data.Linq.Mapping.ParameterAttribute(Name="RoleID", DbType="Int")] System.Nullable<int> roleID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Int")] System.Nullable<int> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), roleID, status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleGetListNotInFunction")]
		public ISingleResult<uspRoleGetListNotInFunctionResult> uspRoleGetListNotInFunction([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> functionID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), functionID);
			return ((ISingleResult<uspRoleGetListNotInFunctionResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleGetListByFunction")]
		public ISingleResult<uspRoleGetListByFunctionResult> uspRoleGetListByFunction([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> functionID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), functionID);
			return ((ISingleResult<uspRoleGetListByFunctionResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspFunctionGetChildInRole")]
		public ISingleResult<uspFunctionGetChildInRoleResult> uspFunctionGetChildInRole([global::System.Data.Linq.Mapping.ParameterAttribute(Name="RoleID", DbType="Int")] System.Nullable<int> roleID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), roleID);
			return ((ISingleResult<uspFunctionGetChildInRoleResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspRoleFunctionUpdate")]
		public int uspRoleFunctionUpdate([global::System.Data.Linq.Mapping.ParameterAttribute(Name="RoleID", DbType="Int")] System.Nullable<int> roleID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="FunctionID", DbType="Int")] System.Nullable<int> functionID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Permission", DbType="Int")] System.Nullable<int> permission)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), roleID, functionID, permission);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class uspFunctionByParentIDResult
	{
		
		private int _FunctionID;
		
		private string _Name;
		
		private string _Url;
		
		private int _Order;
		
		private int _ParrentID;
		
		private System.Nullable<int> _Status;
		
		public uspFunctionByParentIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FunctionID", DbType="Int NOT NULL")]
		public int FunctionID
		{
			get
			{
				return this._FunctionID;
			}
			set
			{
				if ((this._FunctionID != value))
				{
					this._FunctionID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this._Url = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Order]", Storage="_Order", DbType="Int NOT NULL")]
		public int Order
		{
			get
			{
				return this._Order;
			}
			set
			{
				if ((this._Order != value))
				{
					this._Order = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParrentID", DbType="Int NOT NULL")]
		public int ParrentID
		{
			get
			{
				return this._ParrentID;
			}
			set
			{
				if ((this._ParrentID != value))
				{
					this._ParrentID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
		public System.Nullable<int> Status
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
	
	public partial class uspFunctionGetInfoByFunctionIDResult
	{
		
		private int _FunctionID;
		
		private string _Name;
		
		private string _Url;
		
		private int _Order;
		
		private int _ParrentID;
		
		private System.Nullable<int> _Status;
		
		public uspFunctionGetInfoByFunctionIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FunctionID", DbType="Int NOT NULL")]
		public int FunctionID
		{
			get
			{
				return this._FunctionID;
			}
			set
			{
				if ((this._FunctionID != value))
				{
					this._FunctionID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this._Url = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Order]", Storage="_Order", DbType="Int NOT NULL")]
		public int Order
		{
			get
			{
				return this._Order;
			}
			set
			{
				if ((this._Order != value))
				{
					this._Order = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParrentID", DbType="Int NOT NULL")]
		public int ParrentID
		{
			get
			{
				return this._ParrentID;
			}
			set
			{
				if ((this._ParrentID != value))
				{
					this._ParrentID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int")]
		public System.Nullable<int> Status
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
	
	public partial class uspRoleGetAllResult
	{
		
		private int _RoleID;
		
		private string _Name;
		
		private string _Description;
		
		private int _Status;
		
		public uspRoleGetAllResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int NOT NULL")]
		public int RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					this._RoleID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(500)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
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
	
	public partial class uspRoleGetInfoByRoleIDResult
	{
		
		private int _RoleID;
		
		private string _Name;
		
		private string _Description;
		
		private int _Status;
		
		public uspRoleGetInfoByRoleIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int NOT NULL")]
		public int RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					this._RoleID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarChar(500)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
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
	
	public partial class uspRoleGetListNotInFunctionResult
	{
		
		private int _RoleID;
		
		private string _Name;
		
		private int _Status;
		
		public uspRoleGetListNotInFunctionResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int NOT NULL")]
		public int RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					this._RoleID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
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
	
	public partial class uspRoleGetListByFunctionResult
	{
		
		private int _RoleFunctionID;
		
		private int _RoleID;
		
		private int _Permission;
		
		private string _Name;
		
		private int _Status;
		
		private int _FunctionID;
		
		public uspRoleGetListByFunctionResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleFunctionID", DbType="Int NOT NULL")]
		public int RoleFunctionID
		{
			get
			{
				return this._RoleFunctionID;
			}
			set
			{
				if ((this._RoleFunctionID != value))
				{
					this._RoleFunctionID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int NOT NULL")]
		public int RoleID
		{
			get
			{
				return this._RoleID;
			}
			set
			{
				if ((this._RoleID != value))
				{
					this._RoleID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Permission", DbType="Int NOT NULL")]
		public int Permission
		{
			get
			{
				return this._Permission;
			}
			set
			{
				if ((this._Permission != value))
				{
					this._Permission = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Int NOT NULL")]
		public int Status
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FunctionID", DbType="Int NOT NULL")]
		public int FunctionID
		{
			get
			{
				return this._FunctionID;
			}
			set
			{
				if ((this._FunctionID != value))
				{
					this._FunctionID = value;
				}
			}
		}
	}
	
	public partial class uspFunctionGetChildInRoleResult
	{
		
		private string _Name;
		
		private string _ParentName;
		
		private int _FunctionID;
		
		private int _ParrentID;
		
		private int _Order;
		
		private string _OrderParent;
		
		private int _Permission;
		
		public uspFunctionGetChildInRoleResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(100) NOT NULL", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this._Name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentName", DbType="NVarChar(50)")]
		public string ParentName
		{
			get
			{
				return this._ParentName;
			}
			set
			{
				if ((this._ParentName != value))
				{
					this._ParentName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FunctionID", DbType="Int NOT NULL")]
		public int FunctionID
		{
			get
			{
				return this._FunctionID;
			}
			set
			{
				if ((this._FunctionID != value))
				{
					this._FunctionID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParrentID", DbType="Int NOT NULL")]
		public int ParrentID
		{
			get
			{
				return this._ParrentID;
			}
			set
			{
				if ((this._ParrentID != value))
				{
					this._ParrentID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[Order]", Storage="_Order", DbType="Int NOT NULL")]
		public int Order
		{
			get
			{
				return this._Order;
			}
			set
			{
				if ((this._Order != value))
				{
					this._Order = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_OrderParent", DbType="NVarChar(50)")]
		public string OrderParent
		{
			get
			{
				return this._OrderParent;
			}
			set
			{
				if ((this._OrderParent != value))
				{
					this._OrderParent = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Permission", DbType="Int NOT NULL")]
		public int Permission
		{
			get
			{
				return this._Permission;
			}
			set
			{
				if ((this._Permission != value))
				{
					this._Permission = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
