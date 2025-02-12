import React, { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

export default function OrderSummary() {
  const navigate = useNavigate();

  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const [address, setAddress] = useState('');
  const [email, setEmail] = useState('');

  // Mock selected products (replace with Redux state if needed)
  const selectedProducts = [
    { id: 1, name: 'Laptop', price: 999 },
    { id: 2, name: 'Mouse', price: 25 },
  ];

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      // Send data to Node.js server
      await axios.post('http://localhost:3000/api/orders', {
        firstName,
        lastName,
        address,
        email,
        products: selectedProducts,
      });

      alert('Order submitted successfully!');
      navigate('/'); // Redirect to the shopping list
    } catch (error) {
      console.error('Error submitting order:', error);
      alert('Failed to submit order. Please try again.');
    }
  };

  return (
    <div>
      <h1>סיכום ההזמנה</h1>
      <form onSubmit={handleSubmit}>
        <div>
          <label>שם פרטי:</label>
          <input
            type="text"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            required
          />
        </div>
        <div>
          <label>שם משפחה:</label>
          <input
            type="text"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            required
          />
        </div>
        <div>
          <label>כתובת מלאה:</label>
          <input
            type="text"
            value={address}
            onChange={(e) => setAddress(e.target.value)}
            required
          />
        </div>
        <div>
          <label>מייל:</label>
          <input
            type="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>

        <h2>מוצרים שנבחרו:</h2>
        <ul>
          {selectedProducts.map((product) => (
            <li key={product.id}>
              {product.name} - ${product.price}
            </li>
          ))}
        </ul>

        <button type="submit">אשר הזמנה</button>
      </form>
    </div>
  );
}