
import React, { useState, useEffect, useRef } from 'react';
import axios from 'axios';
import ProductTable from './productTable';
import ProductForm from '../components/productForm';
import {Product} from '../model/product';
import { Category } from '../model/category';
import { SubCategory } from '../model/subCategory';
import 'bootstrap/dist/css/bootstrap.min.css'; 

// Define in-memory constants for categories and subcategories

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


interface ProductManagementProps {}

const ProductManagement: React.FC<ProductManagementProps> = () => {
    console.log('Component rendered');

    const [categories, setCategories] = useState<Category[]>(predefinedCategories);
    const [subCategories, setSubCategories] = useState<SubCategory[]>(predefinedSubCategories);
    const [products, setProducts] = useState<Product[]>([]);
    const [selectedProduct, setSelectedProduct] = useState<Product | null>(null);
    const [selectedCategory, setSelectedCategory] = useState<Category | null>(null);
    const [selectedSubCategory, setSelectedSubCategory] = useState<SubCategory | null>(null);
    const [showAddProductForm, setShowAddProductForm] = useState(false);
    const [isProductTableVisible, setIsProductTableVisible] = useState(false);
   
    const [isAddFormVisible, setIsAddFormVisible] = useState(false);
    const [isEditFormVisible, setIsEditFormVisible] = useState(false);
   
    // Ref to track whether an API call is in progress
  const apiCallInProgress = useRef(false);


    const handleSearchClick = async () => {
        try {
          const response = await axios.get('https://localhost:7274/api/Products/GetProductByCategoryAndSubCategory', {
            params: {
              categoryId: selectedCategory?.categoryId,
              subcategoryId: selectedSubCategory?.subCategoryId,
            },
          });
          console.log(response.data)
          setProducts(response.data);
          setIsProductTableVisible(true); // Show the product table
        } catch (error) {
          console.error('Error searching products:', error);
        }
      };
  
    const handleAddProductClick = () => {
      setIsAddFormVisible(true);
      setIsEditFormVisible(false);

    };
  
    const handleEditClick = (product: Product) => {
     setSelectedProduct(product);
     setIsAddFormVisible(false);
     setIsEditFormVisible(true);
    };

    const handleCancelForm = () => {
      setIsAddFormVisible(false);
      setIsEditFormVisible(false);
      setSelectedProduct(null);
    };


      const mapProductToProductCreateDto = (product: Product) => {
        const formData = new FormData();
      
        formData.append('ProductId', product.productId.toString());
        formData.append('ProductCode', product.productCode);
        formData.append('Name', product.productName);
        formData.append('Quantity', product.quantity.toString());
        formData.append('Price', product.price.toString());
        formData.append('Description', product.productDescription);
        formData.append('SubCategoryId', product.subCategoryId.toString());
      
        // Append SubCategory details
        formData.append('CategoryId', product.categoryId.toString());
      
        // Append Image file if it exists
        if (product.image) {
          formData.append('Image', product.image);
        }
      
        // Append ImageUrl if it exists
        formData.append('ImageUrl', product.imageUrl);
      
        return formData;
      };
      
      
      const handleSaveProduct = async (product: Product,image: File | null) => {
        try {
          const formData = mapProductToProductCreateDto(product)
          if (image) {
            formData.append('Image', image);
          }
      
          if (selectedProduct) {
            console.log('update..', formData)
            
              await axios({
                method: 'put',
                url: `https://localhost:7274/api/Products/UpdateProduct/${selectedProduct.productId}`,
                data: formData,
                headers: { 'Content-Type': 'multipart/form-data' },
              });
          
          } else {
            console.log('create..',formData )
            await axios.post('https://localhost:7274/api/Products/AddProduct', formData);
          }
    
          const response = await axios.get('https://localhost:7274/api/Products/GetAllProducts');
          setProducts(response.data);
    
          setShowAddProductForm(false);
          setSelectedProduct(null); // Reset selected product after saving
        } catch (error) {
          console.error('Error saving product:', error);
        }
      };
      


    const handleDeleteClick = async (product: Product) => {
        // setSelectedProduct(product); // This line is not needed
      
        if (product) {
          try {
            // Corrected the endpoint to delete the product
            await axios.delete(`https://localhost:7274/api/Products/DeleteProduct/${product.productId}`);
            
            // Fetch updated product list after deletion
            const response = await axios.get('https://localhost:7274/api/Products/GetAllProducts');
            setProducts(response.data);
          } catch (error) {
            console.error('Error deleting product:', error);
          }
        }
      };
  
    const handleCancelAddProduct = () => {
      setShowAddProductForm(false);
      setSelectedProduct(null);
    };
  
    return (
      <div>
      <div className="my-3">
        <table className="table">
          <tbody>
            <tr>
              <td>
                <label className="form-label">Category:</label>
                <select
                  className="form-select"
                  value={selectedCategory?.categoryId || ''}
                  onChange={(e) => {
                    const selectedCategoryId = Number(e.target.value);
                    const selectedCategory = categories?.find((category) => category.categoryId === selectedCategoryId);
                    setSelectedCategory(selectedCategory || null);
                  }}
                >
                  <option key="defaultCategory" value="">
                    Select Category
                  </option>
                  {categories?.map((category) => (
                    <option key={category.categoryId} value={category.categoryId}>
                      {category.categoryName}
                    </option>
                  ))}
                </select>
              </td>
              <td>
                <label className="form-label">Subcategory:</label>
                <select
                  className="form-select"
                  value={selectedSubCategory?.subCategoryId || ''}
                  onChange={(e) => {
                    const selectedSubCategoryId = Number(e.target.value);
                    const selectedSubCategory = subCategories?.find((subCategory) => subCategory.subCategoryId === selectedSubCategoryId);
                    setSelectedSubCategory(selectedSubCategory || null);
                  }}
                >
                  <option key="defaultSubcategory" value="">
                    Select Subcategory
                  </option>
                  {subCategories?.map((subCategory) => (
                    <option key={subCategory.subCategoryId} value={subCategory.subCategoryId}>
                      {subCategory.subCategoryName}
                    </option>
                  ))}
                </select>
              </td>
              <td>
                <button className="btn btn-primary" onClick={handleSearchClick}>
                  Search
                </button>
              </td>
              <td>
                <button className="btn btn-success" onClick={handleAddProductClick}>
                  Add Product
                </button>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      {isAddFormVisible && (
        <div className="my-3 mt-3">
          <ProductForm
            categories={categories || []}
            subCategories={subCategories || []}
            product={selectedProduct}
            onSave={handleSaveProduct}
            onCancel={handleCancelForm}
          />
        </div>
      )}

      {isEditFormVisible && (
        <div className="my-3 mt-3">
          <ProductForm
            categories={categories || []}
            subCategories={subCategories || []}
            product={selectedProduct}
            onSave={handleSaveProduct}
            onCancel={handleCancelForm}
          />
        </div>
      )}

      {!isAddFormVisible && !isEditFormVisible && isProductTableVisible && (
        <ProductTable
          products={products}
          onEditClick={handleEditClick}
          onClickDelete={handleDeleteClick}
        />
      )}
    </div>
    );
  };
  export{}
  export default ProductManagement;