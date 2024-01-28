// ProductTable.tsx
import React from 'react';
import {Product} from '../model/product';
import { Category } from '../model/category';
import { SubCategory } from '../model/subCategory';

interface ProductTableProps {
  products: Product[];
  onEditClick: (product: Product) => void;
  onClickDelete: (product: Product) => void;
}

const predefinedCategories: Category[] = [
  { categoryId: 1, categoryName: 'Electronics' },
  { categoryId: 2, categoryName: 'Apparel' },
  { categoryId: 3, categoryName: 'Footwear' },
];

 const predefinedSubCategories: SubCategory[] = [
  { subCategoryId: 1, subCategoryName: 'TV' },
  { subCategoryId: 2, subCategoryName: 'Mobiles' },
  { subCategoryId: 3, subCategoryName: 'Refrigerator' },
  { subCategoryId: 4, subCategoryName: 'Mens cloth' },
  { subCategoryId: 5, subCategoryName: 'Womens Cloth' },
  { subCategoryId: 6, subCategoryName: 'Mens Footwear' },
  { subCategoryId: 7, subCategoryName: 'Kids Footwear' },
];

const getQuantityColor = (quantity: number): string => {
  if (quantity < 10) {
    return 'bg-danger text-white'; // Bootstrap red background
  } else if (quantity >= 10 && quantity <= 100) {
    return 'bg-warning text-dark'; // Bootstrap orange background
  } else {
    return 'bg-success text-white'; // Bootstrap green background
  }
};

const getCategoryNameById = (categoryId: number): string => {
  const category = predefinedCategories.find((cat) => cat.categoryId === categoryId);
  return category ? category.categoryName : '';
};

const getSubCategoryNameById = (subCategoryId: number): string => {
  const subCategory = predefinedSubCategories.find((subCat) => subCat.subCategoryId === subCategoryId);
  return subCategory ? subCategory.subCategoryName : '';
};


const ProductTable: React.FC<ProductTableProps> = ({ products, onEditClick, onClickDelete }) => {
  console.log("Product Table Comp", products)
  return (
    <table className="table table-striped">
      <thead>
        <tr>
          <th scope="col">Product Id</th>
          <th scope="col">Product Code</th>
          <th scope="col">Product Name</th>
          <th scope="col">Quantity</th>
          <th scope="col">Price</th>
          <th scope="col">Product Description</th>
          <th scope="col">Category</th>
          <th scope="col">Subcategory</th>
          <th scope="col">Image</th>
          <th scope="col">Actions</th>
        </tr>
      </thead>
      <tbody>
        {products.map((product: Product) => (
          <tr key={product.productId} >
            <td className={getQuantityColor(product.quantity)}>{product.productId}</td>
            <td className={getQuantityColor(product.quantity)}>{product.productCode}</td>
            <td className={getQuantityColor(product.quantity)}>{product.productName}</td>
            <td className={getQuantityColor(product.quantity)}>{product.quantity}</td>
            <td className={getQuantityColor(product.quantity)}>{product.price}</td>
            <td className={getQuantityColor(product.quantity)}>{product.productDescription}</td>
            <td className={getQuantityColor(product.quantity)}>{getCategoryNameById(product.categoryId)}</td>
            <td className={getQuantityColor(product.quantity)}>{getSubCategoryNameById(product.categoryId)}</td>
            <td className={getQuantityColor(product.quantity)}>
              {/* Display the image */}
              <img  src={`https://localhost:7274${product.image}`} alt="Product" style={{ maxWidth: '50px', maxHeight: '50px' }} />
            </td>
            <td>
              <button type="button" className="btn btn-primary" onClick={() => onEditClick(product)}>
                Edit
              </button>
              <button type="button" className="btn btn-danger ml-2" onClick={() => onClickDelete(product)}>
                Delete
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export{}
export default ProductTable;
