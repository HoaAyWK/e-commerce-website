import React from 'react';
import { Pagination, PaginationItem } from '@mui/material';
import { Link, useLocation } from 'react-router-dom';


export namespace Content {
    export interface Props {
        pageCount: number;
        variant: 'outlined' | 'text' | undefined;
        color: 'primary' | 'secondary' | 'standard';
        onChange: (event: React.ChangeEvent<unknown>, value: number) => void;
    }
};

const Content = ({ pageCount, variant, color, onChange }: Content.Props) => {
    const location = useLocation();
    const query = new URLSearchParams(location.search);
    const page = parseInt(query.get('page') || '1', pageCount);

    return (
        <Pagination
            page={page}
            count={pageCount}
            variant={variant}
            color={color}
            onChange={onChange}
        />
    );
};

export default Content;