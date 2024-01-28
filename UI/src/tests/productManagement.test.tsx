export{}
import React from 'react';
import { render, fireEvent, waitFor } from '@testing-library/react';
import axios from 'axios';
import MockAdapter from 'axios-mock-adapter';
import ProductManagement from '../components/ProductManagement'

const mockAxios = new MockAdapter(axios);

describe('ProductManagement', () => {
  const responseMock = [
    // Mocked product data
    {
      productId: 1,
      productCode: 'ABC123',
      productName: 'Test Product',
      quantity: 10,
      price: 50,
      productDescription: 'Description of the product',
      categoryName: 'Category 1',
      subcategoryName: 'Subcategory 1',
    },
  ];

  beforeEach(() => {
    mockAxios.reset();
  });

  it('renders ProductManagement correctly', async () => {
    mockAxios.onGet('https://localhost:7274/api/Products/GetAllCategories').reply(200, []);
    mockAxios.onGet('https://localhost:7274/api/Products/GetAllSubCategories').reply(200, []);
    mockAxios.onGet('https://localhost:7274/api/Products/GetAllProducts').reply(200, responseMock);

    const { getByText } = render(<ProductManagement />);

    await waitFor(() => {
      expect(getByText('Add Product')).toBeInTheDocument();
    });
  });

  it('fetches categories and subcategories on mount', async () => {
    mockAxios.onGet('https://localhost:7274/api/Products/GetAllCategories').reply(200, []);
    mockAxios.onGet('https://localhost:7274/api/Products/GetAllSubCategories').reply(200, []);
    mockAxios.onGet('https://localhost:7274/api/Products/GetAllProducts').reply(200, responseMock);

    render(<ProductManagement />);

    await waitFor(() => {
      expect(mockAxios.history.get.length).toBe(3); // Ensure three GET requests are made
      expect(mockAxios.history.get[0].url).toBe('https://localhost:7274/api/Products/GetAllCategories');
      expect(mockAxios.history.get[1].url).toBe('https://localhost:7274/api/Products/GetAllSubCategories');
      expect(mockAxios.history.get[2].url).toBe('https://localhost:7274/api/Products/GetAllProducts');
    });
  });

  it('calls handleSearchClick when Search button is clicked', async () => {
    const { getByText } = render(<ProductManagement />);
    await waitFor(() => {
      expect(getByText('Add Product')).toBeInTheDocument();
    });

    fireEvent.click(getByText('Search'));

    // Add expectations for the behavior when the Search button is clicked
    await waitFor(() => {
      // Expectations after clicking the Search button
    });
  });

  // Add more tests as needed
});
