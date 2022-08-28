import React from 'react';
import { Routes, Route, useLocation } from 'react-router-dom';

import Home from './Home';
import Product from './Product';

const Pages = () => {
    const location = useLocation();

    return (
        <Routes location={location} key={location.pathname}>
            <Route path='/' element={<Home />} />
            <Route path='/products/:id' element={<Product />} />
        </Routes>
    );
};

export default Pages;