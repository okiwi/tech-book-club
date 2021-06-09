module Domain
    type WidgetCode = WidgetCode of string

    type GizmoCode = GizmoCode of string

    type ProductCode = 
        | Widget of WidgetCode
        | Gizmo of GizmoCode

    type UnitQuantity = UnitQuantity of int

    type KilogramQuantity = KilogramQuantity of decimal

    type OrderQuantity = 
        | Unit of UnitQuantity
        | Kilogram of KilogramQuantity

    type Undefined = exn

    type UnvalidatedCustomer = Undefined

    type UnvalidatedShippingAddress = Undefined
    
    type UnvalidatedBillingAddress = Undefined

    type UnvalidatedProductCode = Undefined
    type UnvalidatedOrderQuantity = Undefined

    type UnvalidatedOrderLine = {
        UnvalidatedProductCode: UnvalidatedProductCode
        UnvalidatedOrderQuantity: UnvalidatedOrderQuantity
    }

    type UnvalidatedOrder = {
        UnvalidatedCustomer: UnvalidatedCustomer
        UnvalidatedShippingAddress: UnvalidatedShippingAddress
        UnvalidatedBillingAddress: UnvalidatedBillingAddress
        UnvalidatedOrderLines: UnvalidatedOrderLine list
    }
  


    type ValidatedCustomerInfo = Undefined
    type ValidatedShippingAddress = Undefined
    type ValidatedBillingAddress = Undefined

    type ValidatedProductCode = Undefined

    type ValidatedOrderLine = {
        ValidatedProductCode: ValidatedProductCode
        ValidatedOrderQuantity: ValidatedProductCode
    }

    type ValidatedOrder = {
        ValidatedCustomerInfo: ValidatedCustomerInfo
        ValidatedShippingAddress: ValidatedShippingAddress
        ValidatedBillingAddress: ValidatedBillingAddress
        ValidatedOrderLines: ValidatedOrderLine list
    } 



    
    type LinePrice = Undefined

    type PricedOrderLine = {
        ValidatedOrderLine: ValidatedOrderLine
        LinePrice: LinePrice
    }
    type AmountToBill = Undefined

    type PricedOrder = {
        ValidatedCustomerInfo: ValidatedCustomerInfo
        ValidatedShippingAddress: ValidatedShippingAddress
        ValidatedBillingAddress: ValidatedBillingAddress
        PricedOrderLines: PricedOrderLine list
        AmountToBill: AmountToBill
    }



    type AcknowledgmentLetter = Undefined
    
    type PlacedOrderAcknowledgment = {
        PricedOrder: PricedOrder
        AcknowledgmentLetter: AcknowledgmentLetter
    }

    type OrderForm = Undefined

    type OrderPlaced = Undefined
    
    type InvalidOrder = Undefined

    type PlaceOrder = OrderForm -> Result<OrderPlaced, InvalidOrder>

    type CheckProductCodeExists = Undefined

    type CheckAddressExists = Undefined

    type ValidationError = Undefined

    type ValidateOrder = CheckProductCodeExists -> CheckAddressExists -> UnvalidatedOrder -> Result<ValidatedOrder, ValidationError>

    type GetProductPrice = Undefined

    type PriceOrder = GetProductPrice -> ValidatedOrder -> PricedOrder

    type SendAcknowledgementToCustomer = PricedOrder -> Unit