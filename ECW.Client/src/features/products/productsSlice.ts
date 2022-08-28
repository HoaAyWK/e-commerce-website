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

export interface ProductsListRequest {
    pageSize: number;
    pageIndex: number;
    brandId?: string;
    categoryId?: string;
};

export interface ProductsListResponse {
    page: number;
    perPage: number;
    total: number;
    pageCount: number;
    products: Product[];
};

export interface ProductsState {
    data: Product[];
    pageCount: number;
    status: 'idle' | 'loading' | 'succeeded' | 'failed';
    error: string | undefined;
};

const initialState: ProductsState = {
    data: [],
    pageCount: 0,
    status: 'idle',
    error: undefined
};

export const fetchProducts = createAsyncThunk(
    'products/fetchProducts', 
    async ({ pageSize, pageIndex, brandId, categoryId }: ProductsListRequest): Promise<ProductsListResponse> => {
        const response = 
            await axios.get(`${baseUrl}products/pagination?pageSize=${pageSize}&pageIndex=${pageIndex}&brandId=${brandId}&categoryId=${categoryId}`);
        
        return response.data;
});


const productsSlice = createSlice({
    name: 'products',
    initialState,
    reducers: {
    },
    extraReducers(builder) {
        builder.addCase(fetchProducts.pending, (state, action) => {
            state.status = 'loading';
        })
        .addCase(fetchProducts.fulfilled, (state, action) => {
            state.status = 'succeeded';
            state.data = (action.payload.products);
            state.pageCount = action.payload.pageCount;
        })
        .addCase(fetchProducts.rejected, (state, action) => {
            state.status = 'failed';
            state.error = action.error.message;
        })
    },
});

export default productsSlice.reducer;

export const selectAllProducts = (state: {products: ProductsState} ) => state.products.data;

export const selectStatus = (state: {products: ProductsState}) => state.products.status;