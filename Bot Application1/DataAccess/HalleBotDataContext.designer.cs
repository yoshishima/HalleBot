﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bot_Application1.DataAccess
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="hallebot")]
	public partial class HalleBotDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertpatient(patient instance);
    partial void Updatepatient(patient instance);
    partial void Deletepatient(patient instance);
    partial void Insertconversation(conversation instance);
    partial void Updateconversation(conversation instance);
    partial void Deleteconversation(conversation instance);
    partial void Insertinteraction(interaction instance);
    partial void Updateinteraction(interaction instance);
    partial void Deleteinteraction(interaction instance);
    partial void InsertinteractionIntent(interactionIntent instance);
    partial void UpdateinteractionIntent(interactionIntent instance);
    partial void DeleteinteractionIntent(interactionIntent instance);
    partial void InsertresponseMessage(responseMessage instance);
    partial void UpdateresponseMessage(responseMessage instance);
    partial void DeleteresponseMessage(responseMessage instance);
    partial void Insertconversation_response(conversation_response instance);
    partial void Updateconversation_response(conversation_response instance);
    partial void Deleteconversation_response(conversation_response instance);
    #endregion
		
		public HalleBotDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["hallebotConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public HalleBotDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HalleBotDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HalleBotDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public HalleBotDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<patient> patients
		{
			get
			{
				return this.GetTable<patient>();
			}
		}
		
		public System.Data.Linq.Table<conversation> conversations
		{
			get
			{
				return this.GetTable<conversation>();
			}
		}
		
		public System.Data.Linq.Table<interaction> interactions
		{
			get
			{
				return this.GetTable<interaction>();
			}
		}
		
		public System.Data.Linq.Table<interactionIntent> interactionIntents
		{
			get
			{
				return this.GetTable<interactionIntent>();
			}
		}
		
		public System.Data.Linq.Table<responseMessage> responseMessages
		{
			get
			{
				return this.GetTable<responseMessage>();
			}
		}
		
		public System.Data.Linq.Table<conversation_response> conversation_responses
		{
			get
			{
				return this.GetTable<conversation_response>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.patient")]
	public partial class patient : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _patientID;
		
		private string _name;
		
		private string _mobileNumber;
		
		private string _homeNumber;
		
		private string _workNumber;
		
		private System.Nullable<System.DateTime> _dateOfBirth;
		
		private System.Nullable<char> _gender;
		
		private System.Nullable<System.DateTime> _createDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnpatientIDChanging(string value);
    partial void OnpatientIDChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnmobileNumberChanging(string value);
    partial void OnmobileNumberChanged();
    partial void OnhomeNumberChanging(string value);
    partial void OnhomeNumberChanged();
    partial void OnworkNumberChanging(string value);
    partial void OnworkNumberChanged();
    partial void OndateOfBirthChanging(System.Nullable<System.DateTime> value);
    partial void OndateOfBirthChanged();
    partial void OngenderChanging(System.Nullable<char> value);
    partial void OngenderChanged();
    partial void OncreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OncreateDateChanged();
    #endregion
		
		public patient()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patientID", DbType="VarChar(255) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string patientID
		{
			get
			{
				return this._patientID;
			}
			set
			{
				if ((this._patientID != value))
				{
					this.OnpatientIDChanging(value);
					this.SendPropertyChanging();
					this._patientID = value;
					this.SendPropertyChanged("patientID");
					this.OnpatientIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(255)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_mobileNumber", DbType="VarChar(20)")]
		public string mobileNumber
		{
			get
			{
				return this._mobileNumber;
			}
			set
			{
				if ((this._mobileNumber != value))
				{
					this.OnmobileNumberChanging(value);
					this.SendPropertyChanging();
					this._mobileNumber = value;
					this.SendPropertyChanged("mobileNumber");
					this.OnmobileNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_homeNumber", DbType="VarChar(20)")]
		public string homeNumber
		{
			get
			{
				return this._homeNumber;
			}
			set
			{
				if ((this._homeNumber != value))
				{
					this.OnhomeNumberChanging(value);
					this.SendPropertyChanging();
					this._homeNumber = value;
					this.SendPropertyChanged("homeNumber");
					this.OnhomeNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_workNumber", DbType="VarChar(20)")]
		public string workNumber
		{
			get
			{
				return this._workNumber;
			}
			set
			{
				if ((this._workNumber != value))
				{
					this.OnworkNumberChanging(value);
					this.SendPropertyChanging();
					this._workNumber = value;
					this.SendPropertyChanged("workNumber");
					this.OnworkNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_dateOfBirth", DbType="DateTime")]
		public System.Nullable<System.DateTime> dateOfBirth
		{
			get
			{
				return this._dateOfBirth;
			}
			set
			{
				if ((this._dateOfBirth != value))
				{
					this.OndateOfBirthChanging(value);
					this.SendPropertyChanging();
					this._dateOfBirth = value;
					this.SendPropertyChanged("dateOfBirth");
					this.OndateOfBirthChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_gender", DbType="Char(1)")]
		public System.Nullable<char> gender
		{
			get
			{
				return this._gender;
			}
			set
			{
				if ((this._gender != value))
				{
					this.OngenderChanging(value);
					this.SendPropertyChanging();
					this._gender = value;
					this.SendPropertyChanged("gender");
					this.OngenderChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> createDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				if ((this._createDate != value))
				{
					this.OncreateDateChanging(value);
					this.SendPropertyChanging();
					this._createDate = value;
					this.SendPropertyChanged("createDate");
					this.OncreateDateChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.conversation")]
	public partial class conversation : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _conversationID;
		
		private string _patientID;
		
		private System.Nullable<System.DateTime> _createDate;
		
		private string _currentLocation;
		
		private EntitySet<interaction> _interactions;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnconversationIDChanging(System.Guid value);
    partial void OnconversationIDChanged();
    partial void OnpatientIDChanging(string value);
    partial void OnpatientIDChanged();
    partial void OncreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OncreateDateChanged();
    partial void OncurrentLocationChanging(string value);
    partial void OncurrentLocationChanged();
    #endregion
		
		public conversation()
		{
			this._interactions = new EntitySet<interaction>(new Action<interaction>(this.attach_interactions), new Action<interaction>(this.detach_interactions));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_conversationID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid conversationID
		{
			get
			{
				return this._conversationID;
			}
			set
			{
				if ((this._conversationID != value))
				{
					this.OnconversationIDChanging(value);
					this.SendPropertyChanging();
					this._conversationID = value;
					this.SendPropertyChanged("conversationID");
					this.OnconversationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_patientID", DbType="VarChar(255) NOT NULL", CanBeNull=false)]
		public string patientID
		{
			get
			{
				return this._patientID;
			}
			set
			{
				if ((this._patientID != value))
				{
					this.OnpatientIDChanging(value);
					this.SendPropertyChanging();
					this._patientID = value;
					this.SendPropertyChanged("patientID");
					this.OnpatientIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> createDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				if ((this._createDate != value))
				{
					this.OncreateDateChanging(value);
					this.SendPropertyChanging();
					this._createDate = value;
					this.SendPropertyChanged("createDate");
					this.OncreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_currentLocation", DbType="VarChar(MAX)")]
		public string currentLocation
		{
			get
			{
				return this._currentLocation;
			}
			set
			{
				if ((this._currentLocation != value))
				{
					this.OncurrentLocationChanging(value);
					this.SendPropertyChanging();
					this._currentLocation = value;
					this.SendPropertyChanged("currentLocation");
					this.OncurrentLocationChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="conversation_interaction", Storage="_interactions", ThisKey="conversationID", OtherKey="conversationID")]
		public EntitySet<interaction> interactions
		{
			get
			{
				return this._interactions;
			}
			set
			{
				this._interactions.Assign(value);
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
		
		private void attach_interactions(interaction entity)
		{
			this.SendPropertyChanging();
			entity.conversation = this;
		}
		
		private void detach_interactions(interaction entity)
		{
			this.SendPropertyChanging();
			entity.conversation = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.interaction")]
	public partial class interaction : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _conversationID;
		
		private System.DateTime _createDate;
		
		private string _text;
		
		private System.Nullable<decimal> _sentiment;
		
		private System.Nullable<int> _flag;
		
		private EntitySet<interactionIntent> _interactionIntents;
		
		private EntityRef<conversation> _conversation;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnconversationIDChanging(System.Guid value);
    partial void OnconversationIDChanged();
    partial void OncreateDateChanging(System.DateTime value);
    partial void OncreateDateChanged();
    partial void OntextChanging(string value);
    partial void OntextChanged();
    partial void OnsentimentChanging(System.Nullable<decimal> value);
    partial void OnsentimentChanged();
    partial void OnflagChanging(System.Nullable<int> value);
    partial void OnflagChanged();
    #endregion
		
		public interaction()
		{
			this._interactionIntents = new EntitySet<interactionIntent>(new Action<interactionIntent>(this.attach_interactionIntents), new Action<interactionIntent>(this.detach_interactionIntents));
			this._conversation = default(EntityRef<conversation>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_conversationID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid conversationID
		{
			get
			{
				return this._conversationID;
			}
			set
			{
				if ((this._conversationID != value))
				{
					if (this._conversation.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnconversationIDChanging(value);
					this.SendPropertyChanging();
					this._conversationID = value;
					this.SendPropertyChanged("conversationID");
					this.OnconversationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createDate", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime createDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				if ((this._createDate != value))
				{
					this.OncreateDateChanging(value);
					this.SendPropertyChanging();
					this._createDate = value;
					this.SendPropertyChanged("createDate");
					this.OncreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_text", DbType="VarChar(MAX)")]
		public string text
		{
			get
			{
				return this._text;
			}
			set
			{
				if ((this._text != value))
				{
					this.OntextChanging(value);
					this.SendPropertyChanging();
					this._text = value;
					this.SendPropertyChanged("text");
					this.OntextChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sentiment", DbType="Decimal(18,8)")]
		public System.Nullable<decimal> sentiment
		{
			get
			{
				return this._sentiment;
			}
			set
			{
				if ((this._sentiment != value))
				{
					this.OnsentimentChanging(value);
					this.SendPropertyChanging();
					this._sentiment = value;
					this.SendPropertyChanged("sentiment");
					this.OnsentimentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_flag", DbType="Int")]
		public System.Nullable<int> flag
		{
			get
			{
				return this._flag;
			}
			set
			{
				if ((this._flag != value))
				{
					this.OnflagChanging(value);
					this.SendPropertyChanging();
					this._flag = value;
					this.SendPropertyChanged("flag");
					this.OnflagChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="interaction_interactionIntent", Storage="_interactionIntents", ThisKey="conversationID,createDate", OtherKey="conversationID,createDate")]
		public EntitySet<interactionIntent> interactionIntents
		{
			get
			{
				return this._interactionIntents;
			}
			set
			{
				this._interactionIntents.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="conversation_interaction", Storage="_conversation", ThisKey="conversationID", OtherKey="conversationID", IsForeignKey=true)]
		public conversation conversation
		{
			get
			{
				return this._conversation.Entity;
			}
			set
			{
				conversation previousValue = this._conversation.Entity;
				if (((previousValue != value) 
							|| (this._conversation.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._conversation.Entity = null;
						previousValue.interactions.Remove(this);
					}
					this._conversation.Entity = value;
					if ((value != null))
					{
						value.interactions.Add(this);
						this._conversationID = value.conversationID;
					}
					else
					{
						this._conversationID = default(System.Guid);
					}
					this.SendPropertyChanged("conversation");
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
		
		private void attach_interactionIntents(interactionIntent entity)
		{
			this.SendPropertyChanging();
			entity.interaction = this;
		}
		
		private void detach_interactionIntents(interactionIntent entity)
		{
			this.SendPropertyChanging();
			entity.interaction = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.interactionIntent")]
	public partial class interactionIntent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _conversationID;
		
		private System.DateTime _createDate;
		
		private int _seq;
		
		private string _name;
		
		private System.Nullable<decimal> _confidence;
		
		private EntityRef<interaction> _interaction;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnconversationIDChanging(System.Guid value);
    partial void OnconversationIDChanged();
    partial void OncreateDateChanging(System.DateTime value);
    partial void OncreateDateChanged();
    partial void OnseqChanging(int value);
    partial void OnseqChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    partial void OnconfidenceChanging(System.Nullable<decimal> value);
    partial void OnconfidenceChanged();
    #endregion
		
		public interactionIntent()
		{
			this._interaction = default(EntityRef<interaction>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_conversationID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid conversationID
		{
			get
			{
				return this._conversationID;
			}
			set
			{
				if ((this._conversationID != value))
				{
					if (this._interaction.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnconversationIDChanging(value);
					this.SendPropertyChanging();
					this._conversationID = value;
					this.SendPropertyChanged("conversationID");
					this.OnconversationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createDate", DbType="DateTime NOT NULL", IsPrimaryKey=true)]
		public System.DateTime createDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				if ((this._createDate != value))
				{
					if (this._interaction.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncreateDateChanging(value);
					this.SendPropertyChanging();
					this._createDate = value;
					this.SendPropertyChanged("createDate");
					this.OncreateDateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_seq", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int seq
		{
			get
			{
				return this._seq;
			}
			set
			{
				if ((this._seq != value))
				{
					this.OnseqChanging(value);
					this.SendPropertyChanging();
					this._seq = value;
					this.SendPropertyChanged("seq");
					this.OnseqChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50)")]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_confidence", DbType="Decimal(18,8)")]
		public System.Nullable<decimal> confidence
		{
			get
			{
				return this._confidence;
			}
			set
			{
				if ((this._confidence != value))
				{
					this.OnconfidenceChanging(value);
					this.SendPropertyChanging();
					this._confidence = value;
					this.SendPropertyChanged("confidence");
					this.OnconfidenceChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="interaction_interactionIntent", Storage="_interaction", ThisKey="conversationID,createDate", OtherKey="conversationID,createDate", IsForeignKey=true)]
		public interaction interaction
		{
			get
			{
				return this._interaction.Entity;
			}
			set
			{
				interaction previousValue = this._interaction.Entity;
				if (((previousValue != value) 
							|| (this._interaction.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._interaction.Entity = null;
						previousValue.interactionIntents.Remove(this);
					}
					this._interaction.Entity = value;
					if ((value != null))
					{
						value.interactionIntents.Add(this);
						this._conversationID = value.conversationID;
						this._createDate = value.createDate;
					}
					else
					{
						this._conversationID = default(System.Guid);
						this._createDate = default(System.DateTime);
					}
					this.SendPropertyChanged("interaction");
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.responseMessage")]
	public partial class responseMessage : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _responseID;
		
		private System.Nullable<int> _messageType;
		
		private string _messageText;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnresponseIDChanging(int value);
    partial void OnresponseIDChanged();
    partial void OnmessageTypeChanging(System.Nullable<int> value);
    partial void OnmessageTypeChanged();
    partial void OnmessageTextChanging(string value);
    partial void OnmessageTextChanged();
    #endregion
		
		public responseMessage()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_responseID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int responseID
		{
			get
			{
				return this._responseID;
			}
			set
			{
				if ((this._responseID != value))
				{
					this.OnresponseIDChanging(value);
					this.SendPropertyChanging();
					this._responseID = value;
					this.SendPropertyChanged("responseID");
					this.OnresponseIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_messageType", DbType="Int")]
		public System.Nullable<int> messageType
		{
			get
			{
				return this._messageType;
			}
			set
			{
				if ((this._messageType != value))
				{
					this.OnmessageTypeChanging(value);
					this.SendPropertyChanging();
					this._messageType = value;
					this.SendPropertyChanged("messageType");
					this.OnmessageTypeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_messageText", DbType="VarChar(MAX)")]
		public string messageText
		{
			get
			{
				return this._messageText;
			}
			set
			{
				if ((this._messageText != value))
				{
					this.OnmessageTextChanging(value);
					this.SendPropertyChanging();
					this._messageText = value;
					this.SendPropertyChanged("messageText");
					this.OnmessageTextChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.conversation_response")]
	public partial class conversation_response : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _conversationID;
		
		private int _responseID;
		
		private System.Nullable<System.DateTime> _createDate;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnconversationIDChanging(System.Guid value);
    partial void OnconversationIDChanged();
    partial void OnresponseIDChanging(int value);
    partial void OnresponseIDChanged();
    partial void OncreateDateChanging(System.Nullable<System.DateTime> value);
    partial void OncreateDateChanged();
    #endregion
		
		public conversation_response()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_conversationID", DbType="UniqueIdentifier NOT NULL", IsPrimaryKey=true)]
		public System.Guid conversationID
		{
			get
			{
				return this._conversationID;
			}
			set
			{
				if ((this._conversationID != value))
				{
					this.OnconversationIDChanging(value);
					this.SendPropertyChanging();
					this._conversationID = value;
					this.SendPropertyChanged("conversationID");
					this.OnconversationIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_responseID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int responseID
		{
			get
			{
				return this._responseID;
			}
			set
			{
				if ((this._responseID != value))
				{
					this.OnresponseIDChanging(value);
					this.SendPropertyChanging();
					this._responseID = value;
					this.SendPropertyChanged("responseID");
					this.OnresponseIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_createDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> createDate
		{
			get
			{
				return this._createDate;
			}
			set
			{
				if ((this._createDate != value))
				{
					this.OncreateDateChanging(value);
					this.SendPropertyChanging();
					this._createDate = value;
					this.SendPropertyChanged("createDate");
					this.OncreateDateChanged();
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
