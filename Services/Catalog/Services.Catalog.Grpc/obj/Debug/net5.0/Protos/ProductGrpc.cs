// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Protos/product.proto
// </auto-generated>
#pragma warning disable 0414, 1591
#region Designer generated code

using grpc = global::Grpc.Core;

namespace Services.Catalog.Grpc.Protos {
  public static partial class ProductProtoService
  {
    static readonly string __ServiceName = "ProductProtoService";

    static void __Helper_SerializeMessage(global::Google.Protobuf.IMessage message, grpc::SerializationContext context)
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (message is global::Google.Protobuf.IBufferMessage)
      {
        context.SetPayloadLength(message.CalculateSize());
        global::Google.Protobuf.MessageExtensions.WriteTo(message, context.GetBufferWriter());
        context.Complete();
        return;
      }
      #endif
      context.Complete(global::Google.Protobuf.MessageExtensions.ToByteArray(message));
    }

    static class __Helper_MessageCache<T>
    {
      public static readonly bool IsBufferMessage = global::System.Reflection.IntrospectionExtensions.GetTypeInfo(typeof(global::Google.Protobuf.IBufferMessage)).IsAssignableFrom(typeof(T));
    }

    static T __Helper_DeserializeMessage<T>(grpc::DeserializationContext context, global::Google.Protobuf.MessageParser<T> parser) where T : global::Google.Protobuf.IMessage<T>
    {
      #if !GRPC_DISABLE_PROTOBUF_BUFFER_SERIALIZATION
      if (__Helper_MessageCache<T>.IsBufferMessage)
      {
        return parser.ParseFrom(context.PayloadAsReadOnlySequence());
      }
      #endif
      return parser.ParseFrom(context.PayloadAsNewBuffer());
    }

    static readonly grpc::Marshaller<global::Services.Catalog.Grpc.Protos.BasketItemRequest> __Marshaller_BasketItemRequest = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Services.Catalog.Grpc.Protos.BasketItemRequest.Parser));
    static readonly grpc::Marshaller<global::Services.Catalog.Grpc.Protos.ProductResponse> __Marshaller_ProductResponse = grpc::Marshallers.Create(__Helper_SerializeMessage, context => __Helper_DeserializeMessage(context, global::Services.Catalog.Grpc.Protos.ProductResponse.Parser));

    static readonly grpc::Method<global::Services.Catalog.Grpc.Protos.BasketItemRequest, global::Services.Catalog.Grpc.Protos.ProductResponse> __Method_CheckStock = new grpc::Method<global::Services.Catalog.Grpc.Protos.BasketItemRequest, global::Services.Catalog.Grpc.Protos.ProductResponse>(
        grpc::MethodType.Unary,
        __ServiceName,
        "CheckStock",
        __Marshaller_BasketItemRequest,
        __Marshaller_ProductResponse);

    /// <summary>Service descriptor</summary>
    public static global::Google.Protobuf.Reflection.ServiceDescriptor Descriptor
    {
      get { return global::Services.Catalog.Grpc.Protos.ProductReflection.Descriptor.Services[0]; }
    }

    /// <summary>Base class for server-side implementations of ProductProtoService</summary>
    [grpc::BindServiceMethod(typeof(ProductProtoService), "BindService")]
    public abstract partial class ProductProtoServiceBase
    {
      public virtual global::System.Threading.Tasks.Task<global::Services.Catalog.Grpc.Protos.ProductResponse> CheckStock(global::Services.Catalog.Grpc.Protos.BasketItemRequest request, grpc::ServerCallContext context)
      {
        throw new grpc::RpcException(new grpc::Status(grpc::StatusCode.Unimplemented, ""));
      }

    }

    /// <summary>Client for ProductProtoService</summary>
    public partial class ProductProtoServiceClient : grpc::ClientBase<ProductProtoServiceClient>
    {
      /// <summary>Creates a new client for ProductProtoService</summary>
      /// <param name="channel">The channel to use to make remote calls.</param>
      public ProductProtoServiceClient(grpc::ChannelBase channel) : base(channel)
      {
      }
      /// <summary>Creates a new client for ProductProtoService that uses a custom <c>CallInvoker</c>.</summary>
      /// <param name="callInvoker">The callInvoker to use to make remote calls.</param>
      public ProductProtoServiceClient(grpc::CallInvoker callInvoker) : base(callInvoker)
      {
      }
      /// <summary>Protected parameterless constructor to allow creation of test doubles.</summary>
      protected ProductProtoServiceClient() : base()
      {
      }
      /// <summary>Protected constructor to allow creation of configured clients.</summary>
      /// <param name="configuration">The client configuration.</param>
      protected ProductProtoServiceClient(ClientBaseConfiguration configuration) : base(configuration)
      {
      }

      public virtual global::Services.Catalog.Grpc.Protos.ProductResponse CheckStock(global::Services.Catalog.Grpc.Protos.BasketItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckStock(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual global::Services.Catalog.Grpc.Protos.ProductResponse CheckStock(global::Services.Catalog.Grpc.Protos.BasketItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.BlockingUnaryCall(__Method_CheckStock, null, options, request);
      }
      public virtual grpc::AsyncUnaryCall<global::Services.Catalog.Grpc.Protos.ProductResponse> CheckStockAsync(global::Services.Catalog.Grpc.Protos.BasketItemRequest request, grpc::Metadata headers = null, global::System.DateTime? deadline = null, global::System.Threading.CancellationToken cancellationToken = default(global::System.Threading.CancellationToken))
      {
        return CheckStockAsync(request, new grpc::CallOptions(headers, deadline, cancellationToken));
      }
      public virtual grpc::AsyncUnaryCall<global::Services.Catalog.Grpc.Protos.ProductResponse> CheckStockAsync(global::Services.Catalog.Grpc.Protos.BasketItemRequest request, grpc::CallOptions options)
      {
        return CallInvoker.AsyncUnaryCall(__Method_CheckStock, null, options, request);
      }
      /// <summary>Creates a new instance of client from given <c>ClientBaseConfiguration</c>.</summary>
      protected override ProductProtoServiceClient NewInstance(ClientBaseConfiguration configuration)
      {
        return new ProductProtoServiceClient(configuration);
      }
    }

    /// <summary>Creates service definition that can be registered with a server</summary>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static grpc::ServerServiceDefinition BindService(ProductProtoServiceBase serviceImpl)
    {
      return grpc::ServerServiceDefinition.CreateBuilder()
          .AddMethod(__Method_CheckStock, serviceImpl.CheckStock).Build();
    }

    /// <summary>Register service method with a service binder with or without implementation. Useful when customizing the  service binding logic.
    /// Note: this method is part of an experimental API that can change or be removed without any prior notice.</summary>
    /// <param name="serviceBinder">Service methods will be bound by calling <c>AddMethod</c> on this object.</param>
    /// <param name="serviceImpl">An object implementing the server-side handling logic.</param>
    public static void BindService(grpc::ServiceBinderBase serviceBinder, ProductProtoServiceBase serviceImpl)
    {
      serviceBinder.AddMethod(__Method_CheckStock, serviceImpl == null ? null : new grpc::UnaryServerMethod<global::Services.Catalog.Grpc.Protos.BasketItemRequest, global::Services.Catalog.Grpc.Protos.ProductResponse>(serviceImpl.CheckStock));
    }

  }
}
#endregion