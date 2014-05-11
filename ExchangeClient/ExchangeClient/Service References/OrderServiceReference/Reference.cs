﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ExchangeClient.OrderServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderServiceReference.IOrderService")]
    public interface IOrderService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/SubmitOrder", ReplyAction="http://tempuri.org/IOrderService/SubmitOrderResponse")]
        ClassLibrary.Order SubmitOrder(ClassLibrary.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/SubmitOrder", ReplyAction="http://tempuri.org/IOrderService/SubmitOrderResponse")]
        System.Threading.Tasks.Task<ClassLibrary.Order> SubmitOrderAsync(ClassLibrary.Order order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrders", ReplyAction="http://tempuri.org/IOrderService/GetOrdersResponse")]
        ClassLibrary.Order[] GetOrders(long traderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/GetOrders", ReplyAction="http://tempuri.org/IOrderService/GetOrdersResponse")]
        System.Threading.Tasks.Task<ClassLibrary.Order[]> GetOrdersAsync(long traderId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/CancelOrder", ReplyAction="http://tempuri.org/IOrderService/CancelOrderResponse")]
        void CancelOrder(long traderId, long orderNumber);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderService/CancelOrder", ReplyAction="http://tempuri.org/IOrderService/CancelOrderResponse")]
        System.Threading.Tasks.Task CancelOrderAsync(long traderId, long orderNumber);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderServiceChannel : ExchangeClient.OrderServiceReference.IOrderService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderServiceClient : System.ServiceModel.ClientBase<ExchangeClient.OrderServiceReference.IOrderService>, ExchangeClient.OrderServiceReference.IOrderService {
        
        public OrderServiceClient() {
        }
        
        public OrderServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public ClassLibrary.Order SubmitOrder(ClassLibrary.Order order) {
            return base.Channel.SubmitOrder(order);
        }
        
        public System.Threading.Tasks.Task<ClassLibrary.Order> SubmitOrderAsync(ClassLibrary.Order order) {
            return base.Channel.SubmitOrderAsync(order);
        }
        
        public ClassLibrary.Order[] GetOrders(long traderId) {
            return base.Channel.GetOrders(traderId);
        }
        
        public System.Threading.Tasks.Task<ClassLibrary.Order[]> GetOrdersAsync(long traderId) {
            return base.Channel.GetOrdersAsync(traderId);
        }
        
        public void CancelOrder(long traderId, long orderNumber) {
            base.Channel.CancelOrder(traderId, orderNumber);
        }
        
        public System.Threading.Tasks.Task CancelOrderAsync(long traderId, long orderNumber) {
            return base.Channel.CancelOrderAsync(traderId, orderNumber);
        }
    }
}