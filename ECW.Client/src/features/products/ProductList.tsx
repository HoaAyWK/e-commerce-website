import React, { useEffect, useState } from 'react';
import { Box, Grid, Pagination } from '@mui/material';

import { useAppSelector, useAppDispatch } from '../../app/hook';
import ProductCard from './ProductCard';
import { fetchProducts, selectAllProducts, selectStatus } from './productsSlice';

export interface ProductListProps {
    brandId: string | '';
    categoryId: string | '';
};


const ProductList = ({ brandId, categoryId }: ProductListProps) => {
    const [pageSize, setPageSize] = useState(8);
    const [pageIndex, setPageIndex] = useState(1);

    const dispatch = useAppDispatch();
    const data = useAppSelector(selectAllProducts);
    const productStatus = useAppSelector(selectStatus);
    const pageCount = useAppSelector(state => state.products.pageCount);

    useEffect(() => {
        dispatch(fetchProducts({pageSize, pageIndex, brandId, categoryId}));
    }, [dispatch, pageIndex, brandId, categoryId]);

    const handlePageChange = (event: React.ChangeEvent<unknown>, value: number) => {
        setPageIndex(value);
    };

    if (productStatus === 'loading') {
        return <div>Loading...</div>
    }

    return (
        <>
            <Grid container alignItems='stretch' spacing={3} minHeight='60vh' my={2}>
                {data?.map((product) => (
                    <Grid key={product.id} item xs={12} sm={6} md={4} lg={3}>
                        <ProductCard product={product} />
                    </Grid>
                ))}
            </Grid>
            <Box
                sx={{
                    display: 'flex',
                    justifyContent: 'center'
                }}
                mb={2}
            >
                <Pagination
                    count={pageCount}
                    page={pageIndex}
                    onChange={handlePageChange}
                />
            </Box>
        </>
    );
};

export default ProductList;