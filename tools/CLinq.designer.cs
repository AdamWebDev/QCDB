﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Qualified_Contractor_Tracking.tools
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="contractors")]
	public partial class CLinqDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertlookupTypeOfPolicy(lookupTypeOfPolicy instance);
    partial void UpdatelookupTypeOfPolicy(lookupTypeOfPolicy instance);
    partial void DeletelookupTypeOfPolicy(lookupTypeOfPolicy instance);
    partial void InsertReportBrokerInfo(ReportBrokerInfo instance);
    partial void UpdateReportBrokerInfo(ReportBrokerInfo instance);
    partial void DeleteReportBrokerInfo(ReportBrokerInfo instance);
    partial void InsertReportAODA(ReportAODA instance);
    partial void UpdateReportAODA(ReportAODA instance);
    partial void DeleteReportAODA(ReportAODA instance);
    #endregion
		
		public CLinqDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["contractorsConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public CLinqDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CLinqDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CLinqDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public CLinqDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<lookupTypeOfPolicy> lookupTypeOfPolicies
		{
			get
			{
				return this.GetTable<lookupTypeOfPolicy>();
			}
		}
		
		public System.Data.Linq.Table<ReportBrokerInfo> ReportBrokerInfos
		{
			get
			{
				return this.GetTable<ReportBrokerInfo>();
			}
		}
		
		public System.Data.Linq.Table<ReportAODA> ReportAODAs
		{
			get
			{
				return this.GetTable<ReportAODA>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.lookupTypeOfPolicy")]
	public partial class lookupTypeOfPolicy : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _Type;
		
		private System.Nullable<bool> _Active;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnTypeChanging(string value);
    partial void OnTypeChanged();
    partial void OnActiveChanging(System.Nullable<bool> value);
    partial void OnActiveChanged();
    #endregion
		
		public lookupTypeOfPolicy()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Type", DbType="NVarChar(25)")]
		public string Type
		{
			get
			{
				return this._Type;
			}
			set
			{
				if ((this._Type != value))
				{
					this.OnTypeChanging(value);
					this.SendPropertyChanging();
					this._Type = value;
					this.SendPropertyChanged("Type");
					this.OnTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Active", DbType="Bit")]
		public System.Nullable<bool> Active
		{
			get
			{
				return this._Active;
			}
			set
			{
				if ((this._Active != value))
				{
					this.OnActiveChanging(value);
					this.SendPropertyChanging();
					this._Active = value;
					this.SendPropertyChanged("Active");
					this.OnActiveChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ReportBrokerInfo")]
	public partial class ReportBrokerInfo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _ID;
		
		private string _BrokerName;
		
		private string _BrokerAddress;
		
		private string _BrokerEmail;
		
		private string _Company;
		
		private System.Nullable<System.DateTime> _ExpiryDate;
		
		private System.Nullable<int> _TypeOfPolicy;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(int value);
    partial void OnIDChanged();
    partial void OnBrokerNameChanging(string value);
    partial void OnBrokerNameChanged();
    partial void OnBrokerAddressChanging(string value);
    partial void OnBrokerAddressChanged();
    partial void OnBrokerEmailChanging(string value);
    partial void OnBrokerEmailChanged();
    partial void OnCompanyChanging(string value);
    partial void OnCompanyChanged();
    partial void OnExpiryDateChanging(System.Nullable<System.DateTime> value);
    partial void OnExpiryDateChanged();
    partial void OnTypeOfPolicyChanging(System.Nullable<int> value);
    partial void OnTypeOfPolicyChanged();
    #endregion
		
		public ReportBrokerInfo()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerName", DbType="NVarChar(255)")]
		public string BrokerName
		{
			get
			{
				return this._BrokerName;
			}
			set
			{
				if ((this._BrokerName != value))
				{
					this.OnBrokerNameChanging(value);
					this.SendPropertyChanging();
					this._BrokerName = value;
					this.SendPropertyChanged("BrokerName");
					this.OnBrokerNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerAddress", DbType="NVarChar(255)")]
		public string BrokerAddress
		{
			get
			{
				return this._BrokerAddress;
			}
			set
			{
				if ((this._BrokerAddress != value))
				{
					this.OnBrokerAddressChanging(value);
					this.SendPropertyChanging();
					this._BrokerAddress = value;
					this.SendPropertyChanged("BrokerAddress");
					this.OnBrokerAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_BrokerEmail", DbType="NVarChar(100)")]
		public string BrokerEmail
		{
			get
			{
				return this._BrokerEmail;
			}
			set
			{
				if ((this._BrokerEmail != value))
				{
					this.OnBrokerEmailChanging(value);
					this.SendPropertyChanging();
					this._BrokerEmail = value;
					this.SendPropertyChanged("BrokerEmail");
					this.OnBrokerEmailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Company", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Company
		{
			get
			{
				return this._Company;
			}
			set
			{
				if ((this._Company != value))
				{
					this.OnCompanyChanging(value);
					this.SendPropertyChanging();
					this._Company = value;
					this.SendPropertyChanged("Company");
					this.OnCompanyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExpiryDate", DbType="Date")]
		public System.Nullable<System.DateTime> ExpiryDate
		{
			get
			{
				return this._ExpiryDate;
			}
			set
			{
				if ((this._ExpiryDate != value))
				{
					this.OnExpiryDateChanging(value);
					this.SendPropertyChanging();
					this._ExpiryDate = value;
					this.SendPropertyChanged("ExpiryDate");
					this.OnExpiryDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_TypeOfPolicy", DbType="Int")]
		public System.Nullable<int> TypeOfPolicy
		{
			get
			{
				return this._TypeOfPolicy;
			}
			set
			{
				if ((this._TypeOfPolicy != value))
				{
					this.OnTypeOfPolicyChanging(value);
					this.SendPropertyChanging();
					this._TypeOfPolicy = value;
					this.SendPropertyChanged("TypeOfPolicy");
					this.OnTypeOfPolicyChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ReportAODA")]
	public partial class ReportAODA : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Nullable<int> _ID;
		
		private string _Company;
		
		private string _MailingAddress;
		
		private string _Town;
		
		private System.Nullable<bool> _AODAFormSubmit;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIDChanging(System.Nullable<int> value);
    partial void OnIDChanged();
    partial void OnCompanyChanging(string value);
    partial void OnCompanyChanged();
    partial void OnMailingAddressChanging(string value);
    partial void OnMailingAddressChanged();
    partial void OnTownChanging(string value);
    partial void OnTownChanged();
    partial void OnAODAFormSubmitChanging(System.Nullable<bool> value);
    partial void OnAODAFormSubmitChanged();
    #endregion
		
		public ReportAODA()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ID", DbType="Int", IsPrimaryKey=true)]
		public System.Nullable<int> ID
		{
			get
			{
				return this._ID;
			}
			set
			{
				if ((this._ID != value))
				{
					this.OnIDChanging(value);
					this.SendPropertyChanging();
					this._ID = value;
					this.SendPropertyChanged("ID");
					this.OnIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Company", DbType="NVarChar(255) NOT NULL", CanBeNull=false)]
		public string Company
		{
			get
			{
				return this._Company;
			}
			set
			{
				if ((this._Company != value))
				{
					this.OnCompanyChanging(value);
					this.SendPropertyChanging();
					this._Company = value;
					this.SendPropertyChanged("Company");
					this.OnCompanyChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_MailingAddress", DbType="NVarChar(255)")]
		public string MailingAddress
		{
			get
			{
				return this._MailingAddress;
			}
			set
			{
				if ((this._MailingAddress != value))
				{
					this.OnMailingAddressChanging(value);
					this.SendPropertyChanging();
					this._MailingAddress = value;
					this.SendPropertyChanged("MailingAddress");
					this.OnMailingAddressChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Town", DbType="NVarChar(50)")]
		public string Town
		{
			get
			{
				return this._Town;
			}
			set
			{
				if ((this._Town != value))
				{
					this.OnTownChanging(value);
					this.SendPropertyChanging();
					this._Town = value;
					this.SendPropertyChanged("Town");
					this.OnTownChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AODAFormSubmit", DbType="Bit")]
		public System.Nullable<bool> AODAFormSubmit
		{
			get
			{
				return this._AODAFormSubmit;
			}
			set
			{
				if ((this._AODAFormSubmit != value))
				{
					this.OnAODAFormSubmitChanging(value);
					this.SendPropertyChanging();
					this._AODAFormSubmit = value;
					this.SendPropertyChanged("AODAFormSubmit");
					this.OnAODAFormSubmitChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
