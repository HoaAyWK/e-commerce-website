import React, { FormEvent } from 'react';
import { Box, Button, Card, CardActions, CardContent, CardMedia, Chip, Grid, TextField, Typography } from '@mui/material';

import type { Product } from '../../features/products/productsSlice';


export interface ProductDetailsProps {
    product: Product;
}


const ProductDetails = ({ product }: ProductDetailsProps) => {

    const handleSubmit = (event: FormEvent<HTMLFormElement>) => {
        event.preventDefault();
        const data = new FormData(event.currentTarget);
        console.log(data.get('quantity'));
    };

    return (
        <Box sx={{ flexGrow: 1, marginBlock: 2 }}>
            <Grid container spacing={1}>
                <Grid item xs={12} sm={8}>
                    <Card>
                        <CardMedia
                            component="img"
                            height="300"
                            image={product.image}
                            alt={product.name}
                        />
                        <CardContent>
                            <Typography gutterBottom variant='h5' component='div'>
                                {product.name}
                            </Typography>
                            <Typography variant="body2" color="text.secondary">
                                {product.description}
                            </Typography>              
                        </CardContent>
                        <CardActions sx={{ display: 'flex', alignItems: 'flex-end', width: '100%' }}>
                            <Chip color='primary' label={`$ ${product.price}`} />
                        </CardActions>
                    </Card>
                </Grid>
                <Grid item xs={12} sm={4}>
                    <Box sx={{ flexGrow: 1 }} component='form' onSubmit={handleSubmit} >
                        <TextField
                            id='quantity'
                            name='quantity'
                            label='Quantity'
                            type='number'
                            defaultValue={1}
                            fullWidth
                        />
                        <Button
                            variant='contained'
                            fullWidth
                            type='submit'
                            sx={{ marginBlockStart: 2 }}
                        >
                            Add To Cart
                        </Button>
                    </Box>
                </Grid>
            </Grid>
        </Box>
    );
};

export default ProductDetails;