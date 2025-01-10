interface IOrder {
  systemId: string
  publicId: string
  deliveryType: number
  products: IProduct[]
  systemUserId: string
  publicUserId: string
}
