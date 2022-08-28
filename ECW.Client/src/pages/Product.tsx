import React, { useEffect } from 'react';
import { useParams } from 'react-router-dom';

import { useAppDispatch, useAppSelector } from '../app/hook';
import ProductDetails from '../features/products/ProductDetails';
import { fetchProductById } from '../features/products/productSlice';
import { Product as ProductType } from '../features/products/productsSlice';
import Layout from '../components/ui/Layout';

const Product = () => {
    const params = useParams();
    const id = params.id as string;
    const product = useAppSelector((state) => state.product.data) as ProductType;
    const status = useAppSelector((state) => state.product.status);
    const dispatch = useAppDispatch();

    useEffect(() => {
        if (status === 'idle')
            dispatch(fetchProductById(id));
    }, [dispatch, id]);

    if (status === 'loading')
        return (
            <Layout>
                <div>Loading...</div>
            </Layout>
        );
    
    if (!product)
    return (
        <Layout>
            <div>Not found</div>
        </Layout>
    );

    console.log(product);

    return (
        <Layout>
            <ProductDetails product={product} />
        </Layout>
    );
};

export default Product;