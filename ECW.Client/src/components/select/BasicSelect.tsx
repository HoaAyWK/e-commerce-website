import React, { useState } from 'react';
import {
    Box,
    FormControl,
    InputLabel,
    MenuItem,
    Select,
    SelectChangeEvent
} from '@mui/material';
import type { Brand } from '../../features/brands/brandsSlice';
import type { Category } from '../../features/categories/categoriesSlice';

export namespace BasicSelect {
    export interface Props<T> {
        name: string;
        label: string;
        value: string;
        data: T[] | undefined;
        handleChange: (event: SelectChangeEvent) => void;
    }
}

const BasicSelect = <T extends Brand | Category>({ name, value, label, data, handleChange }: BasicSelect.Props<T>) => {
    return (
        <Box sx={{ minWidth: 120, marginInlineEnd: 2}}>
            <FormControl fullWidth>
                <InputLabel id={`select-${name}-label`}>{label}</InputLabel>
                <Select
                    labelId={`select-${name}-label`}
                    id={`select-${name}`}
                    value={value}
                    label={`${label}`}
                    onChange={handleChange}
                >
                    <MenuItem key='all' value=''>All</MenuItem>
                    {data?.map((item) => (
                        <MenuItem key={item.id} value={item.id}>{item.name}</MenuItem>
                    ))}
                </Select>
            </FormControl>
        </Box>
    )
};

export default BasicSelect;