﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="FileDTO", Namespace="http://schemas.datacontract.org/2004/07/Project2ObjectWCF.DTO", IsReference=true)]
    public partial class FileDTO : object
    {
        
        private int IdField;
        
        private bool IsDeletedField;
        
        private ServiceReference1.MetadataDTO MetadataField;
        
        private string PathField;
        
        private ServiceReference1.TagDTO[] TagsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool IsDeleted
        {
            get
            {
                return this.IsDeletedField;
            }
            set
            {
                this.IsDeletedField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.MetadataDTO Metadata
        {
            get
            {
                return this.MetadataField;
            }
            set
            {
                this.MetadataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Path
        {
            get
            {
                return this.PathField;
            }
            set
            {
                this.PathField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.TagDTO[] Tags
        {
            get
            {
                return this.TagsField;
            }
            set
            {
                this.TagsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MetadataDTO", Namespace="http://schemas.datacontract.org/2004/07/Project2ObjectWCF.DTO", IsReference=true)]
    public partial class MetadataDTO : object
    {
        
        private System.DateTime CreationDateField;
        
        private ServiceReference1.FileDTO FileField;
        
        private int IdField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime CreationDate
        {
            get
            {
                return this.CreationDateField;
            }
            set
            {
                this.CreationDateField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.FileDTO File
        {
            get
            {
                return this.FileField;
            }
            set
            {
                this.FileField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.Runtime.Serialization.DataContractAttribute(Name="TagDTO", Namespace="http://schemas.datacontract.org/2004/07/Project2ObjectWCF.DTO", IsReference=true)]
    public partial class TagDTO : object
    {
        
        private ServiceReference1.FileDTO FileField;
        
        private int FileIdField;
        
        private int IdField;
        
        private string KeyField;
        
        private string ValueField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference1.FileDTO File
        {
            get
            {
                return this.FileField;
            }
            set
            {
                this.FileField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int FileId
        {
            get
            {
                return this.FileIdField;
            }
            set
            {
                this.FileIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id
        {
            get
            {
                return this.IdField;
            }
            set
            {
                this.IdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Key
        {
            get
            {
                return this.KeyField;
            }
            set
            {
                this.KeyField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Value
        {
            get
            {
                return this.ValueField;
            }
            set
            {
                this.ValueField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IFileMetadataTag")]
    public interface IFileMetadataTag
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FileInterface/AddFile", ReplyAction="http://tempuri.org/FileInterface/AddFileResponse")]
        System.Threading.Tasks.Task AddFileAsync(ServiceReference1.FileDTO file);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FileInterface/DeleteFile", ReplyAction="http://tempuri.org/FileInterface/DeleteFileResponse")]
        System.Threading.Tasks.Task DeleteFileAsync(string filePath);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FileInterface/GetFilesAndMetadata", ReplyAction="http://tempuri.org/FileInterface/GetFilesAndMetadataResponse")]
        System.Threading.Tasks.Task<ServiceReference1.FileDTO[]> GetFilesAndMetadataAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/FileInterface/FindFilesByFileName", ReplyAction="http://tempuri.org/FileInterface/FindFilesByFileNameResponse")]
        System.Threading.Tasks.Task<ServiceReference1.FileDTO[]> FindFilesByFileNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMetadataInterface/ChangeMetadataForFile", ReplyAction="http://tempuri.org/IMetadataInterface/ChangeMetadataForFileResponse")]
        System.Threading.Tasks.Task ChangeMetadataForFileAsync(string path, ServiceReference1.MetadataDTO metadata);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TagInterface/AddTag", ReplyAction="http://tempuri.org/TagInterface/AddTagResponse")]
        System.Threading.Tasks.Task AddTagAsync(ServiceReference1.TagDTO tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TagInterface/DeleteCustomTag", ReplyAction="http://tempuri.org/TagInterface/DeleteCustomTagResponse")]
        System.Threading.Tasks.Task DeleteCustomTagAsync(string tag);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/TagInterface/GetFilesByTagKey", ReplyAction="http://tempuri.org/TagInterface/GetFilesByTagKeyResponse")]
        System.Threading.Tasks.Task<ServiceReference1.FileDTO[]> GetFilesByTagKeyAsync(string key);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public interface IFileMetadataTagChannel : ServiceReference1.IFileMetadataTag, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.2")]
    public partial class FileMetadataTagClient : System.ServiceModel.ClientBase<ServiceReference1.IFileMetadataTag>, ServiceReference1.IFileMetadataTag
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public FileMetadataTagClient() : 
                base(FileMetadataTagClient.GetDefaultBinding(), FileMetadataTagClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IFileMetadataTag.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileMetadataTagClient(EndpointConfiguration endpointConfiguration) : 
                base(FileMetadataTagClient.GetBindingForEndpoint(endpointConfiguration), FileMetadataTagClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileMetadataTagClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(FileMetadataTagClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileMetadataTagClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(FileMetadataTagClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FileMetadataTagClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task AddFileAsync(ServiceReference1.FileDTO file)
        {
            return base.Channel.AddFileAsync(file);
        }
        
        public System.Threading.Tasks.Task DeleteFileAsync(string filePath)
        {
            return base.Channel.DeleteFileAsync(filePath);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.FileDTO[]> GetFilesAndMetadataAsync()
        {
            return base.Channel.GetFilesAndMetadataAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.FileDTO[]> FindFilesByFileNameAsync(string name)
        {
            return base.Channel.FindFilesByFileNameAsync(name);
        }
        
        public System.Threading.Tasks.Task ChangeMetadataForFileAsync(string path, ServiceReference1.MetadataDTO metadata)
        {
            return base.Channel.ChangeMetadataForFileAsync(path, metadata);
        }
        
        public System.Threading.Tasks.Task AddTagAsync(ServiceReference1.TagDTO tag)
        {
            return base.Channel.AddTagAsync(tag);
        }
        
        public System.Threading.Tasks.Task DeleteCustomTagAsync(string tag)
        {
            return base.Channel.DeleteCustomTagAsync(tag);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.FileDTO[]> GetFilesByTagKeyAsync(string key)
        {
            return base.Channel.GetFilesByTagKeyAsync(key);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFileMetadataTag))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IFileMetadataTag))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8000/PC");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return FileMetadataTagClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IFileMetadataTag);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return FileMetadataTagClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IFileMetadataTag);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IFileMetadataTag,
        }
    }
}