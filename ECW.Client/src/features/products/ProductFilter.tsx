import React, { useEffect, useState } from 'react';
import {
    Box,
    SelectChangeEvent
} from '@mui/material';
import BrandSelection from '../brands/BrandSelection';
import CategorySelection from '../categories/CategorySelection';
import ProductList from './ProductList';

const ProductFilter = () => {
    const [brand, setBrand] = useState<string | ''>('');
    const [category, setCategory] = useState<string | ''>('');

    const handleBrandChange = (event: SelectChangeEvent) => {
        setBrand(event.target.value as string);
    };

    const handleCategoryChange = (event: SelectChangeEvent) => {
        setCategory(event.target.value as string);
    };

    return (
        <>
            <Box
                sx={{ display: 'flex', marginBlockStart: 2 }}       
            >
                <BrandSelection
                    value={brand}
                    handleValueChange={handleBrandChange}
                />
                <CategorySelection
                    value={category}
                    handleValueChange={handleCategoryChange}
                />
            </Box>
            <ProductList brandId={brand} categoryId={category} />
        </>
    );
};

export default ProductFilter;