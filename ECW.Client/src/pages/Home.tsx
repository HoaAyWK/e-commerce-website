import React from 'react';

import Layout from '../components/ui/Layout';
import ProductFilter from '../features/products/ProductFilter';

const Home = () => {
    return (
        <Layout>
            <ProductFilter />
        </Layout>
    );
};

export default Home;