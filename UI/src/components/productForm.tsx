// ProductForm.tsx
import React, { useState, useEffect } from 'react';
import {Product} from '../model/product';
import { Category } from '../model/category';
import { SubCategory } from '../model/subCategory';


interface ProductFormProps {
    categories: Category[];
    subCategories: SubCategory[];
    product?: Product | null;
    onSave: (product: Product, image: File | null) => void;
    onCancel: () => void;
  }
  
  const ProductForm: React.FC<ProductFormProps> = ({
    categories,
    subCategories,
    product,
    onSave,
    onCancel,
  }) => {
    const initialFormData: Product = {
      productId: 0,
      productCode: '',
      productName: '',
      quantity: 0,
      price: 0,
      productDescription: '',
      imageUrl: '',
      categoryId: 0,
      subCategoryId: 0,
      categoryName: '',
      subcategoryName: '',
      image : null
    };
  
    const [formData, setFormData] = useState<Product>(initialFormData);
    const [imageFile, setImageFile] = useState<File | null>(null);

    useEffect(() => {
        // Update form data when product prop changes (i.e., when editing)
        if (product) {
          setFormData((prevData) => ({
            ...prevData,
            ...product,
            categoryName: categories.find((c) => c.categoryId === product.categoryId)?.categoryName || '',
            subcategoryName: subCategories.find((sc) => sc.subCategoryId === product.subCategoryId)?.subCategoryName || '',
          }));
        } else {
          // Reset form data for 'Add Product'
          setFormData(initialFormData);
        }
      }, [product, categories, subCategories]);
  
      const handleInputChange = (
        e: React.ChangeEvent<HTMLInputElement | HTMLSelectElement | HTMLTextAreaElement>
      ) => {
        const { name, value } = e.target;
        setFormData((prevData) => ({
          ...prevData,
          [name]: value,
        }));
    
        // For category and subcategory, update their names
        if (name === 'categoryId') {
          const selectedCategory = categories.find((category) => category.categoryId === +value);
          if (selectedCategory) {
            setFormData((prevData) => ({
              ...prevData,
              categoryName: selectedCategory.categoryName,
            }));
          }
        }
    
        if (name === 'subCategoryId') {
          const selectedSubCategory = subCategories.find(
            (subCategory) => subCategory.subCategoryId === +value
          );
          if (selectedSubCategory) {
            setFormData((prevData) => ({
              ...prevData,
              subcategoryName: selectedSubCategory.subCategoryName,
            }));
          }
        }
      };

      const handleImageChange = (e: React.ChangeEvent<HTMLInputElement>) => {
        const file = e.target.files && e.target.files[0];
        setImageFile(file);
      };

    const handleSave = () => {
      onSave(formData, imageFile);
    };
  
    return (
      <div style={{ marginTop: '30px' }}>
       <h2>{product && product.productId !== 0 ? 'Edit Product' : 'Add Product'}</h2>
        <form>
          <table className="table table-dark">
            <tbody>
              <tr>
                <td>
                  <label>Product Code:</label>
                </td>
                <td>
                  <input
                    type="text"
                    name="productCode"
                    value={formData.productCode}
                    onChange={handleInputChange}
                    className="form-control"
                  />
                </td>
                <td>
                  <label>Product Name:</label>
                </td>
                <td>
                  <input
                    type="text"
                    name="productName"
                    value={formData.productName}
                    onChange={handleInputChange}
                    className="form-control"
                  />
                </td>
              </tr>
              <tr>
                <td>
                  <label>Quantity:</label>
                </td>
                <td>
                  <input
                    type="number"
                    name="quantity"
                    value={formData.quantity}
                    onChange={handleInputChange}
                    className="form-control"
                  />
                </td>
                <td>
                  <label>Price:</label>
                </td>
                <td>
                  <input
                    type="number"
                    name="price"
                    value={formData.price}
                    onChange={handleInputChange}
                    className="form-control"
                  />
                </td>
              </tr>
              <tr>
                <td>
                  <label>Product Description:</label>
                </td>
                <td colSpan={3}>
                  <textarea
                    name="productDescription"
                    value={formData.productDescription}
                    onChange={handleInputChange}
                    className="form-control"
                  />
                </td>
              </tr>
              <tr>
                <td>
                  <label>Category:</label>
                </td>
                <td>
                  <select
                    name="categoryId"
                    value={formData.categoryId}
                    onChange={handleInputChange}
                    className="form-control"
                  >
                    <option value={0}>Select Category</option>
                    {categories.map(category => (
                      <option key={category.categoryId} value={category.categoryId}>
                        {category.categoryName}
                      </option>
                    ))}
                  </select>
                </td>
                <td>
                  <label>Subcategory:</label>
                </td>
                <td>
                  <select
                    name="subCategoryId"
                    value={formData.subCategoryId}
                    onChange={handleInputChange}
                    className="form-control"
                  >
                    <option value={0}>Select Subcategory</option>
                    {subCategories.map(subCategory => (
                      <option key={subCategory.subCategoryId} value={subCategory.subCategoryId}>
                        {subCategory.subCategoryName}
                      </option>
                    ))}
                  </select>
                </td>
               
          </tr>
          <tr>
          <td>
            <label>Image:</label>
          </td>
          <td>
            <input type="file" name="image" onChange={handleImageChange} className="form-control" />
          </td>
          </tr>
            </tbody>
          </table>
          <button type="button" onClick={handleSave} className="btn btn-primary">
            Save
          </button>
          <button type="button" onClick={onCancel} className="btn btn-secondary ml-2">
            Cancel
          </button>
        </form>
      </div>
    );
  };
  export{}
  export default ProductForm;