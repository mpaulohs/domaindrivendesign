﻿namespace demo1.Domain.DomainEventHandlers.OrderCancelled
{
    //public class OrderCancelledDomainEventHandler
    //               : INotificationHandler<OrderCancelledDomainEvent>
    //{
    //    private readonly IOrderRepository _orderRepository;
    //    private readonly IBuyerRepository _buyerRepository;
    //    private readonly ILoggerFactory _logger;
    //    private readonly IOrderingIntegrationEventService _orderingIntegrationEventService;

    //    public OrderCancelledDomainEventHandler(
    //        IOrderRepository orderRepository,
    //        ILoggerFactory logger,
    //        IBuyerRepository buyerRepository,
    //        IOrderingIntegrationEventService orderingIntegrationEventService)
    //    {
    //        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    //        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    //        _buyerRepository = buyerRepository ?? throw new ArgumentNullException(nameof(buyerRepository));
    //        _orderingIntegrationEventService = orderingIntegrationEventService;
    //    }

    //    public async Task Handle(OrderCancelledDomainEvent orderCancelledDomainEvent, CancellationToken cancellationToken)
    //    {
    //        _logger.CreateLogger(nameof(OrderCancelledDomainEvent))
    //         .LogTrace($"Order with Id: {orderCancelledDomainEvent.Order.Id} has been successfully updated with " +
    //                   $"a status order id: {OrderStatus.Shipped.Id}");

    //        var order = await _orderRepository.GetAsync(orderCancelledDomainEvent.Order.Id);
    //        var buyer = await _buyerRepository.FindByIdAsync(order.GetBuyerId.Value.ToString());

    //        var orderStatusChangedToCancelledIntegrationEvent = new OrderStatusChangedToCancelledIntegrationEvent(order.Id, order.OrderStatus.Name, buyer.Name);
    //        await _orderingIntegrationEventService.PublishThroughEventBusAsync(orderStatusChangedToCancelledIntegrationEvent);
    //    }
    //}
}
