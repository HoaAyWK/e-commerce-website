import React from 'react';
import {
    Box,
    Container,
    Link,
    Typography
} from '@mui/material';

function Copyright() {
    return (
        <Typography variant="body2" color="text.secondary">
        {'Copyright © '}
        <Link color="inherit" href='/'>
            ECW
        </Link>{' '}
        {new Date().getFullYear()}
        {'.'}
        </Typography>
    );
}

export default function StickyFooter() {
    return (
        <Box
            sx={{
                display: 'flex',
                flexDirection: 'column',
            }}
        >
            <Box
                component="footer"
                sx={{
                    py: 3,
                    px: 2,
                    mt: 'auto',
                    backgroundColor: (theme) =>
                        theme.palette.mode === 'light'
                        ? theme.palette.grey[200]
                        : theme.palette.grey[800],
                }}
            >
                <Container maxWidth="sm" sx={{ display: 'flex', justifyContent: 'center' }}>
                    <Copyright />
                </Container>
            </Box>
        </Box>
    );
}