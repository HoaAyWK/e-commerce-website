import axios from 'axios';
import { createAsyncThunk, createSlice } from '@reduxjs/toolkit';

import { baseUrl } from '../../constants/constant';

export interface Brand {
    id: number;
    name: string;
};

export interface BrandsState {
    data: Brand[];
    status: 'idle' | 'loading' | 'succeeded' | 'failed';
    error: string | undefined;
};

const initialState: BrandsState = {
    data: [],
    status: 'idle',
    error: undefined
};

export const fetchBrands = createAsyncThunk('brands/fetchBrands',
    async () => {
        const response = await axios.get(`${baseUrl}brands`);
        console.log(response.data);
        return response.data;
    }
);

const brandsSlice = createSlice({
    name: 'brands',
    initialState,
    reducers: {
    },
    extraReducers(builder) {
        builder.addCase(fetchBrands.pending, (state, action) => {
            state.status = 'loading';
        })
        .addCase(fetchBrands.fulfilled, (state, action) => {
            state.status = 'succeeded';
            state.data = (action.payload);
        })
        .addCase(fetchBrands.rejected, (state, action) => {
            state.status = 'failed';
            state.error = action.error.message;
        })
    },
});

export default brandsSlice.reducer;
