import React, { ReactNode } from 'react';
import { Container } from '@mui/material';

import Navbar from './Navbar';
import StickyFooter from './Footer';

const Layout = ({ children }: any) => {
    return (
        <>
            <Navbar />
            <Container maxWidth='lg'>
                {children}
            </Container>
            <StickyFooter />
        </>
    );
};

export default Layout;