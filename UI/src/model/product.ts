export {};
export interface Product {
    productId: number;
    productCode: string;
    productName: string;
    quantity: number;
    price: number;
    productDescription: string;
    imageUrl: string;
    categoryId : number;
    subCategoryId : number;
    categoryName : string;
    subcategoryName : string;
    image: File | null;
  }

