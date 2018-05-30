﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WPFGUI.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Register", ReplyAction="http://tempuri.org/IService1/RegisterResponse")]
        string Register(string Username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Register", ReplyAction="http://tempuri.org/IService1/RegisterResponse")]
        System.Threading.Tasks.Task<string> RegisterAsync(string Username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        bool Login(string Username, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/Login", ReplyAction="http://tempuri.org/IService1/LoginResponse")]
        System.Threading.Tasks.Task<bool> LoginAsync(string Username, string Password);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserProducts", ReplyAction="http://tempuri.org/IService1/GetUserProductsResponse")]
        System.Collections.Generic.List<DotNetPracticum5.Model.UserProducts> GetUserProducts(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserProducts", ReplyAction="http://tempuri.org/IService1/GetUserProductsResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DotNetPracticum5.Model.UserProducts>> GetUserProductsAsync(int UserId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/BuyProduct", ReplyAction="http://tempuri.org/IService1/BuyProductResponse")]
        bool BuyProduct(int UserId, int ProductId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/BuyProduct", ReplyAction="http://tempuri.org/IService1/BuyProductResponse")]
        System.Threading.Tasks.Task<bool> BuyProductAsync(int UserId, int ProductId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetInventory", ReplyAction="http://tempuri.org/IService1/GetInventoryResponse")]
        System.Collections.Generic.List<DotNetPracticum5.Model.Inventory> GetInventory();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetInventory", ReplyAction="http://tempuri.org/IService1/GetInventoryResponse")]
        System.Threading.Tasks.Task<System.Collections.Generic.List<DotNetPracticum5.Model.Inventory>> GetInventoryAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserByUsername", ReplyAction="http://tempuri.org/IService1/GetUserByUsernameResponse")]
        DotNetPracticum5.Model.User GetUserByUsername(string Username);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/GetUserByUsername", ReplyAction="http://tempuri.org/IService1/GetUserByUsernameResponse")]
        System.Threading.Tasks.Task<DotNetPracticum5.Model.User> GetUserByUsernameAsync(string Username);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : WPFGUI.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<WPFGUI.ServiceReference1.IService1>, WPFGUI.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string Register(string Username) {
            return base.Channel.Register(Username);
        }
        
        public System.Threading.Tasks.Task<string> RegisterAsync(string Username) {
            return base.Channel.RegisterAsync(Username);
        }
        
        public bool Login(string Username, string Password) {
            return base.Channel.Login(Username, Password);
        }
        
        public System.Threading.Tasks.Task<bool> LoginAsync(string Username, string Password) {
            return base.Channel.LoginAsync(Username, Password);
        }
        
        public System.Collections.Generic.List<DotNetPracticum5.Model.UserProducts> GetUserProducts(int UserId) {
            return base.Channel.GetUserProducts(UserId);
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DotNetPracticum5.Model.UserProducts>> GetUserProductsAsync(int UserId) {
            return base.Channel.GetUserProductsAsync(UserId);
        }
        
        public bool BuyProduct(int UserId, int ProductId) {
            return base.Channel.BuyProduct(UserId, ProductId);
        }
        
        public System.Threading.Tasks.Task<bool> BuyProductAsync(int UserId, int ProductId) {
            return base.Channel.BuyProductAsync(UserId, ProductId);
        }
        
        public System.Collections.Generic.List<DotNetPracticum5.Model.Inventory> GetInventory() {
            return base.Channel.GetInventory();
        }
        
        public System.Threading.Tasks.Task<System.Collections.Generic.List<DotNetPracticum5.Model.Inventory>> GetInventoryAsync() {
            return base.Channel.GetInventoryAsync();
        }
        
        public DotNetPracticum5.Model.User GetUserByUsername(string Username) {
            return base.Channel.GetUserByUsername(Username);
        }
        
        public System.Threading.Tasks.Task<DotNetPracticum5.Model.User> GetUserByUsernameAsync(string Username) {
            return base.Channel.GetUserByUsernameAsync(Username);
        }
    }
}