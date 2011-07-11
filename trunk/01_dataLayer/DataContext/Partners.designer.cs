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
	public partial class PartnersDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public PartnersDataContext() : 
				base(global::DataContext.Properties.Settings.Default.Database1ConnectionString1, mappingSource)
		{
			OnCreated();
		}
		
		public PartnersDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PartnersDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PartnersDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public PartnersDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspPartnersGetAll")]
		public ISingleResult<uspPartnersGetAllResult> uspPartnersGetAll()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<uspPartnersGetAllResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspPartnersGetInfoByPartnersID")]
		public ISingleResult<uspPartnersGetInfoByPartnersIDResult> uspPartnersGetInfoByPartnersID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PartnersID", DbType="Int")] System.Nullable<int> partnersID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), partnersID);
			return ((ISingleResult<uspPartnersGetInfoByPartnersIDResult>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspPartnersUpdateByPartnersID")]
		public int uspPartnersUpdateByPartnersID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PartnersID", DbType="Int")] System.Nullable<int> partnersID, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(200)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Img", DbType="VarChar(200)")] string img, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Website", DbType="VarChar(400)")] string website, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Bit")] System.Nullable<bool> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), partnersID, name, img, website, status);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspPartnersDeleteByPartnersID")]
		public int uspPartnersDeleteByPartnersID([global::System.Data.Linq.Mapping.ParameterAttribute(Name="PartnersID", DbType="Int")] System.Nullable<int> partnersID)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), partnersID);
			return ((int)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.uspPartnersInsert")]
		public int uspPartnersInsert([global::System.Data.Linq.Mapping.ParameterAttribute(Name="Name", DbType="NVarChar(200)")] string name, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Img", DbType="VarChar(200)")] string img, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Website", DbType="VarChar(400)")] string website, [global::System.Data.Linq.Mapping.ParameterAttribute(Name="Status", DbType="Bit")] System.Nullable<bool> status)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), name, img, website, status);
			return ((int)(result.ReturnValue));
		}
	}
	
	public partial class uspPartnersGetAllResult
	{
		
		private int _PartnersID;
		
		private string _Name;
		
		private string _Img;
		
		private string _Website;
		
		private System.Nullable<bool> _Status;
		
		public uspPartnersGetAllResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PartnersID", DbType="Int NOT NULL")]
		public int PartnersID
		{
			get
			{
				return this._PartnersID;
			}
			set
			{
				if ((this._PartnersID != value))
				{
					this._PartnersID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(200)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Website", DbType="VarChar(400)")]
		public string Website
		{
			get
			{
				return this._Website;
			}
			set
			{
				if ((this._Website != value))
				{
					this._Website = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit")]
		public System.Nullable<bool> Status
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
	
	public partial class uspPartnersGetInfoByPartnersIDResult
	{
		
		private int _PartnersID;
		
		private string _Name;
		
		private string _Img;
		
		private string _Website;
		
		private System.Nullable<bool> _Status;
		
		public uspPartnersGetInfoByPartnersIDResult()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PartnersID", DbType="Int NOT NULL")]
		public int PartnersID
		{
			get
			{
				return this._PartnersID;
			}
			set
			{
				if ((this._PartnersID != value))
				{
					this._PartnersID = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarChar(200)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Website", DbType="VarChar(400)")]
		public string Website
		{
			get
			{
				return this._Website;
			}
			set
			{
				if ((this._Website != value))
				{
					this._Website = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Status", DbType="Bit")]
		public System.Nullable<bool> Status
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