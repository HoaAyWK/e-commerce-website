import { configureStore } from "@reduxjs/toolkit";

import productsReducer from '../features/products/productsSlice';
import brandsReducer from '../features/brands/brandsSlice';
import categoriesReducer from '../features/categories/categoriesSlice';
import productReducer from '../features/products/productSlice';

export const store = configureStore({
    reducer: {
        products: productsReducer,
        brands: brandsReducer,
        categories: categoriesReducer,
        product: productReducer,
    },
});


// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>;
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch;

export default store;