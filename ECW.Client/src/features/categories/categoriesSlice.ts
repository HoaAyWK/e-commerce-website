import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

import { baseUrl } from '../../constants/constant';

export interface Category {
    id: number;
    name: string;
};

export interface CategoriesState {
    data: Category[];
    status: 'idle' | 'loading' | 'succeeded' | 'failed';
    error: string | undefined;
};

const initialState: CategoriesState = {
    data: [],
    status: 'idle',
    error: undefined
};

export const fetchCategories = createAsyncThunk('categories/fetchCategories',
    async() => {
        const response = await axios.get(`${baseUrl}categories`);

        return response.data;
});

const categoriesSlice = createSlice({
    name: 'categories',
    initialState,
    reducers: {
    },
    extraReducers(builder) {
        builder.addCase(fetchCategories.pending, (state, action) =>{
            state.status = 'loading';
        })
        .addCase(fetchCategories.fulfilled, (state, action) => {
            state.data = action.payload;
            state.status = 'succeeded';
        })
        .addCase(fetchCategories.rejected, (state, action) => {
            state.status = 'failed';
            state.error = action.error.message;
        })
    }
});

export default categoriesSlice.reducer;