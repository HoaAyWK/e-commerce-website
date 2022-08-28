import axios from 'axios';
import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';

import { baseUrl } from '../../constants/constant';

export interface Product {
    id: number;
    name: string;
    description: string;
    price: number;
    image: string;
    brandId: number;
    categoryId: number;
};

export interface ProductState {
    data: Product | undefined;
    status: 'idle' | 'loading' | 'succeeded' | 'failed';
    error: string | undefined;
};

const initialState: ProductState = {
    data: undefined,
    status: 'idle',
    error: undefined
};


export const fetchProductById = createAsyncThunk(
    'products/fetchProductById',
    async (id: string) => {
        const response = await axios.get(`${baseUrl}products/${id}`);
        console.log(response.data);
        return response.data;
    }
);

const productSlice = createSlice({
    name: 'products',
    initialState,
    reducers: {
    },
    extraReducers(builder) {
        builder.addCase(fetchProductById.pending, (state, action) => {
            state.status = 'loading';
        })
        .addCase(fetchProductById.fulfilled, (state, action) => {
            state.status = 'succeeded';
            state.data = action.payload;
        })
        .addCase(fetchProductById.rejected, (state, action) => {
            state.status = 'failed';
            state.error = action.error.message;
        })
    },
});

export default productSlice.reducer;