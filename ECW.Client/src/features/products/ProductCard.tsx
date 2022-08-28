import React from 'react';
import {
    Card,
    CardActionArea,
    CardContent,
    CardMedia,
    Typography
} from '@mui/material';
import { Link } from 'react-router-dom';

import type { Product } from '../../features/products/productsSlice';

namespace ProductCard {
    export interface Props {
        product: Product;
    }
};

const ProductCard = ({ product }: ProductCard.Props) => {
    return (
        <Card sx={{ maxWidth: 345 }}>
            <CardActionArea>
                <Link to={`products/${product.id}`} 
                    style={{
                        textDecoration: 'none',
                        color: 'inherit'
                    }}
                >
                    <CardMedia
                        component='img'
                        height='160'
                        image={product.image}
                        alt={product.name}
                    />
                    <CardContent>
                        <Typography gutterBottom variant='body1' component='div'>
                            {product.name}
                        </Typography>              
                        <Typography variant="body2" color="text.secondary">
                            {product.description}
                        </Typography>

                        <Typography gutterBottom variant='h6' component='div' color='primary' textAlign='center'>
                            $ {product.price}
                        </Typography>
                    </CardContent>
                </Link>
            </CardActionArea>
        </Card>
    );
};

export default ProductCard;