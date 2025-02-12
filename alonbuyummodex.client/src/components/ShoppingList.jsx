import { useDispatch, useSelector } from 'react-redux';
import { fetchCategories } from '../store/store';
import { useEffect } from 'react';

export default function ShoppingList() {
  const dispatch = useDispatch();
  const categories = useSelector((state) => state.categories);

  useEffect(() => {
	dispatch(fetchCategories()); // Fetch data from .NET backend
  }, [dispatch]);

  const handleContinue = () => {
    navigate('/order-summary');
  };

  return (
	<div>
	  <h1>רשימת קניות</h1>
	  <ul>
		{categories.map((item) => (
		  <li key={item.id}>{item.name}</li>
		))}
	  </ul>
      <button onClick={handleContinue}>המשך להזמנה</button>	
	  </div>
  );
}