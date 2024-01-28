import React from 'react';
import logo from './logo.svg';
import './App.css';
import ProductManagement from './components/ProductManagement'
import 'bootstrap/dist/css/bootstrap.min.css'; 

function App() {
  return (
   
    <div style={{ marginTop: '20px', marginLeft: '20px',  marginRight: '20px' }}>
      <h1 >Product Management</h1>
      <ProductManagement />
    </div>
  
  );
}

export default App;
