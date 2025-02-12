import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

// Fetch data from .NET API
export const fetchCategories = createAsyncThunk('categories/fetch', async () => {
  const response = await axios.get('http://localhost:7088/api/Categories/GetAllCategories');
  return response.data;
});

const categoriesSlice = createSlice({
  name: 'categories',
  initialState: [],
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(fetchCategories.fulfilled, (state, action) => {
      return action.payload;
    });
  },
});

export const store = configureStore({
  reducer: {
    categories: categoriesSlice.reducer,
  },
});