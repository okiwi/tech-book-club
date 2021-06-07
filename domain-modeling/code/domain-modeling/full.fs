module rec Domain
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

    type UnvalidatedOrder = {
        UnvalidatedCustomer: UnvalidatedCustomer
        UnvalidatedShippingAddress: UnvalidatedShippingAddress
        UnvalidatedBillingAddress: UnvalidatedBillingAddress
        UnvalidatedOrderLines: UnvalidatedOrderLine list
    }

    type UnvalidatedProductCode = Undefined
    type UnvalidatedOrderQuantity = Undefined

    type UnvalidatedOrderLine = {
        UnvalidatedProductCode: UnvalidatedProductCode
        UnvalidatedOrderQuantity: UnvalidatedOrderQuantity
    }

    type ValidatedCustomerInfo = Undefined
    type ValidatedShippingAddress = Undefined
    type ValidatedBillingAddress = Undefined

    type ValidatedOrder = {
        ValidatedCustomerInfo: ValidatedCustomerInfo
        ValidatedShippingAddress: ValidatedShippingAddress
        ValidatedBillingAddress: ValidatedBillingAddress
        ValidatedOrderLines: ValidatedOrderLine list
    } 

    type ValidatedProductCode = Undefined

    type ValidatedOrderLine = {
        ValidatedProductCode: ValidatedProductCode
        ValidatedOrderQuantity: ValidatedProductCode
    }

    type AmountToBill = Undefined

    type PricedOrder = {
        ValidatedCustomerInfo: ValidatedCustomerInfo
        ValidatedShippingAddress: ValidatedShippingAddress
        ValidatedBillingAddress: ValidatedBillingAddress
        PricedOrderLines: PricedOrderLine list
        AmountToBill: AmountToBill
    }

    type LinePrice = Undefined

    type PricedOrderLine = {
        ValidatedOrderLine: ValidatedOrderLine
        LinePrice: LinePrice
    }

    type AcknowledgmentLetter = Undefined
    
    type PlacedOrderAcknowledgment = {
        PricedOrder: PricedOrder
        AcknowledgmentLetter: AcknowledgmentLetter
    }
