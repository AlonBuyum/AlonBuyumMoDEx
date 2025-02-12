import React from 'react';
import { BrowserRouter , Route, Routes } from 'react-router-dom';
import {ShoppingList} from './components/ShoppingList';
import {OrderSummary} from './components/OrderSummary.jsx';
import './App.css';

function App() {
	return (
		<BrowserRouter>
		  <Routes>
			<Route path="/" element={<ShoppingList />} />
			<Route path="/order-summary" element={<OrderSummary />} />
		  </Routes>
		</BrowserRouter>
	  );
}

export default App;