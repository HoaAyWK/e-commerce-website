import React from 'react';
import { MemoryRouter, Route, Routes } from 'react-router-dom';

import Content from './Content';


export interface Props {
    initialEntries: string;
    pageCount: number;
    variant: 'outlined' | 'text' | undefined;
    color: 'primary' | 'secondary' | 'standard';
    onChange: (event: React.ChangeEvent<unknown>, value: number) => void;
};

const PaginationLink = ({ initialEntries, pageCount, variant, color, onChange }: Props) => {
    return (
        <MemoryRouter initialEntries={[initialEntries]} initialIndex={0}>
            <Route path="*" element={<Content pageCount={pageCount} variant={variant} color={color} onChange={onChange} />} />
        </MemoryRouter>
    );
};

export default PaginationLink;